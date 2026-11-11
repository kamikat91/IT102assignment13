<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.btnupdatepilots = New System.Windows.Forms.Button()
        Me.btnaddpilots = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnupdatepilots
        '
        Me.btnupdatepilots.Location = New System.Drawing.Point(338, 237)
        Me.btnupdatepilots.Name = "btnupdatepilots"
        Me.btnupdatepilots.Size = New System.Drawing.Size(141, 23)
        Me.btnupdatepilots.TabIndex = 3
        Me.btnupdatepilots.Text = "Update passengers"
        Me.btnupdatepilots.UseVisualStyleBackColor = True
        '
        'btnaddpilots
        '
        Me.btnaddpilots.Location = New System.Drawing.Point(338, 191)
        Me.btnaddpilots.Name = "btnaddpilots"
        Me.btnaddpilots.Size = New System.Drawing.Size(128, 23)
        Me.btnaddpilots.TabIndex = 2
        Me.btnaddpilots.Text = "add passengers"
        Me.btnaddpilots.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnupdatepilots)
        Me.Controls.Add(Me.btnaddpilots)
        Me.Name = "frmMain"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnupdatepilots As Button
    Friend WithEvents btnaddpilots As Button
End Class
