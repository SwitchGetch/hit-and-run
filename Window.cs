using SFML.Graphics;
using SFML.System;
using SFML.Window;

public static class Window
{
    public static RenderWindow RenderWindow = null;

    public static Vector2f Size = new Vector2f();

    public static CurrentWindow Current = CurrentWindow.Menu;
    public static Vector2f Center()
    {
        return Size / 2;
    }

    public static void Initialize(uint X, uint Y)
    {
        RenderWindow = new RenderWindow(new VideoMode(X, Y), "HIT AND RUN");
        Size = new Vector2f(X, Y);

        RenderWindow.SetFramerateLimit(60);

        RenderWindow.Closed += Event.OnClose;
    }
}

public static class Event
{
    public static void OnClose(object sender, EventArgs e) => Window.RenderWindow.Close();

    public static void OnMenuMouseButtonPressed(object sender, EventArgs e)
    {
        if (Buttons.START.CheckCollisionWithMouse())
        {
            Sounds.ButtonPress.Play();

            Window.Current = CurrentWindow.Game;
        }
    }

    public static void OnGameMouseButtonPressed(object sender, EventArgs e)
    {
        if (Mouse.IsButtonPressed(Mouse.Button.Left))
        {
            Bullets.New();
        }
    }

    public static void OnGameOverMouseButtonPressed(object sender, EventArgs e)
    {
        if (Buttons.YES.CheckCollisionWithMouse())
        {
            //Sounds.ButtonPress.Play();

            Window.Current = CurrentWindow.Menu;
        }
        else if (Buttons.NO.CheckCollisionWithMouse())
        {
            Sounds.Shot.Stop();
            Sounds.Hit.Stop();
            Sounds.GameOverMusic.Stop();

            Window.RenderWindow.Close();
        }
    }
}

public enum CurrentWindow
{
    Menu, Game, GameOver
}