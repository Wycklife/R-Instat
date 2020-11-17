<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgCircularScatterPlot
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
        Me.ucrSelectorCircularDataFrame = New instat.ucrSelectorByDataFrameAddRemove()
        Me.ucrReceiverCircularVariable = New instat.ucrReceiverSingle()
        Me.lblVariable = New System.Windows.Forms.Label()
        Me.ucrSaveCircularPlot = New instat.ucrSave()
        Me.SuspendLayout()
        '
        'ucrBase
        '
        Me.ucrBase.Location = New System.Drawing.Point(5, 266)
        Me.ucrBase.Name = "ucrBase"
        Me.ucrBase.Size = New System.Drawing.Size(410, 52)
        Me.ucrBase.TabIndex = 0
        '
        'ucrSelectorCircularDataFrame
        '
        Me.ucrSelectorCircularDataFrame.bDropUnusedFilterLevels = False
        Me.ucrSelectorCircularDataFrame.bShowHiddenColumns = False
        Me.ucrSelectorCircularDataFrame.bUseCurrentFilter = True
        Me.ucrSelectorCircularDataFrame.Location = New System.Drawing.Point(9, 9)
        Me.ucrSelectorCircularDataFrame.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrSelectorCircularDataFrame.Name = "ucrSelectorCircularDataFrame"
        Me.ucrSelectorCircularDataFrame.Size = New System.Drawing.Size(210, 180)
        Me.ucrSelectorCircularDataFrame.TabIndex = 1
        '
        'ucrReceiverCircularVariable
        '
        Me.ucrReceiverCircularVariable.frmParent = Me
        Me.ucrReceiverCircularVariable.Location = New System.Drawing.Point(291, 31)
        Me.ucrReceiverCircularVariable.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverCircularVariable.Name = "ucrReceiverCircularVariable"
        Me.ucrReceiverCircularVariable.Selector = Nothing
        Me.ucrReceiverCircularVariable.Size = New System.Drawing.Size(120, 20)
        Me.ucrReceiverCircularVariable.strNcFilePath = ""
        Me.ucrReceiverCircularVariable.TabIndex = 2
        Me.ucrReceiverCircularVariable.ucrSelector = Nothing
        '
        'lblVariable
        '
        Me.lblVariable.AutoSize = True
        Me.lblVariable.Location = New System.Drawing.Point(287, 15)
        Me.lblVariable.Name = "lblVariable"
        Me.lblVariable.Size = New System.Drawing.Size(48, 13)
        Me.lblVariable.TabIndex = 3
        Me.lblVariable.Text = "Variable:"
        '
        'ucrSaveCircularPlot
        '
        Me.ucrSaveCircularPlot.Location = New System.Drawing.Point(9, 217)
        Me.ucrSaveCircularPlot.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrSaveCircularPlot.Name = "ucrSaveCircularPlot"
        Me.ucrSaveCircularPlot.Size = New System.Drawing.Size(272, 34)
        Me.ucrSaveCircularPlot.TabIndex = 4
        '
        'dlgCircularScatterPlot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(420, 323)
        Me.Controls.Add(Me.ucrSaveCircularPlot)
        Me.Controls.Add(Me.lblVariable)
        Me.Controls.Add(Me.ucrReceiverCircularVariable)
        Me.Controls.Add(Me.ucrSelectorCircularDataFrame)
        Me.Controls.Add(Me.ucrBase)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgCircularScatterPlot"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Scatter Plot"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ucrBase As ucrButtons
    Friend WithEvents ucrSelectorCircularDataFrame As ucrSelectorByDataFrameAddRemove
    Friend WithEvents ucrReceiverCircularVariable As ucrReceiverSingle
    Friend WithEvents ucrSaveCircularPlot As ucrSave
    Friend WithEvents lblVariable As Label
End Class
