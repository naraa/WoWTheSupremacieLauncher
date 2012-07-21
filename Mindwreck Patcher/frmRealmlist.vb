Public Class frmRealmlist

    Dim defRealm As String = "Ajouter un realmlist"
    Dim defPort As String = "port"

    Private Sub frmRealmlist_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'mise à jour du parent
        frmMain.lblRealmlistSelected.Text = My.Settings.RealmSelected
    End Sub


    Private Sub frmRealmlist_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        'declaration des realms diposnibles
        Dim realm(4) As String
        realm(0) = My.Settings.realm1 & ":" & My.Settings.port1
        realm(1) = My.Settings.realm2 & ":" & My.Settings.port2
        realm(2) = My.Settings.realm3 & ":" & My.Settings.port3
        realm(3) = My.Settings.realm4 & ":" & My.Settings.port4
        realm(4) = My.Settings.realm5 & ":" & My.Settings.port5

        'ajout du realmlist principal
        cbRealmList.Items.Add(My.Settings.themindwreck)

        'ajout des realm supplementaire ajouter par l'utilisateur
        For i As Integer = 0 To realm.Length - 1
            If Not realm(i) = defRealm & ":" & defPort Then
                If Not realm(i) = ":" Then
                    cbRealmList.Items.Add(realm(i))
                End If
            End If
        Next

        If Not realm(0) = defRealm & ":" & defPort Then
            If Not realm(0) = ":" Then
                txtRealmList1.Text = My.Settings.realm1
                txtPort1.Text = My.Settings.port1
            Else
                txtRealmList1.Text = defRealm
                txtPort1.Text = defPort
            End If
        End If

        If Not realm(1) = defRealm & ":" & defPort Then
            If Not realm(1) = ":" Then
                txtRealmList2.Text = My.Settings.realm2
                txtPort2.Text = My.Settings.port2
            Else
                txtRealmList2.Text = defRealm
                txtPort2.Text = defPort
            End If
        End If

        If Not realm(2) = defRealm & ":" & defPort Then
            If Not realm(2) = ":" Then
                txtRealmList3.Text = My.Settings.realm3
                txtPort3.Text = My.Settings.port3
            Else
                txtRealmList3.Text = defRealm
                txtPort3.Text = defPort
            End If
        End If

        If Not realm(3) = defRealm & ":" & defPort Then
            If Not realm(3) = ":" Then
                txtRealmList4.Text = My.Settings.realm4
                txtPort4.Text = My.Settings.port4
            Else
                txtRealmList4.Text = defRealm
                txtPort4.Text = defPort
            End If
        End If

        If Not realm(4) = defRealm & ":" & defPort Then
            If Not realm(4) = ":" Then
                txtRealmList5.Text = My.Settings.realm5
                txtPort5.Text = My.Settings.port5
            Else
                txtRealmList5.Text = defRealm
                txtPort5.Text = defPort
            End If
        End If



    End Sub

    
    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click

        'sauvegarde des realmlist personalisé
        Try
            Dim realm(4) As String
            realm(0) = txtRealmList1.Text & ":" & txtPort1.Text
            realm(1) = txtRealmList2.Text & ":" & txtPort2.Text
            realm(2) = txtRealmList3.Text & ":" & txtPort3.Text
            realm(3) = txtRealmList4.Text & ":" & txtPort4.Text
            realm(4) = txtRealmList5.Text & ":" & txtPort5.Text

            If Not realm(0) = defRealm & ":" & defPort Then
                My.Settings.realm1 = txtRealmList1.Text
                My.Settings.port1 = txtPort1.Text
            Else
                My.Settings.realm1 = defRealm
                My.Settings.port1 = defPort
            End If

            If Not realm(1) = defRealm & ":" & defPort Then
                My.Settings.realm2 = txtRealmList2.Text
                My.Settings.port2 = txtPort2.Text
            Else
                My.Settings.realm2 = defRealm
                My.Settings.port2 = defPort
            End If

            If Not realm(2) = defRealm & ":" & defPort Then
                My.Settings.realm3 = txtRealmList3.Text
                My.Settings.port3 = txtPort3.Text
            Else
                My.Settings.realm3 = defRealm
                My.Settings.port3 = defPort
            End If

            If Not realm(3) = defRealm & ":" & defPort Then
                My.Settings.realm4 = txtRealmList4.Text
                My.Settings.port4 = txtPort4.Text
            Else
                My.Settings.realm4 = defRealm
                My.Settings.port4 = defPort
            End If

            If Not realm(4) = defRealm & ":" & defPort Then
                My.Settings.realm5 = txtRealmList5.Text
                My.Settings.port5 = txtPort5.Text
            Else
                My.Settings.realm5 = defRealm
                My.Settings.port5 = defPort
            End If
        Catch ex As Exception
            MsgBox("Une erreur c'est produite avec la sauvegarde de vos nouvelles adresses realmlists et la mise à jour de la la liste des realmlists disponible" _
                   & vbCrLf & ex.Message, MsgBoxStyle.RetryCancel, "Erreur de suppresion de l'adresse")
        End Try
        'mise a jour de la liste
        Call update_realm()
        btnSave.Text = "La liste à bien été sauvegarder"
        btnSave.ForeColor = Color.DarkGreen
        Call Delay(0.5)
        btnSave.Text = "Sauvegarder la liste"
        btnSave.ForeColor = Color.Black

    End Sub

    Private Sub btnSelect_Click(sender As System.Object, e As System.EventArgs) Handles btnSelect.Click

        'sélection du realmlist
        Try
            If Not cbRealmList.SelectedIndex >= 0 Then
                MsgBox("Vous devez selectionner un realmlist", MsgBoxStyle.Exclamation, "Erreur de suppresion de l'adresse")
                Exit Sub
            End If
            My.Settings.RealmSelected = cbRealmList.Text
        Catch ex As Exception
            MsgBox("Une erreur c'est produite avec la sélection du realmlist" _
                   & vbCrLf & ex.Message, MsgBoxStyle.RetryCancel, "Erreur de sélection du realmlist")
        End Try
        'mise a jour de la liste
        Call update_realm()
        btnSelect.Text = "La sélection est bien enregistrer"
        btnSelect.ForeColor = Color.DarkGreen
        Call Delay(1)
        btnSelect.Text = "Sélectioner ce realmlist"
        btnSelect.ForeColor = Color.Black

    End Sub

#Region "Bouton delete"
    Private Sub btnDel1_Click(sender As System.Object, e As System.EventArgs) Handles btnDel1.Click
        'supression du realmlist 1
        Try
            txtRealmList1.Text = defRealm
            txtPort1.Text = defPort
            My.Settings.realm1 = defRealm
            My.Settings.port1 = defPort
        Catch ex As Exception
            MsgBox("Une erreur c'est produite avec la suppresion de l'adresse realmlist" & vbCrLf & _
                   ex.Message, MsgBoxStyle.RetryCancel, "Erreur de suppresion de l'adresse")
        End Try
        Call update_realm()
        lblDel1.Text = "(Succès)"
        Call Delay(0.3)
        lblDel1.Text = ""

    End Sub

    Private Sub btnDel2_Click(sender As System.Object, e As System.EventArgs) Handles btnDel2.Click
        'supression du realmlist 2
        Try
            txtRealmList2.Text = defRealm
            txtPort2.Text = defPort
            My.Settings.realm2 = defRealm
            My.Settings.port2 = defPort
        Catch ex As Exception
            MsgBox("Une erreur c'est produite avec la suppresion de l'adresse realmlist" & vbCrLf & _
                   ex.Message, MsgBoxStyle.RetryCancel, "Erreur de suppresion de l'adresse")
        End Try
        Call update_realm()
        lblDel2.Text = "(Succès)"
        Call Delay(0.3)
        lblDel2.Text = ""
    End Sub

    Private Sub btnDel3_Click(sender As System.Object, e As System.EventArgs) Handles btnDel3.Click
        'supression du realmlist 3
        Try
            txtRealmList3.Text = defRealm
            txtPort3.Text = defPort
            My.Settings.realm3 = defRealm
            My.Settings.port3 = defPort
        Catch ex As Exception
            MsgBox("Une erreur c'est produite avec la suppresion de l'adresse realmlist" & vbCrLf & _
                   ex.Message, MsgBoxStyle.RetryCancel, "Erreur de suppresion de l'adresse")
        End Try
        Call update_realm()
        lblDel3.Text = "(Succès)"
        Call Delay(0.3)
        lblDel3.Text = ""
    End Sub

    Private Sub btnDel4_Click(sender As System.Object, e As System.EventArgs) Handles btnDel4.Click
        'supression du realmlist 4
        Try
            txtRealmList4.Text = defRealm
            txtPort4.Text = defPort
            My.Settings.realm4 = defRealm
            My.Settings.port4 = defPort
        Catch ex As Exception
            MsgBox("Une erreur c'est produite avec la suppresion de l'adresse realmlist" & vbCrLf & _
                   ex.Message, MsgBoxStyle.RetryCancel, "Erreur de suppresion de l'adresse")
        End Try
        Call update_realm()
        lblDel4.Text = "(Succès)"
        Call Delay(0.3)
        lblDel4.Text = ""
    End Sub

    Private Sub btnDel5_Click(sender As System.Object, e As System.EventArgs) Handles btnDel5.Click
        'supression du realmlist 5
        Try
            txtRealmList5.Text = defRealm
            txtPort5.Text = defPort
            My.Settings.realm5 = defRealm
            My.Settings.port5 = defPort
        Catch ex As Exception
            MsgBox("Une erreur c'est produite avec la suppresion de l'adresse realmlist" & vbCrLf & _
                   ex.Message, MsgBoxStyle.RetryCancel, "Erreur de suppresion de l'adresse")
        End Try
        Call update_realm()
        lblDel5.Text = "(Succès)"
        Call Delay(0.3)
        lblDel5.Text = ""
    End Sub
#End Region

    Public Sub update_realm()

        'mise à jour de la liste des realmlist
        Try
            'on effacer la liste de realm
            cbRealmList.Items.Clear()
            'declaration des realms diposnibles
            Dim realm(4) As String
            realm(0) = My.Settings.realm1 & ":" & My.Settings.port1
            realm(1) = My.Settings.realm2 & ":" & My.Settings.port2
            realm(2) = My.Settings.realm3 & ":" & My.Settings.port3
            realm(3) = My.Settings.realm4 & ":" & My.Settings.port4
            realm(4) = My.Settings.realm5 & ":" & My.Settings.port5
            'ajout du realmlist principal
            cbRealmList.Items.Add(My.Settings.themindwreck)
            'ajout des realm supplementaire ajouter par l'utilisateur
            For i As Integer = 0 To realm.Length - 1
                If Not realm(i) = defRealm & ":" & defPort Then
                    cbRealmList.Items.Add(realm(i))
                End If
            Next
        Catch ex As Exception
            MsgBox("Une erreur c'est produite avec la mise à jour de la liste des realmlist disponible" & vbCrLf & _
                 ex.Message, MsgBoxStyle.RetryCancel, "Erreur de mise à jour")
        End Try

    End Sub

#Region "affichage"
    '::::::::::::::::::::::::::::::::::::::::::::::::::: Affichage TextBox Realmlist :::::::::::::::::::::::::::::::::'
    Private Sub txtRealmList1_GotFocus(sender As Object, e As System.EventArgs) Handles txtRealmList1.GotFocus
        If txtRealmList1.Text = defRealm Then
            txtRealmList1.Text = ""
        End If
    End Sub

    Private Sub txtRealmList2_GotFocus(sender As Object, e As System.EventArgs) Handles txtRealmList2.GotFocus
        If txtRealmList2.Text = defRealm Then
            txtRealmList2.Text = ""
        End If
    End Sub
    Private Sub txtRealmList3_GotFocus(sender As Object, e As System.EventArgs) Handles txtRealmList3.GotFocus
        If txtRealmList3.Text = defRealm Then
            txtRealmList3.Text = ""
        End If
    End Sub
    Private Sub txtRealmList4_GotFocus(sender As Object, e As System.EventArgs) Handles txtRealmList4.GotFocus
        If txtRealmList4.Text = defRealm Then
            txtRealmList4.Text = ""
        End If
    End Sub
    Private Sub txtRealmList5_GotFocus(sender As Object, e As System.EventArgs) Handles txtRealmList5.GotFocus
        If txtRealmList5.Text = defRealm Then
            txtRealmList5.Text = ""
        End If
    End Sub

    Private Sub txtRealmList1_LostFocus(sender As Object, e As System.EventArgs) Handles txtRealmList1.LostFocus
        If txtRealmList1.Text = "" Then
            txtRealmList1.Text = defRealm
        End If
    End Sub
    Private Sub txtRealmList2_LostFocus(sender As Object, e As System.EventArgs) Handles txtRealmList2.LostFocus
        If txtRealmList2.Text = "" Then
            txtRealmList2.Text = defRealm
        End If
    End Sub
    Private Sub txtRealmList3_LostFocus(sender As Object, e As System.EventArgs) Handles txtRealmList3.LostFocus
        If txtRealmList3.Text = "" Then
            txtRealmList3.Text = defRealm
        End If
    End Sub
    Private Sub txtRealmList4_LostFocus(sender As Object, e As System.EventArgs) Handles txtRealmList4.LostFocus
        If txtRealmList4.Text = "" Then
            txtRealmList4.Text = defRealm
        End If
    End Sub
    Private Sub txtRealmList5_LostFocus(sender As Object, e As System.EventArgs) Handles txtRealmList5.LostFocus
        If txtRealmList5.Text = "" Then
            txtRealmList5.Text = defRealm
        End If
    End Sub
    ':::::::::::::::::::::::::::::::::::::::::::: Affichage TextBox Port ::::::::::::::::::::::::::::::::::::::::::::'
    Private Sub txtPort1_GotFocus(sender As Object, e As System.EventArgs) Handles txtPort1.GotFocus
        If txtPort1.Text = defPort Then
            txtPort1.Text = ""
        End If
    End Sub

    Private Sub txtPort2_GotFocus(sender As Object, e As System.EventArgs) Handles txtPort2.GotFocus
        If txtPort2.Text = defPort Then
            txtPort2.Text = ""
        End If
    End Sub
    Private Sub txtPort3_GotFocus(sender As Object, e As System.EventArgs) Handles txtPort3.GotFocus
        If txtPort3.Text = defPort Then
            txtPort3.Text = ""
        End If
    End Sub
    Private Sub txtPort4_GotFocus(sender As Object, e As System.EventArgs) Handles txtPort4.GotFocus
        If txtPort4.Text = defPort Then
            txtPort4.Text = ""
        End If
    End Sub
    Private Sub txtPort5_GotFocus(sender As Object, e As System.EventArgs) Handles txtPort5.GotFocus
        If txtPort5.Text = defPort Then
            txtPort5.Text = ""
        End If
    End Sub

    Private Sub txtPort1_LostFocus(sender As Object, e As System.EventArgs) Handles txtPort1.LostFocus
        If txtPort1.Text = "" Then
            txtPort1.Text = defPort
        End If
    End Sub
    Private Sub txtPort2_LostFocus(sender As Object, e As System.EventArgs) Handles txtPort2.LostFocus
        If txtPort2.Text = "" Then
            txtPort2.Text = defPort
        End If
    End Sub
    Private Sub txtPort3_LostFocus(sender As Object, e As System.EventArgs) Handles txtPort3.LostFocus
        If txtPort3.Text = "" Then
            txtPort3.Text = defPort
        End If
    End Sub
    Private Sub txtPortt4_LostFocus(sender As Object, e As System.EventArgs) Handles txtPort4.LostFocus
        If txtPort4.Text = "" Then
            txtPort4.Text = defPort
        End If
    End Sub
    Private Sub txtPort5_LostFocus(sender As Object, e As System.EventArgs) Handles txtPort5.LostFocus
        If txtPort5.Text = "" Then
            txtPort5.Text = defPort
        End If
    End Sub
#End Region

  
End Class