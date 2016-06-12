Public Class Fonts
    Public Shared Georgia_16 As SpriteFont

    Public Shared Sub Load()
        Georgia_16 = Globals.Content.Load(Of SpriteFont)("Fonts/Georgia_16")
    End Sub
End Class

