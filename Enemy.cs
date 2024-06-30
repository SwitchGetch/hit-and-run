using SFML.Graphics;
using SFML.System;

public class Enemy
{
    public CircleShape Shape = new CircleShape(25)
    {
        FillColor = Color.Black,
        OutlineColor = Color.White,
        OutlineThickness = 1
    };

    public int HP = 5;
    public int MaxHP = 5;

    public Vector2f Direction = new Vector2f();

    public Vector2f Center()
    {
        return Shape.Position + new Vector2f(Shape.Radius, Shape.Radius);
    }
}

public static class Enemies
{
    public static List<Enemy> AllEnemies = new List<Enemy>();
    public static int MaxEnemyCount = 5;

    public static float Speed = 0.05F;
    public static int Damage = 1;

    public static void New()
    {
        if (AllEnemies.Count < MaxEnemyCount)
        {
            Random random = new Random();
            Enemy enemy = new Enemy();
            int temp = random.Next(0, 4);

            switch (temp)
            {
                case 0: enemy.Shape.Position = new Vector2f(random.Next(0, (int)Window.Size.X), -2 * enemy.Shape.Radius); break;
                case 1: enemy.Shape.Position = new Vector2f(-2 * enemy.Shape.Radius, random.Next(0, (int)Window.Size.Y)); break;
                case 2: enemy.Shape.Position = new Vector2f(Window.Size.X, random.Next(0, (int)Window.Size.Y)); break;
                case 3: enemy.Shape.Position = new Vector2f(random.Next(0, (int)Window.Size.X), Window.Size.Y); break;
            }

            AllEnemies.Add(enemy);
        }
    }

    public static void Move()
    {
        for (int i = 0; i < AllEnemies.Count; i++)
        {
            AllEnemies[i].Direction = Vector.Normalize(Player.Center() - AllEnemies[i].Center());

            AllEnemies[i].Shape.Position += Speed * AllEnemies[i].Direction;

            if (CheckForCollisionWithPlayer(i))
            {
                if (Player.HP > 0)
                {
                    Player.HP -= Damage;

                    Sounds.Hit.Play();

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
            Vector.Length(AllEnemies[Index].Center(), Player.Center()) <
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