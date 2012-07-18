Option Strict Off
Imports System
Imports System.IO
Imports System.Data
Imports Microsoft.Win32
Imports System.Diagnostics

Public Class frmMain

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        'vérification de l'emplacement du patcher
        If Not System.IO.File.Exists(file_path & "\Battle.net.dll") Then
            MsgBox("Vous devez lancer cette application à partir de la racine du dossier de jeux world of warcraft. Déplacer cette application au bon endroit et relancer là.", _
                   MsgBoxStyle.Critical, "Erreur de lancement")
            Me.Close()

        ElseIf Not System.IO.Directory.Exists(file_path & "\Data") Then

            MsgBox("Vous devez lancer cette application à partir de la racine du dossier de jeux world of warcraft. Déplacer cette application au bon endroit et relancer là.", _
                   MsgBoxStyle.Critical, "Erreur de lancement")
            Me.Close()
        Else

            'si une connextion internet est disponible
            If connexionInternet() = True Then
                'on vérifie si une mise à jour est disponible
                checkforupdate("http://dl.dropbox.com/u/68710014/version.txt", "2.0.3")
            Else
                'on informe qu'aucune connexion est disponible et quil est impossible de vériffier la mise à jour
                MsgBox("Vous n'êtes pas connectés à internet!" & vbCrLf _
                       & "Il est donc impossible de vérifier si une mise à jour de l'application est disponible.", _
                       MsgBoxStyle.Information, "Connexion internet indisponible")
            End If

            '[UPDATESTATUS] initialisation du patch
            lblInfo.Text = UpdateStatus("Initialisation du patcher.", "Veuillez patienter un moment S.V.P.", "Initialisation terminer.")

            '-----------------------------------------------------------------------------'
            'initialisation des élément de l'interface (bouton play)
            Me.btnPatch.BackgroundImage = My.Resources.btnPlay_patcher
            Me.btnPatch.BackgroundImageLayout = ImageLayout.Stretch
            Me.btnPatch.FlatStyle = FlatStyle.Flat

            Me.btnUnpatch.BackgroundImage = My.Resources.btnRem_patcher
            Me.btnUnpatch.BackgroundImageLayout = ImageLayout.Stretch
            Me.btnUnpatch.FlatStyle = FlatStyle.Flat
            '------------------------------------------------------------------------------'


            'on commence la trame sonore de fond
            My.Computer.Audio.Play(My.Resources.sound, AudioPlayMode.BackgroundLoop)



            'Détection de la langue du jeux
            If System.IO.Directory.Exists(file_path & "\Data\frFR") Then
                lblLangueDetect.ForeColor = Color.DarkGreen
                lblLangueDetect.Text = "Français Europe"
            ElseIf System.IO.Directory.Exists(file_path & "\Data\enUS") Then
                lblLangueDetect.ForeColor = Color.DarkGreen
                lblLangueDetect.Text = "Anglais États-Unies"
            ElseIf System.IO.Directory.Exists(file_path & "\Data\enGB") Then
                lblLangueDetect.ForeColor = Color.DarkGreen
                lblLangueDetect.Text = "Anglais Grande Bretagne"
            Else
                lblLangueDetect.ForeColor = Color.DarkRed
                lblLangueDetect.Text = "Détection Impossible"
            End If



            'on vérifie si le jeux n'est pas déjà patcher et on active et désactive les élément selon le cas
            If System.IO.File.Exists(file_path & "\wow.bk") Or System.IO.File.Exists(file_path & "\Wow.bk") Then
                btnUnpatch.Enabled = True
                UnpatchToolStripMenuItem.Enabled = True
            Else
                btnUnpatch.Enabled = False
                btnUnpatch.BackgroundImage = My.Resources.btnRem_Unpatch
                UnpatchToolStripMenuItem.Enabled = False
            End If


            'initialisation du %
            lblPourcent.Text = "0 %"
        End If
    End Sub



    Private Sub btnPatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPatch.Click

        'on vérifie si le jeux n'est pas déjà patcher.
        If System.IO.File.Exists(file_path & "\wow.bk") Or System.IO.File.Exists(file_path & "\Wow.bk") Then
            'si le jeux est patcher on START le jeux
            'son de demmarage du jeux
            My.Computer.Audio.Play(My.Resources._291, AudioPlayMode.WaitToComplete)
            Process.Start(file_path & "\Wow_The_Mindwreck.exe")
            Me.Close()

        Else


            'On donne la couleur souhaiter au label 
            lblInfo.ForeColor = Color.Chocolate
            '[UPDATESTATUS] début de la copie des fichier
            lblInfo.Text = UpdateStatus("Début de la copie des fichiers sur le disque.", "Veuillez patienter un moment S.V.P.")
            Call Delay(0.3)


            'On enregistre l'archive down.zip sur le disque dur
            Try
                SaveToDisk("down.zip", file_path & "\Data\Down.zip")
            Catch ex As Exception
                MsgBox("Une erreur c'est produite lors de l'enregistrement des nouveaux fichiers sur le disque dur. " _
                       + ex.Message, MsgBoxStyle.Critical)
            End Try


            '[UPDATESTATUS] fin de la copie des fichier
            lblInfo.Text = UpdateStatus("Début de la copie des fichiers sur le disque.", "Veuillez patienter un moment S.V.P.", "Terminer.")
            lblPourcent.Text = "10 %"
            Call Delay(0.3)
            '[UPDATESTATUS] début de l'extraction des fichiers
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


            '[UPDATESTATUS] fin de l'extraction des fichiers
            lblInfo.Text = UpdateStatus("Début de l'extraction des fichiers copiés.", "Veuillez patienter un moment S.V.P.", "Terminer.")
            lblPourcent.Text = "20 %"
            Call Delay(0.3)
            '[UPDATESTATUS] début de la suppression des fichier de jeux
            lblInfo.Text = UpdateStatus("Début de la modiffication des fichiers", "Veuillez patienter un moment S.V.P.")


            'suppression du fichier alternate.mpq
            If System.IO.File.Exists(file_path & "\Data\alternate.MPQ") Then
                System.IO.File.Delete(file_path & "\Data\alternate.MPQ")
                lblPourcent.Text = "32 %" 'on affiche le pourcentage
            ElseIf System.IO.File.Exists(file_path & "\Data\alternate.mpq") Then
                System.IO.File.Delete(file_path & "\Data\alternate.mpq")
                lblPourcent.Text = "32 %" 'on affiche le pourcentage
            End If


            'Détection de la langue du jeux, ajout des fichier : wow-update-13623.MPQ, wow-update-13624.MPQ et changement de realmlist
            'LANGUE frFR
            If System.IO.Directory.Exists(file_path & "\Data\frFR") Then
                'on copie le nouveau fichier wow-update-13623.MPQ
                If System.IO.File.Exists(file_path & "\Data\down\frFR\wow-update-13623.MPQ") Then
                    System.IO.File.Copy(file_path & "\Data\down\frFR\wow-update-13623.MPQ", file_path & "\Data\wow-update-13623.MPQ")
                    lblPourcent.Text = "38 %" 'on affiche le pourcentage
                Else
                    lblInfo.Text = UpdateStatus("Erreur lors de la tentative.", "Le patch n'a pas fonctionné comme il devrait.", "Veuillez recommencer.", "Opération annulée.")
                    lblInfo.ForeColor = Color.Red
                    My.Computer.Audio.Play(My.Resources._420, AudioPlayMode.WaitToComplete)
                    My.Computer.Audio.Play(My.Resources.sound, AudioPlayMode.Background)
                    Exit Sub
                End If
                'on copie le nouveau fichier wow-update-13624.MPQ
                If System.IO.File.Exists(file_path & "\Data\down\frFR\wow-update-13624.MPQ") Then
                    System.IO.File.Copy(file_path & "\Data\down\frFR\wow-update-13624.MPQ", file_path & "\Data\wow-update-13624.MPQ")
                    lblPourcent.Text = "45 %" 'on affiche le pourcentage
                Else
                    lblInfo.Text = UpdateStatus("Erreur lors de la tentative.", "Le patch n'a pas fonctionné comme il devrait.", "Veuillez recommencer.", "Opération annulée.")
                    lblInfo.ForeColor = Color.Red
                    My.Computer.Audio.Play(My.Resources._420, AudioPlayMode.WaitToComplete)
                    My.Computer.Audio.Play(My.Resources.sound, AudioPlayMode.Background)
                    Exit Sub
                End If
                'on renomme realmlist.wtf
                If System.IO.File.Exists(file_path & "\Data\frFR\realmlist.wtf") Then
                    My.Computer.FileSystem.RenameFile(file_path & "\Data\frFR\realmlist.wtf", "realmlist.bk")
                    lblPourcent.Text = "46 %"
                ElseIf System.IO.File.Exists(file_path & "\Data\frFR\realmlist.WTF") Then
                    My.Computer.FileSystem.RenameFile(file_path & "\Data\frFR\realmlist.WTF", "realmlist.bk")
                    lblPourcent.Text = "46 %" 'on affiche le pourcentage
                Else
                    lblInfo.Text = UpdateStatus("Erreur lors de la tentative.", "Il semblerais qu'il manque un ou plusieurs fichiers.", "Veuillez recommencer.", "Opération annulée.")
                    lblInfo.ForeColor = Color.Red
                    My.Computer.Audio.Play(My.Resources._420, AudioPlayMode.WaitToComplete)
                    My.Computer.Audio.Play(My.Resources.sound, AudioPlayMode.Background)
                    Exit Sub
                End If
                'On copie le nouveaux fichier Realmlist frFR
                If System.IO.File.Exists(file_path & "\Data\down\realmlist.wtf") Then
                    System.IO.File.Copy(file_path & "\Data\down\realmlist.wtf", file_path & "\Data\frFR\realmlist.wtf")
                Else
                    lblInfo.Text = UpdateStatus("Erreur lors de la tentative.", "Le patch n'a pas fonctionné comme il devrait.", "Veuillez recommencer.", "Opération annulée.")
                    lblInfo.ForeColor = Color.Red
                    My.Computer.Audio.Play(My.Resources._420, AudioPlayMode.WaitToComplete)
                    My.Computer.Audio.Play(My.Resources.sound, AudioPlayMode.Background)
                    Exit Sub
                End If
                'LANGUE enUS
            ElseIf System.IO.Directory.Exists(file_path & "\Data\enUS") Then
                'on copie le nouveau fichier wow-update-13623.MPQ
                If System.IO.File.Exists(file_path & "\Data\down\enUS\wow-update-13623.MPQ") Then
                    System.IO.File.Copy(file_path & "\Data\down\enUS\wow-update-13623.MPQ", file_path & "\Data\wow-update-13623.MPQ")
                    lblPourcent.Text = "38 %" 'on affiche le pourcentage
                Else
                    lblInfo.Text = UpdateStatus("Erreur lors de la tentative.", "Le patch n'a pas fonctionné comme il devrait.", "Veuillez recommencer.", "Opération annulée.")
                    lblInfo.ForeColor = Color.Red
                    My.Computer.Audio.Play(My.Resources._420, AudioPlayMode.WaitToComplete)
                    My.Computer.Audio.Play(My.Resources.sound, AudioPlayMode.Background)
                    Exit Sub
                End If
                'on copie le nouveau fichier wow-update-13624.MPQ
                If System.IO.File.Exists(file_path & "\Data\down\enUS\wow-update-13624.MPQ") Then
                    System.IO.File.Copy(file_path & "\Data\down\enUS\wow-update-13624.MPQ", file_path & "\Data\wow-update-13624.MPQ")
                    lblPourcent.Text = "45 %" 'on affiche le pourcentage
                Else
                    lblInfo.Text = UpdateStatus("Erreur lors de la tentative.", "Le patch n'a pas fonctionné comme il devrait.", "Veuillez recommencer.", "Opération annulée.")
                    lblInfo.ForeColor = Color.Red
                    My.Computer.Audio.Play(My.Resources._420, AudioPlayMode.WaitToComplete)
                    My.Computer.Audio.Play(My.Resources.sound, AudioPlayMode.Background)
                    Exit Sub
                End If
                'On renomme realmlist.wtf
                If System.IO.File.Exists(file_path & "\Data\enUS\realmlist.wtf") Then
                    My.Computer.FileSystem.RenameFile(file_path & "\Data\enUS\realmlist.wtf", "realmlist.bk")
                    lblPourcent.Text = "46 %"
                ElseIf System.IO.File.Exists(file_path & "\Data\enUS\realmlist.WTF") Then
                    My.Computer.FileSystem.RenameFile(file_path & "\Data\enUS\realmlist.WTF", "realmlist.bk")
                    lblPourcent.Text = "46 %"
                Else
                    lblInfo.Text = UpdateStatus("Erreur lors de la tentative.", "Il semblerais qu'il manque un ou plusieurs fichiers.", "Veuillez recommencer.", "Opération annulée.")
                    lblInfo.ForeColor = Color.Red
                    My.Computer.Audio.Play(My.Resources._420, AudioPlayMode.WaitToComplete)
                    My.Computer.Audio.Play(My.Resources.sound, AudioPlayMode.Background)
                    Exit Sub
                End If
                'On copie le nouveau fichier realmlist.wtf
                If System.IO.File.Exists(file_path & "\Data\down\realmlist.wtf") Then
                    System.IO.File.Copy(file_path & "\Data\down\realmlist.wtf", file_path & "\Data\enUS\realmlist.wtf")
                    lblPourcent.Text = "46 %"
                Else
                    lblInfo.Text = UpdateStatus("Erreur lors de la tentative.", "Le patch n'a pas fonctionné comme il devrait.", "Veuillez recommencer.", "Opération annulée.")
                    lblInfo.ForeColor = Color.Red
                    My.Computer.Audio.Play(My.Resources._420, AudioPlayMode.WaitToComplete)
                    My.Computer.Audio.Play(My.Resources.sound, AudioPlayMode.Background)
                    Exit Sub
                End If
                'LANGUE enGB
            ElseIf System.IO.Directory.Exists(file_path & "\Data\enGB") Then
                'on copie le nouveau fichier wow-update-13623.MPQ
                If System.IO.File.Exists(file_path & "\Data\down\enGB\wow-update-13623.MPQ") Then
                    System.IO.File.Copy(file_path & "\Data\down\enGB\wow-update-13623.MPQ", file_path & "\Data\wow-update-13623.MPQ")
                    lblPourcent.Text = "38 %" 'on affiche le pourcentage
                Else
                    lblInfo.Text = UpdateStatus("Erreur lors de la tentative.", "Le patch n'a pas fonctionné comme il devrait.", "Veuillez recommencer.", "Opération annulée.")
                    lblInfo.ForeColor = Color.Red
                    My.Computer.Audio.Play(My.Resources._420, AudioPlayMode.WaitToComplete)
                    My.Computer.Audio.Play(My.Resources.sound, AudioPlayMode.Background)
                    Exit Sub
                End If
                'on copie le nouveau fichier wow-update-13624.MPQ
                If System.IO.File.Exists(file_path & "\Data\down\enGB\wow-update-13624.MPQ") Then
                    System.IO.File.Copy(file_path & "\Data\down\enGB\wow-update-13624.MPQ", file_path & "\Data\wow-update-13624.MPQ")
                    lblPourcent.Text = "45 %" 'on affiche le pourcentage
                Else
                    lblInfo.Text = UpdateStatus("Erreur lors de la tentative.", "Le patch n'a pas fonctionné comme il devrait.", "Veuillez recommencer.", "Opération annulée.")
                    lblInfo.ForeColor = Color.Red
                    My.Computer.Audio.Play(My.Resources._420, AudioPlayMode.WaitToComplete)
                    My.Computer.Audio.Play(My.Resources.sound, AudioPlayMode.Background)
                    Exit Sub
                End If
                'on renomme realmlist.wtf
                If System.IO.File.Exists(file_path & "\Data\enGB\realmlist.wtf") Then
                    My.Computer.FileSystem.RenameFile(file_path & "\Data\enGB\realmlist.wtf", "realmlist.bk")
                    lblPourcent.Text = "46 %"
                ElseIf System.IO.File.Exists(file_path & "\Data\enGB\realmlist.WTF") Then
                    My.Computer.FileSystem.RenameFile(file_path & "\Data\enGB\realmlist.WTF", "realmlist.bk")
                    lblPourcent.Text = "46 %"
                Else
                    lblInfo.Text = UpdateStatus("Erreur lors de la tentative.", "Il semblerais qu'il manque un ou plusieurs fichiers.", "Veuillez recommencer.", "Opération annulée.")
                    lblInfo.ForeColor = Color.Red
                    My.Computer.Audio.Play(My.Resources._420, AudioPlayMode.WaitToComplete)
                    My.Computer.Audio.Play(My.Resources.sound, AudioPlayMode.Background)
                    Exit Sub
                End If
                'on copie le nouveau fichier realmlist.wtf
                If System.IO.File.Exists(file_path & "\Data\down\realmlist.wtf") Then
                    System.IO.File.Copy(file_path & "\Data\down\realmlist.wtf", file_path & "\Data\enGB\realmlist.wtf")
                    lblPourcent.Text = "46 %"
                Else
                    lblInfo.Text = UpdateStatus("Erreur lors de la tentative.", "Le patch n'a pas fonctionné comme il devrait.", "Veuillez recommencer.", "Opération annulée.")
                    lblInfo.ForeColor = Color.Red
                    My.Computer.Audio.Play(My.Resources._420, AudioPlayMode.WaitToComplete)
                    My.Computer.Audio.Play(My.Resources.sound, AudioPlayMode.Background)
                    Exit Sub
                End If
                'IMPOSSIBLE DE DÉTECTER LA LANGUE ERREUR
            Else
                lblInfo.Text = UpdateStatus("Erreur durant l'opération", "Langue impossible à détecter.", "Veuillez recommencer.", "Opération annulée.")
                lblInfo.ForeColor = Color.Red
                My.Computer.Audio.Play(My.Resources._420, AudioPlayMode.WaitToComplete)
                My.Computer.Audio.Play(My.Resources.sound, AudioPlayMode.Background)
                Exit Sub
            End If

            'on renomme wow.exe
            If System.IO.File.Exists(file_path & "\Wow.exe") Then
                My.Computer.FileSystem.RenameFile(file_path & "\Wow.exe", "Wow.bk")
                lblPourcent.Text = "54 %" 'on affiche le pourcentage
            ElseIf System.IO.File.Exists(file_path & "\wow.exe") Then
                My.Computer.FileSystem.RenameFile(file_path & "\wow.exe", "Wow.bk")
                lblPourcent.Text = "54 %" 'on affiche le pourcentage
            End If

            'on renomme luncher.exe
            If System.IO.File.Exists(file_path & "\Launcher.exe") Then
                My.Computer.FileSystem.RenameFile(file_path & "\Launcher.exe", "Launcher.bk")
                lblPourcent.Text = "62 %" 'on affiche le pourcentage
            ElseIf System.IO.File.Exists(file_path & "\launcher.exe") Then
                My.Computer.FileSystem.RenameFile(file_path & "\launcher.exe", "Launcher.bk")
                lblPourcent.Text = "62 %" 'on affiche le pourcentage
            End If

            'on copie le nouveau fichier Wow_The_Mindwreck.exe
            If System.IO.File.Exists(file_path & "\Data\down\Wow_The_Mindwreck.exe") Then
                System.IO.File.Copy(file_path & "\Data\down\Wow_The_Mindwreck.exe", file_path & "\Wow_The_Mindwreck.exe")
                lblPourcent.Text = "78 %" 'on affiche le pourcentage
            Else
                lblInfo.Text = UpdateStatus("Erreur lors de la tentative.", "Le patch n'a pas fonctionné comme il devrait.", "Veuillez recommencer.", "Opération annulée.")
                lblInfo.ForeColor = Color.Red
                My.Computer.Audio.Play(My.Resources._420, AudioPlayMode.WaitToComplete)
                My.Computer.Audio.Play(My.Resources.sound, AudioPlayMode.Background)
                Exit Sub
            End If

            '[UPDATESTATUS] début de la suppression des fichier de jeux
            lblInfo.Text = UpdateStatus("Début de la modiffication des fichiers", "Veuillez patienter un moment S.V.P.", "Terminer")
            lblPourcent.Text = "80 %"
            Call Delay(1)
            '[UPDATESTATUS] création des nouveau fichier de jeux
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


            '[UPDATESTATUS] création des nouveau fichier de jeux
            lblInfo.Text = UpdateStatus("Supression des fichiers temporraires", "Création du racourcie sur le bureau", "Un moment S.V.P.", "Terminer!")
            Call Delay(0.3)
            lblPourcent.Text = "90 %"
            '[UPDATESTATUS] opération a réussie.
            lblInfo.Text = UpdateStatus("Opération terminer.", "Opération réussie avec succès.")
            lblPourcent.Text = "100 %"


            'Début du jeux et fermeture du luncher.
            Try
                'son de demmarage du jeux
                My.Computer.Audio.Play(My.Resources._291, AudioPlayMode.WaitToComplete)
                Process.Start(file_path & "\Wow_The_Mindwreck.exe")
            Catch ex As Exception
                MsgBox("Erreur : " & ex.Message)
            End Try

            Me.Close() 'fermeture du patch

        End If

    End Sub

    Private Sub btnUnpatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnpatch.Click

        'On initialise la ProgressBar à 0 
        lblInfo.ForeColor = Color.Goldenrod


        '[UPDATESTATUS] initialisation du Unpatch
        lblInfo.Text = UpdateStatus("Initialisation du Unpatcher.", "Veuillez patienter un moment S.V.P.", "Initialisation terminer.")
        Call Delay(0.3)
        '[UPDATESTATUS] suppression des fichier de jeux patcher
        lblInfo.Text = UpdateStatus("Début de la suppression des fichiers de jeu patcher.", "Veuillez patienter un moment S.V.P.")


        'suppression du fichier alternate.mpq
        If System.IO.File.Exists(file_path & "\Data\alternate.MPQ") Then
            System.IO.File.Delete(file_path & "\Data\alternate.MPQ")
            lblPourcent.Text = "38 %"
        ElseIf System.IO.File.Exists(file_path & "\Data\alternate.mpq") Then
            System.IO.File.Delete(file_path & "\Data\alternate.mpq")
            lblPourcent.Text = "38 %"
        End If

        'suppression du fichier \Data\wow-update-13623.MPQ
        If System.IO.File.Exists(file_path & "\Data\wow-update-13623.MPQ") Then
            System.IO.File.Delete(file_path & "\Data\wow-update-13623.MPQ")
            lblPourcent.Text = "38 %"
        End If

        'suppression du fichier \Data\wow-update-13624.MPQ
        If System.IO.File.Exists(file_path & "\Data\wow-update-13624.MPQ") Then
            System.IO.File.Delete(file_path & "\Data\wow-update-13624.MPQ")
            lblPourcent.Text = "38 %"
        End If


        'Détection de la langue du jeux et on renomme realmlist.bk et supprime realmlist patcher selon la langue
        'LANGUE frFR
        If System.IO.Directory.Exists(file_path & "\Data\frFR") Then
            'on renomme realmlist.wtf
            If System.IO.File.Exists(file_path & "\Data\frFR\realmlist.wtf") Then
                System.IO.File.Delete(file_path & "\Data\frFR\realmlist.wtf")
                My.Computer.FileSystem.RenameFile(file_path & "\Data\frFR\realmlist.bk", "realmlist.wtf")
                lblPourcent.Text = "46 %"
            Else
                lblInfo.Text = UpdateStatus("Erreur lors de la tentative.", "Il semblerais qu'il manque un ou plusieurs fichiers.", "Veuillez recommencer.", "Opération annulée.")
                lblInfo.ForeColor = Color.Red
                My.Computer.Audio.Play(My.Resources._420, AudioPlayMode.WaitToComplete)
                My.Computer.Audio.Play(My.Resources.sound, AudioPlayMode.Background)
                Exit Sub
            End If
            'LANGUE enUS
        ElseIf System.IO.Directory.Exists(file_path & "\Data\enUS") Then
            'on renomme realmlist.wtf
            If System.IO.File.Exists(file_path & "\Data\enUS\realmlist.wtf") Then
                System.IO.File.Delete(file_path & "\Data\enUS\realmlist.wtf")
                My.Computer.FileSystem.RenameFile(file_path & "\Data\enUS\realmlist.bk", "realmlist.wtf")
                lblPourcent.Text = "46 %"
            Else
                lblInfo.Text = UpdateStatus("Erreur lors de la tentative.", "Il semblerais qu'il manque un ou plusieurs fichiers.", "Veuillez recommencer.", "Opération annulée.")
                lblInfo.ForeColor = Color.Red
                My.Computer.Audio.Play(My.Resources._420, AudioPlayMode.WaitToComplete)
                My.Computer.Audio.Play(My.Resources.sound, AudioPlayMode.Background)
                Exit Sub
            End If
            'LANGUE enGB
        ElseIf System.IO.Directory.Exists(file_path & "\Data\enGB") Then
            'on renomme realmlist.wtf
            If System.IO.File.Exists(file_path & "\Data\enGB\realmlist.wtf") Then
                System.IO.File.Delete(file_path & "\Data\enGB\realmlist.wtf")
                My.Computer.FileSystem.RenameFile(file_path & "\Data\enGB\realmlist.bk", "realmlist.wtf")
                lblPourcent.Text = "46 %"
            Else
                lblInfo.Text = UpdateStatus("Erreur lors de la tentative.", "Il semblerais qu'il manque un ou plusieurs fichiers.", "Veuillez recommencer.", "Opération annulée.")
                lblInfo.ForeColor = Color.Red
                My.Computer.Audio.Play(My.Resources._420, AudioPlayMode.WaitToComplete)
                My.Computer.Audio.Play(My.Resources.sound, AudioPlayMode.Background)
                Exit Sub
            End If
            'LANGUE INDÉTECTABLE
        Else
            lblInfo.Text = UpdateStatus("Erreur durant l'opération", "Langue impossible à détecter.", "Veuillez recommencer.", "Opération annulée.")
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
            lblPourcent.Text = "54 %"
        End If

        'On renomme Launcher.bk
        If System.IO.File.Exists(file_path & "\Launcher.bk") Then
            My.Computer.FileSystem.RenameFile(file_path & "\Launcher.bk", "Launcher.exe")
        End If
        lblPourcent.Text = "54 %"

        'on supprimé le raccourcies créé sur le bureau
        Try
            System.IO.File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\Wow The Mindwreck Launcher.lnk")
        Catch ex As Exception
            MsgBox("Impossible de supprimer raccourcie du bureau il semble être inexistant.", MsgBoxStyle.Information)
        End Try


        '[UPDATESTATUS] suppression des fichier de jeux patcher
        lblInfo.Text = UpdateStatus("Début de la suppression des fichiers de jeu patcher.", "Veuillez patienter un moment S.V.P.", "Suppression des fichiers terminer.")
        Call Delay(0.3)
        '[UPDATESTATUS] opération a réussie.
        lblInfo.Text = UpdateStatus("Opération terminer.", "Opération réussie avec succès.")
        lblPourcent.Text = "100 %"


        'On active le bouton patch et on désactive les autre.
        btnUnpatch.Enabled = False
        btnUnpatch.BackgroundImage = My.Resources.btnRem_Unpatch
        UnpatchToolStripMenuItem.Enabled = False

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

    Private Sub ÀProposToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ÀProposToolStripMenuItem2.Click
        frmAbout.Show()
    End Sub

    Private Sub AideToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AideToolStripMenuItem1.Click
        frmHelp.Show()
    End Sub


    '--------------------------------------------------------------------- UPDATE -------------------------------------------------------------------------'
    Sub checkforupdate(ByVal updatetextfileurl As String, ByVal currentversion As String)
        'on supprime l'ancienne version du fichier version
        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath + "/version.dat") Then
            My.Computer.FileSystem.DeleteFile(My.Application.Info.DirectoryPath + "/version.dat")
        End If

        'on supprime l'ancienne version du fichier update
        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath + "/update.exe") Then
            My.Computer.FileSystem.DeleteFile(My.Application.Info.DirectoryPath + "/update.exe")
        End If

        Try
            My.Computer.Network.DownloadFile(updatetextfileurl, My.Application.Info.DirectoryPath + "/version.dat")
            If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath + "/version.dat") Then
                Dim reader As New System.IO.StreamReader(My.Application.Info.DirectoryPath + "/version.dat")
                Dim read As String = reader.ReadToEnd
                reader.Close()
                If read <> currentversion Then
                    MsgBox("Attention !" & vbCrLf & "Une nouvelle version est disponible pour The Mindwreck Patcher." & vbCrLf & _
                           "Vous avez actuellement la version " & currentversion & "." & vbCrLf & _
                           "La version la plus récente de The Mindwreck Patcher est " & read & "." & vbCrLf & vbCrLf & _
                            "La programme de mise à jour sera automatiquement lancé à la fermeture de cette fenêtre." & vbCrLf & vbCrLf & _
                            "Appuyez sur OK pour continué.", _
                            MsgBoxStyle.Information, "The Mindwreck Patcher - Mise à jour disponible")

                    Try
                        'on supprime les fichier de version 
                        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath + "/version.dat") Then
                            My.Computer.FileSystem.DeleteFile(My.Application.Info.DirectoryPath + "/version.dat")
                        End If
                        'on supprime les fichiers update
                        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath + "/update.exe") Then
                            My.Computer.FileSystem.DeleteFile(My.Application.Info.DirectoryPath + "/update.exe")
                        End If
                        'on appel le sup downloadupdate
                        downloadupdate("http://dl.dropbox.com/u/68710014/Release.exe", True)

                    Catch ex As Exception
                        MsgBox("Erreur : " + ex.Message)
                    End Try

                Else
                    'on fais rien le programme est à jour.
                End If
            Else
                MsgBox("Une erreur c'est produite lors de la vérification de la version du programme.", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("Erreur avec le programme de mise à jour, " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Sub downloadupdate(ByVal updaterexecuteableurl As String, ByVal showUI As Boolean)
        Try
            My.Computer.Network.DownloadFile(updaterexecuteableurl, My.Application.Info.DirectoryPath + "/update.exe", "", "", showUI, 99999999, True)
            If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath + "/update.exe") Then

                url = updaterexecuteableurl
                bool_showUI = showUI
                Timer1.Interval = 10
                Progress.Maximum = 1000
                Timer1.Enabled = True
                Timer1.Start()
                AddHandler Timer1.Tick, AddressOf Timer1_tick
            Else
                downloadupdate(updaterexecuteableurl, showUI)
            End If

        Catch ex As Exception
            MsgBox("Erreur lors du téléchargement de la mise à jour, " + ex.Message)
        End Try
    End Sub

    Sub Timer1_tick(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Do Until Progress.Value = 1000
                Progress.Value = Progress.Value + 1
            Loop
            If Progress.Value = 1000 Then
                If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath + "/update.exe") Then
                    Shell(My.Application.Info.DirectoryPath + "/update.exe", AppWinStyle.NormalFocus)
                    Me.Close()
                    Timer1.Stop()
                    Timer1.Enabled = False
                    Exit Sub
                Else
                    downloadupdate(url, bool_showUI)
                End If
            End If
        Catch ex As Exception
            If ex.Message.Contains("not") Then
                Shell(My.Application.Info.DirectoryPath + "/update.exe", AppWinStyle.NormalFocus)
                Me.Close()
                Timer1.Stop()
                Timer1.Enabled = False
            End If
        End Try
    End Sub
    '--------------------------------------------------------------------- /UPDATE -----------------------------------------------------------------------'


End Class
