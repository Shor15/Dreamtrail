Public Class Game1
    Inherits Microsoft.Xna.Framework.Game
    Private ScreenManager As ScreenManager

    Private WithEvents graphics As GraphicsDeviceManager
    Private WithEvents spriteBatch As SpriteBatch


    Public Sub New()
        Globals.Graphics = New GraphicsDeviceManager(Me)
        Content.RootDirectory = "Content"
    End Sub

    ''' <summary>
    ''' Allows the game to perform any initialization it needs to before starting to run.
    ''' This is where it can query for any required services and load any non-graphic
    ''' related content.  Calling MyBase.Initialize will enumerate through any components
    ''' and initialize them as well.
    ''' </summary>
    Protected Overrides Sub Initialize()
        Me.IsMouseVisible = True
        ' TODO: Add your initialization logic here
        Window.AllowUserResizing = False

        Globals.GameSize = New Vector2(800, 600)
        Globals.Graphics.PreferredBackBufferWidth = Globals.GameSize.X
        Globals.Graphics.PreferredBackBufferHeight = Globals.GameSize.Y
        Globals.Graphics.ApplyChanges()

        Globals.BackBuffer = New RenderTarget2D(Globals.Graphics.GraphicsDevice, Globals.GameSize.X, Globals.GameSize.Y, False, SurfaceFormat.Color, DepthFormat.None)

        MyBase.Initialize()
    End Sub

    ''' <summary>
    ''' LoadContent will be called once per game and is the place to load
    ''' all of your content.
    ''' </summary>
    Protected Overrides Sub LoadContent()
        ' Create a new SpriteBatch, which can be used to draw textures.
        Globals.SpriteBatch = New SpriteBatch(GraphicsDevice)
        Globals.Content = Me.Content
        Fonts.Load()
        Textures.Load()

        ScreenManager = New ScreenManager()
        ScreenManager.AddScreen(New TitleScreen)
        ScreenManager.AddScreen(New MainMenu)



        ' TODO: use Me.Content to load your game content here
    End Sub

    ''' <summary>
    ''' UnloadContent will be called once per game and is the place to unload
    ''' all content.
    ''' </summary>
    Protected Overrides Sub UnloadContent()
        ' TODO: Unload any non ContentManager content here
    End Sub

    ''' <summary>
    ''' Allows the game to run logic such as updating the world,
    ''' checking for collisions, gathering input, and playing audio.
    ''' </summary>
    ''' <param name="gameTime">Provides a snapshot of timing values.</param>
    Protected Overrides Sub Update(ByVal gameTime As GameTime)
        ' Allows the game to exit
        If GamePad.GetState(PlayerIndex.One).Buttons.Back = ButtonState.Pressed Then
            Me.Exit()
        End If

        If (MainMenu.isExit = True) Then
            [Exit]()
        End If

        Globals.WindowFocused = Me.IsActive
        Globals.GameTime = gameTime
        ' TODO: Add your update logic here
        MyBase.Update(gameTime)

        ScreenManager.Update()

        'INPUT UPDATE
        Input.Update()

    End Sub

    ''' <summary>
    ''' This is called when the game should draw itself.
    ''' </summary>
    ''' <param name="gameTime">Provides a snapshot of timing values.</param>
    Protected Overrides Sub Draw(ByVal gameTime As GameTime)
        Globals.Graphics.GraphicsDevice.SetRenderTarget(Globals.BackBuffer)
        GraphicsDevice.Clear(Color.Black)

        ' TODO: Add your drawing code here
        MyBase.Draw(gameTime)

        ScreenManager.Draw()

        Globals.Graphics.GraphicsDevice.SetRenderTarget(Nothing)

        Globals.SpriteBatch.Begin()
        Globals.SpriteBatch.Draw(Globals.BackBuffer, New Rectangle(0, 0, Globals.Graphics.GraphicsDevice.Viewport.Width, Globals.Graphics.GraphicsDevice.Viewport.Height), Color.White)

        Globals.SpriteBatch.End()

    End Sub

End Class
