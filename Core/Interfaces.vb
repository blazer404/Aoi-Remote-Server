Public Class Interfaces

    ''' <summary>
    ''' Интерфейс для отловки сообщений
    ''' </summary>
    ''' <remarks></remarks>
    Interface IServerListener
        Sub OnCloseConnection()
        Sub OnOpenConnection()
        Sub OnUpdateLog(data As String)
        Sub OnShowError(data As String)
        Sub OnCommandReceived(target As String, command As String)
    End Interface

End Class
