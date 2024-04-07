Imports System.Runtime.InteropServices


Public Class MediaPlayer

    Public Const MPC = "MPC"
    Public Const AIMP = "AIMP"

    Public Const MPC_PLAYPAUSE = 889
    Public Const MPC_PREV = 921 'jump prev chapter, use 919 for jump files
    Public Const MPC_NEXT = 922 'jump next chapter, use 920 for jump files
    Public Const MPC_VOL_UP = 907
    Public Const MPC_VOL_DOWN = 908
    Public Const MPC_STOP = 890
    Public Const MPC_AUDIO_NEXT = 952
    Public Const MPC_AUDIO_PREV = 953
    Public Const MPC_MUTE = 909
    Public Const MPC_SUB_NEXT = 954
    Public Const MPC_SUB_PREV = 955
    Public Const MPC_SUB_ONOFF = 956
    Public Const MPC_FULLSCREEN = 830
    Public Const MPC_CLOSE = 804
    Public Const MPC_EXIT = 816

    Public WM_COMMANDS As New Dictionary(Of String, Integer()) From {
        {MPC, New Integer() {&H111}},
        {AIMP, New Integer() {}}
    }

    Public APP_COMMANDS As New Dictionary(Of String, Integer()) From {
        {MPC, New Integer() {
                MPC_PLAYPAUSE,
                MPC_PREV,
                MPC_NEXT,
                MPC_VOL_UP,
                MPC_VOL_DOWN,
                MPC_STOP,
                MPC_AUDIO_NEXT,
                MPC_AUDIO_PREV,
                MPC_MUTE,
                MPC_SUB_NEXT,
                MPC_SUB_PREV,
                MPC_SUB_ONOFF,
                MPC_FULLSCREEN,
                MPC_CLOSE,
                MPC_EXIT
            }},
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
    ''' <remarks></remarks>
    Private Function GetPath(ByVal name As String)
        Dim path As String = Nothing
        Select Case name
            Case MPC
                path = My.Settings.MpcPath
            Case AIMP
                path = My.Settings.AimpPath
            Case Else
                path = Nothing
        End Select
        If path Is Nothing Or path = "" Then
            Return Nothing
        End If
        Return path
    End Function

    ''' <summary>
    ''' Поиск дескриптора окна проигрывателя по его пути, который указан в настройках
    ''' </summary>
    ''' <param name="name"></param>
    ''' <remarks></remarks>
    Private Function FindByName(ByVal name As String)
        Dim path = GetPath(name)
        If path Is Nothing Then
            Return Nothing
        End If
        Dim processes As Process() = Process.GetProcesses()
        For Each process As Process In processes
            Try
                If Not String.IsNullOrEmpty(process.MainModule.FileName) AndAlso process.MainModule.FileName.ToLower() = path.ToLower() Then
                    Dim playerWindowHandle As IntPtr = process.MainWindowHandle
                    If playerWindowHandle <> IntPtr.Zero Then
                        Return playerWindowHandle
                    End If
                End If
            Catch ex As Exception
            End Try
        Next
        Return Nothing
    End Function

    ''' <summary>
    ''' Отправка команды проигрывателю
    ''' </summary>
    ''' <param name="playerName"></param>
    ''' <param name="commandKey"></param>
    ''' <remarks></remarks>
    Public Sub SendCommand(ByVal playerName As String, ByVal commandKey As Integer)
        Try
            Dim playerPid = FindByName(playerName)
            If playerPid Is Nothing Then
                Exit Sub
            End If
            Dim WmCommand = WM_COMMANDS(playerName)(0)
            SendMessage(playerPid, WmCommand, commandKey, IntPtr.Zero)
        Catch ex As Exception
            MainForm.OnUpdateLog(ex.Message)
        End Try
    End Sub

End Class
