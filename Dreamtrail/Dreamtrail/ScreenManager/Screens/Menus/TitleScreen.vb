Public Class TitleScreen
    Inherits BaseScreen

    Public Sub New()
        Name = "TitleScreen"
        State = ScreenState.Active
    End Sub

    Public Overrides Sub HandleInput()
        'MyBase.HandleInput()

    End Sub

    Public Overrides Sub Update()

    End Sub

    Public Overrides Sub Draw()
        MyBase.Draw()

        Globals.SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone)
        Globals.SpriteBatch.Draw(Textures.background, New Rectangle(0, 0, 800, 600), Color.White)
        Globals.SpriteBatch.Draw(Textures.titlu, New Rectangle(Globals.GameSize.X / 2 - Textures.titlu.Width / 2, 200, Textures.titlu.Width, Textures.titlu.Height), Color.White)
        Globals.SpriteBatch.End()
    End Sub

    Public Overrides Sub Unload()
        MyBase.Unload()
    End Sub
End Class
