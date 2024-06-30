using SFML.System;
using SFML.Graphics;

public static class Menu
{
    public static void Start()
    {
        Window.RenderWindow.MouseButtonPressed += Event.OnMenuMouseButtonPressed;
        Sounds.MenuMusic.Play();

        Font Font = new Font("Fonts/impact.ttf");
        Text Text = new Text()
        {
            Font = Font,
            DisplayedString = "HIT AND RUN!",
            CharacterSize = 120,
            Position = new Vector2f(200, 100)
        };

        while (Window.RenderWindow.IsOpen && Window.Current == CurrentWindow.Menu)
        {
            Window.RenderWindow.DispatchEvents();

            Window.RenderWindow.Clear(new Color(56, 207, 209));

            Buttons.START.Draw();

            Window.RenderWindow.Draw(Text);

            Window.RenderWindow.Display();
        }

        if (Window.Current == CurrentWindow.Game)
        {
            Window.RenderWindow.MouseButtonPressed -= Event.OnMenuMouseButtonPressed;

            Sounds.MenuMusic.Stop();

            Game.Start();
        }
    }
}