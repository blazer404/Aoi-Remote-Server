Dim fso, filePath, version

Set fso = CreateObject("Scripting.FileSystemObject")
filePath = "My Project/AssemblyInfo.vb"

version = GenerateVersion()

If fso.FileExists(filePath) Then
    UpdateFileVersion fso, filePath, version
Else
    WScript.Echo "File not found: " & filePath
End If

Function GenerateVersion()
    Dim y, m, d, h, i, s
    y = Right("0" & Year(Date), 2)
    m = Right("0" & Month(Date), 2)
    d = Right("" & Day(Date), 2)
    h = Right("0" & Hour(Time), 2)
    i = Right("0" & Minute(Time), 2)
    s = Right("" & Second(Time), 2)
    
    GenerateVersion = y & m & "." & d & "." & h & i & "." & s
End Function

Sub UpdateFileVersion(fso, filePath, version)
    Dim file, newFileContent
    Set file = fso.OpenTextFile(filePath, 1)
    newFileContent = ""

    Do While Not file.AtEndOfStream
        Dim line
        line = file.ReadLine
        newFileContent = newFileContent & ProcessLine(line, version) & vbCrLf
    Loop
    file.Close

    Set file = fso.OpenTextFile(filePath, 2)
    file.Write newFileContent
    file.Close
End Sub

Function ProcessLine(line, version)
    If Left(Trim(line), 1) = "'" Then
        ProcessLine = line ' пропускаем коменты
    ElseIf InStr(line, "AssemblyVersion") > 0 Then
        ProcessLine = "<Assembly: AssemblyVersion(""" & version & """)>"
    ElseIf InStr(line, "AssemblyFileVersion") > 0 Then		
        ProcessLine = "<Assembly: AssemblyFileVersion(""" & version & """)>"
    Else
        ProcessLine = line
    End If
End Function
