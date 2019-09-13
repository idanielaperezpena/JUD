
Public Class WebForm1


    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub



    <System.Web.Services.WebMethod()>
    Public Shared Function validar(ByVal no_empleado As String, ByVal password As String) As String()
        Dim respuesta(2) As String
        Dim ctlogin2 As New Ct_login
        If ctlogin2.logear(no_empleado, password) Then
            respuesta(0) = "Hola " & no_empleado & "   " & password
            respuesta(1) = "no"
        Else
            respuesta(0) = "La informacion es incorrecta"
            respuesta(1) = "error"
        End If
        Return respuesta

    End Function



End Class