using SFML.Graphics;
using SFML.System;
using SFML.Window;

public static class Player
{
    public static CircleShape Shape = new CircleShape(50)
    { 
        FillColor = Color.White,
        OutlineColor = Color.Black,
        OutlineThickness = 1,
        Position = Window.Center() - new Vector2f(50, 50)
    };

    public static float Speed = 0.15F;

    public static int HP = 10;
    public static int MaxHP = 10;

    public static int KilledEnemiesCount = 0;

    public static void Move()
    {
        Vector2f Move = new Vector2f();

        if (Keyboard.IsKeyPressed(Keyboard.Key.W)) Move.Y--;
        if (Keyboard.IsKeyPressed(Keyboard.Key.A)) Move.X--;
        if (Keyboard.IsKeyPressed(Keyboard.Key.S)) Move.Y++;
        if (Keyboard.IsKeyPressed(Keyboard.Key.D)) Move.X++;

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

    public static Vector2f Center()
    {
        return Shape.Position + new Vector2f(Shape.Radius, Shape.Radius);
    }
}