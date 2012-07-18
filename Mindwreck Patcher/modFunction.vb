Imports System.Reflection 'sub Save to disk
Imports IWshRuntimeLibrary 'pour le sub create shurtcut


Module modFunction

    '-------------------------------------------------------------------- VARIABLE ET CONSTANTE ------------------------------------------------------------'

    'Obtient le chemin du dossier ou le .exe est lancé sans \ à la fin
    Public file_path As String = Application.StartupPath

    'Déclaration des variable pour la mise à jour.
    Public Progress As New ProgressBar
    Public url As String
    Public bool_showUI As Boolean
    Public Timer1 As New Timer

    '----------------------------------------------------------------------- PROCÉDURE ET FUNCTION --------------------------------------------------------'


    'fonction qui permet de vérifier si l'internet est disponible
    Public Function connexionInternet() As Boolean
        Dim objUrl As New System.Uri("http://www.kobixxe.com/")
        Dim objWebReq As System.Net.WebRequest
        objWebReq = System.Net.WebRequest.Create(objUrl)
        Dim objResp As System.Net.WebResponse
        Try
            objResp = objWebReq.GetResponse
            objResp.Close()
            objWebReq = Nothing
            Return True
        Catch ex As Exception

            objWebReq = Nothing
            Return False
        End Try
    End Function


    'sub qui permet d'enregistrer les ressources du Exe sur le disque dur.
    Public Sub SaveToDisk(ByVal resourceName As String, ByVal fileName As String)

        'Get a reference to the running application.
        Dim assy As [Assembly] = [Assembly].GetExecutingAssembly()
        ' Loop through each resource, looking for the image name (case-insensitive).
        For Each resource As String In assy.GetManifestResourceNames()
            If resource.ToLower().IndexOf(resourceName.ToLower) <> -1 Then
                ' Get the embedded file from the assembly as a MemoryStream.
                Using resourceStream As System.IO.Stream = assy.GetManifestResourceStream(resource)
                    If resourceStream IsNot Nothing Then
                        Using reader As New BinaryReader(resourceStream)
                            ' Read the bytes from the input stream.
                            Dim buffer() As Byte = reader.ReadBytes(CInt(resourceStream.Length))
                            Using outputStream As New FileStream(fileName, FileMode.Create)
                                Using writer As New BinaryWriter(outputStream)
                                    ' Write the bytes to the output stream.
                                    writer.Write(buffer)
                                End Using
                            End Using
                        End Using
                    End If
                End Using
                Exit For
            End If
        Next resource
    End Sub


    'Sub qui permet d'extraire des archive.zip
    Public Sub ExtractArchive(ByVal zipFilename As String, ByVal ExtractDir As String)

        'Sub fonction permettant d'extraire un fichier .zip
        'ce Sub exploite le dll ICSharpCode.SharpZipLib.dll inclus dans les référence
        Dim Redo As Integer = 1
        Dim MyZipInputStream As ZipInputStream
        Dim MyFileStream As FileStream
        MyZipInputStream = New ZipInputStream(New FileStream(zipFilename, FileMode.Open, FileAccess.Read))
        Dim MyZipEntry As ZipEntry = MyZipInputStream.GetNextEntry
        Directory.CreateDirectory(ExtractDir)
        While Not MyZipEntry Is Nothing
            If (MyZipEntry.IsDirectory) Then
                Directory.CreateDirectory(ExtractDir & "\" & MyZipEntry.Name)
            Else
                If Not Directory.Exists(ExtractDir & "\" & _
                Path.GetDirectoryName(MyZipEntry.Name)) Then
                    Directory.CreateDirectory(ExtractDir & "\" & _
                    Path.GetDirectoryName(MyZipEntry.Name))
                End If
                MyFileStream = New FileStream(ExtractDir & "\" & _
                  MyZipEntry.Name, FileMode.OpenOrCreate, FileAccess.Write)
                Dim count As Integer
                Dim buffer(4096) As Byte
                count = MyZipInputStream.Read(buffer, 0, 4096)
                While count > 0
                    MyFileStream.Write(buffer, 0, count)
                    count = MyZipInputStream.Read(buffer, 0, 4096)
                End While
                MyFileStream.Close()
            End If

            Try
                MyZipEntry = MyZipInputStream.GetNextEntry
            Catch ex As Exception
                MyZipEntry = Nothing
            End Try
        End While
        If Not (MyZipInputStream Is Nothing) Then MyZipInputStream.Close()
        If Not (MyFileStream Is Nothing) Then MyFileStream.Close()

    End Sub


    'Sub fonction qui permet d'appeler un délais de (x) secondes
    Sub Delay(ByVal dblSecs As Double)

        Const OneSec As Double = 1.0# / (1440.0# * 60.0#)
        Dim dblWaitTil As Date
        Now.AddSeconds(OneSec)
        dblWaitTil = Now.AddSeconds(OneSec).AddSeconds(dblSecs)
        Do Until Now > dblWaitTil
            Application.DoEvents()
        Loop

    End Sub

    'Sub pour créé un racourcie sur le bureau
    Public Sub CreateShortCut(ByVal OutputPathFileName As String, ByVal Title As String)
        Try
            Dim WshShell As New WshShell
            ' short cut files have a .lnk extension
            Dim shortCut As IWshRuntimeLibrary.IWshShortcut = DirectCast(WshShell.CreateShortcut(OutputPathFileName),  _
                IWshRuntimeLibrary.IWshShortcut)

            ' set the shortcut properties
            With shortCut
                .TargetPath = file_path & "\Mindwreck Patcher.exe"
                .WindowStyle = 1I
                .Description = Title
                .WorkingDirectory = Application.StartupPath
                ' the next line gets the first Icon from the executing program
                .IconLocation = Application.ExecutablePath & ", 0"
                .Arguments = String.Empty
                .Save() ' save the shortcut file
            End With
        Catch ex As System.Exception
            MsgBox("Could not create the shortcut" & Environment.NewLine & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    'Function de mise à jours du status d'opération
    Public Function UpdateStatus(ByVal ligne1 As String, Optional ByVal ligne2 As String = "", _
                                 Optional ByVal ligne3 As String = "", Optional ByVal ligne4 As String = "") As String
        UpdateStatus = vbCrLf & "=======================================" & vbCrLf
        UpdateStatus += ligne1 & vbCrLf
        UpdateStatus += ligne2 & vbCrLf
        UpdateStatus += ligne3 & vbCrLf
        UpdateStatus += ligne4 & vbCrLf
        UpdateStatus += "=======================================" & vbCrLf
        Return UpdateStatus
    End Function


End Module
