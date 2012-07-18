<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.btnPatch = New System.Windows.Forms.Button()
        Me.btnUnpatch = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblPourcent = New System.Windows.Forms.Label()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.JouerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ÀProposToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FermerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.OptionsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PatchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UnpatchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QuitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AideToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.InfoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ÀProposToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AideToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ÀProposToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblLangue = New System.Windows.Forms.Label()
        Me.lblLangueDetect = New System.Windows.Forms.Label()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnPatch
        '
        Me.btnPatch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPatch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPatch.ForeColor = System.Drawing.Color.Black
        Me.btnPatch.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPatch.Location = New System.Drawing.Point(650, 524)
        Me.btnPatch.Name = "btnPatch"
        Me.btnPatch.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnPatch.Size = New System.Drawing.Size(140, 84)
        Me.btnPatch.TabIndex = 0
        Me.btnPatch.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnPatch.UseVisualStyleBackColor = True
        '
        'btnUnpatch
        '
        Me.btnUnpatch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUnpatch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUnpatch.ForeColor = System.Drawing.Color.Black
        Me.btnUnpatch.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnUnpatch.Location = New System.Drawing.Point(504, 524)
        Me.btnUnpatch.Name = "btnUnpatch"
        Me.btnUnpatch.Size = New System.Drawing.Size(140, 84)
        Me.btnUnpatch.TabIndex = 4
        Me.btnUnpatch.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnUnpatch.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Chocolate
        Me.Label1.Location = New System.Drawing.Point(395, 594)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Compléter :"
        '
        'lblPourcent
        '
        Me.lblPourcent.AutoSize = True
        Me.lblPourcent.BackColor = System.Drawing.Color.Transparent
        Me.lblPourcent.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPourcent.ForeColor = System.Drawing.Color.Chocolate
        Me.lblPourcent.Location = New System.Drawing.Point(460, 594)
        Me.lblPourcent.Name = "lblPourcent"
        Me.lblPourcent.Size = New System.Drawing.Size(42, 13)
        Me.lblPourcent.TabIndex = 8
        Me.lblPourcent.Text = "Label2"
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.NotifyIcon1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "The Mindwreck Patcher "
        Me.NotifyIcon1.Visible = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.JouerToolStripMenuItem, Me.ÀProposToolStripMenuItem, Me.FermerToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(123, 70)
        '
        'JouerToolStripMenuItem
        '
        Me.JouerToolStripMenuItem.Name = "JouerToolStripMenuItem"
        Me.JouerToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.JouerToolStripMenuItem.Text = "Jouer"
        '
        'ÀProposToolStripMenuItem
        '
        Me.ÀProposToolStripMenuItem.Name = "ÀProposToolStripMenuItem"
        Me.ÀProposToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.ÀProposToolStripMenuItem.Text = "À Propos"
        '
        'FermerToolStripMenuItem
        '
        Me.FermerToolStripMenuItem.Name = "FermerToolStripMenuItem"
        Me.FermerToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.FermerToolStripMenuItem.Text = "Fermer"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.MenuStrip1.BackColor = System.Drawing.Color.Black
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI Symbol", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OptionsToolStripMenuItem1, Me.AideToolStripMenuItem1, Me.InfoToolStripMenuItem})
        Me.MenuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.MenuStrip1.Location = New System.Drawing.Point(5, 0)
        Me.MenuStrip1.Margin = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.MenuStrip1.MaximumSize = New System.Drawing.Size(807, 24)
        Me.MenuStrip1.MinimumSize = New System.Drawing.Size(807, 24)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(0)
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.MenuStrip1.Size = New System.Drawing.Size(807, 24)
        Me.MenuStrip1.TabIndex = 10
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'OptionsToolStripMenuItem1
        '
        Me.OptionsToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PatchToolStripMenuItem, Me.UnpatchToolStripMenuItem, Me.QuitToolStripMenuItem})
        Me.OptionsToolStripMenuItem1.Font = New System.Drawing.Font("Segoe UI Symbol", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptionsToolStripMenuItem1.ForeColor = System.Drawing.Color.White
        Me.OptionsToolStripMenuItem1.Name = "OptionsToolStripMenuItem1"
        Me.OptionsToolStripMenuItem1.Size = New System.Drawing.Size(59, 24)
        Me.OptionsToolStripMenuItem1.Text = "Actions"
        '
        'PatchToolStripMenuItem
        '
        Me.PatchToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlText
        Me.PatchToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.PatchToolStripMenuItem.Name = "PatchToolStripMenuItem"
        Me.PatchToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.PatchToolStripMenuItem.Text = "Play / Patch"
        '
        'UnpatchToolStripMenuItem
        '
        Me.UnpatchToolStripMenuItem.BackColor = System.Drawing.Color.Black
        Me.UnpatchToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.UnpatchToolStripMenuItem.Name = "UnpatchToolStripMenuItem"
        Me.UnpatchToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.UnpatchToolStripMenuItem.Text = "Unpatch"
        '
        'QuitToolStripMenuItem
        '
        Me.QuitToolStripMenuItem.BackColor = System.Drawing.Color.Black
        Me.QuitToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.QuitToolStripMenuItem.Name = "QuitToolStripMenuItem"
        Me.QuitToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.QuitToolStripMenuItem.Text = "Quit"
        '
        'AideToolStripMenuItem1
        '
        Me.AideToolStripMenuItem1.ForeColor = System.Drawing.Color.White
        Me.AideToolStripMenuItem1.Name = "AideToolStripMenuItem1"
        Me.AideToolStripMenuItem1.Size = New System.Drawing.Size(43, 24)
        Me.AideToolStripMenuItem1.Text = "Aide"
        '
        'InfoToolStripMenuItem
        '
        Me.InfoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ÀProposToolStripMenuItem2})
        Me.InfoToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.InfoToolStripMenuItem.Name = "InfoToolStripMenuItem"
        Me.InfoToolStripMenuItem.Size = New System.Drawing.Size(40, 24)
        Me.InfoToolStripMenuItem.Text = "Info"
        '
        'ÀProposToolStripMenuItem2
        '
        Me.ÀProposToolStripMenuItem2.BackColor = System.Drawing.Color.Black
        Me.ÀProposToolStripMenuItem2.ForeColor = System.Drawing.Color.White
        Me.ÀProposToolStripMenuItem2.Name = "ÀProposToolStripMenuItem2"
        Me.ÀProposToolStripMenuItem2.Size = New System.Drawing.Size(122, 22)
        Me.ÀProposToolStripMenuItem2.Text = "À propos"
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.BackColor = System.Drawing.Color.Black
        Me.OptionsToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(61, 24)
        Me.OptionsToolStripMenuItem.Text = "Options"
        '
        'AideToolStripMenuItem
        '
        Me.AideToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.AideToolStripMenuItem.Name = "AideToolStripMenuItem"
        Me.AideToolStripMenuItem.Size = New System.Drawing.Size(43, 24)
        Me.AideToolStripMenuItem.Text = "Aide"
        '
        'ÀProposToolStripMenuItem1
        '
        Me.ÀProposToolStripMenuItem1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.ÀProposToolStripMenuItem1.Name = "ÀProposToolStripMenuItem1"
        Me.ÀProposToolStripMenuItem1.Size = New System.Drawing.Size(40, 24)
        Me.ÀProposToolStripMenuItem1.Text = "Info"
        '
        'lblLangue
        '
        Me.lblLangue.AutoSize = True
        Me.lblLangue.BackColor = System.Drawing.Color.Transparent
        Me.lblLangue.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLangue.ForeColor = System.Drawing.Color.Chocolate
        Me.lblLangue.Location = New System.Drawing.Point(360, 515)
        Me.lblLangue.Name = "lblLangue"
        Me.lblLangue.Size = New System.Drawing.Size(93, 13)
        Me.lblLangue.TabIndex = 11
        Me.lblLangue.Text = "Langue détecté :"
        '
        'lblLangueDetect
        '
        Me.lblLangueDetect.AutoSize = True
        Me.lblLangueDetect.BackColor = System.Drawing.Color.Transparent
        Me.lblLangueDetect.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLangueDetect.ForeColor = System.Drawing.Color.Chocolate
        Me.lblLangueDetect.Location = New System.Drawing.Point(360, 528)
        Me.lblLangueDetect.Name = "lblLangueDetect"
        Me.lblLangueDetect.Size = New System.Drawing.Size(42, 13)
        Me.lblLangueDetect.TabIndex = 12
        Me.lblLangueDetect.Text = "Label3"
        '
        'lblInfo
        '
        Me.lblInfo.AutoSize = True
        Me.lblInfo.BackColor = System.Drawing.Color.Transparent
        Me.lblInfo.ForeColor = System.Drawing.Color.Chocolate
        Me.lblInfo.Location = New System.Drawing.Point(21, 515)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(43, 13)
        Me.lblInfo.TabIndex = 13
        Me.lblInfo.Text = "Status :"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(807, 625)
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.lblLangueDetect)
        Me.Controls.Add(Me.lblLangue)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.lblPourcent)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnUnpatch)
        Me.Controls.Add(Me.btnPatch)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(813, 653)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(813, 653)
        Me.Name = "frmMain"
        Me.Text = "The Mindwreck - WoW Luncher V2.0.3"
        Me.TopMost = True
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnPatch As System.Windows.Forms.Button
    Friend WithEvents btnUnpatch As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblPourcent As System.Windows.Forms.Label
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents FermerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents JouerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ÀProposToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AideToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ÀProposToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OptionsToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AideToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InfoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PatchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UnpatchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents QuitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ÀProposToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblLangue As System.Windows.Forms.Label
    Friend WithEvents lblLangueDetect As System.Windows.Forms.Label
    Friend WithEvents lblInfo As System.Windows.Forms.Label


End Class
