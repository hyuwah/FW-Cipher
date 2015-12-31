Public Class fwengine
    Public Function cipher(ByVal teksinput As String, ByVal kunci As Integer) As String
        'Konversi string input menjadi array karakter teksarray
        Dim teksarray() As Char = teksinput.ToCharArray()
        'buat variabel penampung karakter dalam ascii
        Dim ascii(teksarray.Length) As Integer

        'Cek kunci negatif (decrypt)
        If kunci < 0 Then kunci = 26 + (kunci Mod 26)

        For iterasi As Integer = 0 To teksarray.Length - 1
            'konversi array karakter kedalam ascii
            ascii(iterasi) = Asc(teksarray(iterasi))

            'filter karakter dan angka
            ' angka dari 48 - 57
            ' A - Z dari 65 - 90
            ' a - z dari 97 - 122
            If ascii(iterasi) >= 48 And ascii(iterasi) <= 57 Then
                ascii(iterasi) -= 48 'assign angka as 1 sampai 0 in order
                ascii(iterasi) = (ascii(iterasi) + kunci) Mod 10
                ascii(iterasi) += 48
            ElseIf ascii(iterasi) >= 65 And ascii(iterasi) <= 90 Then
                ascii(iterasi) -= 65 'assign A-Z as 0 to 25 in order
                ascii(iterasi) = (ascii(iterasi) + kunci) Mod 26
                ascii(iterasi) += 65
            ElseIf ascii(iterasi) >= 97 And ascii(iterasi) <= 122 Then
                ascii(iterasi) -= 97 'assign a-z as 0 to 25 in order
                ascii(iterasi) = (ascii(iterasi) + kunci) Mod 26
                ascii(iterasi) += 97
            End If
            'konversi ascii ke karakter
            teksarray(iterasi) = Chr(ascii(iterasi))
        Next

        'return array of Char as String
        Return teksarray
    End Function
End Class
