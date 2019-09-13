
Imports System.Web.HttpContext

Public Class Ct_login

    Public Function logear(ByVal usuario As String, ByVal password As String) As Boolean
        ' Aqui se valida etc etc
        Dim Empleado_invi_logeado = New Empleado_Invi
        Empleado_invi_logeado.logear(usuario, password)
        Current.Session("empleado_logeado") = Empleado_invi_logeado
        Return True
    End Function

    Public Function recuperar_password(ByVal password As String) As Boolean
        Return True
    End Function

End Class
