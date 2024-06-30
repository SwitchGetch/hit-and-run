using SFML.Graphics;
using SFML.System;

public static class Line
{
    public static Vector2f Direction = new Vector2f();

    public static void Draw()
    {
        VertexArray Line = new VertexArray(PrimitiveType.Lines, 2);

        Vector2f Mouse = new Vector2f(SFML.Window.Mouse.GetPosition(Window.RenderWindow).X, SFML.Window.Mouse.GetPosition(Window.RenderWindow).Y);
        Direction = Vector.Normalize(Mouse - Player.Center());
        float l = Vector.Length(Window.Center()) + Vector.Length(Window.Center(), Player.Center());

        Line.Append(new Vertex(Player.Center(), Color.Red));
        Line.Append(new Vertex(Mouse + l * Direction, Color.Red));

        Window.RenderWindow.Draw(Line);
    }
}