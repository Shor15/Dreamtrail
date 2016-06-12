Public Class MainMenu
    Inherits BaseScreen
    Public Shared isExit = False
    Private Entries As New List(Of MenuEntry)
    Private MenuSelect As Integer = 0
    Private MenuSize As New Vector2(250, 160)
    Private MenuPos As New Vector2(400, 240)
    Public Sub New()
        Name = "MainMenu"
        State = ScreenState.Active

        AddEntry("New Game", True)
        AddEntry("Credits", True)
        AddEntry("Exit", True)
        'Textures.MenuMusic.Play()

    End Sub

    Public Sub AddEntry(text As String, enabled As Boolean)
        Dim Entry As MenuEntry
        Entry = New MenuEntry
        With Entry
            .Text = text
            .Enabled = enabled
        End With

        Entries.Add(Entry)

    End Sub

    Public Overrides Sub HandleInput()
        'MENU UP
        If Input.KeyPressed(Keys.Up) Or Input.KeyPressed(Keys.W) Then
            MenuSelect -= 1
            If (MenuSelect < 0) Then
                MenuSelect = Entries.Count - 1
            End If
            Do Until Entries(MenuSelect).Enabled = True
                MenuSelect -= 1
                If MenuSelect < 0 Then
                    MenuSelect = Entries.Count - 1
                End If
            Loop
        End If

        'MENU DOWN
        If Input.KeyPressed(Keys.Down) Or Input.KeyPressed(Keys.S) Then
            MenuSelect += 1
            If (MenuSelect > Entries.Count - 1) Then
                MenuSelect = 0
            End If
            Do Until Entries(MenuSelect).Enabled = True
                MenuSelect += 1
                If MenuSelect < Entries.Count Then
                    MenuSelect = 0
                End If
            Loop
        End If

        'SELECTAREA PROPRIU-ZISA

        If Input.KeyPressed(Keys.Enter) Then
            Select Case MenuSelect
                Case 0
                    ScreenManager.UnloadScreen("TitleScreen")
                    ScreenManager.UnloadScreen("MainMenu")
                    ScreenManager.AddScreen(New LevelOneIntrod())

                Case 1
                    ScreenManager.UnloadScreen("TitleScreen")
                    ScreenManager.UnloadScreen("MainMenu")
                    ScreenManager.AddScreen(New Credits())
                Case 2
                    isExit = True
            End Select
        End If
    End Sub

    Public Overrides Sub Draw()
        Globals.SpriteBatch.Begin()

        Dim MenuY As Integer = MenuPos.Y + 20

        For x = 0 To Entries.Count - 1
            If x = MenuSelect Then
                Dim MenuX As Integer = MenuPos.X - Fonts.Georgia_16.MeasureString(Entries.Item(x).Text).X / 2
                Globals.SpriteBatch.DrawString(Fonts.Georgia_16, Entries.Item(x).Text, New Vector2(MenuX, MenuY), Color.White)
            ElseIf Entries.Item(x).Enabled = True Then
                Dim MenuX As Integer = MenuPos.X - Fonts.Georgia_16.MeasureString(Entries.Item(x).Text).X / 2
                Globals.SpriteBatch.DrawString(Fonts.Georgia_16, Entries.Item(x).Text, New Vector2(MenuX, MenuY), Color.Gray)
            Else
                Dim MenuX As Integer = MenuPos.X - Fonts.Georgia_16.MeasureString(Entries.Item(x).Text).X / 2
                Globals.SpriteBatch.DrawString(Fonts.Georgia_16, Entries.Item(x).Text, New Vector2(MenuX, MenuY), Color.Red)
            End If

            MenuY += 30

        Next

        Globals.SpriteBatch.End()
    End Sub

End Class
