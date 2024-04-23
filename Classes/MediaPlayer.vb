Imports System.Runtime.InteropServices


Public Class MediaPlayer

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
    ''' <remarks></remarks>
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
    Private Function FindProcessByName(name As String)
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
                'просто напоминалка
                If Debugger.IsAttached Then
                    Console.WriteLine("Это запланированое падение - забей. Метод не нашел провцесс или не смог получить к нему доступ")
                End If
            End Try
        Next
        Return Nothing
    End Function

    ''' <summary>
    ''' Отправка команды проигрывателю
    ''' </summary>
    ''' <param name="target"></param>
    ''' <param name="commandKey"></param>
    ''' <remarks></remarks>
    Public Sub SendCommand(target As String, commandKey As Integer)

        'todo разобрать тут команды по свитчу: системные в одну сторону, от проигрывателей в другую

        Try
            Dim pid = FindProcessByName(target)
            If pid Is Nothing Then
                Exit Sub
            End If
            Dim WmCommand = WM_COMMANDS(target)(0)
            SendMessage(pid, WmCommand, commandKey, IntPtr.Zero)
        Catch ex As Exception
            MainForm.OnUpdateLog(ex.Message)
        End Try
    End Sub

End Class
