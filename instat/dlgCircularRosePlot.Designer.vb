﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgCircularRosePlot
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ucrBase = New instat.ucrButtons()
        Me.ucrSelctorCircularDataFrame = New instat.ucrSelectorByDataFrameAddRemove()
        Me.ucrSaveCircularRosePlot = New instat.ucrSave()
        Me.ucrReceiverVariable = New instat.ucrReceiverSingle()
        Me.lblVariable = New System.Windows.Forms.Label()
        Me.ucrInputBins = New instat.ucrInputTextBox()
        Me.lblBins = New System.Windows.Forms.Label()
        Me.ucrInputComboRadius = New instat.ucrInputComboBox()
        Me.lblRadiusScale = New System.Windows.Forms.Label()
        Me.cmdCircularOptions = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ucrBase
        '
        Me.ucrBase.Location = New System.Drawing.Point(6, 273)
        Me.ucrBase.Name = "ucrBase"
        Me.ucrBase.Size = New System.Drawing.Size(406, 52)
        Me.ucrBase.TabIndex = 0
        '
        'ucrSelctorCircularDataFrame
        '
        Me.ucrSelctorCircularDataFrame.bDropUnusedFilterLevels = False
        Me.ucrSelctorCircularDataFrame.bShowHiddenColumns = False
        Me.ucrSelctorCircularDataFrame.bUseCurrentFilter = True
        Me.ucrSelctorCircularDataFrame.Location = New System.Drawing.Point(6, 9)
        Me.ucrSelctorCircularDataFrame.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrSelctorCircularDataFrame.Name = "ucrSelctorCircularDataFrame"
        Me.ucrSelctorCircularDataFrame.Size = New System.Drawing.Size(210, 180)
        Me.ucrSelctorCircularDataFrame.TabIndex = 1
        '
        'ucrSaveCircularRosePlot
        '
        Me.ucrSaveCircularRosePlot.Location = New System.Drawing.Point(6, 232)
        Me.ucrSaveCircularRosePlot.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrSaveCircularRosePlot.Name = "ucrSaveCircularRosePlot"
        Me.ucrSaveCircularRosePlot.Size = New System.Drawing.Size(279, 28)
        Me.ucrSaveCircularRosePlot.TabIndex = 2
        '
        'ucrReceiverVariable
        '
        Me.ucrReceiverVariable.frmParent = Me
        Me.ucrReceiverVariable.Location = New System.Drawing.Point(292, 64)
        Me.ucrReceiverVariable.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverVariable.Name = "ucrReceiverVariable"
        Me.ucrReceiverVariable.Selector = Nothing
        Me.ucrReceiverVariable.Size = New System.Drawing.Size(120, 20)
        Me.ucrReceiverVariable.strNcFilePath = ""
        Me.ucrReceiverVariable.TabIndex = 3
        Me.ucrReceiverVariable.ucrSelector = Nothing
        '
        'lblVariable
        '
        Me.lblVariable.AutoSize = True
        Me.lblVariable.Location = New System.Drawing.Point(289, 42)
        Me.lblVariable.Name = "lblVariable"
        Me.lblVariable.Size = New System.Drawing.Size(48, 13)
        Me.lblVariable.TabIndex = 4
        Me.lblVariable.Text = "Variable:"
        '
        'ucrInputBins
        '
        Me.ucrInputBins.AddQuotesIfUnrecognised = True
        Me.ucrInputBins.IsMultiline = False
        Me.ucrInputBins.IsReadOnly = False
        Me.ucrInputBins.Location = New System.Drawing.Point(359, 128)
        Me.ucrInputBins.Name = "ucrInputBins"
        Me.ucrInputBins.Size = New System.Drawing.Size(66, 21)
        Me.ucrInputBins.TabIndex = 5
        '
        'lblBins
        '
        Me.lblBins.AutoSize = True
        Me.lblBins.Location = New System.Drawing.Point(324, 132)
        Me.lblBins.Name = "lblBins"
        Me.lblBins.Size = New System.Drawing.Size(30, 13)
        Me.lblBins.TabIndex = 6
        Me.lblBins.Text = "Bins:"
        '
        'ucrInputComboRadius
        '
        Me.ucrInputComboRadius.AddQuotesIfUnrecognised = True
        Me.ucrInputComboRadius.GetSetSelectedIndex = -1
        Me.ucrInputComboRadius.IsReadOnly = False
        Me.ucrInputComboRadius.Location = New System.Drawing.Point(361, 168)
        Me.ucrInputComboRadius.Name = "ucrInputComboRadius"
        Me.ucrInputComboRadius.Size = New System.Drawing.Size(66, 21)
        Me.ucrInputComboRadius.TabIndex = 7
        '
        'lblRadiusScale
        '
        Me.lblRadiusScale.AutoSize = True
        Me.lblRadiusScale.Location = New System.Drawing.Point(283, 172)
        Me.lblRadiusScale.Name = "lblRadiusScale"
        Me.lblRadiusScale.Size = New System.Drawing.Size(73, 13)
        Me.lblRadiusScale.TabIndex = 8
        Me.lblRadiusScale.Text = "Radius Scale:"
        '
        'cmdCircularOptions
        '
        Me.cmdCircularOptions.Enabled = False
        Me.cmdCircularOptions.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdCircularOptions.Location = New System.Drawing.Point(6, 199)
        Me.cmdCircularOptions.Name = "cmdCircularOptions"
        Me.cmdCircularOptions.Size = New System.Drawing.Size(120, 25)
        Me.cmdCircularOptions.TabIndex = 9
        Me.cmdCircularOptions.Tag = "Circular_Options"
        Me.cmdCircularOptions.Text = "Circular Options"
        Me.cmdCircularOptions.UseVisualStyleBackColor = True
        '
        'dlgCircularRosePlot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(433, 330)
        Me.Controls.Add(Me.cmdCircularOptions)
        Me.Controls.Add(Me.lblRadiusScale)
        Me.Controls.Add(Me.ucrInputComboRadius)
        Me.Controls.Add(Me.lblBins)
        Me.Controls.Add(Me.ucrInputBins)
        Me.Controls.Add(Me.lblVariable)
        Me.Controls.Add(Me.ucrReceiverVariable)
        Me.Controls.Add(Me.ucrSaveCircularRosePlot)
        Me.Controls.Add(Me.ucrSelctorCircularDataFrame)
        Me.Controls.Add(Me.ucrBase)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgCircularRosePlot"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Rose Plot"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ucrBase As ucrButtons
    Friend WithEvents ucrSelctorCircularDataFrame As ucrSelectorByDataFrameAddRemove
    Friend WithEvents ucrSaveCircularRosePlot As ucrSave
    Friend WithEvents ucrReceiverVariable As ucrReceiverSingle
    Friend WithEvents lblVariable As Label
    Friend WithEvents ucrInputBins As ucrInputTextBox
    Friend WithEvents lblBins As Label
    Friend WithEvents lblRadiusScale As Label
    Friend WithEvents ucrInputComboRadius As ucrInputComboBox
    Friend WithEvents cmdCircularOptions As Button
End Class
