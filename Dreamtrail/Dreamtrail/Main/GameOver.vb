Public Class GameOver
    Inherits BaseScreen
    Public Sub New()
        Name = "GameOver"
        State = ScreenState.Active
    End Sub

    Public Overrides Sub Update()

    End Sub

    Public Overrides Sub HandleInput()
        If (Input.KeyPressed(Keys.Escape)) Then
            ScreenManager.UnloadScreen("PlayerGame")
            ScreenManager.UnloadScreen("GameOver")
            ScreenManager.AddScreen(New TitleScreen())
            ScreenManager.AddScreen(New MainMenu())
        End If
    End Sub

    Public Overrides Sub Draw()
        MyBase.Draw()

        Globals.SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone)
        Globals.SpriteBatch.Draw(Textures.GameEnd, New Rectangle(400 - Textures.GameEnd.Width / 2, 300 - Textures.GameEnd.Height / 2, Textures.GameEnd.Width, Textures.GameEnd.Height), Color.White)
        Globals.SpriteBatch.DrawString(Fonts.Georgia_16, "Press ESC to return to Main Menu", New Vector2(230, 400), Color.White)
        Globals.SpriteBatch.DrawString(Fonts.Georgia_16, "Your score is: " + PlayerGame.score.ToString + "!", New Vector2(300, 200), Color.White)
        Globals.SpriteBatch.End()
    End Sub


End Class
