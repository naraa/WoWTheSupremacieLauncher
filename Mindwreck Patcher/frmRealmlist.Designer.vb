<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRealmlist
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRealmlist))
        Me.cbRealmList = New System.Windows.Forms.ComboBox()
        Me.txtRealmList1 = New System.Windows.Forms.TextBox()
        Me.txtPort1 = New System.Windows.Forms.TextBox()
        Me.lblRealmList = New System.Windows.Forms.Label()
        Me.lblPort = New System.Windows.Forms.Label()
        Me.gbRealmlist = New System.Windows.Forms.GroupBox()
        Me.lblDel5 = New System.Windows.Forms.Label()
        Me.lblDel4 = New System.Windows.Forms.Label()
        Me.lblDel3 = New System.Windows.Forms.Label()
        Me.lblDel2 = New System.Windows.Forms.Label()
        Me.lblDel1 = New System.Windows.Forms.Label()
        Me.btnDel5 = New System.Windows.Forms.Button()
        Me.btnDel4 = New System.Windows.Forms.Button()
        Me.btnDel3 = New System.Windows.Forms.Button()
        Me.btnDel2 = New System.Windows.Forms.Button()
        Me.btnDel1 = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.txtRealmList5 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtPort5 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtRealmList4 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPort4 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtRealmList3 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPort3 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtRealmList2 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPort2 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.gbRealmSelected = New System.Windows.Forms.GroupBox()
        Me.btnSelect = New System.Windows.Forms.Button()
        Me.gbRealmlist.SuspendLayout()
        Me.gbRealmSelected.SuspendLayout()
        Me.SuspendLayout()
        '
        'cbRealmList
        '
        Me.cbRealmList.FormattingEnabled = True
        Me.cbRealmList.Location = New System.Drawing.Point(9, 19)
        Me.cbRealmList.Name = "cbRealmList"
        Me.cbRealmList.Size = New System.Drawing.Size(442, 22)
        Me.cbRealmList.TabIndex = 1
        '
        'txtRealmList1
        '
        Me.txtRealmList1.Location = New System.Drawing.Point(9, 39)
        Me.txtRealmList1.Name = "txtRealmList1"
        Me.txtRealmList1.Size = New System.Drawing.Size(269, 20)
        Me.txtRealmList1.TabIndex = 6
        Me.txtRealmList1.Text = "Ajouter un realmlist"
        '
        'txtPort1
        '
        Me.txtPort1.Location = New System.Drawing.Point(284, 39)
        Me.txtPort1.Name = "txtPort1"
        Me.txtPort1.Size = New System.Drawing.Size(86, 20)
        Me.txtPort1.TabIndex = 7
        Me.txtPort1.Text = "port"
        '
        'lblRealmList
        '
        Me.lblRealmList.AutoSize = True
        Me.lblRealmList.Font = New System.Drawing.Font("Georgia", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRealmList.ForeColor = System.Drawing.Color.YellowGreen
        Me.lblRealmList.Location = New System.Drawing.Point(8, 23)
        Me.lblRealmList.Name = "lblRealmList"
        Me.lblRealmList.Size = New System.Drawing.Size(80, 14)
        Me.lblRealmList.TabIndex = 4
        Me.lblRealmList.Text = "Realmlist 1"
        '
        'lblPort
        '
        Me.lblPort.AutoSize = True
        Me.lblPort.Font = New System.Drawing.Font("Georgia", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPort.ForeColor = System.Drawing.Color.YellowGreen
        Me.lblPort.Location = New System.Drawing.Point(281, 23)
        Me.lblPort.Name = "lblPort"
        Me.lblPort.Size = New System.Drawing.Size(35, 14)
        Me.lblPort.TabIndex = 5
        Me.lblPort.Text = "Port"
        '
        'gbRealmlist
        '
        Me.gbRealmlist.Controls.Add(Me.lblDel5)
        Me.gbRealmlist.Controls.Add(Me.lblDel4)
        Me.gbRealmlist.Controls.Add(Me.lblDel3)
        Me.gbRealmlist.Controls.Add(Me.lblDel2)
        Me.gbRealmlist.Controls.Add(Me.lblDel1)
        Me.gbRealmlist.Controls.Add(Me.btnDel5)
        Me.gbRealmlist.Controls.Add(Me.btnDel4)
        Me.gbRealmlist.Controls.Add(Me.btnDel3)
        Me.gbRealmlist.Controls.Add(Me.btnDel2)
        Me.gbRealmlist.Controls.Add(Me.btnDel1)
        Me.gbRealmlist.Controls.Add(Me.btnSave)
        Me.gbRealmlist.Controls.Add(Me.txtRealmList5)
        Me.gbRealmlist.Controls.Add(Me.Label7)
        Me.gbRealmlist.Controls.Add(Me.txtPort5)
        Me.gbRealmlist.Controls.Add(Me.Label8)
        Me.gbRealmlist.Controls.Add(Me.txtRealmList4)
        Me.gbRealmlist.Controls.Add(Me.Label5)
        Me.gbRealmlist.Controls.Add(Me.txtPort4)
        Me.gbRealmlist.Controls.Add(Me.Label6)
        Me.gbRealmlist.Controls.Add(Me.txtRealmList3)
        Me.gbRealmlist.Controls.Add(Me.Label3)
        Me.gbRealmlist.Controls.Add(Me.txtPort3)
        Me.gbRealmlist.Controls.Add(Me.Label4)
        Me.gbRealmlist.Controls.Add(Me.txtRealmList2)
        Me.gbRealmlist.Controls.Add(Me.Label1)
        Me.gbRealmlist.Controls.Add(Me.txtPort2)
        Me.gbRealmlist.Controls.Add(Me.Label2)
        Me.gbRealmlist.Controls.Add(Me.txtRealmList1)
        Me.gbRealmlist.Controls.Add(Me.lblPort)
        Me.gbRealmlist.Controls.Add(Me.txtPort1)
        Me.gbRealmlist.Controls.Add(Me.lblRealmList)
        Me.gbRealmlist.Font = New System.Drawing.Font("Georgia", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbRealmlist.ForeColor = System.Drawing.Color.YellowGreen
        Me.gbRealmlist.Location = New System.Drawing.Point(10, 8)
        Me.gbRealmlist.Name = "gbRealmlist"
        Me.gbRealmlist.Size = New System.Drawing.Size(459, 293)
        Me.gbRealmlist.TabIndex = 3
        Me.gbRealmlist.TabStop = False
        Me.gbRealmlist.Text = "Ajouter un Realmlist"
        '
        'lblDel5
        '
        Me.lblDel5.AutoSize = True
        Me.lblDel5.Location = New System.Drawing.Point(382, 204)
        Me.lblDel5.Name = "lblDel5"
        Me.lblDel5.Size = New System.Drawing.Size(0, 14)
        Me.lblDel5.TabIndex = 34
        '
        'lblDel4
        '
        Me.lblDel4.AutoSize = True
        Me.lblDel4.Location = New System.Drawing.Point(382, 161)
        Me.lblDel4.Name = "lblDel4"
        Me.lblDel4.Size = New System.Drawing.Size(0, 14)
        Me.lblDel4.TabIndex = 33
        '
        'lblDel3
        '
        Me.lblDel3.AutoSize = True
        Me.lblDel3.Location = New System.Drawing.Point(382, 114)
        Me.lblDel3.Name = "lblDel3"
        Me.lblDel3.Size = New System.Drawing.Size(0, 14)
        Me.lblDel3.TabIndex = 32
        '
        'lblDel2
        '
        Me.lblDel2.AutoSize = True
        Me.lblDel2.Location = New System.Drawing.Point(382, 67)
        Me.lblDel2.Name = "lblDel2"
        Me.lblDel2.Size = New System.Drawing.Size(0, 14)
        Me.lblDel2.TabIndex = 31
        '
        'lblDel1
        '
        Me.lblDel1.AutoSize = True
        Me.lblDel1.Location = New System.Drawing.Point(382, 23)
        Me.lblDel1.Name = "lblDel1"
        Me.lblDel1.Size = New System.Drawing.Size(0, 14)
        Me.lblDel1.TabIndex = 30
        '
        'btnDel5
        '
        Me.btnDel5.ForeColor = System.Drawing.Color.Black
        Me.btnDel5.Location = New System.Drawing.Point(376, 219)
        Me.btnDel5.Name = "btnDel5"
        Me.btnDel5.Size = New System.Drawing.Size(75, 23)
        Me.btnDel5.TabIndex = 29
        Me.btnDel5.Text = "Delete"
        Me.btnDel5.UseVisualStyleBackColor = True
        '
        'btnDel4
        '
        Me.btnDel4.ForeColor = System.Drawing.Color.Black
        Me.btnDel4.Location = New System.Drawing.Point(376, 176)
        Me.btnDel4.Name = "btnDel4"
        Me.btnDel4.Size = New System.Drawing.Size(75, 23)
        Me.btnDel4.TabIndex = 28
        Me.btnDel4.Text = "Delete"
        Me.btnDel4.UseVisualStyleBackColor = True
        '
        'btnDel3
        '
        Me.btnDel3.ForeColor = System.Drawing.Color.Black
        Me.btnDel3.Location = New System.Drawing.Point(376, 129)
        Me.btnDel3.Name = "btnDel3"
        Me.btnDel3.Size = New System.Drawing.Size(75, 23)
        Me.btnDel3.TabIndex = 27
        Me.btnDel3.Text = "Delete"
        Me.btnDel3.UseVisualStyleBackColor = True
        '
        'btnDel2
        '
        Me.btnDel2.ForeColor = System.Drawing.Color.Black
        Me.btnDel2.Location = New System.Drawing.Point(376, 82)
        Me.btnDel2.Name = "btnDel2"
        Me.btnDel2.Size = New System.Drawing.Size(75, 23)
        Me.btnDel2.TabIndex = 26
        Me.btnDel2.Text = "Delete"
        Me.btnDel2.UseVisualStyleBackColor = True
        '
        'btnDel1
        '
        Me.btnDel1.ForeColor = System.Drawing.Color.Black
        Me.btnDel1.Location = New System.Drawing.Point(376, 38)
        Me.btnDel1.Name = "btnDel1"
        Me.btnDel1.Size = New System.Drawing.Size(75, 23)
        Me.btnDel1.TabIndex = 25
        Me.btnDel1.Text = "Delete"
        Me.btnDel1.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.ForeColor = System.Drawing.Color.Black
        Me.btnSave.Location = New System.Drawing.Point(6, 246)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(445, 40)
        Me.btnSave.TabIndex = 24
        Me.btnSave.Text = "Sauvegarder la liste"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'txtRealmList5
        '
        Me.txtRealmList5.Location = New System.Drawing.Point(9, 220)
        Me.txtRealmList5.Name = "txtRealmList5"
        Me.txtRealmList5.Size = New System.Drawing.Size(269, 20)
        Me.txtRealmList5.TabIndex = 22
        Me.txtRealmList5.Text = "Ajouter un realmlist"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Georgia", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.YellowGreen
        Me.Label7.Location = New System.Drawing.Point(281, 204)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(35, 14)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "Port"
        '
        'txtPort5
        '
        Me.txtPort5.Location = New System.Drawing.Point(284, 220)
        Me.txtPort5.Name = "txtPort5"
        Me.txtPort5.Size = New System.Drawing.Size(86, 20)
        Me.txtPort5.TabIndex = 23
        Me.txtPort5.Text = "port"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Georgia", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.YellowGreen
        Me.Label8.Location = New System.Drawing.Point(8, 204)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(81, 14)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Realmlist 5"
        '
        'txtRealmList4
        '
        Me.txtRealmList4.Location = New System.Drawing.Point(9, 177)
        Me.txtRealmList4.Name = "txtRealmList4"
        Me.txtRealmList4.Size = New System.Drawing.Size(269, 20)
        Me.txtRealmList4.TabIndex = 18
        Me.txtRealmList4.Text = "Ajouter un realmlist"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Georgia", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.YellowGreen
        Me.Label5.Location = New System.Drawing.Point(281, 161)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 14)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Port"
        '
        'txtPort4
        '
        Me.txtPort4.Location = New System.Drawing.Point(284, 177)
        Me.txtPort4.Name = "txtPort4"
        Me.txtPort4.Size = New System.Drawing.Size(86, 20)
        Me.txtPort4.TabIndex = 19
        Me.txtPort4.Text = "port"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Georgia", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.YellowGreen
        Me.Label6.Location = New System.Drawing.Point(8, 161)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(81, 14)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Realmlist 4"
        '
        'txtRealmList3
        '
        Me.txtRealmList3.Location = New System.Drawing.Point(9, 130)
        Me.txtRealmList3.Name = "txtRealmList3"
        Me.txtRealmList3.Size = New System.Drawing.Size(269, 20)
        Me.txtRealmList3.TabIndex = 14
        Me.txtRealmList3.Text = "Ajouter un realmlist"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Georgia", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.YellowGreen
        Me.Label3.Location = New System.Drawing.Point(281, 114)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 14)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Port"
        '
        'txtPort3
        '
        Me.txtPort3.Location = New System.Drawing.Point(284, 130)
        Me.txtPort3.Name = "txtPort3"
        Me.txtPort3.Size = New System.Drawing.Size(86, 20)
        Me.txtPort3.TabIndex = 15
        Me.txtPort3.Text = "port"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Georgia", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.YellowGreen
        Me.Label4.Location = New System.Drawing.Point(8, 114)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 14)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Realmlist 3"
        '
        'txtRealmList2
        '
        Me.txtRealmList2.Location = New System.Drawing.Point(9, 83)
        Me.txtRealmList2.Name = "txtRealmList2"
        Me.txtRealmList2.Size = New System.Drawing.Size(269, 20)
        Me.txtRealmList2.TabIndex = 10
        Me.txtRealmList2.Text = "Ajouter un realmlist"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Georgia", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.YellowGreen
        Me.Label1.Location = New System.Drawing.Point(281, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 14)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Port"
        '
        'txtPort2
        '
        Me.txtPort2.Location = New System.Drawing.Point(284, 83)
        Me.txtPort2.Name = "txtPort2"
        Me.txtPort2.Size = New System.Drawing.Size(86, 20)
        Me.txtPort2.TabIndex = 11
        Me.txtPort2.Text = "port"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Georgia", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.YellowGreen
        Me.Label2.Location = New System.Drawing.Point(8, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 14)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Realmlist 2"
        '
        'gbRealmSelected
        '
        Me.gbRealmSelected.Controls.Add(Me.btnSelect)
        Me.gbRealmSelected.Controls.Add(Me.cbRealmList)
        Me.gbRealmSelected.Font = New System.Drawing.Font("Georgia", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbRealmSelected.ForeColor = System.Drawing.Color.YellowGreen
        Me.gbRealmSelected.Location = New System.Drawing.Point(10, 316)
        Me.gbRealmSelected.Name = "gbRealmSelected"
        Me.gbRealmSelected.Size = New System.Drawing.Size(459, 94)
        Me.gbRealmSelected.TabIndex = 0
        Me.gbRealmSelected.TabStop = False
        Me.gbRealmSelected.Text = "Sélectionner un RealmList"
        '
        'btnSelect
        '
        Me.btnSelect.ForeColor = System.Drawing.Color.Black
        Me.btnSelect.Location = New System.Drawing.Point(8, 47)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(443, 40)
        Me.btnSelect.TabIndex = 2
        Me.btnSelect.Text = "Sélectioner ce realmlist"
        Me.btnSelect.UseVisualStyleBackColor = True
        '
        'frmRealmlist
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(57, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(479, 422)
        Me.Controls.Add(Me.gbRealmSelected)
        Me.Controls.Add(Me.gbRealmlist)
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(485, 450)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(485, 450)
        Me.Name = "frmRealmlist"
        Me.Opacity = 0.9R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "The Mindwreck - WoW Luncher "
        Me.TopMost = True
        Me.gbRealmlist.ResumeLayout(False)
        Me.gbRealmlist.PerformLayout()
        Me.gbRealmSelected.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cbRealmList As System.Windows.Forms.ComboBox
    Friend WithEvents txtRealmList1 As System.Windows.Forms.TextBox
    Friend WithEvents txtPort1 As System.Windows.Forms.TextBox
    Friend WithEvents lblRealmList As System.Windows.Forms.Label
    Friend WithEvents lblPort As System.Windows.Forms.Label
    Friend WithEvents gbRealmlist As System.Windows.Forms.GroupBox
    Friend WithEvents gbRealmSelected As System.Windows.Forms.GroupBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents txtRealmList5 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtPort5 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtRealmList4 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPort4 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtRealmList3 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPort3 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtRealmList2 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPort2 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnSelect As System.Windows.Forms.Button
    Friend WithEvents btnDel5 As System.Windows.Forms.Button
    Friend WithEvents btnDel4 As System.Windows.Forms.Button
    Friend WithEvents btnDel3 As System.Windows.Forms.Button
    Friend WithEvents btnDel2 As System.Windows.Forms.Button
    Friend WithEvents btnDel1 As System.Windows.Forms.Button
    Friend WithEvents lblDel5 As System.Windows.Forms.Label
    Friend WithEvents lblDel4 As System.Windows.Forms.Label
    Friend WithEvents lblDel3 As System.Windows.Forms.Label
    Friend WithEvents lblDel2 As System.Windows.Forms.Label
    Friend WithEvents lblDel1 As System.Windows.Forms.Label
End Class
