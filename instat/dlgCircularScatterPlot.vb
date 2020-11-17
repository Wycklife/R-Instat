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
    Public bfirstload As Boolean = True
    Public bReset As Boolean = True
    Public clsCircularPointFunction As New RFunction
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

        ucrSelectorCircularDataFrame.SetParameter(New RParameter("data", 0))
        ucrSelectorCircularDataFrame.SetParameterIsrfunction()

        ucrReceiverCircularVariable.SetParameter(New RParameter("x", 0))
        ucrReceiverCircularVariable.Selector = ucrSelectorCircularDataFrame

    End Sub

    Private Sub SetDefaults()
        clsCircularPointFunction = New RFunction

        ucrSelectorCircularDataFrame.Reset()
        ucrReceiverCircularVariable.SetMeAsReceiver()
        ucrSaveCircularPlot.Reset()

    End Sub

    Public Sub SetRCodeForControls(bReset As Boolean)

    End Sub

    Private Sub TestOKEnabled()

    End Sub
End Class