﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Этот код создан программой.
'     Исполняемая версия:4.0.30319.42000
'
'     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
'     повторной генерации кода.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace My.Resources
    
    'Этот класс создан автоматически классом StronglyTypedResourceBuilder
    'с помощью такого средства, как ResGen или Visual Studio.
    'Чтобы добавить или удалить член, измените файл .ResX и снова запустите ResGen
    'с параметром /str или перестройте свой проект VS.
    '''<summary>
    '''  Класс ресурса со строгой типизацией для поиска локализованных строк и т.д.
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.Microsoft.VisualBasic.HideModuleNameAttribute()>  _
    Friend Module Resources
        
        Private resourceMan As Global.System.Resources.ResourceManager
        
        Private resourceCulture As Global.System.Globalization.CultureInfo
        
        '''<summary>
        '''  Возвращает кэшированный экземпляр ResourceManager, использованный этим классом.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("AoiRemoteServer.Resources", GetType(Resources).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  Перезаписывает свойство CurrentUICulture текущего потока для всех
        '''  обращений к ресурсу с помощью этого класса ресурса со строгой типизацией.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        '''<summary>
        '''  Ищет локализованную строку, похожую на IP address is invalid.
        '''</summary>
        Friend ReadOnly Property err_WrongIp() As String
            Get
                Return ResourceManager.GetString("err_WrongIp", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Ищет локализованную строку, похожую на Port is invalid. It must be in range from 1024 to 65535.
        '''</summary>
        Friend ReadOnly Property err_WrongPort() As String
            Get
                Return ResourceManager.GetString("err_WrongPort", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Поиск локализованного ресурса типа System.Drawing.Icon, аналогичного (Значок).
        '''</summary>
        Friend ReadOnly Property icon_green_circle() As System.Drawing.Icon
            Get
                Dim obj As Object = ResourceManager.GetObject("icon_green_circle", resourceCulture)
                Return CType(obj,System.Drawing.Icon)
            End Get
        End Property
        
        '''<summary>
        '''  Поиск локализованного ресурса типа System.Drawing.Icon, аналогичного (Значок).
        '''</summary>
        Friend ReadOnly Property icon_green_square() As System.Drawing.Icon
            Get
                Dim obj As Object = ResourceManager.GetObject("icon_green_square", resourceCulture)
                Return CType(obj,System.Drawing.Icon)
            End Get
        End Property
        
        '''<summary>
        '''  Поиск локализованного ресурса типа System.Drawing.Icon, аналогичного (Значок).
        '''</summary>
        Friend ReadOnly Property icon_orange_circle() As System.Drawing.Icon
            Get
                Dim obj As Object = ResourceManager.GetObject("icon_orange_circle", resourceCulture)
                Return CType(obj,System.Drawing.Icon)
            End Get
        End Property
        
        '''<summary>
        '''  Поиск локализованного ресурса типа System.Drawing.Icon, аналогичного (Значок).
        '''</summary>
        Friend ReadOnly Property icon_orange_squae() As System.Drawing.Icon
            Get
                Dim obj As Object = ResourceManager.GetObject("icon_orange_squae", resourceCulture)
                Return CType(obj,System.Drawing.Icon)
            End Get
        End Property
        
        '''<summary>
        '''  Ищет локализованную строку, похожую на Endpoint: .
        '''</summary>
        Friend ReadOnly Property lbl_Endpoint() As String
            Get
                Return ResourceManager.GetString("lbl_Endpoint", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Ищет локализованную строку, похожую на ☻ Exception: .
        '''</summary>
        Friend ReadOnly Property lbl_Exeption() As String
            Get
                Return ResourceManager.GetString("lbl_Exeption", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Ищет локализованную строку, похожую на Request: .
        '''</summary>
        Friend ReadOnly Property lbl_Request() As String
            Get
                Return ResourceManager.GetString("lbl_Request", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Ищет локализованную строку, похожую на Confirmation.
        '''</summary>
        Friend ReadOnly Property msg_ConfirmTitle() As String
            Get
                Return ResourceManager.GetString("msg_ConfirmTitle", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Ищет локализованную строку, похожую на Error.
        '''</summary>
        Friend ReadOnly Property msg_ErrorTitle() As String
            Get
                Return ResourceManager.GetString("msg_ErrorTitle", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Ищет локализованную строку, похожую на Are you sure you want to reset?.
        '''</summary>
        Friend ReadOnly Property msg_ResetSettingText() As String
            Get
                Return ResourceManager.GetString("msg_ResetSettingText", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Ищет локализованную строку, похожую на Unauthorized.
        '''</summary>
        Friend ReadOnly Property req_401Unauthorized() As String
            Get
                Return ResourceManager.GetString("req_401Unauthorized", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Ищет локализованную строку, похожую на Internal server error.
        '''</summary>
        Friend ReadOnly Property req_500Internal() As String
            Get
                Return ResourceManager.GetString("req_500Internal", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Ищет локализованную строку, похожую на Connection timeout.
        '''</summary>
        Friend ReadOnly Property req_500Timeout() As String
            Get
                Return ResourceManager.GetString("req_500Timeout", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Ищет локализованную строку, похожую на OK.
        '''</summary>
        Friend ReadOnly Property req_Ok() As String
            Get
                Return ResourceManager.GetString("req_Ok", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Ищет локализованную строку, похожую на Settings is reset.
        '''</summary>
        Friend ReadOnly Property set_Reset() As String
            Get
                Return ResourceManager.GetString("set_Reset", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Ищет локализованную строку, похожую на Settings is saved.
        '''</summary>
        Friend ReadOnly Property set_Saved() As String
            Get
                Return ResourceManager.GetString("set_Saved", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Ищет локализованную строку, похожую на Close connection.
        '''</summary>
        Friend ReadOnly Property srv_CloseConnection() As String
            Get
                Return ResourceManager.GetString("srv_CloseConnection", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Ищет локализованную строку, похожую на Create server.
        '''</summary>
        Friend ReadOnly Property srv_Create() As String
            Get
                Return ResourceManager.GetString("srv_Create", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Ищет локализованную строку, похожую на Open connection.
        '''</summary>
        Friend ReadOnly Property srv_OpenConnection() As String
            Get
                Return ResourceManager.GetString("srv_OpenConnection", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Ищет локализованную строку, похожую на Server is running.
        '''</summary>
        Friend ReadOnly Property srv_Running() As String
            Get
                Return ResourceManager.GetString("srv_Running", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Ищет локализованную строку, похожую на Server is stopped.
        '''</summary>
        Friend ReadOnly Property srv_Stopped() As String
            Get
                Return ResourceManager.GetString("srv_Stopped", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Ищет локализованную строку, похожую на Exit.
        '''</summary>
        Friend ReadOnly Property str_Exit() As String
            Get
                Return ResourceManager.GetString("str_Exit", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Ищет локализованную строку, похожую на [ функция недоступна или отключена ].
        '''</summary>
        Friend ReadOnly Property str_FunctionNotAlailable() As String
            Get
                Return ResourceManager.GetString("str_FunctionNotAlailable", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Ищет локализованную строку, похожую на Hide.
        '''</summary>
        Friend ReadOnly Property str_Hide() As String
            Get
                Return ResourceManager.GetString("str_Hide", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Ищет локализованную строку, похожую на Show.
        '''</summary>
        Friend ReadOnly Property str_Show() As String
            Get
                Return ResourceManager.GetString("str_Show", resourceCulture)
            End Get
        End Property
    End Module
End Namespace
