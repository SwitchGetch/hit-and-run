using SFML.Graphics;
using SFML.System;

public static class Game
{
    private static void NewGame()
    {
        Player.HP = Player.MaxHP;
        Player.Position = Window.Center();
        Player.KilledEnemiesCount = 0;

        Bullets.AllBullets = new List<Bullet>();

        Enemies.AllEnemies = new List<Enemy>();
        Enemies.MaxEnemyCount = 5;
    }

    public static void Start()
    {
        Window.RenderWindow.MouseButtonPressed += Event.OnGameMouseButtonPressed;

        //Sounds.GameMusic.Play();

        NewGame(); // reset in-game parameters

        Font Font = new Font("Fonts/impact.ttf");
        Text Text = new Text() { Font = Font };

        while (Window.RenderWindow.IsOpen && Window.Current == CurrentWindow.Game)
        {
            Window.RenderWindow.DispatchEvents();

            Window.RenderWindow.Clear(new Color(56, 207, 209));

            Enemies.New();
            Bullets.New();

            Player.Move();
            Enemies.Move();
            Bullets.Move();

            Line.Draw();
            Bullets.Draw();
            Enemies.Draw();
            Player.Draw();

            LifeBar.Draw();

            Text.DisplayedString =
                " SCORE: " + Player.KilledEnemiesCount + 
                "\n\n DIRECTION:\n X: " + Line.Direction.X +
                "\n Y: " + Line.Direction.Y;

            Window.RenderWindow.Draw(Text);

            Window.RenderWindow.Display();
        }

        if (Window.Current == CurrentWindow.GameOver)
        {
            Window.RenderWindow.MouseButtonPressed -= Event.OnGameMouseButtonPressed;

            Sounds.GameMusic.Stop();

            GameOver.Start();
        }
    }
}