Public Class Interfaces

    ''' <summary>
    ''' Интерфейс для отловки сообщений
    ''' </summary>
    ''' <remarks></remarks>
    Interface IMessageListener
        Sub OnCloseConnection()
        Sub OnOpenConnection()
        Sub OnUpdateLog(ByVal data As String)
        Sub OnShowError(ByVal data As String)
        Sub OnCommandReceived(ByVal playerName As String, ByVal command As String)
    End Interface

End Class
