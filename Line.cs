using SFML.Graphics;
using SFML.System;
using SFML.Window;

public static class Line
{
    public static Vector2f Direction = new Vector2f();
    public static List<Vector2f> Directions = new List<Vector2f>();
    public static int DirectionCount = Config.BulletDirectionCount;

    private static void DefineDirections()
    {
        Directions.Clear();

        double Angle = Math.Atan(Direction.Y / Direction.X);
        int Sign = Direction.X >= 0 ? 1 : -1;

        for (int i = 0; i < DirectionCount; i++)
        {
            Angle += 2 * Math.PI / DirectionCount;

            Directions.Add(new Vector2f(Sign * (float)Math.Cos(Angle), Sign * (float)Math.Sin(Angle)));
        }
    }

    public static void DefineDirection()
    {
        Vector2f Mouse = new Vector2f(SFML.Window.Mouse.GetPosition(Window.RenderWindow).X, SFML.Window.Mouse.GetPosition(Window.RenderWindow).Y);
        Direction = Vector.Normalize(Mouse - Player.Position);
    }

    public static void Draw()
    {
        DefineDirection();
        DefineDirections();

        for (int i = 0; i < DirectionCount; i++) DrawLine(Directions[i]);
    }

    private static void DrawLine(Vector2f Direction)
    {
        VertexArray Line = new VertexArray(PrimitiveType.Lines, 2);

        float l = Vector.Length(Window.Size);

        Line.Append(new Vertex(Player.Position, Color.Red));
        Line.Append(new Vertex(Player.Position + l * Direction, Color.Red));

        Window.RenderWindow.Draw(Line);
    }
}