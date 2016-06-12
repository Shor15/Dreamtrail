Public Enum ScreenState
    Active
    ShutDown
    Hidden
End Enum

Public Class ScreenManager
    Private Shared Screens As New List(Of BaseScreen)
    Private Shared NewScreens As New List(Of BaseScreen)

    Public Sub New() 'Creaza o instanta noua de ScreenManager

    End Sub

    Public Sub Update()
        'Populeaza lista de screens care trebuie inchise
        Dim RemoveScreens As New List(Of BaseScreen)
        For Each FoundScreen As BaseScreen In Screens
            If (FoundScreen.State = ScreenState.ShutDown) Then
                RemoveScreens.Add(FoundScreen)
            Else : FoundScreen.Focused = False
            End If
        Next

        'Stergere propriu-zisa a screen-urilor
        For Each FoundScreen As BaseScreen In RemoveScreens
            Screens.Remove(FoundScreen)
        Next

        'Adaugare de screen-uri noi
        For Each FoundScreen As BaseScreen In NewScreens
            Screens.Add(FoundScreen)
        Next
        NewScreens.Clear()

        'Verifica focus-ul
        If Screens.Count > 0 Then
            For i = Screens.Count - 1 To 0 Step -1
                If (Screens(i).GrabFocus) Then
                    Screens(i).Focused = True
                    Exit For
                End If
            Next
        End If

        'Input-ul pentru screen - verifica starea screen-ului propriu zis (minimized, maximized)
        For Each FoundScreen As BaseScreen In Screens
            If Globals.WindowFocused Then
                FoundScreen.HandleInput()
            End If
            FoundScreen.Update()
        Next
    End Sub

    Public Sub Draw()
        For Each FoundScreen As BaseScreen In Screens
            If (FoundScreen.State = ScreenState.Active) Then
                FoundScreen.Draw()
            End If
        Next
    End Sub

    Public Shared Sub AddScreen(screen As BaseScreen)
        NewScreens.Add(screen)
    End Sub

    Public Shared Sub UnloadScreen(screen As String)
        For Each FoundScreen As BaseScreen In Screens
            If (FoundScreen.Name = screen) Then
                FoundScreen.Unload()
                Exit For
            End If
        Next

    End Sub

End Class
