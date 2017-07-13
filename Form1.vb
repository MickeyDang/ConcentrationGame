Public Class Form1
    Dim n As Integer
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = Nothing Then
            MessageBox.Show("Please input the names of both players")
        ElseIf TextBox2.Text = Nothing Then
            MessageBox.Show("Please input the names of both players")
        End If

        If RadioButton1.Checked = True Then
            Form2.Visible = True
            Form3.Close()
            Form4.Close()
        End If

        If RadioButton2.Checked = True Then
            Form3.Visible = True
            Form2.Close()
            Form4.Close()
        End If

        If RadioButton3.Checked = True Then
            Form4.Visible = True
            Form2.Close()
            Form3.Close()
        End If

        Timer1.Stop()
        PB1.Image = Nothing
        PB2.Image = Nothing
        PB3.Image = Nothing
        PB4.Image = Nothing
        PB5.Image = Nothing
        PB6.Image = Nothing
        Label4.Text = Nothing
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        n += 1

        Select Case n
            Case Is > 80
                PB1.Image = Nothing
                PB2.Image = Nothing
                PB3.Image = Nothing
                PB4.Image = Nothing
                PB5.Image = Nothing
                PB6.Image = Nothing
                Label4.Visible = False
                n = 0
            Case Is > 70
                Label4.Visible = True
            Case Is > 60
                PB6.Image = My.Resources.Back
            Case Is > 50
                PB5.Image = My.Resources.Back
            Case Is > 40
                PB4.Image = My.Resources.Back
            Case Is > 30
                PB3.Image = My.Resources.Back
            Case Is > 20
                PB2.Image = My.Resources.Back
            Case Is > 10
                PB1.Image = My.Resources.Back
        End Select
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Start()
    End Sub
End Class
