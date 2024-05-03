Public Class Json

    ''' <summary>
    ''' Конвертируем переданные параметры в JSON для ответа клиенту
    ''' </summary>
    ''' <param name="success"></param>
    ''' <param name="code"></param>
    ''' <param name="message"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CreateResponse(success As Boolean, Optional code As Integer = Nothing, Optional message As String = "") As String
        Dim params As New Dictionary(Of String, Object) From {
            {"success", success},
            {"code", code},
            {"message", message}
        }
        Return SerializeObject(params)
    End Function

    ''' <summary>
    ''' Сериализуем объект в JSON
    ''' </summary>
    ''' <param name="params"></param>
    ''' <returns></returns>
    Private Shared Function SerializeObject(params As Dictionary(Of String, Object))
        Dim json As String = "{"
        For Each pair As KeyValuePair(Of String, Object) In params
            Dim key = pair.Key
            Dim value = pair.Value
            Dim type As String = If(value IsNot Nothing, value.GetType().ToString(), "null")
            json &= """" & key & """:"
            Select Case type
                Case "System.String"
                    json &= """" & value & """, "
                Case "System.Int32"
                    json &= value & ", "
                Case "System.Boolean"
                    json &= value.ToString.ToLower & ", "
                Case Else
                    json &= """"", "
            End Select
        Next
        If params.Count > 0 Then
            json = json.Substring(0, json.Length - 2)
        End If
        json &= "}"
        Return json
    End Function

End Class
