Imports System.Runtime.InteropServices
Imports System.IO
Imports AoiRemoteServer.Interfaces


Public Class MediaPlayer
    Public Property Listener As IServerListener = Nothing

    Private Const MPC = "MPC"
    Private Const AIMP = "AIMP"

    Private ReadOnly WM_COMMANDS As New Dictionary(Of String, Integer()) From {
        {MPC, New Integer() {&H111}},
        {AIMP, New Integer() {}}
    }


    ''' <summary>
    ''' Импорт функции SendMessage для работы с окнами
    ''' </summary>
    ''' <param name="hWnd"></param>
    ''' <param name="Msg"></param>
    ''' <param name="wParam"></param>
    ''' <param name="lParam"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DllImport("user32.dll", SetLastError:=True)>
    Private Shared Function SendMessage(hWnd As IntPtr, Msg As UInteger, wParam As IntPtr, lParam As IntPtr) As IntPtr
    End Function

    ''' <summary>
    ''' Получение пути проигрывателя по его имени
    ''' </summary>
    ''' <param name="name"></param>
    ''' <returns></returns>
    Private Function GetPath(name As String)
        Dim path As String = Nothing
        Select Case name
            Case MPC
                path = My.Settings.MpcPath
            Case AIMP
                path = My.Settings.AimpPath
            Case Else
                path = Nothing
        End Select
        Return path
    End Function

    '''' <summary>
    '''' Поиск дескриптора окна проигрывателя по его пути, который указан в настройках
    '''' </summary>
    '''' <param name="name"></param>
    Public Function GetProcessByTarget(targetName As String) As IntPtr
        Dim targetFilePath As String = GetPath(targetName)
        If String.IsNullOrEmpty(targetFilePath) Then
            Return IntPtr.Zero
        End If
        Dim targetFileName = Path.GetFileNameWithoutExtension(targetFilePath)
        Dim processes() As Process = Process.GetProcessesByName(targetFileName)
        For Each process As Process In processes
            Try
                If Not String.IsNullOrEmpty(process.MainModule.FileName) AndAlso process.MainModule.FileName.ToLower() = targetFilePath.ToLower() Then
                    Dim windowHandle As IntPtr = process.MainWindowHandle
                    If windowHandle <> IntPtr.Zero Then
                        Return windowHandle
                    End If
                End If
            Catch ex As Exception
                If Debugger.IsAttached Then
                    Console.WriteLine("Это запланированое падение - забей. Метод не нашел процесс или не смог получить к нему доступ")
                End If
            End Try
        Next
        Return IntPtr.Zero
    End Function

    ''' <summary>
    ''' Отправка команды проигрывателю
    ''' </summary>
    ''' <param name="target"></param>
    ''' <param name="commandKey"></param>
    Public Sub SendCommand(target As String, commandKey As Integer)

        'todo разобрать тут команды по свитчу: системные в одну сторону, от проигрывателей в другую

        Try
            Dim targetHandle = GetProcessByTarget(target)
            Listener.OnUpdateLog("Target process handle: " & targetHandle.ToString())
            If targetHandle = IntPtr.Zero Then
                Exit Sub
            End If
            Dim WmCommand = WM_COMMANDS(target)(0)
            SendMessage(targetHandle, WmCommand, commandKey, IntPtr.Zero)
        Catch ex As Exception
            Listener.OnUpdateLog("☻ Exception: " & ex.Message)
        End Try
    End Sub

End Class