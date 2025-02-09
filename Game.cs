﻿using SFML.Graphics;
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

        if (Config.PlaySound) Sounds.GameMusic.Play();

        NewGame(); // reset in-game parameters

        Font Font = new Font("Fonts/impact.ttf");
        Text Text = new Text()
        {
            Font = Font,
            FillColor = Color.Black,
            OutlineColor = Color.White,
            OutlineThickness = 5
        };

        while (Window.RenderWindow.IsOpen && Window.Current == CurrentWindow.Game)
        {
            Window.RenderWindow.DispatchEvents();

            Window.RenderWindow.Clear();

            Enemies.New();
            if (Config.MachineGunMode) Bullets.New();

            Player.Move();
            Enemies.Move();
            Bullets.Move();

            if (Config.ShowLine) Line.Draw();
            Bullets.Draw();
            Enemies.Draw();
            Player.Draw();

            if (Config.ShowLifeBar) LifeBar.Draw();

            Text.DisplayedString =
                " YOUR HP: " + Player.HP +
                "\n SCORE: " + Player.KilledEnemiesCount;

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