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
        Friend ReadOnly Property ERR_WRONG_IP() As String
            Get
                Return ResourceManager.GetString("ERR_WRONG_IP", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Ищет локализованную строку, похожую на Port is invalid. It must be in range from 1024 to 65535.
        '''</summary>
        Friend ReadOnly Property ERR_WRONG_PORT() As String
            Get
                Return ResourceManager.GetString("ERR_WRONG_PORT", resourceCulture)
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
        Friend ReadOnly Property LBL_ENDPOINT() As String
            Get
                Return ResourceManager.GetString("LBL_ENDPOINT", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Ищет локализованную строку, похожую на ☻ Exception: .
        '''</summary>
        Friend ReadOnly Property LBL_EXCEPTION() As String
            Get
                Return ResourceManager.GetString("LBL_EXCEPTION", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Ищет локализованную строку, похожую на Request: .
        '''</summary>
        Friend ReadOnly Property LBL_REQUEST() As String
            Get
                Return ResourceManager.GetString("LBL_REQUEST", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Ищет локализованную строку, похожую на Confirmation.
        '''</summary>
        Friend ReadOnly Property MSG_TTL_CONFIRM() As String
            Get
                Return ResourceManager.GetString("MSG_TTL_CONFIRM", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Ищет локализованную строку, похожую на Error.
        '''</summary>
        Friend ReadOnly Property MSG_TTL_ERROR() As String
            Get
                Return ResourceManager.GetString("MSG_TTL_ERROR", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Ищет локализованную строку, похожую на Are you sure you want to reset?.
        '''</summary>
        Friend ReadOnly Property MSG_TXT_RESET_SETTINGS() As String
            Get
                Return ResourceManager.GetString("MSG_TXT_RESET_SETTINGS", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Ищет локализованную строку, похожую на OK.
        '''</summary>
        Friend ReadOnly Property REQ_200_OK() As String
            Get
                Return ResourceManager.GetString("REQ_200_OK", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Ищет локализованную строку, похожую на Unauthorized.
        '''</summary>
        Friend ReadOnly Property REQ_401_UNAUTHORIZEDd() As String
            Get
                Return ResourceManager.GetString("REQ_401_UNAUTHORIZEDd", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Ищет локализованную строку, похожую на Request body is empty.
        '''</summary>
        Friend ReadOnly Property REQ_422_EMPTY_BODY() As String
            Get
                Return ResourceManager.GetString("REQ_422_EMPTY_BODY", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Ищет локализованную строку, похожую на Internal server error.
        '''</summary>
        Friend ReadOnly Property REQ_500_INTERNAL() As String
            Get
                Return ResourceManager.GetString("REQ_500_INTERNAL", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Ищет локализованную строку, похожую на Connection timeout.
        '''</summary>
        Friend ReadOnly Property REQ_500_TIMEOUT() As String
            Get
                Return ResourceManager.GetString("REQ_500_TIMEOUT", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Ищет локализованную строку, похожую на Close connection.
        '''</summary>
        Friend ReadOnly Property SRV_CLOSE_CONNECTION() As String
            Get
                Return ResourceManager.GetString("SRV_CLOSE_CONNECTION", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Ищет локализованную строку, похожую на Create server.
        '''</summary>
        Friend ReadOnly Property SRV_CREATE() As String
            Get
                Return ResourceManager.GetString("SRV_CREATE", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Ищет локализованную строку, похожую на Open connection.
        '''</summary>
        Friend ReadOnly Property SRV_OPEN_CONNECTION() As String
            Get
                Return ResourceManager.GetString("SRV_OPEN_CONNECTION", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Ищет локализованную строку, похожую на Server is running.
        '''</summary>
        Friend ReadOnly Property SRV_RUNNING() As String
            Get
                Return ResourceManager.GetString("SRV_RUNNING", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Ищет локализованную строку, похожую на Server is stopped.
        '''</summary>
        Friend ReadOnly Property SRV_STOPPED() As String
            Get
                Return ResourceManager.GetString("SRV_STOPPED", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Ищет локализованную строку, похожую на Settings is reset.
        '''</summary>
        Friend ReadOnly Property STG_RESET() As String
            Get
                Return ResourceManager.GetString("STG_RESET", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Ищет локализованную строку, похожую на Settings is saved.
        '''</summary>
        Friend ReadOnly Property STG_SAVED() As String
            Get
                Return ResourceManager.GetString("STG_SAVED", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Ищет локализованную строку, похожую на Exit.
        '''</summary>
        Friend ReadOnly Property STR_EXIT() As String
            Get
                Return ResourceManager.GetString("STR_EXIT", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Ищет локализованную строку, похожую на [ функция недоступна или отключена ].
        '''</summary>
        Friend ReadOnly Property STR_FUNCTION_NOT_AVAILABLE() As String
            Get
                Return ResourceManager.GetString("STR_FUNCTION_NOT_AVAILABLE", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Ищет локализованную строку, похожую на Hide.
        '''</summary>
        Friend ReadOnly Property STR_HIDE() As String
            Get
                Return ResourceManager.GetString("STR_HIDE", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Ищет локализованную строку, похожую на Show.
        '''</summary>
        Friend ReadOnly Property STR_SHOW() As String
            Get
                Return ResourceManager.GetString("STR_SHOW", resourceCulture)
            End Get
        End Property
    End Module
End Namespace
