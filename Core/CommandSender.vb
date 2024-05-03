Imports AoiRemoteServer.Interfaces
Imports System.IO


Public Class CommandSender

    Public Property Listener As IServerListener = Nothing
    Private Property TargetWindowId As IntPtr = IntPtr.Zero
    Private Property TargetWindowHandle As IntPtr = IntPtr.Zero
    Private Property TargetWindowTitle As String = Nothing


    ''' <summary>
    ''' Отправка команды цели
    ''' </summary>
    ''' <param name="target"></param>
    ''' <param name="command"></param>
    Public Sub Send(target As String, command As String)
        Try
            Select Case target
                Case Constants.MPC
                    SendMPC(command)
                Case Constants.AIMP
                    SendAIMP(command)
                Case Constants.SYSTEM
                    SendSystem(command)
                Case Else
                    ' todo set listener log here and client response
            End Select
        Catch ex As Exception
            Listener.OnUpdateLog(My.Resources.lbl_Exeption & ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Отправка команды MPC
    ''' </summary>
    ''' <param name="command"></param>
    ''' <returns></returns>
    Private Function SendMPC(command As String) As Boolean
        InitTargetApp(Constants.MPC)
        If TargetWindowHandle = IntPtr.Zero Then
            ' todo set listener log here and client response
            Return False
        End If
        If Libs.SendMessage(TargetWindowHandle, Constants.WM_COMMAND, command, IntPtr.Zero) = 0 Then
            ' todo set listener log here and client response
            Return False
        End If
        ' todo set listener log here and client response
        Return True
    End Function

    ''' <summary>
    ''' Отправка команды AIMP
    ''' </summary>
    ''' <param name="command"></param>
    ''' <returns></returns>
    Private Function SendAIMP(command As String) As Boolean
        ' soon... may be
        InitTargetApp(Constants.AIMP)
        If TargetWindowHandle = IntPtr.Zero Then
            Return False
        End If
        ' todo send command here
        Listener.OnUpdateLog("get: " & command.ToString())
        Return True
    End Function

    ''' <summary>
    ''' Отправка системной команды 
    ''' </summary>
    ''' <param name="command"></param>
    ''' <returns></returns>
    Private Function SendSystem(command As String) As Boolean
        ' soon... may be
        Listener.OnUpdateLog("get: " & command.ToString())
        Return True
    End Function

    ''' <summary>
    ''' Инициализация параметров проигрывателя по его имени
    ''' </summary>
    ''' <param name="target"></param>
    Private Sub InitTargetApp(target As String)
        Dim filePath As String = GetTargetPathByName(target)
        If String.IsNullOrEmpty(filePath) Then
            Listener.OnUpdateLog("Process path not found")
            Exit Sub
        End If
        Dim fileName = Path.GetFileNameWithoutExtension(filePath)
        Dim processes() As Process = Process.GetProcessesByName(fileName)
        For Each process As Process In processes
            Try
                If Not String.IsNullOrEmpty(process.MainModule.FileName) AndAlso process.MainModule.FileName.ToLower() = filePath.ToLower() Then
                    SetTargetByProcess(process)
                End If
            Catch ex As Exception
                'do nothing
            End Try
        Next
    End Sub

    ''' <summary>
    ''' Получение пути проигрывателя по его имени
    ''' </summary>
    ''' <param name="name"></param>
    ''' <returns></returns>
    Private Function GetTargetPathByName(name As String) As String
        Select Case name
            Case Constants.MPC
                Return My.Settings.MpcPath
            Case Constants.AIMP
                Return My.Settings.AimpPath
            Case Else
                Return Nothing
        End Select
    End Function

    ''' <summary>
    ''' Установка параметров проигрывателя для взаимоодействия
    ''' </summary>
    ''' <param name="process"></param>
    Private Sub SetTargetByProcess(ByRef process As Process)
        If process.MainWindowHandle <> IntPtr.Zero AndAlso TargetWindowId <> process.Id Then
            TargetWindowId = process.Id
            TargetWindowHandle = process.MainWindowHandle
            TargetWindowTitle = process.MainWindowTitle
        End If
    End Sub

End Class