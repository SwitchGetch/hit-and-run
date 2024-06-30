using SFML.System;

public static class Vector
{
    public static Vector2f Normalize(Vector2f v) => v / (float)Math.Sqrt(v.X * v.X + v.Y * v.Y);

    public static float Length(Vector2f v1, Vector2f v2 = new Vector2f()) => (float)Math.Sqrt(Math.Pow(v1.X - v2.X, 2) + Math.Pow(v1.Y - v2.Y, 2));
}