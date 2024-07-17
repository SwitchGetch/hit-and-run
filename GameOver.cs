using SFML.Graphics;
using SFML.System;

public static class GameOver
{
    public static void Start()
    {
        Window.RenderWindow.MouseButtonPressed += Event.OnGameOverMouseButtonPressed;

        if (Config.PlaySound) Sounds.GameOverMusic.Play();

        Font Font = new Font("Fonts/impact.ttf");
        Text Text = new Text() 
        {
            Font = Font,
            DisplayedString = "GAME OVER\nSCORE: " + Player.KilledEnemiesCount + "\nWANNA PLAY AGAIN?", 
            CharacterSize = 120, 
            Position = new Vector2f(20, 0)
        };

        while (Window.RenderWindow.IsOpen && Window.Current == CurrentWindow.GameOver)
        {
            Window.RenderWindow.DispatchEvents();

            Window.RenderWindow.Clear(Color.Red);

            Window.RenderWindow.Draw(Text);

            Buttons.YES.Draw();

            Buttons.NO.Draw();

            Window.RenderWindow.Display();
        }

        if (Window.Current == CurrentWindow.Menu)
        {
            Window.RenderWindow.MouseButtonPressed -= Event.OnGameOverMouseButtonPressed;

            Sounds.GameOverMusic.Stop();

            Menu.Start();
        }
    }
}
