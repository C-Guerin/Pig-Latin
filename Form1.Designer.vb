<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMain
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
        Me.TxtEnglishInput = New System.Windows.Forms.TextBox()
        Me.TxtPigLatinOutput = New System.Windows.Forms.TextBox()
        Me.BtnClear = New System.Windows.Forms.Button()
        Me.BtnExit = New System.Windows.Forms.Button()
        Me.BtnTranslate = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'TxtEnglishInput
        '
        Me.TxtEnglishInput.Location = New System.Drawing.Point(13, 13)
        Me.TxtEnglishInput.Multiline = True
        Me.TxtEnglishInput.Name = "TxtEnglishInput"
        Me.TxtEnglishInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtEnglishInput.Size = New System.Drawing.Size(459, 200)
        Me.TxtEnglishInput.TabIndex = 0
        Me.TxtEnglishInput.Text = "Type English here."
        '
        'TxtPigLatinOutput
        '
        Me.TxtPigLatinOutput.Location = New System.Drawing.Point(13, 248)
        Me.TxtPigLatinOutput.Multiline = True
        Me.TxtPigLatinOutput.Name = "TxtPigLatinOutput"
        Me.TxtPigLatinOutput.ReadOnly = True
        Me.TxtPigLatinOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtPigLatinOutput.Size = New System.Drawing.Size(459, 201)
        Me.TxtPigLatinOutput.TabIndex = 1
        Me.TxtPigLatinOutput.Text = "Get Pig Lain here."
        '
        'BtnClear
        '
        Me.BtnClear.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClear.Location = New System.Drawing.Point(13, 219)
        Me.BtnClear.Name = "BtnClear"
        Me.BtnClear.Size = New System.Drawing.Size(75, 23)
        Me.BtnClear.TabIndex = 2
        Me.BtnClear.Text = "Clear"
        Me.BtnClear.UseVisualStyleBackColor = True
        '
        'BtnExit
        '
        Me.BtnExit.Location = New System.Drawing.Point(397, 219)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(75, 23)
        Me.BtnExit.TabIndex = 3
        Me.BtnExit.Text = "Exit"
        Me.BtnExit.UseVisualStyleBackColor = True
        '
        'BtnTranslate
        '
        Me.BtnTranslate.Location = New System.Drawing.Point(206, 219)
        Me.BtnTranslate.Name = "BtnTranslate"
        Me.BtnTranslate.Size = New System.Drawing.Size(75, 23)
        Me.BtnTranslate.TabIndex = 4
        Me.BtnTranslate.Text = "Translate"
        Me.BtnTranslate.UseVisualStyleBackColor = True
        '
        'FrmMain
        '
        Me.AcceptButton = Me.BtnTranslate
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnClear
        Me.ClientSize = New System.Drawing.Size(484, 461)
        Me.Controls.Add(Me.BtnTranslate)
        Me.Controls.Add(Me.BtnExit)
        Me.Controls.Add(Me.BtnClear)
        Me.Controls.Add(Me.TxtPigLatinOutput)
        Me.Controls.Add(Me.TxtEnglishInput)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "FrmMain"
        Me.Text = "FrmMain"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TxtEnglishInput As TextBox
    Friend WithEvents TxtPigLatinOutput As TextBox
    Friend WithEvents BtnClear As Button
    Friend WithEvents BtnExit As Button
    Friend WithEvents BtnTranslate As Button
End Class
