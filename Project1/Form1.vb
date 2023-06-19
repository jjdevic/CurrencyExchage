Public Class Form1
    Dim conv1, conv2 As Double
    Dim nameAux As String
    ReadOnly textAux As String = "1"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim currency As New List(Of Item)
        Dim currency2 As New List(Of Item)

        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox2.DropDownStyle = ComboBoxStyle.DropDownList

        AddList(currency, currency2)

        ComboBox1.DataSource = currency
        ComboBox2.DataSource = currency2

        Aesthetics()
    End Sub

    Private Sub Aesthetics()
        TextBox1.Text = textAux
        Me.BackgroundImage = My.Resources.gris2
        Me.BackgroundImageLayout = ImageLayout.Stretch

        Label1.BackColor = Color.Transparent
        Label2.BackColor = Color.Transparent
        Label3.BackColor = Color.Transparent
        Label4.BackColor = Color.Transparent

        TextBox1.BorderStyle = BorderStyle.None

        Button1.FlatStyle = FlatStyle.Flat
        Button1.FlatAppearance.BorderSize = 0

        ComboBox1.FlatStyle = FlatStyle.Flat
        ComboBox2.FlatStyle = FlatStyle.Flat

        DateSet()

        Label1.Text = "1 USD"
    End Sub

    Private Sub AddList(currency As List(Of Item), currency2 As List(Of Item))
        currency.Add(New Item(prize:=1, id:="USD"))
        currency.Add(New Item(prize:=0.9135, id:="EUR"))
        currency.Add(New Item(prize:=56.2983, id:="MKD"))
        currency.Add(New Item(prize:=107.1508, id:="RSD"))
        currency.Add(New Item(prize:=98.7278, id:="ALL"))
        currency.Add(New Item(prize:=1.7867, id:="BAM"))
        currency.Add(New Item(prize:=1.7867, id:="BNG"))
        currency.Add(New Item(prize:=4.5311, id:="RON"))
        currency.Add(New Item(prize:=0.8939, id:="CHF"))
        currency.Add(New Item(prize:=10.643, id:="SEK"))

        currency2.Add(New Item(prize:=1, id:="USD"))
        currency2.Add(New Item(prize:=0.9135, id:="EUR"))
        currency2.Add(New Item(prize:=56.2983, id:="MKD"))
        currency2.Add(New Item(prize:=107.1508, id:="RSD"))
        currency2.Add(New Item(prize:=98.7278, id:="ALL"))
        currency2.Add(New Item(prize:=1.7867, id:="BAM"))
        currency2.Add(New Item(prize:=1.7867, id:="BNG"))
        currency2.Add(New Item(prize:=4.5311, id:="RON"))
        currency2.Add(New Item(prize:=0.8939, id:="CHF"))
        currency2.Add(New Item(prize:=10.643, id:="SEK"))
    End Sub

    Private Sub Logic()
        TextBox1.Update()
        Dim num As Integer = Val(TextBox1.Text)
        Dim result As Double = (num / conv1) * conv2
        Dim text As String = result.ToString

        If result.ToString.Contains(",") Then
            Label1.Text = text.Substring(0, text.IndexOf(",") + 3)
        Else
            Label1.Text = text
        End If
        Label1.Text += " " & nameAux
    End Sub

    Private Sub DateSet()
        Dim dateAux As String = "18/06/2023"
        Label4.Text = "Last Update: " + dateAux
    End Sub

    Private Sub ComboBox1_DrawItem(sender As Object, e As DrawItemEventArgs) Handles ComboBox1.DrawItem
        If e.Index >= 0 Then
            Dim text As String = ComboBox1.Items(e.Index).ToString()
            Dim flag As Image = My.Resources.ResourceManager.GetObject(text.ToLower)
            Dim resizedFlag As New Bitmap(flag, 22, 15)

            'e.DrawBackground()
            e.Graphics.DrawImage(resizedFlag, e.Bounds.Left, e.Bounds.Top)
            e.Graphics.DrawString(text, ComboBox1.Font, Brushes.Black, e.Bounds.Left + resizedFlag.Width, e.Bounds.Top + (e.Bounds.Height - ComboBox1.Font.Height) / 2)
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim aux As Item = ComboBox1.SelectedItem
        conv1 = aux.Prize
        Logic()
    End Sub

    Private Sub ComboBox2_DrawItem(sender As Object, e As DrawItemEventArgs) Handles ComboBox2.DrawItem
        If e.Index >= 0 Then
            Dim texto As String = ComboBox2.Items(e.Index).ToString()
            Dim flag As Image = My.Resources.ResourceManager.GetObject(texto.ToLower)
            Dim resizedFlag As New Bitmap(flag, 22, 15)

            'e.DrawBackground()
            e.Graphics.DrawImage(resizedFlag, e.Bounds.Left, e.Bounds.Top)
            e.Graphics.DrawString(texto, ComboBox2.Font, Brushes.Black, e.Bounds.Left + resizedFlag.Width, e.Bounds.Top + (e.Bounds.Height - ComboBox2.Font.Height) / 2)
        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        Dim aux As Item = ComboBox2.SelectedItem
        conv2 = aux.Prize
        nameAux = aux.Id
        Logic()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim num As Integer = Val(TextBox1.Text)
        Dim result As Double = (num / conv1) * conv2
        Dim text As String = result.ToString

        If result.ToString.Contains(",") Then
            Label1.Text = text.Substring(0, text.IndexOf(",") + 3)
        Else
            Label1.Text = text
        End If
        Label1.Text += " " & nameAux
    End Sub

    Private Sub TextBox1_GotFocus(sender As Object, e As EventArgs) Handles TextBox1.GotFocus
        If TextBox1.Text = textAux Then
            TextBox1.Text = ""
        End If
    End Sub

    Private Sub TextBox1_LostFocus(sender As Object, e As EventArgs) Handles TextBox1.LostFocus
        If String.IsNullOrWhiteSpace(TextBox1.Text) Then
            TextBox1.Text = textAux
        End If
    End Sub

    Private Sub textBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        ' Verificar si el carácter ingresado es numérico
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True ' Ignorar el carácter no numérico
        End If
    End Sub

    Private Sub TextBox1_Click(sender As Object, e As EventArgs) Handles TextBox1.Click
        TextBox1.Text = String.Empty
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1_Click(sender, e)
        End If
    End Sub

    Private Sub textBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Logic()
    End Sub

    Private Sub Label1_SizeChanged(sender As Object, e As EventArgs) Handles Label1.SizeChanged
        Label1.Left = (Me.ClientSize.Width - Label1.Width) \ 2
        Label1.Top = ((Me.ClientSize.Height - Label1.Height) \ 2) + 35
    End Sub

End Class

Public Class Item
    Public Property Prize As Double
    Public Property Id As String

    Public Sub New(id As String, prize As Double)
        Me.Prize = prize
        Me.Id = id
    End Sub

    Public Overrides Function ToString() As String
        Return Id
    End Function
End Class
