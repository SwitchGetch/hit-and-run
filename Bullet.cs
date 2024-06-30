using SFML.Graphics;
using SFML.System;

public class Bullet
{
    public CircleShape Shape = new CircleShape(15)
    {
        FillColor = Color.Yellow,
        OutlineColor = Color.Red,
        OutlineThickness = 1
    };

    public Vector2f Direction = new Vector2f();

    public Vector2f Center()
    {
        return Shape.Position + new Vector2f(Shape.Radius, Shape.Radius);
    }
}

public static class Bullets
{
    public static List<Bullet> AllBullets = new List<Bullet>();

    public static float Speed = 0.2F;
    public static int Damage = 1;

    public static void New()
    {
        Bullet bullet = new Bullet();

        bullet.Shape.Position = Player.Center() - new Vector2f(bullet.Shape.Radius, bullet.Shape.Radius);

        bullet.Direction = Line.Direction;

        AllBullets.Add(bullet);
    }

    public static void Move()
    {
        for (int i = 0; i < AllBullets.Count; i++)
        {
            AllBullets[i].Shape.Position += Speed * AllBullets[i].Direction;

            if (CheckForCollisionWithWalls(i) || CheckForCollisionWithEnemies(i))
            {
                AllBullets.RemoveAt(i);
                i--;
            }
        }
    }

    private static bool CheckForCollisionWithWalls(int Index)
    {
        Vector2f Position = AllBullets[Index].Shape.Position;

        return 
            Position.X + 2 * AllBullets[Index].Shape.Radius <= 0 ||
            Position.X >= Window.Size.X ||
            Position.Y + 2 * AllBullets[Index].Shape.Radius <= 0 ||
            Position.Y >= Window.Size.Y;
    }

    private static bool CheckForCollisionWithEnemies(int Index)
    {
        for (int i = 0; i < Enemies.AllEnemies.Count; i++)
        {
            if (Vector.Length(AllBullets[Index].Center(), Enemies.AllEnemies[i].Center()) <
                AllBullets[Index].Shape.Radius + Enemies.AllEnemies[i].Shape.Radius)
            {
                Enemies.AllEnemies[i].HP -= Damage;

                Sounds.Hit.Play();

                if (Enemies.AllEnemies[i].HP <= 0)
                {
                    Enemies.AllEnemies.RemoveAt(i);

                    // increase parameters depending on the number of killed enemies
                    Player.KilledEnemiesCount++;
                    Player.Speed = 0.15F + 0.01F * Player.KilledEnemiesCount / 10;
                    Enemies.MaxEnemyCount = 5 + Player.KilledEnemiesCount / 10;
                    Enemies.Speed = 0.05F + 0.01F * Player.KilledEnemiesCount / 10;
                    Speed = 0.2F + 0.01F * Player.KilledEnemiesCount / 10;
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