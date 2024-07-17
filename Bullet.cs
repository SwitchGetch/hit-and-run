using SFML.Graphics;
using SFML.System;

public class Bullet
{
    public CircleShape Shape = new CircleShape()
    {
        Radius = Config.BulletShapeRadius,
        FillColor = Color.Yellow,
        OutlineColor = Color.White,
        OutlineThickness = 5
    };

    public Vector2f Position
    {
        get => Shape.Position + new Vector2f(Shape.Radius, Shape.Radius);
        set => Shape.Position = value - new Vector2f(Shape.Radius, Shape.Radius);
    }

    public Vector2f Direction = new Vector2f();
}

public static class Bullets
{
    public static List<Bullet> AllBullets = new List<Bullet>();

    public static int Speed = Config.BulletSpeed;
    public static int Damage = Config.BulletDamage;
    public static bool IsSpectral = Config.Piercing;

    public static void New()
    {
        Line.DefineDirection();

        if (Line.Directions.Count == Line.DirectionCount)
        {
            for (int i = 0; i < Line.DirectionCount; i++)
            {
                AllBullets.Add(new Bullet() { Position = Player.Position, Direction = Line.Directions[i] });
            }
        }

        if (Config.PlaySound) Sounds.Shot.Play();
    }

    public static void Move()
    {
        for (int i = 0; i < AllBullets.Count; i++)
        {
            AllBullets[i].Position += Speed * AllBullets[i].Direction;

            if (CheckForCollisionWithWalls(i) || CheckForCollisionWithEnemies(i) && !IsSpectral)
            {
                AllBullets.RemoveAt(i);
                i--;
            }
        }
    }

    private static bool CheckForCollisionWithWalls(int Index)
    {
        Vector2f Position = AllBullets[Index].Position;
        float Radius = AllBullets[Index].Shape.Radius;

        return 
            Position.X + Radius <= 0 ||
            Position.X - Radius >= Window.Size.X ||
            Position.Y + Radius <= 0 ||
            Position.Y - Radius >= Window.Size.Y;
    }

    private static bool CheckForCollisionWithEnemies(int Index)
    {
        bool Hit = false;

        for (int i = 0; i < Enemies.AllEnemies.Count; i++)
        {
            if (Vector.Length(AllBullets[Index].Position, Enemies.AllEnemies[i].Position) <
                AllBullets[Index].Shape.Radius + Enemies.AllEnemies[i].Shape.Radius)
            {
                Enemies.AllEnemies[i].HP -= Damage;

                Hit = true;

                if (Config.PlaySound) Sounds.Hit.Play();

                if (Enemies.AllEnemies[i].HP <= 0)
                {
                    Enemies.AllEnemies.RemoveAt(i);

                    Player.KilledEnemiesCount++;
                }
            }
        }

        return Hit;
    }

    public static void Draw()
    {
        for (int i = 0; i < AllBullets.Count; i++)
        {
            Window.RenderWindow.Draw(AllBullets[i].Shape);
        }
    }
}