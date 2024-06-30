using SFML.Graphics;
using SFML.System;
using SFML.Window;

public static class Game
{
    private static void NewGame()
    {
        Player.HP = Player.MaxHP;
        Player.Shape.Position = Window.Center() - new Vector2f(50, 50);
        Player.KilledEnemiesCount = 0;
        Player.Speed = 0.15F;

        Bullets.AllBullets = new List<Bullet>();
        Bullets.Speed = 0.2F;

        Enemies.AllEnemies = new List<Enemy>();
        Enemies.MaxEnemyCount = 5;
        Enemies.Speed = 0.05F;
    }

    public static void Start()
    {
        Window.RenderWindow.MouseButtonPressed += Event.OnGameMouseButtonPressed;

        Sounds.GameMusic.Play();

        NewGame(); // reset in-game parameters

        Font Font = new Font("Fonts/impact.ttf");
        Text Text = new Text() { Font = Font };

        while (Window.RenderWindow.IsOpen && Window.Current == CurrentWindow.Game)
        {
            Window.RenderWindow.DispatchEvents();

            Window.RenderWindow.Clear(new Color(56, 207, 209));

            Enemies.New();

            Player.Move();
            Enemies.Move();
            Bullets.Move();

            Line.Draw();
            Bullets.Draw();
            Enemies.Draw();
            Player.Draw();

            LifeBar.Draw();

            Text.DisplayedString = "SCORE: " + Player.KilledEnemiesCount;
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