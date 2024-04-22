Public Class Interfaces

    ''' <summary>
    ''' Интерфейс для отловки сообщений
    ''' </summary>
    ''' <remarks></remarks>
    Interface IServerListener
        Sub OnCloseConnection()
        Sub OnOpenConnection()
        Sub OnUpdateLog(ByVal data As String)
        Sub OnShowError(ByVal data As String)
        Sub OnCommandReceived(ByVal target As String, ByVal commandKey As String)
    End Interface

End Class
