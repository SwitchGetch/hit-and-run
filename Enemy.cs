using SFML.Graphics;
using SFML.System;

public class Enemy
{
    public CircleShape Shape = new CircleShape()
    {
        Radius = Config.EnemyShapeRadius,
        FillColor = Color.Black,
        OutlineColor = Color.White,
        OutlineThickness = 1
    };

    public Vector2f Position
    {
        get => Shape.Position + new Vector2f(Shape.Radius, Shape.Radius);
        set => Shape.Position = value - new Vector2f(Shape.Radius, Shape.Radius);
    }

    public int HP = Enemies.MaxHP;

    public Vector2f Direction = new Vector2f();
}

public static class Enemies
{
    public static List<Enemy> AllEnemies = new List<Enemy>();
    public static int MaxEnemyCount = 5;

    public static int Speed = Config.EnemySpeed;
    public static int Damage = Config.EnemyDamage;
    public static int MaxHP = Config.EnemyMaxHP;

    public static void New()
    {
        //if (AllEnemies.Count == 0)
        //{
        //    Player.WaveCount++;

        //    for (int i = 0; i < MaxEnemyCount; i++)
        //    {
        //        Random random = new Random();
        //        Enemy enemy = new Enemy();
        //        int temp = random.Next(0, 4);

        //        switch (temp) // set random position to enemy
        //        {
        //            case 0: enemy.Position = new Vector2f(random.Next(0, (int)Window.Size.X), -enemy.Shape.Radius); break;
        //            case 1: enemy.Position = new Vector2f(-enemy.Shape.Radius, random.Next(0, (int)Window.Size.Y)); break;
        //            case 2: enemy.Position = new Vector2f(Window.Size.X + enemy.Shape.Radius, random.Next(0, (int)Window.Size.Y)); break;
        //            case 3: enemy.Position = new Vector2f(random.Next(0, (int)Window.Size.X), Window.Size.Y + enemy.Shape.Radius); break;
        //        }

        //        AllEnemies.Add(enemy);
        //    }
        //}

        if (AllEnemies.Count < MaxEnemyCount)
        {
            Random random = new Random();
            Enemy enemy = new Enemy();
            int temp = random.Next(0, 4);

            switch (temp) // set random position to enemy
            {
                case 0: enemy.Position = new Vector2f(random.Next(0, (int)Window.Size.X), -enemy.Shape.Radius); break;
                case 1: enemy.Position = new Vector2f(-enemy.Shape.Radius, random.Next(0, (int)Window.Size.Y)); break;
                case 2: enemy.Position = new Vector2f(Window.Size.X + enemy.Shape.Radius, random.Next(0, (int)Window.Size.Y)); break;
                case 3: enemy.Position = new Vector2f(random.Next(0, (int)Window.Size.X), Window.Size.Y + enemy.Shape.Radius); break;
            }

            AllEnemies.Add(enemy);
        }
    }

    public static void Move()
    {
        for (int i = 0; i < AllEnemies.Count; i++)
        {
            AllEnemies[i].Direction = Vector.Normalize(Player.Position - AllEnemies[i].Position);

            AllEnemies[i].Shape.Position += Speed * AllEnemies[i].Direction;

            if (CheckForCollisionWithPlayer(i))
            {
                if (Player.HP > 0)
                {
                    Player.HP -= Damage;

                    //Sounds.Hit.Play();

                    AllEnemies.RemoveAt(i);

                    i--;
                }
                
                if (Player.HP <= 0) Window.Current = CurrentWindow.GameOver;
            }
        }
    }

    public static bool CheckForCollisionWithPlayer(int Index)
    {
        return 
            Vector.Length(AllEnemies[Index].Position, Player.Position) <
            AllEnemies[Index].Shape.Radius + Player.Shape.Radius;
    }

    public static void Draw()
    {
        for (int i = 0; i < AllEnemies.Count; i++)
        {
            Window.RenderWindow.Draw(AllEnemies[i].Shape);
        }
    }
}