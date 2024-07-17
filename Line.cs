using SFML.Graphics;
using SFML.System;
using SFML.Window;

public static class Line
{
    public static Vector2f Direction = new Vector2f(1, 0);
    public static List<Vector2f> Directions = new List<Vector2f>();
    public static int DirectionCount = Config.BulletDirectionCount;

    public static void DefineDirection()
    {
        if (Config.AutoRotationMode)
        {
            double Angle = Math.Atan(Direction.Y / Direction.X);
            int Sign = Direction.X >= 0 ? 1 : -1;
            Angle += Config.AutoRotationSpeed * Math.Tau / 360;
            Direction = new Vector2f(Sign * (float)Math.Cos(Angle), Sign * (float)Math.Sin(Angle));
        }
        else
        {
            Vector2f Mouse = new Vector2f(SFML.Window.Mouse.GetPosition(Window.RenderWindow).X, SFML.Window.Mouse.GetPosition(Window.RenderWindow).Y);
            Direction = Vector.Normalize(Mouse - Player.Position);
        }

        if (Direction != new Vector2f())
        {
            Directions.Clear();

            double Angle = Math.Atan(Direction.Y / Direction.X);
            int Sign = Direction.X >= 0 ? 1 : -1;

            for (int i = 0; i < DirectionCount; i++)
            {
                Angle += Math.Tau / DirectionCount;

                Directions.Add(new Vector2f(Sign * (float)Math.Cos(Angle), Sign * (float)Math.Sin(Angle)));
            }
        }
    }

    public static void Draw()
    {
        DefineDirection();

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