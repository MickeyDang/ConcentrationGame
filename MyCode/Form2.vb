Public Class Form2
    Dim Cardprop(13) As Integer 'array element is the card number.  The value of the element is the card type (ie ace of hearts)
    Dim cardval(6) As Integer ' array element is just element.  The value is a number corresponding to the type of card (ie 3 of hearts)
    Dim cardhistory(13) As Integer 'array stores the element numbers of cardprop that are assigned values on form load. this is to prevent overwrites
    Dim matchhistory(1) As Integer ' this is supposed to store the values of player's 1st and 2nd card
    Dim turn(0) As Integer
    Dim cardtoflip(1) As Integer ' this stores the 2 cards that are wrong and must be flipped back
    Dim cardnotpick(13) As Integer ' This array stores all the cards (actual location not val) that are flipped over and therefore can't be re-selected

    Dim player1 As String = Form1.TextBox1.Text
    Dim player2 As String = Form1.TextBox2.Text
    Dim turnp1 As String = "Turn: " & player1
    Dim turnp2 As String = "Turn: " & player2
    Dim time As New DateTime  ' this is similar to my racegame code.  I need it to time how long my annimation works

    Sub thumbs(ByVal A As Integer)
        If A = 1 Then
            time = DateTime.Now
            Timer1.Start()
        End If
        If A = 2 Then
            time = DateTime.Now
            Timer2.Start()
        End If
    End Sub

    Sub ifcardnotmatch(ByVal selected As Integer, ByVal selected2 As Integer) ' this runs if the two cards dont match
        Call thumbs(2)
        MessageBox.Show("Wrong!")

        Dim card1 As Object
        Dim card2 As Object

        Select Case selected - 1
            Case 0
                card1 = PB1
            Case 1
                card1 = PB2
            Case 2
                card1 = PB3
            Case 3
                card1 = PB4
            Case 4
                card1 = PB5
            Case 5
                card1 = PB6
            Case 6
                card1 = PB7
            Case 7
                card1 = PB8
            Case 8
                card1 = PB9
            Case 9
                card1 = PB10
            Case 10
                card1 = PB11
            Case 11
                card1 = PB12
            Case 12
                card1 = PB13
            Case 13
                card1 = PB14

        End Select

        Select Case selected2 - 1
            Case 0
                card2 = PB1
            Case 1
                card2 = PB2
            Case 2
                card2 = PB3
            Case 3
                card2 = PB4
            Case 4
                card2 = PB5
            Case 5
                card2 = PB6
            Case 6
                card2 = PB7
            Case 7
                card2 = PB8
            Case 8
                card2 = PB9
            Case 9
                card2 = PB10
            Case 10
                card2 = PB11
            Case 11
                card2 = PB12
            Case 12
                card2 = PB13
            Case 13
                card2 = PB14
        End Select

        card1.Image = My.Resources.Back
        card2.Image = My.Resources.Back
    End Sub

    Sub ifcardmatch(ByVal Selected As Integer, ByVal card1or2 As Integer) 'runs if the two cards match
        Static a As Integer
        Static b As Integer

        If cardtoflip(0) <> 0 And cardtoflip(1) <> 0 Then
            cardtoflip(0) = 0
            cardtoflip(1) = 0
        End If

        If cardtoflip(0) = 0 Then
            cardtoflip(0) = Selected
        ElseIf cardtoflip(0) <> 0 And cardtoflip(1) = 0 Then
            cardtoflip(1) = Selected
        End If

        'If cardtoflip(0) = cardtoflip(1) Then
        '    MessageBox.Show("You can't pick the same card!")
        '    Exit Sub
        'End If

        If matchhistory(0) <> 0 And matchhistory(1) <> 0 Then
            ReDim matchhistory(1)
        End If

        matchhistory(card1or2) = Cardprop(Selected - 1)

        If matchhistory(0) <> matchhistory(1) And matchhistory(0) <> 0 And matchhistory(1) <> 0 Then
            Call ifcardnotmatch(cardtoflip(0), cardtoflip(1))
        End If

        If matchhistory(0) = matchhistory(1) And Label3.Text = turnp1 Then
            a += 1
            Label7.Text = Form1.TextBox1.Text & ":" & " " & a
            Call thumbs(1)
        ElseIf matchhistory(0) = matchhistory(1) And Label3.Text = turnp2 Then
            b += 1
            Label8.Text = Form1.TextBox2.Text & ":" & " " & b
            Call thumbs(1)
        End If

        If b + a = 7 Then
            If b > a Then
                MessageBox.Show("Good job " & Form1.TextBox2.Text & "!" & vbCrLf & "Care to play again?")
                RadioButton1.Checked = False
                RadioButton2.Checked = False
                RadioButton3.Checked = False
                Me.Close()
            ElseIf b < a Then
                MessageBox.Show("Good job " & Form1.TextBox1.Text & "!" & vbCrLf & "Care to play again?")
                RadioButton1.Checked = False
                RadioButton2.Checked = False
                RadioButton3.Checked = False
                Me.Close()
            End If
        End If

        'this code will make it run once when i need it to run twice when two cards match
        'as a result, it'll only give one index of cardnotpick a value when i need it to block two cards it'll block one
        If matchhistory(0) = matchhistory(1) And matchhistory(0) <> 0 And matchhistory(1) <> 0 Then
            If cardnotpick(0) = 0 And cardnotpick(1) = 0 Then
                cardnotpick(0) = cardtoflip(0)
                cardnotpick(1) = cardtoflip(1)
            ElseIf cardnotpick(2) = 0 And cardnotpick(3) = 0 Then
                cardnotpick(2) = cardtoflip(0)
                cardnotpick(3) = cardtoflip(1)
            ElseIf cardnotpick(4) = 0 And cardnotpick(5) = 0 Then
                cardnotpick(4) = cardtoflip(0)
                cardnotpick(5) = cardtoflip(1)
            ElseIf cardnotpick(6) = 0 And cardnotpick(7) = 0 Then
                cardnotpick(6) = cardtoflip(0)
                cardnotpick(7) = cardtoflip(1)
            ElseIf cardnotpick(8) = 0 And cardnotpick(9) = 0 Then
                cardnotpick(8) = cardtoflip(0)
                cardnotpick(9) = cardtoflip(1)
            ElseIf cardnotpick(10) = 0 And cardnotpick(11) = 0 Then
                cardnotpick(10) = cardtoflip(0)
                cardnotpick(11) = cardtoflip(1)
            ElseIf cardnotpick(12) = 0 And cardnotpick(13) = 0 Then
                cardnotpick(12) = cardtoflip(0)
                cardnotpick(13) = cardtoflip(1)
            End If
        End If
    End Sub
    Sub turnchange(ByVal clicks As Integer)
        If clicks = 2 And turn(0) = 0 Then
            Label3.Text = turnp2
        ElseIf clicks = 2 And turn(0) = 1 Then
            Label3.Text = turnp1
        ElseIf clicks = 4 And turn(0) = 0 Then
            Label3.Text = turnp1
        ElseIf clicks = 4 And turn(0) = 1 Then
            Label3.Text = turnp2
        End If
    End Sub

    Sub startturn()

        Randomize()
        turn(0) = Rnd()

        If turn(0) = 0 Then
            Label3.Text = turnp1
        ElseIf turn(0) = 1 Then
            Label3.Text = turnp2
        End If
    End Sub

    Sub ARYtoCARD(ByVal num As Integer) 'this converts the array "cardprop" and its values into actual cards.  This is called on button click
        Dim handledcard As Object

        Select Case num
            Case 1
                handledcard = PB1
            Case 2
                handledcard = PB2
            Case 3
                handledcard = PB3
            Case 4
                handledcard = PB4
            Case 5
                handledcard = PB5
            Case 6
                handledcard = PB6
            Case 7
                handledcard = PB7
            Case 8
                handledcard = PB8
            Case 9
                handledcard = PB9
            Case 10
                handledcard = PB10
            Case 11
                handledcard = PB11
            Case 12
                handledcard = PB12
            Case 13
                handledcard = PB13
            Case 14
                handledcard = PB14
        End Select

        'If cardtoflip(0) = num Then
        '    handledcard.image = My.Resources.Back
        '    Exit Sub
        'End If

        Select Case Cardprop(num - 1)
            Case 0
                handledcard.image = My.Resources.Ace_diamonds
            Case 1
                handledcard.image = My.Resources.Ace_clubs
            Case 2
                handledcard.image = My.Resources.Ace_hearts
            Case 3
                handledcard.image = My.Resources.Ace_spades
            Case 4
                handledcard.image = My.Resources.threehearts
            Case 5
                handledcard.image = My.Resources.fivespade
            Case 6
                handledcard.image = My.Resources.sixclub
            Case 7
                handledcard.image = My.Resources.sevenclubs
            Case 8
                handledcard.image = My.Resources.tendiamonds
            Case 9
                handledcard.image = My.Resources.Jack_diamond
            Case 10
                handledcard.image = My.Resources.Queen_Club
            Case 11
                handledcard.image = My.Resources.King_diamond
            Case 12
                handledcard.image = My.Resources.tenhearts
        End Select
    End Sub

    Sub ValtoCard(ByVal A As Integer, ByVal B As Integer)

        Dim cardpos As Integer

        Randomize()
        cardpos = Rnd() * 13

        'The if statements below leave a problem.  The last number left in cardhistory starts as a 0 (be default) 
        'So if 0 is the only index of cardprop available but my if statements doesnt allow cardpos to be any cardhistory number
        'There is a problem of infinite loop because the only number left is 0 but it can't equal 0 because 0 is cardhistory(9) by default
        'This if statement fixes that problem and ends the sub to prevent the remaining lines from executing.
        If cardhistory(0) <> 0 And cardhistory(1) <> 0 And cardhistory(2) <> 0 And cardhistory(3) <> 0 And cardhistory(4) <> 0 And _
            cardhistory(5) <> 0 And cardhistory(6) <> 0 And cardhistory(7) <> 0 And cardhistory(8) <> 0 And cardhistory(9) <> 0 And cardhistory(10) <> 0 And cardhistory(11) <> 0 And cardhistory(12) <> 0 Then
            cardhistory(13) = 0
            Cardprop(0) = cardval(B)
            Exit Sub
        End If

        'This prevents cardpos from overwritting an element of cardprop (in case the rnd generates a number twice)
        'it makes it check with "card history" so if the cardposition has been previously used it will repeat and keep generating a value until it does not equal any number
        If cardpos <> cardhistory(0) And cardpos <> cardhistory(1) And cardpos <> cardhistory(2) And cardpos <> cardhistory(3) _
            And cardpos <> cardhistory(4) And cardpos <> cardhistory(5) And cardpos <> cardhistory(6) And cardpos <> cardhistory(7) _
            And cardpos <> cardhistory(8) And cardpos <> cardhistory(9) And cardpos <> cardhistory(10) And cardpos <> cardhistory(11) And cardpos <> cardhistory(12) And cardpos <> cardhistory(13) Then

            cardhistory(A) = cardpos
            Cardprop(cardpos) = cardval(B)
        Else
            Call ValtoCard(A, B)
        End If
    End Sub

    Private Sub BackToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub InstructionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InstructionsToolStripMenuItem.Click
        MessageBox.Show("Each player alternates turns." & vbCrLf & "Select a card by clicking on a card." & vbCrLf & "Once the card flips up, you click another card to try and match." & vbCrLf & "The person with the most pairs in the end wins." & vbCrLf & "Goodluck! Be Brave! Don't fail me!")
    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Annimation.Visible = False
        PB1.Image = My.Resources.Back
        PB2.Image = My.Resources.Back
        PB3.Image = My.Resources.Back
        PB4.Image = My.Resources.Back
        PB5.Image = My.Resources.Back
        PB6.Image = My.Resources.Back
        PB7.Image = My.Resources.Back
        PB8.Image = My.Resources.Back
        PB9.Image = My.Resources.Back
        PB10.Image = My.Resources.Back
        PB11.Image = My.Resources.Back
        PB12.Image = My.Resources.Back
        PB13.Image = My.Resources.Back
        PB14.Image = My.Resources.Back

        Label7.Text = Form1.TextBox1.Text & ":"
        Label8.Text = Form1.TextBox2.Text & ":"
        Dim n As Integer = 0
        Dim a As Integer = 0

        Call startturn() ' decide's which player starts first

        'This for next will generate the card for each of the 5 pairs

        For repeat2 As Integer = 0 To 6
            Dim genval As Integer
            Randomize()
            genval = Rnd() * 12
            If genval <> cardval(0) And genval <> cardval(1) And genval <> cardval(2) And genval <> cardval(3) And genval <> cardval(4) And genval <> cardval(5) And genval <> cardval(6) Then
                cardval(repeat2) = genval
            Else
                cardval(repeat2) = Nothing
                repeat2 -= 1
            End If
        Next


        'This will assign the card values to a number from 0 to 9 (corresponds to the position of cards on form)
        For repeat As Integer = 0 To 13

            Call ValtoCard(repeat, n)

            If repeat <= 5 Then
                n += 1
            ElseIf repeat = 6 Then
                n = n
            ElseIf repeat > 5 Then
                n -= 1
            End If
        Next

        MessageBox.Show("Each player alternates turns." & vbCrLf & "Select a card by clicking on a card." & vbCrLf & "Once the card flips up, you click another card to try and match." & vbCrLf & "The person with the most pairs in the end wins." & vbCrLf & "Goodluck! Be Brave! Don't fail me!")
    End Sub

   Sub PBClick(ByVal num As Integer)
        Static clicks As Integer 'this will be used in all 18 card clicks (goes into a sub where the value determines who's turn it is)
        Static card12 As Integer

        If num = cardnotpick(0) Or num = cardnotpick(1) Or num = cardnotpick(2) Or num = cardnotpick(3) _
            Or num = cardnotpick(4) Or num = cardnotpick(5) Or num = cardnotpick(6) Or num = cardnotpick(7) _
            Or num = cardnotpick(8) Or num = cardnotpick(9) Or num = cardnotpick(10) Or num = cardnotpick(11) _
            Or num = cardnotpick(12) Or num = cardnotpick(13) Then
            MessageBox.Show("This card is already face up! Pick another!")
            Exit Sub
        End If

        clicks += 1
        Call ARYtoCARD(num)
        Call ifcardmatch(num, card12)

        'If cardtoflip(0) = cardtoflip(1) Then
        '    Exit Sub
        'End If

        Call turnchange(clicks)
        If card12 < 1 Then
            card12 += 1
        Else
            card12 = 0
        End If
        If clicks = 4 Then
            clicks = 0
        End If
    End Sub

    Private Sub PB1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB1.Click
        Call PBClick(1)
    End Sub

    Private Sub PB2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB2.Click
        Call PBClick(2)
    End Sub

    Private Sub PB3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB3.Click
        Call PBClick(3)
    End Sub

    Private Sub PB4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB4.Click
        Call PBClick(4)
    End Sub

    Private Sub PB5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB5.Click
        Call PBClick(5)
    End Sub

    Private Sub PB6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB6.Click
        Call PBClick(6)
    End Sub

    Private Sub PB7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB7.Click
        Call PBClick(7)
    End Sub

    Private Sub PB8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB8.Click
        Call PBClick(8)
    End Sub

    Private Sub PB9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB9.Click
        Call PBClick(9)
    End Sub

    Private Sub PB10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB10.Click
        Call PBClick(10)
    End Sub

    Private Sub PB11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB11.Click
        Call PBClick(11)
    End Sub

    Private Sub PB12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB12.Click
        Call PBClick(12)
    End Sub

    Private Sub PB13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB13.Click
        Call PBClick(13)
    End Sub

    Private Sub PB14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB14.Click
        Call PBClick(14)
    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click
        MessageBox.Show(Cardprop(0) & vbCrLf & Cardprop(1) & vbCrLf & Cardprop(2) & vbCrLf & Cardprop(3) & vbCrLf & Cardprop(4) & vbCrLf & Cardprop(5) & vbCrLf & Cardprop(6) & vbCrLf & Cardprop(7) & vbCrLf & Cardprop(8) & vbCrLf & Cardprop(9) & vbCrLf & Cardprop(10) & vbCrLf & Cardprop(11) & vbCrLf & Cardprop(12) & vbCrLf & Cardprop(13))
    End Sub

    Private Sub CheatHintsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheatHintsToolStripMenuItem.Click
        MessageBox.Show("click on the name of the game developer and you will find some 'useful' information" & vbCrLf & "(if only you knew what it meant =P )")
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            My.Computer.Audio.Play(My.Resources.Original_Tetris_Theme___Extended_10min_1_, AudioPlayMode.BackgroundLoop)
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            My.Computer.Audio.Play(My.Resources.Pokemon_Diamond_Pearl_Platinum___Solaceon_Town_Mus, AudioPlayMode.BackgroundLoop)
        End If
    End Sub

    Private Sub RadioButton3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton3.CheckedChanged
        If RadioButton3.Checked = True Then
            My.Computer.Audio.Play(My.Resources.Mario_Kart_Theme_tune, AudioPlayMode.BackgroundLoop)
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Annimation.Visible = True
        Annimation.Image = My.Resources.thumbsup
        Dim DIF As TimeSpan = DateTime.Now - time

        If DIF.Seconds >= 1 Then
            Annimation.Visible = False
            Annimation.Image = Nothing
            Timer1.Stop()
        End If
    End Sub

    Private Sub Timer2_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Annimation.Visible = True
        Dim DIF As TimeSpan = DateTime.Now - time
        Annimation.Image = My.Resources.thumbsdown

        If DIF.Seconds >= 1 Then
            Annimation.Visible = False
            Annimation.Image = Nothing
            Timer2.Stop()
        End If
    End Sub
End Class
