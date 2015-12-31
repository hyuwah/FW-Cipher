Public Class MainWindow
    Dim fw As New fwengine
    Private OpenFileDialog1 As Object
    Private SaveFileDialog1 As Object

    ''' <summary>
    ''' Inisialisasi MainWindows
    ''' disable bt_copy dan bt_save
    ''' </summary>
    ''' Main Windows
    ''' Initialization
    ''' <remarks></remarks>
    Private Sub MainWindow1_Initialized(sender As Object, e As EventArgs) Handles MainWindow1.Initialized
        bt_copy.IsEnabled = False
        bt_save.IsEnabled = False
    End Sub

    ''' <summary>
    ''' OPERASI TOMBOL ENKRIPSI
    ''' </summary>
    ''' bt_encrypt = Encrypt Button
    ''' Click Event
    Private Sub bt_encrypt_Click(sender As Object, e As RoutedEventArgs) Handles bt_encrypt.Click
        'Cek input text dan key jikalau kosong
        If tb_input.Text Is String.Empty Or tb_key.Text Is String.Empty Then
            MsgBox("Input text and key cannot be empty..", MsgBoxStyle.Critical, "Can't Encrypt")
            Exit Sub
        End If

        'Deklarasi variabel
        Dim key As Integer 'kunci
        Dim entext As String 'hasil enkripsi

        'inisialisasi nilai
        key = Integer.Parse(tb_key.Text) Mod 26

        'proses enkripsi
        entext = fw.cipher(tb_input.Text, key)
        tb_output.Text = entext
        'aktifkan save button
        If tb_output IsNot String.Empty Then bt_save.IsEnabled = True
    End Sub

    ''' <summary>
    ''' OPERASI TOMBOL DEKRIPSI
    ''' </summary>
    ''' bt_decrypt = Decrypt Button
    ''' Click Event
    Private Sub bt_decrypt_Click(sender As Object, e As RoutedEventArgs) Handles bt_decrypt.Click
        'Cek input text dan key jikalau kosong
        If tb_input.Text Is String.Empty Or tb_key.Text Is String.Empty Then
            MsgBox("Input text and key cannot be empty..", MsgBoxStyle.Critical, "Can't Encrypt")
            Exit Sub
        End If

        'Deklarasi variabel
        Dim key As Integer 'kunci
        Dim detext As String 'hasil dekripsi

        'inisialisasi nilai kunci (dekripsi = negatif)
        key = -Integer.Parse(tb_key.Text) Mod 26

        'proses dekripsi
        detext = fw.cipher(tb_input.Text, key)
        tb_output.Text = detext
        'aktifkan save button
        If tb_output IsNot String.Empty Then bt_save.IsEnabled = True
    End Sub

    ''' <summary>
    ''' OPERASI TOMBOL RESET
    ''' tb_key = 0, tb_input = "", tb_output = ""
    ''' </summary>
    ''' bt_reset = Reset Button
    ''' Click Event
    Private Sub bt_reset_Click(sender As Object, e As EventArgs) Handles bt_reset.Click
        tb_key.Text = "0"
        tb_input.Text = ""
        tb_output.Text = ""
        bt_save.IsEnabled = False
    End Sub

    ''' <summary>
    ''' OPERASI TOMBOL COPY PASTE
    ''' I/O ke Clipboard
    ''' </summary>
    ''' bt_paste = Paste Button
    ''' bt_copy = Copy Button
    ''' Click Event
    Private Sub bt_paste_Click(sender As Object, e As EventArgs) Handles bt_paste.Click
        tb_input.Text = Clipboard.GetText
    End Sub
    Private Sub bt_copy_Click(sender As Object, e As EventArgs) Handles bt_copy.Click
        Clipboard.SetText(tb_output.Text)
    End Sub

    'Operasi pengecekan bila output kosong, maka bt_copy disabled
    Private Sub tb_output_TextChanged(sender As Object, e As TextChangedEventArgs) Handles tb_output.TextChanged
        If (String.IsNullOrWhiteSpace(tb_output.Text)) Then bt_copy.IsEnabled = False Else bt_copy.IsEnabled = True
    End Sub

    ''' <summary>
    ''' OPERASI TOMBOL KEY
    ''' Increment dan Decrement nilai tb_key
    ''' </summary>
    ''' bt_keyup dan bt_keydown
    ''' Click Event
    ''' <remarks></remarks>
    Private Sub bt_keyup_Click(sender As Object, e As RoutedEventArgs) Handles bt_keyup.Click
        Dim value As Integer  
        If tb_key.Text IsNot "" Then
            value = Integer.Parse(tb_key.Text)
            value += 1
            tb_key.Text = value
        Else
            tb_key.Text = 0
        End If
    End Sub
    Private Sub bt_keydown_Click(sender As Object, e As RoutedEventArgs) Handles bt_keydown.Click
        Dim value As Integer
        If tb_key.Text IsNot "" Then
            value = Integer.Parse(tb_key.Text)
            value -= 1
            If value <= 0 Then
                tb_key.Text = 0
                Exit Sub
            End If
            tb_key.Text = value
        Else
            tb_key.Text = 0
        End If
    End Sub
    ' Numeric key only
    Private Sub tb_key_PreviewTextInput(sender As Object, e As TextCompositionEventArgs) Handles tb_key.PreviewTextInput
        If Not Char.IsNumber(CChar(e.Text)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub bt_open_Click(sender As Object, e As RoutedEventArgs) Handles bt_open.Click

    End Sub
End Class
