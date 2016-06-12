Public Class Textures
    Public Shared background As Texture2D
    Public Shared titlu As Texture2D
    Public Shared bg_nivel1 As Texture2D
    Public Shared char1 As Texture2D
    Public Shared char2 As Texture2D
    Public Shared howto As Texture2D
    Public Shared box As Texture2D
    Public Shared GameEnd As Texture2D
    Public Shared star As Texture2D
    Public Shared MenuMusic As SoundEffect

    Public Shared Sub Load()
        background = Globals.Content.Load(Of Texture2D)("Resources/menu_bg1")
        titlu = Globals.Content.Load(Of Texture2D)("Resources/titlu")
        char1 = Globals.Content.Load(Of Texture2D)("Resources/sprite1")
        char2 = Globals.Content.Load(Of Texture2D)("Resources/sprite2")
        bg_nivel1 = Globals.Content.Load(Of Texture2D)("Resources/bg")
        howto = Globals.Content.Load(Of Texture2D)("Resources/howtoplay")
        box = Globals.Content.Load(Of Texture2D)("Resources/box")
        GameEnd = Globals.Content.Load(Of Texture2D)("Resources/gameover")
        star = Globals.Content.Load(Of Texture2D)("Resources/star")


    End Sub

End Class
