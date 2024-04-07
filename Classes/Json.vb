Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq


Public Class Json

    Public success As Boolean
    Public code As Integer
    Public message As String


    ''' <summary>
    ''' Сериализация параметров в JSON
    ''' </summary>
    ''' <returns></returns>
    Public Function Serialize() As String
        Dim data As New JObject From {
            {"success", success},
            {"code", code},
            {"message", message}
        }
        Return JsonConvert.SerializeObject(data)
    End Function

    ''' <summary>
    ''' Десериализация JSON в объект
    ''' </summary>
    ''' <param name="json"></param>
    ''' <returns></returns>
    Public Function Deserialize(ByVal json As String) As Object
        Dim data As JObject = JObject.Parse(json)
        Return data
    End Function

End Class
