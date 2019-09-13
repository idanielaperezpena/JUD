
Public Class Validaciones

    Private regex_cadena As String


    Private Function validar_regex(ByVal texto_verificar As String) As Boolean
        Dim regex As Regex = New Regex(regex_cadena)
        Dim match As Match = regex.Match(texto_verificar)
        Dim valida As Boolean

        If match.Success Then
            valida = True
        Else
            valida = False
        End If

        Return valida
    End Function


End Class
