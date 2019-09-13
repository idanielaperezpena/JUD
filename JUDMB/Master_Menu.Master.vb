Imports System.Web.HttpContext
Public Class Master_Menu
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Current.Session("empleado_logeado") IsNot Nothing Then
            Dim Empleado_invi_logeado As Empleado_Invi
            Empleado_invi_logeado = Current.Session("empleado_logeado")
            lbl_user.Text = Empleado_invi_logeado.get_nombre
        Else
            Response.Redirect("/Login.aspx")
        End If

    End Sub

End Class