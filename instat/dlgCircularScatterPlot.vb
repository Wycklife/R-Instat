' R- Instat
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

Public Class dlgCircularScatterPlot
    Private bfirstload As Boolean = True
    Private bReset As Boolean = True
    Private clsCircularPointFunction As New RFunction
    Private clsRsyntax As RSyntax
    Private Sub dlgCircularScatterPlot_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        autoTranslate(Me)
        If bfirstload Then
            InitialiseDialog()
            bfirstload = False
        End If
        If bReset Then
            SetDefaults()
        End If
        SetRCodeForControls(bReset)
        bReset = False
        TestOKEnabled()
    End Sub

    Private Sub InitialiseDialog()

        ucrBase.clsRsyntax.bExcludeAssignedFunctionOutput = False
        ucrBase.clsRsyntax.iCallType = 3

        ucrSelectorCircularDataFrame.SetParameter(New RParameter("data", 0))
        ucrSelectorCircularDataFrame.SetParameterIsrfunction()

        ucrReceiverCircularVariable.SetParameter(New RParameter("x", 0))
        ucrReceiverCircularVariable.Selector = ucrSelectorCircularDataFrame
        ucrReceiverCircularVariable.SetParameterIsRFunction()
        ucrReceiverCircularVariable.bWithQuotes = False

        ucrSaveCircularPlot.SetPrefix("circular_scatter_plot")
        ucrSaveCircularPlot.SetDataFrameSelector(ucrSelectorCircularDataFrame.ucrAvailableDataFrames)
        ucrSaveCircularPlot.SetIsComboBox()
        ucrSaveCircularPlot.SetCheckBoxText("Save Graph")
        ucrSaveCircularPlot.SetSaveTypeAsGraph()
        ucrSaveCircularPlot.SetAssignToIfUncheckedValue("last_graph")

    End Sub

    Private Sub SetDefaults()
        clsCircularPointFunction = New RFunction

        ucrSelectorCircularDataFrame.Reset()
        ucrReceiverCircularVariable.SetMeAsReceiver()
        ucrSaveCircularPlot.Reset()

        clsCircularPointFunction.SetPackageName("circular")
        clsCircularPointFunction.SetRCommand("points.circular")

        ucrBase.clsRsyntax.SetBaseRFunction(clsCircularPointFunction)
    End Sub

    Public Sub SetRCodeForControls(bReset As Boolean)
        ucrReceiverCircularVariable.SetRCode(clsCircularPointFunction, bReset)
    End Sub

    Private Sub TestOKEnabled()
        If ucrSaveCircularPlot.IsComplete AndAlso Not ucrReceiverCircularVariable.IsEmpty Then
            ucrBase.OKEnabled(True)
        Else
            ucrBase.OKEnabled(False)
        End If
    End Sub

    Private Sub CoreControls_ControlContentsChanged() Handles ucrReceiverCircularVariable.ControlContentsChanged, ucrSaveCircularPlot.ControlContentsChanged
        TestOKEnabled()
    End Sub

    Private Sub ucrBase_ClickReset(sender As Object, e As EventArgs) Handles ucrBase.ClickReset
        SetDefaults()
        SetRCodeForControls(True)
        TestOKEnabled()
    End Sub
End Class