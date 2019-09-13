Public Class Empleado_Invi

    Private no_empleado As String
    Private nombre As String
    Private ap_pat As String
    Private ap_mat As String
    Private password As String

    Public Sub New()

    End Sub

    Public Sub logear(ByVal usuario As String, ByVal password As String)
        Me.no_empleado = usuario
        Me.password = password
        Me.nombre = "Andres"
        Me.ap_pat = "Mitzi"
    End Sub

    Public Function get_nombre() As String
        Return Me.nombre & "  " & Me.ap_pat
    End Function





End Class
