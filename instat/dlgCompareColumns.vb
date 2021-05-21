﻿' R- Instat
' Copyright (C) 2015-2017
'
' This program is free software: you can redistribute it and/or modify
' it under the terms of the GNU General Public License as published by
' the Free Software Foundation, either version 3 of the License, or
' (at your option) any later version.
'
' This program is distributed in the hope that it will be useful,
' but WITHOUT ANY WARRANTY; without even the implied warranty of
' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
' GNU General Public License for more details.
'
' You should have received a copy of the GNU General Public License 
' along with this program.  If not, see <http://www.gnu.org/licenses/>.

Imports instat.Translations

Public Class dlgCompareColumns

    Private bFirstLoad As Boolean = True
    Private bReset As Boolean = True
    Private bRcodeSet As Boolean = False
    Private clsCompareColumns, clsIfElseCompareFunction, clsAbsoluteFunction As New RFunction
    Private clsAsCharacterFunctionOne, clsAsCharacterFunctionTwo, clsSummaryFunction As New RFunction
    Private clsYinXOperator, clsIsEqualToOperator, clsSubtractOperator, clsLessorEqualToOperator As New ROperator

    Private Sub dlgCompareColumns_Load(sender As Object, e As EventArgs) Handles Me.Load
        If bFirstLoad Then
            InitialiseDialog()
            bFirstLoad = False
        End If

        If bReset Then
            SetDefaults()
        End If
        SetRCodeForControls(bReset)
        bReset = False
        autoTranslate(Me)
        TestOkEnabled()
    End Sub

    Private Sub InitialiseDialog()
        Dim dctTolerance As New Dictionary(Of String, String)
        ucrBase.iHelpTopicID = 546

        ucrPnlOptions.AddRadioButton(rdoByRow)
        ucrPnlOptions.AddRadioButton(rdoByValue)

        ucrPnlOptions.AddFunctionNamesCondition(rdoByRow, "ifelse")
        ucrPnlOptions.AddFunctionNamesCondition(rdoByValue, {"%in%", "compare_columns"})

        ucrPnlOptions.AddToLinkedControls({ucrChkSort, ucrChkUnique}, {rdoByValue}, bNewLinkedAddRemoveParameter:=True, bNewLinkedHideIfParameterMissing:=True)

        ucrReceiverFirst.SetParameter(New RParameter("x", 0))
        ucrReceiverFirst.Selector = ucrSelectorCompareColumns
        ucrReceiverFirst.SetParameterIsRFunction()
        ucrReceiverFirst.bAttachedToPrimaryDataFrame = False
        ucrReceiverFirst.bOnlyLinkedToPrimaryDataFrames = False
        ucrReceiverFirst.bIncludeDataFrameInAssignment = True

        ucrReceiverSecond.SetParameter(New RParameter("y", 1))
        ucrReceiverSecond.Selector = ucrSelectorCompareColumns
        ucrReceiverSecond.SetParameterIsRFunction()
        ucrReceiverSecond.bAttachedToPrimaryDataFrame = False
        ucrReceiverSecond.bOnlyLinkedToPrimaryDataFrames = False
        ucrReceiverSecond.bIncludeDataFrameInAssignment = True

        ucrInputTolerance.SetParameter(New RParameter("tol", 1))
        dctTolerance.Add("0", "0")
        dctTolerance.Add("0.005", "0.005")
        dctTolerance.Add("0.0000000001", "0.0000000001")
        ucrInputTolerance.SetItems(dctTolerance)
        ucrInputTolerance.bAllowNonConditionValues = True
        ucrInputTolerance.SetValidationTypeAsNumeric()
        ucrInputTolerance.AddQuotesIfUnrecognised = False
        ucrInputTolerance.SetLinkedDisplayControl(lblTolerance)

        ucrChkUnique.SetParameter(New RParameter("use_unique", 2), bNewChangeParameterValue:=True)
        ucrChkUnique.SetText("Use unique values for comparison")
        ucrChkUnique.SetRDefault("TRUE")

        ucrChkSort.SetParameter(New RParameter("sort_values", 3), bNewChangeParameterValue:=True)
        ucrChkSort.SetText("Sort values")
        ucrChkSort.SetRDefault("TRUE")

        ucrChkFirstNotSecond.SetParameter(New RParameter("firstnotsecond", 4), bNewChangeParameterValue:=True)
        ucrChkFirstNotSecond.SetText("Values in first column not in second")
        ucrChkFirstNotSecond.SetRDefault("TRUE")

        ucrChkSecondNotFirst.SetParameter(New RParameter("secondnotfirst", 5), bNewChangeParameterValue:=True)
        ucrChkSecondNotFirst.SetText("Values in second column not in first")
        ucrChkSecondNotFirst.SetRDefault("TRUE")

        ucrChkIntersection.SetParameter(New RParameter("display_intersection", 6), bNewChangeParameterValue:=True)
        ucrChkIntersection.SetText("Values in both columns (intersection)")
        ucrChkIntersection.SetRDefault("FALSE")

        ucrChkUnion.SetParameter(New RParameter("display_union", 7), bNewChangeParameterValue:=True)
        ucrChkUnion.SetText("Values in either column (union)")
        ucrChkUnion.SetRDefault("FALSE")

        ucrChkAllValues.SetParameter(New RParameter("display_values", 8), bNewChangeParameterValue:=True)
        ucrChkAllValues.SetText("All values if columns are equal")
        ucrChkAllValues.SetRDefault("TRUE")

        ucrSaveLogical.SetPrefix("compare")
        ucrSaveLogical.SetSaveTypeAsColumn()
        ucrSaveLogical.SetDataFrameSelector(ucrSelectorCompareColumns.ucrAvailableDataFrames)
        ucrSaveLogical.SetIsComboBox()
        ucrSaveLogical.SetLabelText("Save result for second column:")
        ucrSaveLogical.setLinkedReceiver(ucrReceiverSecond)

        ucrBase.clsRsyntax.iCallType = 2
    End Sub

    Private Sub SetDefaults()
        clsCompareColumns = New RFunction
        clsIfElseCompareFunction = New RFunction
        clsAbsoluteFunction = New RFunction
        clsAsCharacterFunctionOne = New RFunction
        clsAsCharacterFunctionTwo = New RFunction
        clsSummaryFunction = New RFunction
        clsYinXOperator = New ROperator
        clsIsEqualToOperator = New ROperator
        clsSubtractOperator = New ROperator
        clsLessorEqualToOperator = New ROperator

        ucrBase.clsRsyntax.ClearCodes()
        ucrInputTolerance.SetText("0")

        ucrSelectorCompareColumns.Reset()
        ucrReceiverFirst.SetMeAsReceiver()
        ucrSaveLogical.Reset()

        clsCompareColumns.SetRCommand("compare_columns")
        clsYinXOperator.SetOperation("%in%")

        clsAsCharacterFunctionOne.SetRCommand("as.character")
        clsAsCharacterFunctionTwo.SetRCommand("as.character")

        clsIsEqualToOperator.SetOperation("==")
        clsIsEqualToOperator.AddParameter("first", clsRFunctionParameter:=clsAsCharacterFunctionOne, iPosition:=0)
        clsIsEqualToOperator.AddParameter("second", clsRFunctionParameter:=clsAsCharacterFunctionTwo, iPosition:=1)

        clsSubtractOperator.SetOperation("-")

        clsAbsoluteFunction.SetRCommand("abs")
        clsAbsoluteFunction.AddParameter("x", clsROperatorParameter:=clsSubtractOperator, iPosition:=0)

        clsLessorEqualToOperator.SetOperation("<=")
        clsLessorEqualToOperator.AddParameter("first", clsRFunctionParameter:=clsAbsoluteFunction, iPosition:=0)
        clsLessorEqualToOperator.AddParameter("tol", "0", iPosition:=1)

        clsIfElseCompareFunction.SetRCommand("ifelse")
        clsIfElseCompareFunction.AddParameter("test", clsROperatorParameter:=clsIsEqualToOperator, iPosition:=0)
        clsIfElseCompareFunction.AddParameter("yes", "TRUE", iPosition:=1)
        clsIfElseCompareFunction.AddParameter("no", "FALSE", iPosition:=2)

        clsSummaryFunction.SetRCommand("summary")
        clsSummaryFunction.AddParameter("x", clsRFunctionParameter:=clsIfElseCompareFunction, bIncludeArgumentName:=False, iPosition:=1)
        clsSummaryFunction.iCallType = 2

        ucrBase.clsRsyntax.SetBaseRFunction(clsIfElseCompareFunction)
    End Sub

    Private Sub SetRCodeForControls(bReset As Boolean)
        bRcodeSet = False
        ucrReceiverFirst.AddAdditionalCodeParameterPair(clsYinXOperator, New RParameter("right", iNewPosition:=1), iAdditionalPairNo:=1)
        ucrReceiverFirst.AddAdditionalCodeParameterPair(clsAsCharacterFunctionOne, New RParameter("first", bNewIncludeArgumentName:=False, iNewPosition:=0), iAdditionalPairNo:=2)
        ucrReceiverFirst.AddAdditionalCodeParameterPair(clsSubtractOperator, New RParameter("first", bNewIncludeArgumentName:=False, iNewPosition:=0), iAdditionalPairNo:=3)

        ucrReceiverSecond.AddAdditionalCodeParameterPair(clsYinXOperator, New RParameter("left", iNewPosition:=0), iAdditionalPairNo:=1)
        ucrReceiverSecond.AddAdditionalCodeParameterPair(clsAsCharacterFunctionTwo, New RParameter("second", bNewIncludeArgumentName:=False, iNewPosition:=1), iAdditionalPairNo:=2)
        ucrReceiverSecond.AddAdditionalCodeParameterPair(clsSubtractOperator, New RParameter("second", bNewIncludeArgumentName:=False, iNewPosition:=1), iAdditionalPairNo:=3)

        ucrPnlOptions.SetRCode(ucrBase.clsRsyntax.clsBaseFunction, bReset)

        ucrReceiverFirst.SetRCode(clsCompareColumns, bReset)
        ucrReceiverSecond.SetRCode(clsCompareColumns, bReset)
        ucrChkUnique.SetRCode(clsCompareColumns, bReset)
        ucrChkSort.SetRCode(clsCompareColumns, bReset)
        ucrChkFirstNotSecond.SetRCode(clsCompareColumns, bReset)
        ucrChkSecondNotFirst.SetRCode(clsCompareColumns, bReset)
        ucrChkIntersection.SetRCode(clsCompareColumns, bReset)
        ucrChkUnion.SetRCode(clsCompareColumns, bReset)
        ucrChkAllValues.SetRCode(clsCompareColumns, bReset)
        ucrInputTolerance.SetRCode(clsLessorEqualToOperator, bReset)

        ucrSaveLogical.SetRCode(clsIfElseCompareFunction, bReset)
        ucrSaveLogical.AddAdditionalRCode(clsYinXOperator, iAdditionalPairNo:=1)
        bRcodeSet = True
    End Sub

    Private Sub TestOkEnabled()
        If Not ucrReceiverFirst.IsEmpty AndAlso Not ucrReceiverSecond.IsEmpty AndAlso ucrSaveLogical.IsComplete() Then
            If rdoByRow.Checked Then
                If {"integer", "numeric"}.Contains(ucrReceiverFirst.strCurrDataType) AndAlso {"integer", "numeric"}.Contains(ucrReceiverSecond.strCurrDataType) Then
                    ucrBase.OKEnabled(True)
                ElseIf ucrReceiverFirst.strCurrDataType = "Date" AndAlso ucrReceiverSecond.strCurrDataType = "Date" Then
                    ucrBase.OKEnabled(True)
                ElseIf {"factor", "character"}.Contains(ucrReceiverFirst.strCurrDataType) AndAlso {"factor", "character"}.Contains(ucrReceiverSecond.strCurrDataType) Then
                    ucrBase.OKEnabled(True)
                ElseIf ucrReceiverFirst.strCurrDataType = "logical" AndAlso ucrReceiverSecond.strCurrDataType = "logical" Then
                    ucrBase.OKEnabled(True)
                Else
                    ucrBase.OKEnabled(False)
                End If
            Else
                ucrBase.OKEnabled(True)
            End If
        Else
            ucrBase.OKEnabled(False)
        End If
    End Sub

    Private Sub Controls_ControlContentsChanged(ucrChangedControl As ucrCore) Handles ucrReceiverFirst.ControlContentsChanged, ucrReceiverSecond.ControlContentsChanged, ucrSaveLogical.ControlContentsChanged
        TestOkEnabled()
    End Sub

    Private Sub ucrBase_ClickReset(sender As Object, e As EventArgs) Handles ucrBase.ClickReset
        SetDefaults()
        SetRCodeForControls(True)
        TestOkEnabled()
    End Sub

    Private Sub ucrPnlOptions_ControlValueChanged(ucrChangedControl As ucrCore) Handles ucrPnlOptions.ControlValueChanged
        If rdoByValue.Checked Then
            grpComparisions.Visible = True
            ucrBase.clsRsyntax.SetBaseRFunction(clsCompareColumns)
            ucrBase.clsRsyntax.RemoveFromAfterCodes(clsSummaryFunction)
            ucrBase.clsRsyntax.AddToAfterCodes(clsYinXOperator, iPosition:=1)
        Else
            grpComparisions.Visible = False
            ucrBase.clsRsyntax.SetBaseRFunction(clsIfElseCompareFunction)
            ucrBase.clsRsyntax.RemoveFromAfterCodes(clsYinXOperator)
            ucrBase.clsRsyntax.AddToAfterCodes(clsSummaryFunction, iPosition:=1)
        End If
        CheckDatatype()
    End Sub

    Private Sub CheckDatatype()
        If bRcodeSet Then
            If rdoByRow.Checked Then
                If {"integer", "numeric"}.Contains(ucrReceiverFirst.strCurrDataType) AndAlso {"integer", "numeric"}.Contains(ucrReceiverSecond.strCurrDataType) Then
                    ucrInputTolerance.Visible = True
                    clsIfElseCompareFunction.AddParameter("test", clsROperatorParameter:=clsLessorEqualToOperator, iPosition:=0)
                ElseIf ucrReceiverFirst.strCurrDataType = "date" AndAlso ucrReceiverSecond.strCurrDataType = "date" Then
                    ucrInputTolerance.Visible = True
                    clsIfElseCompareFunction.AddParameter("test", clsROperatorParameter:=clsLessorEqualToOperator, iPosition:=0)
                ElseIf {"factor", "character"}.Contains(ucrReceiverFirst.strCurrDataType) AndAlso {"factor", "character"}.Contains(ucrReceiverSecond.strCurrDataType) Then
                    ucrInputTolerance.Visible = False
                    clsIfElseCompareFunction.AddParameter("test", clsROperatorParameter:=clsIsEqualToOperator, iPosition:=0)
                ElseIf ucrReceiverFirst.strCurrDataType = "logical" AndAlso ucrReceiverSecond.strCurrDataType = "logical" Then
                    ucrInputTolerance.Visible = False
                    clsIfElseCompareFunction.AddParameter("test", clsROperatorParameter:=clsIsEqualToOperator, iPosition:=0)
                Else
                    MsgBox("Receivers must have the same data type, OK will not be enabled")
                    ucrInputTolerance.Visible = False
                End If
            Else
                ucrInputTolerance.Visible = False
            End If
        End If
        TestOkEnabled()
    End Sub

    Private Sub ucrReceiverFirst_ValueChanged(sender As Object, e As EventArgs) Handles ucrReceiverFirst.ValueChanged
        If Not ucrReceiverSecond.IsEmpty Then
            CheckDatatype()
        End If
    End Sub

    Private Sub ucrReceiverSecond_ValueChanged(sender As Object, e As EventArgs) Handles ucrReceiverSecond.ValueChanged
        If Not ucrReceiverFirst.IsEmpty Then
            CheckDatatype()
        End If
    End Sub
End Class