Imports Microsoft.Win32
Imports Microsoft.Win32.Registry


Module WindowsStartup

    Private regSubKey As String = "SOFTWARE\Microsoft\Windows\CurrentVersion\Run"

    ''' <summary>
    ''' Добавление приложения в автозагрузку
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Add()
        If IsActive() = False Then
            Dim regKey As RegistryKey = CurrentUser.OpenSubKey(regSubKey, True)
            regKey.SetValue(Application.ProductName, Application.ExecutablePath)
        End If
    End Sub

    ''' <summary>
    ''' Удаление приложения из автозагрузки
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Remove()
        If IsActive() = True Then
            Dim regKey As RegistryKey = CurrentUser.OpenSubKey(regSubKey, True)
            regKey.DeleteValue(Application.ProductName, False)
        End If
    End Sub

    ''' <summary>
    ''' Проверка находится ли приложение в автозагрузке
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsActive() As Boolean
        Dim regKey As RegistryKey = CurrentUser.OpenSubKey(regSubKey, False)
        Dim value As Object = regKey.GetValue(Application.ProductName)
        Return (value IsNot Nothing AndAlso value.ToString() = Application.ExecutablePath)
    End Function

End Module
