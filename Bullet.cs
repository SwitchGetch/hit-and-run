using SFML.Graphics;
using SFML.System;

public class Bullet
{
    public CircleShape Shape = new CircleShape()
    {
        Radius = Config.BulletShapeRadius,
        FillColor = Color.Yellow,
        OutlineColor = Color.Red,
        OutlineThickness = 1
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
    public static bool IsSpectral = Config.IsBulletSpectral;

    public static void New()
    {
        if (Line.Direction != new Vector2f())
        {
            for (int i = 0; i < Line.DirectionCount; i++)
            {
                AllBullets.Add(new Bullet() { Position = Player.Position, Direction = Line.Directions[i] });
            }
        }

        //Sounds.Shot.Play();
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
        for (int i = 0; i < Enemies.AllEnemies.Count; i++)
        {
            if (Vector.Length(AllBullets[Index].Position, Enemies.AllEnemies[i].Position) <
                AllBullets[Index].Shape.Radius + Enemies.AllEnemies[i].Shape.Radius)
            {
                Enemies.AllEnemies[i].HP -= Damage;

                //Sounds.Hit.Play();

                if (Enemies.AllEnemies[i].HP <= 0)
                {
                    Enemies.AllEnemies.RemoveAt(i);

                    Player.KilledEnemiesCount++;
                }

                i--;

                return true;
            }
        }

        return false;
    }

    public static void Draw()
    {
        for (int i = 0; i < AllBullets.Count; i++)
        {
            Window.RenderWindow.Draw(AllBullets[i].Shape);
        }
    }
}