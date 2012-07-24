Imports System
Imports System.IO
Imports System.Data
Imports Microsoft.Win32
Imports System.Diagnostics

Public Class frmMain
    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ':::::::::::::::::::::::::::::::  Détection initial des paramètres / emplacement / Langue / Internet ::::::::::::::::::::::::::::::::::::::::::::
        'vérification de l'emplacement du patcher
        If Not System.IO.File.Exists(file_path & "\Battle.net.dll") Or Not System.IO.Directory.Exists(file_path & "\Data") Then
            MsgBox("Vous devez lancer cette application à partir de la racine du dossier de jeux world of warcraft. Déplacer cette application au bon endroit et relancer là.", _
                   MsgBoxStyle.Critical, "Erreur de lancement")
            Me.Close()
        Else


            '  Vous devez cliquer sur My Projet dans l'explorateur de solution et aller dans parametres pour entrez votre realmlist par default 
            '  dans la case themindwreck
            '
            '  Vous devez enlevez le message box d'avertissement
            '
            'Supprimer ce msgbox() apres avoir configurer le realmlist par default
            MsgBox("Vous devez cliquer sur My Projet dans l'explorateur de solution et aller dans parametres pour entrez votre realmlist par default dans la case themindwreck" _
                   , MsgBoxStyle.Critical, "Configuration inclomplette")


            '::::::::::::::::::::::::::::::::::::::::::::::::::: AUTO-UPDATER PEUX (À configurer) ::::::::::::::::::::::::::::::::::::::::::::::::::::::

            ''si une connextion internet est disponible
            'If connexionInternet() = True Then

            '    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '    'cette fonction est désactivé pour la réactivé consulter les commentaire 
            '    'du block de code de la fonction checkforupdate()
            '    'syntax checkforupdate("lien vers un fichier version.txt contenant la version actuelle de l'application sur le serveur de mise à jours","version de la nouvelle build")
            '    'le fichier version.txt doit etre en mode Read Execute sur le serveur et doit contenir seulement la version ex: 2.0.0
            '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '    'on vérifie si une mise à jour est disponible                   '-> ici pour changer la version de la mise a jour
            '    checkforupdate("http://localhost/update/version.txt", "2.0.4")
            'Else
            '    'on informe qu'aucune connexion est disponible et quil est impossible de vériffier la mise à jour
            '    MsgBox("Vous n'êtes pas connectés à internet!" & vbCrLf _
            '           & "Il est donc impossible de vérifier si une mise à jour de l'application est disponible.", _
            '           MsgBoxStyle.Information, "Connexion internet indisponible")
            'End If


            ':::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::


            'Détection de la langue du jeux (Possibilité d'ajouter des langues.)
            Dim langs(2) As String
            langs(2) = "frFR"
            langs(1) = "enUS"
            langs(0) = "enGB"
            Dim langs_text(2) As String
            langs_text(2) = "Français Europe"
            langs_text(1) = "Anglais États-Unies"
            langs_text(0) = "Anglais Grande Bretagne"
            For i As Integer = 0 To langs.Length - 1
                If System.IO.Directory.Exists(file_path & "\Data\" & langs(i) & "") Then
                    lblLangueDetect.ForeColor = Color.DarkGreen
                    lblLangueDetect.Text = langs_text(i)
                    language = langs(i)
                    Exit For
                Else
                    lblLangueDetect.ForeColor = Color.DarkRed
                    lblLangueDetect.Text = "Langue inconnue"
                    language = "notfound"
                End If
            Next

            '::::::::::::::::::::::::::::::::::::::::::      Initialisation des éléments de l'interface      :::::::::::::::::::::::::::::::::::::

            'on commence la trame sonore de fond
            My.Computer.Audio.Play(My.Resources.sound, AudioPlayMode.BackgroundLoop)

            'affichage à 0
            pgrbStatus.Value = 0
            lblInfo.Text = UpdateStatus("Initialisation du patcher.", "Veuillez patienter un moment S.V.P.", "Initialisation terminer.")

            '(play / patch)
            Me.btnPatch.BackgroundImage = My.Resources.btnPlay_patcher
            Me.btnPatch.BackgroundImageLayout = ImageLayout.Stretch
            Me.btnPatch.FlatStyle = FlatStyle.Flat
            '(remove patch)
            Me.btnUnpatch.BackgroundImage = My.Resources.btnRem_patcher
            Me.btnUnpatch.BackgroundImageLayout = ImageLayout.Stretch
            Me.btnUnpatch.FlatStyle = FlatStyle.Flat

            'sélection du realm par défault si aucun n'est sélectionner.
            If My.Settings.RealmSelected = "" Then
                My.Settings.RealmSelected = My.Settings.themindwreck
            End If
            'affichage du realmlist sélecitonner
            lblRealmlistSelected.Text = My.Settings.RealmSelected
            lblRealmlistSelected.ForeColor = Color.DarkGreen

            If game_already_patch() Then 'si le jeux est déja patcher
                btnUnpatch.Enabled = True
                UnpatchToolStripMenuItem.Enabled = True
            Else
                btnUnpatch.Enabled = False
                btnUnpatch.BackgroundImage = My.Resources.btnRem_Unpatch
                UnpatchToolStripMenuItem.Enabled = False
            End If

        End If

    End Sub



    Private Sub btnPatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPatch.Click

        'on vérifie si le jeux n'est pas déjà patcher.
        If game_already_patch() Then
            'On créé le nouveaux fichier realmlist
            Try
                Dim FSys = CreateObject("Scripting.FileSystemObject")
                Dim realmlist = FSys.CreateTextFile(file_path & "\Data\" & language & "\realmlist.wtf")
                With realmlist
                    .writeLine("set realmlist " & My.Settings.RealmSelected)
                End With
            Catch ex As Exception
                lblInfo.Text = UpdateStatus("Erreur lors de la tentative.", "Le patch n'a pas fonctionné comme il devrait.", "Veuillez recommencer.", "Opération annulée.")
                lblInfo.ForeColor = Color.Red
                My.Computer.Audio.Play(My.Resources._420, AudioPlayMode.WaitToComplete)
                My.Computer.Audio.Play(My.Resources.sound, AudioPlayMode.Background)
                Exit Sub
            End Try
            Process.Start(file_path & "\Wow_The_Mindwreck.exe")
            Me.Close()
        Else

            'IMPOSSIBLE DE DÉTECTER LA LANGUE ERREUR
            If language = "notfound" Then
                lblInfo.Text = UpdateStatus("Erreur durant l'opération", "Langue impossible à détecter.", "Veuillez recommencer.", "Opération annulée.")
                lblInfo.ForeColor = Color.Red
                My.Computer.Audio.Play(My.Resources._420, AudioPlayMode.WaitToComplete)
                My.Computer.Audio.Play(My.Resources.sound, AudioPlayMode.Background)
                Exit Sub
            Else

                'On donne la couleur souhaiter au label 
                lblInfo.ForeColor = Color.DarkGray
                lblInfo.Text = UpdateStatus("Début de la copie des fichiers sur le disque.", "Veuillez patienter un moment S.V.P.")
                Call Delay(0.3)

                'On enregistre l'archive down.zip sur le disque dur
                Try
                    SaveToDisk("down.zip", file_path & "\Data\Down.zip")
                Catch ex As Exception
                    MsgBox("Une erreur c'est produite lors de l'enregistrement des nouveaux fichiers sur le disque dur. " _
                           + ex.Message, MsgBoxStyle.Critical)
                End Try

                lblInfo.Text = UpdateStatus("Début de la copie des fichiers sur le disque.", "Veuillez patienter un moment S.V.P.", "Terminer.")
                pgrbStatus.Value = 10
                Call Delay(0.3)
                lblInfo.Text = UpdateStatus("Début de l'extraction des fichiers copiés.", "Veuillez patienter un moment S.V.P.")

                'on extrait l'archive via la fonction extract créé plus haut
                Try
                    ExtractArchive(file_path & "\Data\down.zip", file_path & "\Data")
                Catch ex As Exception
                    MsgBox("Une erreur c'est produit lors de l'extraction des nouveaux fichiers. " + ex.Message, _
                           MsgBoxStyle.Critical)
                End Try
                'on appelle Delay pour 3 seconde le temps de l'extraction
                Call Delay(4)

                lblInfo.Text = UpdateStatus("Début de l'extraction des fichiers copiés.", "Veuillez patienter un moment S.V.P.", "Terminer.")
                pgrbStatus.Value = 20
                Call Delay(0.3)
                lblInfo.Text = UpdateStatus("Début de la modiffication des fichiers", "Veuillez patienter un moment S.V.P.")

                'suppression du fichier alternate.mpq
                If System.IO.File.Exists(file_path & "\Data\alternate.MPQ") Then
                    System.IO.File.Delete(file_path & "\Data\alternate.MPQ")
                    pgrbStatus.Value = 32 'on affiche le pourcentage
                ElseIf System.IO.File.Exists(file_path & "\Data\alternate.mpq") Then
                    System.IO.File.Delete(file_path & "\Data\alternate.mpq")
                    pgrbStatus.Value = 32  'on affiche le pourcentage
                End If

                'on copie le nouveau fichier wow-update-13623.MPQ
                If System.IO.File.Exists(file_path & "\Data\down\" & language & "\wow-update-13623.MPQ") Then
                    System.IO.File.Copy(file_path & "\Data\down\" & language & "\wow-update-13623.MPQ", file_path & "\Data\wow-update-13623.MPQ")
                    pgrbStatus.Value = 38 'on affiche le pourcentage
                Else
                    lblInfo.Text = UpdateStatus("Erreur lors de la tentative.", "Le patch n'a pas fonctionné comme il devrait.", "Veuillez recommencer.", "Opération annulée.")
                    lblInfo.ForeColor = Color.Red
                    My.Computer.Audio.Play(My.Resources._420, AudioPlayMode.WaitToComplete)
                    My.Computer.Audio.Play(My.Resources.sound, AudioPlayMode.Background)
                    Exit Sub
                End If
                'on copie le nouveau fichier wow-update-13624.MPQ
                If System.IO.File.Exists(file_path & "\Data\down\" & language & "\wow-update-13624.MPQ") Then
                    System.IO.File.Copy(file_path & "\Data\down\" & language & "\wow-update-13624.MPQ", file_path & "\Data\wow-update-13624.MPQ")
                    pgrbStatus.Value = 45 'on affiche le pourcentage
                Else
                    lblInfo.Text = UpdateStatus("Erreur lors de la tentative.", "Le patch n'a pas fonctionné comme il devrait.", "Veuillez recommencer.", "Opération annulée.")
                    lblInfo.ForeColor = Color.Red
                    My.Computer.Audio.Play(My.Resources._420, AudioPlayMode.WaitToComplete)
                    My.Computer.Audio.Play(My.Resources.sound, AudioPlayMode.Background)
                    Exit Sub
                End If

                'on renomme realmlist.wtf
                If System.IO.File.Exists(file_path & "\Data\" & language & "\realmlist.wtf") Then
                    My.Computer.FileSystem.RenameFile(file_path & "\Data\" & language & "\realmlist.wtf", "realmlist.bk")
                    pgrbStatus.Value = 46
                ElseIf System.IO.File.Exists(file_path & "\Data\" & language & "\realmlist.WTF") Then
                    My.Computer.FileSystem.RenameFile(file_path & "\Data\" & language & "\realmlist.WTF", "realmlist.bk")
                    pgrbStatus.Value = 46 'on affiche le pourcentage
                Else
                    lblInfo.Text = UpdateStatus("Erreur lors de la tentative.", "Il semblerais qu'il manque un ou plusieurs fichiers.", "Veuillez recommencer.", "Opération annulée.")
                    lblInfo.ForeColor = Color.Red
                    My.Computer.Audio.Play(My.Resources._420, AudioPlayMode.WaitToComplete)
                    My.Computer.Audio.Play(My.Resources.sound, AudioPlayMode.Background)
                    Exit Sub
                End If
                'On créé le nouveaux fichier realmlist
                Try
                    Dim FSys = CreateObject("Scripting.FileSystemObject")
                    Dim realmlist = FSys.CreateTextFile(file_path & "\Data\" & language & "\realmlist.wtf")
                    With realmlist
                        .writeLine("set realmlist " & My.Settings.RealmSelected)
                    End With
                Catch ex As Exception
                    lblInfo.Text = UpdateStatus("Erreur lors de la tentative.", "Le patch n'a pas fonctionné comme il devrait.", "Veuillez recommencer.", "Opération annulée.")
                    lblInfo.ForeColor = Color.Red
                    My.Computer.Audio.Play(My.Resources._420, AudioPlayMode.WaitToComplete)
                    My.Computer.Audio.Play(My.Resources.sound, AudioPlayMode.Background)
                    Exit Sub
                End Try

                'on renomme wow.exe
                If System.IO.File.Exists(file_path & "\Wow.exe") Then
                    My.Computer.FileSystem.RenameFile(file_path & "\Wow.exe", "Wow.bk")
                    pgrbStatus.Value = 54 'on affiche le pourcentage
                ElseIf System.IO.File.Exists(file_path & "\wow.exe") Then
                    My.Computer.FileSystem.RenameFile(file_path & "\wow.exe", "Wow.bk")
                    pgrbStatus.Value = 54 'on affiche le pourcentage
                End If

                'on renomme luncher.exe
                If System.IO.File.Exists(file_path & "\Launcher.exe") Then
                    My.Computer.FileSystem.RenameFile(file_path & "\Launcher.exe", "Launcher.bk")
                    pgrbStatus.Value = 62 'on affiche le pourcentage
                ElseIf System.IO.File.Exists(file_path & "\launcher.exe") Then
                    My.Computer.FileSystem.RenameFile(file_path & "\launcher.exe", "Launcher.bk")
                    pgrbStatus.Value = 62 'on affiche le pourcentage
                End If

                'on copie le nouveau fichier Wow_The_Mindwreck.exe
                If System.IO.File.Exists(file_path & "\Data\down\Wow_The_Mindwreck.exe") Then
                    System.IO.File.Copy(file_path & "\Data\down\Wow_The_Mindwreck.exe", file_path & "\Wow_The_Mindwreck.exe")
                    pgrbStatus.Value = 78 'on affiche le pourcentage
                Else
                    lblInfo.Text = UpdateStatus("Erreur lors de la tentative.", "Le patch n'a pas fonctionné comme il devrait.", "Veuillez recommencer.", "Opération annulée.")
                    lblInfo.ForeColor = Color.Red
                    My.Computer.Audio.Play(My.Resources._420, AudioPlayMode.WaitToComplete)
                    My.Computer.Audio.Play(My.Resources.sound, AudioPlayMode.Background)
                    Exit Sub
                End If

                lblInfo.Text = UpdateStatus("Début de la modiffication des fichiers", "Veuillez patienter un moment S.V.P.", "Terminer")
                pgrbStatus.Value = 80
                Call Delay(1)
                lblInfo.Text = UpdateStatus("Supression des fichiers temporraires", "Création du racourcie sur le bureau", "Un moment S.V.P.")

                'On crée le raccourcie pour le wow.exe patcher
                Try
                    CreateShortCut(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), _
                                               "Wow The Mindwreck Launcher.lnk"), "Wow The Mindwreck Launcher")
                Catch ex As Exception
                    MsgBox("Erreur : " & ex.Message & "Le raccourcies n'a pas pu être créé sur le bureau.", MsgBoxStyle.Information)
                End Try

                'Suppression du dossier contenant les fichier de jeu patcher.
                Try
                    If System.IO.Directory.Exists(file_path & "\Data\down") Then
                        System.IO.Directory.Delete(file_path & "\Data\down", True)
                    End If
                    If System.IO.File.Exists(file_path & "\Data\down.zip") Then
                        System.IO.File.Delete(file_path & "\Data\down.zip")
                    End If
                Catch ex As Exception
                    MsgBox("Erreur : " & ex.Message)
                End Try

                lblInfo.Text = UpdateStatus("Supression des fichiers temporraires", "Création du racourcie sur le bureau", "Un moment S.V.P.", "Terminer!")
                Call Delay(0.3)
                pgrbStatus.Value = 90
                lblInfo.Text = UpdateStatus("Opération terminer.", "Opération réussie avec succès.")
                pgrbStatus.Value = 100

                'Début du jeux et fermeture du luncher.
                Try
                    Process.Start(file_path & "\Wow_The_Mindwreck.exe")
                Catch ex As Exception
                    MsgBox("Erreur : " & ex.Message)
                End Try
                Me.Close() 'fermeture du patch

            End If
        End If

    End Sub

    Private Sub btnUnpatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnpatch.Click

        'IMPOSSIBLE DE DÉTECTER LA LANGUE ERREUR
        If language = "notfound" Then
            lblInfo.Text = UpdateStatus("Erreur durant l'opération", "Langue impossible à détecter.", "Veuillez recommencer.", "Opération annulée.")
            lblInfo.ForeColor = Color.Red
            My.Computer.Audio.Play(My.Resources._420, AudioPlayMode.WaitToComplete)
            My.Computer.Audio.Play(My.Resources.sound, AudioPlayMode.Background)
            Exit Sub
        Else

            'On initialise le patcher 
            lblInfo.ForeColor = Color.DarkGray
            lblInfo.Text = UpdateStatus("Initialisation du Unpatcher.", "Veuillez patienter un moment S.V.P.", "Initialisation terminer.")
            Call Delay(0.3)
            lblInfo.Text = UpdateStatus("Début de la suppression des fichiers de jeu patcher.", "Veuillez patienter un moment S.V.P.")

            'suppression du fichier alternate.mpq
            If System.IO.File.Exists(file_path & "\Data\alternate.MPQ") Then
                System.IO.File.Delete(file_path & "\Data\alternate.MPQ")
                pgrbStatus.Value = 38
            ElseIf System.IO.File.Exists(file_path & "\Data\alternate.mpq") Then
                System.IO.File.Delete(file_path & "\Data\alternate.mpq")
                pgrbStatus.Value = 38
            End If

            'suppression du fichier \Data\wow-update-13623.MPQ
            If System.IO.File.Exists(file_path & "\Data\wow-update-13623.MPQ") Then
                System.IO.File.Delete(file_path & "\Data\wow-update-13623.MPQ")
                pgrbStatus.Value = 38
            End If

            'suppression du fichier \Data\wow-update-13624.MPQ
            If System.IO.File.Exists(file_path & "\Data\wow-update-13624.MPQ") Then
                System.IO.File.Delete(file_path & "\Data\wow-update-13624.MPQ")
                pgrbStatus.Value = 38
            End If


            'Supprimation du realmlist
            If System.IO.File.Exists(file_path & "\Data\" & language & "\realmlist.wtf") Then
                System.IO.File.Delete(file_path & "\Data\" & language & "\realmlist.wtf")
                My.Computer.FileSystem.RenameFile(file_path & "\Data\" & language & "\realmlist.bk", "realmlist.wtf")
                pgrbStatus.Value = 46
            Else
                lblInfo.Text = UpdateStatus("Erreur lors de la tentative.", "Il semblerais qu'il manque un ou plusieurs fichiers.", "Veuillez recommencer.", "Opération annulée.")
                lblInfo.ForeColor = Color.Red
                My.Computer.Audio.Play(My.Resources._420, AudioPlayMode.WaitToComplete)
                My.Computer.Audio.Play(My.Resources.sound, AudioPlayMode.Background)
                Exit Sub
            End If

            'On supprime Wow_The_Mindwreck.exe et on ajoute wow.exe 
            If System.IO.File.Exists(file_path & "\Wow_The_Mindwreck.exe") Then
                System.IO.File.Delete(file_path & "\Wow_The_Mindwreck.exe")
                If System.IO.File.Exists(file_path & "\Wow.bk") Then
                    My.Computer.FileSystem.RenameFile(file_path & "\Wow.bk", "Wow.exe")
                End If
                pgrbStatus.Value = 54
            End If

            'On renomme Launcher.bk
            If System.IO.File.Exists(file_path & "\Launcher.bk") Then
                My.Computer.FileSystem.RenameFile(file_path & "\Launcher.bk", "Launcher.exe")
            End If
            pgrbStatus.Value = 54

            'on supprimé le raccourcies créé sur le bureau
            Try
                System.IO.File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\Wow The Mindwreck Launcher.lnk")
            Catch ex As Exception
                MsgBox("Impossible de supprimer raccourcie du bureau il semble être inexistant.", MsgBoxStyle.Information)
            End Try

            lblInfo.Text = UpdateStatus("Début de la suppression des fichiers de jeu patcher.", "Veuillez patienter un moment S.V.P.", "Suppression des fichiers terminer.")
            Call Delay(0.3)
            lblInfo.Text = UpdateStatus("Opération terminer.", "Opération réussie avec succès.")
            pgrbStatus.Value = 100

            'On active le bouton patch et on désactive les autre.
            btnUnpatch.Enabled = False
            btnUnpatch.BackgroundImage = My.Resources.btnRem_Unpatch
            UnpatchToolStripMenuItem.Enabled = False
        End If
    End Sub

    '===================================== Application des événement pour le bouton Play ===================================================================='

    Private Sub btnPatch_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnPatch.MouseDown
        Me.btnPatch.BackgroundImage = My.Resources.btnPlay_MDown
    End Sub

    Private Sub btnPatch_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPatch.MouseEnter
        Me.btnPatch.BackgroundImage = My.Resources.btnPlay_MOver
    End Sub

    Private Sub btnPatch_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPatch.MouseLeave
        Me.btnPatch.BackgroundImage = My.Resources.btnPlay_patcher
    End Sub

    Private Sub btnPatch_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnPatch.MouseUp
        Me.btnPatch.BackgroundImage = My.Resources.btnPlay_patcher
    End Sub
    '===================================== Application des événement pour le bouton Remove patch ============================================================='
    Private Sub btnUnpatch_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnUnpatch.MouseDown
        Me.btnUnpatch.BackgroundImage = My.Resources.btnRem_MDown
    End Sub

    Private Sub btnUnpatch_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUnpatch.MouseEnter
        Me.btnUnpatch.BackgroundImage = My.Resources.btnRem_MOver
    End Sub

    Private Sub btnUnpatch_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUnpatch.MouseLeave
        Me.btnUnpatch.BackgroundImage = My.Resources.btnRem_patcher
    End Sub

    Private Sub btnUnpatch_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnUnpatch.MouseUp
        Me.btnUnpatch.BackgroundImage = My.Resources.btnRem_patcher
    End Sub
    '=========================================== Section menu et notification menu ======================================================='
    Private Sub JouerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JouerToolStripMenuItem.Click
        Process.Start(file_path & "\Wow_The_Mindwreck.exe")
        Me.Close()
    End Sub

    Private Sub FermerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FermerToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ÀProposToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ÀProposToolStripMenuItem.Click
        System.Diagnostics.Process.Start("http://mindwreck.no-ip.org")
    End Sub

    Private Sub PatchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PatchToolStripMenuItem.Click
        'On appelle le sub btnPatch_click
        btnPatch_Click(sender, New System.EventArgs())
    End Sub

    Private Sub UnpatchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnpatchToolStripMenuItem.Click
        'On appelle le sub btnPatch_click
        btnUnpatch_Click(sender, New System.EventArgs())
    End Sub

    Private Sub QuitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub InfoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles InfoToolStripMenuItem.Click
        frmAbout.Show()
    End Sub

    Private Sub AideToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AideToolStripMenuItem1.Click
        frmHelp.Show()
    End Sub

    Private Sub RealmListToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RealmListToolStripMenuItem.Click
        frmRealmlist.Show()
    End Sub

#Region "Updater"

    ''::::::::::::::::::::::::::::::::::::::::::::::::: UPDATE :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::'
    ''Cette fonction est temporairement désactivé vous devez la configuré pour envoyer vos propre mise à jour
    ''de l'application une section dans le form_load est aussi à configuré.
    ''
    ''Pour configurer le système de mise à jour.
    ''
    ''1) 
    '' ->Vous devez avoir un serveur web configuré ou vous pouvez utilisé dropbox Gratuit
    '' ->Un dossier sur votre serveur web 
    ''   ex: Update contenant un fichier version.txt et une archive sfx Release.exe
    ''   dans ce fichier version.text vous aller inscrire la version de l'application qui est sur le serveur
    ''      
    ''   Dans l'archive sfx créé avec winrar déposer .exe de l'application ainsi que les fichier que vous
    ''   vous voulez déploiyer durant la mise à jour ex: Release.exe <-- (Archive sfx créé avec winrar)
    ''
    '' ->Vous devez modifier la ligne suivante dans le sub checkforupdate() :
    ''   
    ''   downloadupdate("http://localhost/Update/Release.exe", True)
    ''
    ''   Remplacer le lien pour le faire pointer sur votre archive sfx sur votre serveur
    ''   dans notre exemple http://server-adresse/Update/Release.exe
    ''
    ''2)
    '' ->Dans frmMain_Load() modifier la ligne suivante :
    ''   checkforupdate("http://localhost/update/version.txt", "2.0.4")
    ''
    ''   Remplacer le lien pour le faire pointer sur votre fichier version.txt
    ''   ex: http://server-adresse/Update/version.txt
    ''   et mettre le num/ro de version de la build que vous creer actuellement
    ''
    ''   la version dans le fichier version.txt et la version dans le release.exe et a la ligne
    ''   checkforupdate() doivent etre la meme pour que lapplication ne demande pas de mise a jour
    ''
    ''3) decommenter toute la section update ci bas et la petite section dans le form load
    ''::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

    'Sub checkforupdate(ByVal updatetextfileurl As String, ByVal currentversion As String)
    '    'on supprime l'ancienne version du fichier version
    '    If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath + "/version.dat") Then
    '        My.Computer.FileSystem.DeleteFile(My.Application.Info.DirectoryPath + "/version.dat")
    '    End If

    '    'on supprime l'ancienne version du fichier update
    '    If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath + "/update.exe") Then
    '        My.Computer.FileSystem.DeleteFile(My.Application.Info.DirectoryPath + "/update.exe")
    '    End If

    '    Try
    '        My.Computer.Network.DownloadFile(updatetextfileurl, My.Application.Info.DirectoryPath + "/version.dat")
    '        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath + "/version.dat") Then
    '            Dim reader As New System.IO.StreamReader(My.Application.Info.DirectoryPath + "/version.dat")
    '            Dim read As String = reader.ReadToEnd
    '            reader.Close()
    '            If read <> currentversion Then
    '                MsgBox("Attention !" & vbCrLf & "Une nouvelle version est disponible pour The Mindwreck Patcher." & vbCrLf & _
    '                       "Vous avez actuellement la version " & currentversion & "." & vbCrLf & _
    '                       "La version la plus récente de The Mindwreck Patcher est " & read & "." & vbCrLf & vbCrLf & _
    '                        "La programme de mise à jour sera automatiquement lancé à la fermeture de cette fenêtre." & vbCrLf & vbCrLf & _
    '                        "Appuyez sur OK pour continué.", _
    '                        MsgBoxStyle.Information, "The Mindwreck Patcher - Mise à jour disponible")

    '                Try
    '                    'on supprime les fichier de version 
    '                    If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath + "/version.dat") Then
    '                        My.Computer.FileSystem.DeleteFile(My.Application.Info.DirectoryPath + "/version.dat")
    '                    End If
    '                    'on supprime les fichiers update
    '                    If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath + "/update.exe") Then
    '                        My.Computer.FileSystem.DeleteFile(My.Application.Info.DirectoryPath + "/update.exe")
    '                    End If
    '                    'on appel le sup downloadupdate
    '                    downloadupdate("http://server-adresse/release.exe", True)

    '                Catch ex As Exception
    '                    MsgBox("Erreur : " + ex.Message)
    '                End Try

    '            Else
    '                'on fais rien le programme est à jour.
    '            End If
    '        Else
    '            MsgBox("Une erreur c'est produite lors de la vérification de la version du programme.", MsgBoxStyle.Critical)
    '        End If
    '    Catch ex As Exception
    '        MsgBox("Erreur avec le programme de mise à jour, " + ex.Message, MsgBoxStyle.Critical)
    '    End Try
    'End Sub

    'Sub downloadupdate(ByVal updaterexecuteableurl As String, ByVal showUI As Boolean)
    '    Try
    '        My.Computer.Network.DownloadFile(updaterexecuteableurl, My.Application.Info.DirectoryPath + "/update.exe", "", "", showUI, 99999999, True)
    '        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath + "/update.exe") Then

    '            url = updaterexecuteableurl
    '            bool_showUI = showUI
    '            Timer1.Interval = 10
    '            Progress.Maximum = 1000
    '            Timer1.Enabled = True
    '            Timer1.Start()
    '            AddHandler Timer1.Tick, AddressOf Timer1_tick
    '        Else
    '            downloadupdate(updaterexecuteableurl, showUI)
    '        End If

    '    Catch ex As Exception
    '        MsgBox("Erreur lors du téléchargement de la mise à jour, " + ex.Message)
    '    End Try
    'End Sub

    'Sub Timer1_tick(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Try
    '        Do Until Progress.Value = 1000
    '            Progress.Value = Progress.Value + 1
    '        Loop
    '        If Progress.Value = 1000 Then
    '            If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath + "/update.exe") Then
    '                Shell(My.Application.Info.DirectoryPath + "/update.exe", AppWinStyle.NormalFocus)
    '                Me.Close()
    '                Timer1.Stop()
    '                Timer1.Enabled = False
    '                Exit Sub
    '            Else
    '                downloadupdate(url, bool_showUI)
    '            End If
    '        End If
    '    Catch ex As Exception
    '        If ex.Message.Contains("not") Then
    '            Shell(My.Application.Info.DirectoryPath + "/update.exe", AppWinStyle.NormalFocus)
    '            Me.Close()
    '            Timer1.Stop()
    '            Timer1.Enabled = False
    '        End If
    '    End Try
    'End Sub
    ''::::::::::::::::::::::::::::::::::::::::::::::::::::::::: /UPDATE ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::'
#End Region





End Class
