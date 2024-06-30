using SFML.Graphics;
using SFML.System;
using SFML.Window;

public static class LifeBar
{
    public static void Draw()
    {
        RectangleShape EmptyBar = new RectangleShape() { FillColor = Color.Black };
        RectangleShape FullBar = new RectangleShape();
        float Ratio = (float)Player.HP / Player.MaxHP;
        byte Red = Convert.ToByte(255 * (1 - Ratio));
        byte Green = Convert.ToByte(255 * Ratio);

        //player

        EmptyBar.Size = new Vector2f(2 * Player.Shape.Radius, 0.5F * Player.Shape.Radius);
        FullBar.Size = new Vector2f(2 * Ratio * Player.Shape.Radius, 0.5F * Player.Shape.Radius);

        EmptyBar.Position = Player.Shape.Position - new Vector2f(0, Player.Shape.Radius);
        FullBar.Position = Player.Shape.Position - new Vector2f(0, Player.Shape.Radius);

        FullBar.FillColor = new Color(Red, Green, 0);
        //FullBar.FillColor = Color.Green;

        if (Player.HP < Player.MaxHP)
        {
            Window.RenderWindow.Draw(EmptyBar);
            Window.RenderWindow.Draw(FullBar);
        }

        //enemies

        for (int i = 0; i < Enemies.AllEnemies.Count; i++)
        {
            Enemy enemy = Enemies.AllEnemies[i];

            Ratio = (float)enemy.HP /enemy.MaxHP;
            Red = Convert.ToByte(255 * (1 - Ratio));
            Green = Convert.ToByte(255 * Ratio);

            EmptyBar.Size = new Vector2f(2 * enemy.Shape.Radius, 0.5F * enemy.Shape.Radius);
            FullBar.Size = new Vector2f(2 * Ratio * enemy.Shape.Radius, 0.5F * enemy.Shape.Radius);

            EmptyBar.Position = enemy.Shape.Position - new Vector2f(0, enemy.Shape.Radius);
            FullBar.Position = enemy.Shape.Position - new Vector2f(0, enemy.Shape.Radius);

            FullBar.FillColor = new Color(Red, Green, 0);

            if (enemy.HP < enemy.MaxHP)
            {
                Window.RenderWindow.Draw(EmptyBar);
                Window.RenderWindow.Draw(FullBar);
            }
        }
    }
}