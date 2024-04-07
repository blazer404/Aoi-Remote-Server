Imports Microsoft.Win32
Imports Microsoft.Win32.Registry


Public Class WindowsStartup

    Public Property IsActive As Boolean = False
    Private Property RegSubKey As String = "SOFTWARE\Microsoft\Windows\CurrentVersion\Run"


    ''' <summary>
    ''' Конструктор класса
    ''' </summary>
    Public Sub New()
        IsActive = GetStatus()
    End Sub

    ''' <summary>
    ''' Добавление приложения в автозагрузку
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Add()
        If IsActive = False Then
            Dim regKey As RegistryKey = CurrentUser.OpenSubKey(RegSubKey, True)
            regKey.SetValue(Application.ProductName, Application.ExecutablePath)
        End If
    End Sub

    ''' <summary>
    ''' Удаление приложения из автозагрузки
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Remove()
        If IsActive = True Then
            Dim regKey As RegistryKey = CurrentUser.OpenSubKey(RegSubKey, True)
            regKey.DeleteValue(Application.ProductName, False)
        End If
    End Sub

    ''' <summary>
    ''' Проверка находится ли приложение в автозагрузке
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetStatus() As Boolean
        Dim regKey As RegistryKey = CurrentUser.OpenSubKey(RegSubKey, False)
        Dim value As Object = regKey.GetValue(Application.ProductName)
        Return (value IsNot Nothing AndAlso value.ToString() = Application.ExecutablePath)
    End Function

End Class
