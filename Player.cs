using SFML.Graphics;
using SFML.System;
using SFML.Window;

public static class Player
{
    public static CircleShape Shape = new CircleShape()
    {
        Radius = Config.PlayerShapeRadius,
        FillColor = Color.White,
        OutlineColor = Color.Black,
        OutlineThickness = 1,
    };

    public static Vector2f Position
    {
        get => Shape.Position + new Vector2f(Shape.Radius, Shape.Radius);
        set => Shape.Position = value - new Vector2f(Shape.Radius, Shape.Radius);
    }

    public static int Speed = Config.PlayerSpeed;
    public static int HP = 10;
    public static int MaxHP = Config.PlayerMaxHP;

    public static int WaveCount = 0;

    private static int killed_enemies_count = 0;
    public static int KilledEnemiesCount
    {
        get => killed_enemies_count;
        set // increase parameters depending on the number of killed enemies
        {
            killed_enemies_count = value;

            Enemies.MaxEnemyCount = 5 + killed_enemies_count / 10;
            Enemies.MaxHP = 5 + killed_enemies_count / 10;
        }
    }

    public static void Move()
    {
        Vector2f Move = new Vector2f();

        if (Keyboard.IsKeyPressed(Keyboard.Key.W)) Move.Y--;
        if (Keyboard.IsKeyPressed(Keyboard.Key.A)) Move.X--;
        if (Keyboard.IsKeyPressed(Keyboard.Key.S)) Move.Y++;
        if (Keyboard.IsKeyPressed(Keyboard.Key.D)) Move.X++;
        if (Keyboard.IsKeyPressed(Keyboard.Key.Space)) Bullets.New();

        if (Move != new Vector2f())
        {
            Move = Vector.Normalize(Move) * Speed;
            Shape.Position += Move;

            if (Shape.Position.X < 0 || Shape.Position.X + 2 * Shape.Radius > Window.Size.X)
            {
                Shape.Position -= new Vector2f(Move.X, 0);
            }

            if (Shape.Position.Y < 0 || Shape.Position.Y + 2 * Shape.Radius > Window.Size.Y)
            {
                Shape.Position -= new Vector2f(0, Move.Y);
            }
        }
        
    }

    public static void Draw()
    {
        Window.RenderWindow.Draw(Shape);
    }
}