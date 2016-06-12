Public Class Credits
    Inherits BaseScreen

    Public Sub New()
        Name = "Credits"
        State = ScreenState.Active
    End Sub

    Public Overrides Sub HandleInput()
        'MyBase.HandleInput()

    End Sub

    Public Overrides Sub Update()
        If Input.KeyPressed(Keys.Escape) Then
            ScreenManager.UnloadScreen("Credits")
            ScreenManager.AddScreen(New TitleScreen())
            ScreenManager.AddScreen(New MainMenu())
        End If
    End Sub

    Public Overrides Sub Draw()
        MyBase.Draw()

        Globals.SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone)
        Globals.SpriteBatch.DrawString(Fonts.Georgia_16, "TRUFAN ANDREEA", New Vector2(320, 200), Color.White)
        Globals.SpriteBatch.DrawString(Fonts.Georgia_16, "FIESC, CALCULATOARE", New Vector2(300, 240), Color.White)
        Globals.SpriteBatch.DrawString(Fonts.Georgia_16, "GRUPA 3121A", New Vector2(340, 280), Color.White)
        Globals.SpriteBatch.End()
    End Sub

    Public Overrides Sub Unload()
        MyBase.Unload()
    End Sub
End Class

