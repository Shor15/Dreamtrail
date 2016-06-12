Public Class PlayerGame
    Inherits BaseScreen

    Public Shared bgPos As Vector2 = New Vector2(0, 0)
    Public Shared bgPos2 As Vector2 = New Vector2(bgPos.X + Textures.bg_nivel1.Width, 0)
    Public Shared speed As Integer = 3
    Public Shared time As Integer = 0
    Public Shared charPos As Vector2 = New Vector2(120, 312)
    Public Shared charPos2 As Vector2 = New Vector2(120, 312)
    Public Shared boxPos As Vector2 = New Vector2(950, 320)
    Public Shared boxPos2 As Vector2 = New Vector2(950, 320)
    Public Shared boxPos3 As Vector2 = New Vector2(800, 320)
    Public Shared boxPos4 As Vector2 = New Vector2(800, 320)
    Public Shared charBounds As New Rectangle(charPos.X - Textures.char1.Width / 2, charPos.Y - Textures.char1.Height / 2, Textures.char1.Width, Textures.char1.Height)
    Public Shared boxBounds As New Rectangle(boxPos.X - Textures.box.Width / 2, boxPos.Y - Textures.box.Height / 2, Textures.box.Width, Textures.box.Height)
    Public Shared boxBounds2 As New Rectangle(boxPos3.X - Textures.box.Width / 2, boxPos3.Y - Textures.box.Height / 2, Textures.box.Width, Textures.box.Height)
    Public Shared starPos As Vector2 = New Vector2(950, 240)
    Public Shared starBounds As Rectangle = New Rectangle(starPos.X - Textures.star.Width, starPos.Y, Textures.star.Width, Textures.star.Height)
    Dim jumping As Boolean
    Dim startY As Single = charPos.Y
    Dim jumpspeed As Single = 0
    Dim runspeed As Integer = 0
    Public Shared score As Double = 0
    Dim timer As Integer = 0
    Dim timer2 As Integer = 0
    Dim timer3 As Integer = 0
    Dim random As Integer = CInt(Int((301 * Rnd()) + 250))


    Public Sub New()
        Name = "PlayerGame"
        State = ScreenState.Active
    End Sub

    Public Overrides Sub Load()

    End Sub

    Public Overrides Sub Update()
        bgPos = New Vector2(bgPos.X - speed, bgPos.Y)
        bgPos2 = New Vector2(bgPos.X + Textures.bg_nivel1.Width, 0)
        If (bgPos.X + Textures.bg_nivel1.Width <= 0) Then
            bgPos.X = bgPos2.X
        End If

        random = (301 * Rnd()) + 250

        runspeed += 1
        timer2 += 1
        timer += 1
        If (timer Mod 20 = 0) Then
            score += 1
            timer = 0
        End If
        If (runspeed = 10) Then
            If (charPos2.Y = 312) Then
                charPos2.Y = 313
                runspeed = 0
            ElseIf (charPos2.Y = 313) Then
                charPos2.Y = 312
                runspeed = 0
            End If
        End If



        If (timer2 Mod 1800 = 0) Then
            speed += 0.5
            timer2 = 0
            runspeed += 0.1
        End If


        charBounds = New Rectangle(charPos.X - Textures.char1.Width / 2, charPos.Y - Textures.char1.Height / 2, Textures.char1.Width, Textures.char1.Height)

        starPos = New Vector2(starPos.X - speed, starPos.Y)
        starBounds = New Rectangle(starPos.X - speed, starPos.Y, Textures.star.Width, Textures.star.Height)
        If (starPos.X + Textures.star.Width <= 0) Then
            Randomize()
            starPos.X = 800 + random
        End If

        If (starBounds.Intersects(charBounds)) Then
            score += 20
            starPos.X = 800 + random
        End If


        boxPos = New Vector2(boxPos.X - speed, boxPos.Y)
        If (boxPos.X + Textures.box.Width <= 0) Then
            If (timer3 Mod 240 = 0) Then
                Randomize()
                random = (301 * Rnd()) + 250
                boxPos.X = 800 + random
            End If
        End If

        boxBounds = New Rectangle(boxPos.X - Textures.box.Width / 2 + 2, boxPos.Y - Textures.box.Height / 2, Textures.box.Width - 2, Textures.box.Height)

        If (charBounds.Intersects(boxBounds)) Then
            ScreenManager.UnloadScreen("PlayerGame")
            ScreenManager.AddScreen(New GameOver())
            speed = 0
            jumpspeed = 0

        End If

        boxPos3 = New Vector2(boxPos3.X - speed, boxPos3.Y)
        If (boxPos3.X + Textures.box.Width <= 0) Then
            boxPos3.X = 800
            timer3 = 0
        End If
        If (boxPos3.X + Textures.box.Width <= 800) Then
            timer3 += 1
        End If
        boxBounds2 = New Rectangle(boxPos3.X - Textures.box.Width / 2 + 2, boxPos3.Y - Textures.box.Height / 2, Textures.box.Width - 2, Textures.box.Height)

        If (charBounds.Intersects(boxBounds2)) Then
            ScreenManager.UnloadScreen("PlayerGame")
            ScreenManager.AddScreen(New GameOver())
            speed = 0
            jumpspeed = 0
        End If

        If jumping Then
            charPos2.Y = 312
            charPos.Y += jumpspeed
            jumpspeed += 0.45
            If charPos.Y >= startY Then
                charPos.Y = startY
                jumping = False
            End If
        Else

            If Input.KeyDown(Keys.Space) Then
                jumping = True
                jumpspeed = -11
            End If
        End If

        If Input.KeyPressed(Keys.Escape) Then

            ScreenManager.UnloadScreen("PlayerGame")
            ScreenManager.AddScreen(New TitleScreen())
            ScreenManager.AddScreen(New MainMenu())
        End If
    End Sub


    Public Overrides Sub Draw()
        Globals.SpriteBatch.Begin()
        Globals.SpriteBatch.Draw(Textures.bg_nivel1, bgPos, Color.White)
        Globals.SpriteBatch.Draw(Textures.bg_nivel1, bgPos2, Color.White)
        Globals.SpriteBatch.Draw(Textures.box, boxPos3, Color.White)
        Globals.SpriteBatch.Draw(Textures.star, starPos, Color.White)

        If (boxBounds2.Intersects(boxBounds) = False) Then
            Globals.SpriteBatch.Draw(Textures.box, boxPos, Color.White)
        End If

        If (charPos2.Y = 312) Then
            Globals.SpriteBatch.Draw(Textures.char1, charPos, Color.White)
        ElseIf (charPos2.Y = 313) Then
            Globals.SpriteBatch.Draw(Textures.char2, charPos, Color.White)
        End If
        Globals.SpriteBatch.DrawString(Fonts.Georgia_16, "Score: " + score.ToString, New Vector2(700, 20), Color.Black)

        Globals.SpriteBatch.End()

    End Sub
End Class
