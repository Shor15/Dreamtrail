Public Class LevelOneIntrod
    Inherits BaseScreen
    Dim text As String = "Press SPACE to jump"
    Dim text2 As String = "Press ESC to go back to Main Menu"

    Public Sub New()
        Name = "LevelOneIntrod"
        State = ScreenState.Active
    End Sub



    Public Overrides Sub Update()
        PlayerGame.speed = 3
        PlayerGame.charPos = New Vector2(120, 312)
        PlayerGame.charPos2 = New Vector2(120, 312)
        PlayerGame.boxPos = New Vector2(800, 320)
        PlayerGame.boxPos2 = New Vector2(800, 320)
        PlayerGame.charBounds = New Rectangle(PlayerGame.charPos.X - Textures.char1.Width / 2, PlayerGame.charPos.Y - Textures.char1.Height / 2, Textures.char1.Width, Textures.char1.Height)
        PlayerGame.boxBounds = New Rectangle(PlayerGame.boxPos.X - Textures.box.Width / 2, PlayerGame.boxPos.Y - Textures.box.Height / 2, Textures.box.Width, Textures.box.Height)
        PlayerGame.bgPos = New Vector2(PlayerGame.bgPos.X - PlayerGame.speed, PlayerGame.bgPos.Y)
        PlayerGame.bgPos2 = New Vector2(PlayerGame.bgPos.X + Textures.bg_nivel1.Width, 0)
        PlayerGame.boxPos3 = New Vector2(950, 320)
        PlayerGame.boxBounds2 = New Rectangle(PlayerGame.boxPos3.X - Textures.box.Width / 2, PlayerGame.boxPos3.Y - Textures.box.Height / 2, Textures.box.Width, Textures.box.Height)
        PlayerGame.starPos = New Vector2(PlayerGame.starPos.X - PlayerGame.speed, PlayerGame.starPos.Y)
        PlayerGame.starBounds = New Rectangle(PlayerGame.starPos.X - PlayerGame.speed, PlayerGame.starPos.Y, Textures.star.Width, Textures.star.Height)
        If (PlayerGame.bgPos.X + Textures.bg_nivel1.Width <= 0) Then
            PlayerGame.bgPos.X = PlayerGame.bgPos2.X
        End If
        PlayerGame.score = 0
    End Sub

    Public Overrides Sub HandleInput()
        If (Input.KeyPressed(Keys.Enter)) Then
            ScreenManager.UnloadScreen("LevelOneIntrod")
            ScreenManager.AddScreen(New PlayerGame())
        End If
    End Sub

    Public Overrides Sub Draw()
        MyBase.Draw()

        Globals.SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone)
        Globals.SpriteBatch.DrawString(Fonts.Georgia_16, text2, New Vector2(380, 340), Color.White)
        Globals.SpriteBatch.Draw(Textures.howto, New Rectangle(400 - Textures.howto.Width / 2, 200 - Textures.howto.Height / 2, Textures.howto.Width, Textures.howto.Height), Color.White)
        Globals.SpriteBatch.DrawString(Fonts.Georgia_16, text, New Vector2(380, 300), Color.White)
        Globals.SpriteBatch.DrawString(Fonts.Georgia_16, "Press ENTER to play", New Vector2(380, 380), Color.White)
        Globals.SpriteBatch.End()
    End Sub


End Class
