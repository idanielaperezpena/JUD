Public Class Ct_login

    Public Function logear(ByVal usuario As String, ByVal password As String) As Boolean

        Dim Empleado_invi_logeado = New Empleado_Invi
        Empleado_invi_logeado.logear(usuario, password)
        Return True
    End Function

    Public Function recuperar_password(ByVal password As String) As Boolean
        Return True
    End Function

End Class
