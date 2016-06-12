Public Class MainScreen
    Inherits BaseScreen

    Public Shared bgPos As Vector2 = New Vector2(0, 0)
    Public Shared bgPos2 As Vector2 = New Vector2(bgPos.X + Textures.bg_nivel1.Width, 0)
    Public Shared speed As Integer = 1

    Public Sub New()
        Name = "MainScreen"
        State = ScreenState.Active
    End Sub

    Public Overrides Sub Update()

        bgPos = New Vector2(bgPos.X - speed, bgPos.Y)
        bgPos2 = New Vector2(bgPos.X + Textures.bg_nivel1.Width, 0)
        If (bgPos.X + Textures.bg_nivel1.Width = 0) Then
            bgPos.X = bgPos2.X
        End If
        'If (bgPos2.X = 0) Then

        'End If

    End Sub


    Public Overrides Sub Draw()
        Globals.SpriteBatch.Begin()
        Globals.SpriteBatch.Draw(Textures.bg_nivel1, bgPos, Color.White)
        Globals.SpriteBatch.Draw(Textures.bg_nivel1, bgPos2, Color.White)
        Globals.SpriteBatch.End()

    End Sub
End Class
