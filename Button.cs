using SFML.Graphics;
using SFML.System;
using SFML.Window;

public class Button
{
    public RectangleShape Rectangle = new RectangleShape();
    public Color BackgroundColor = new Color();
    public Color HoverColor = new Color();

    public Text Text = new Text();
    public Font Font = null;

    public Button(
        Vector2f Size = new Vector2f(),
        Vector2f Position = new Vector2f(),
        Color BackgroundColor = new Color(),
        Color HoverColor = new Color(),
        Color TextColor = new Color(),
        uint CharacterSize = 0,
        string FontFileName = "",
        string ButtonText = ""
        )
    {
        Rectangle.Size = Size;
        Rectangle.Position = Position;
        Rectangle.FillColor = BackgroundColor;

        this.BackgroundColor = BackgroundColor;
        this.HoverColor = HoverColor;

        Text.FillColor = TextColor;
        Font = new Font(FontFileName);
        Text.Font = Font;
        Text.DisplayedString = ButtonText;
        Text.Position = Rectangle.Position + new Vector2f(Size.X - ButtonText.Length * CharacterSize / 2, Size.Y - CharacterSize * 1.2f) / 2;
        Text.CharacterSize = CharacterSize;
    }

    public void Draw()
    {
        Rectangle.FillColor = CheckCollisionWithMouse() ? HoverColor : BackgroundColor;

        Window.RenderWindow.Draw(Rectangle);
        Window.RenderWindow.Draw(Text);
    }

    public bool CheckCollisionWithMouse()
    {
        Vector2f Mouse = new Vector2f(SFML.Window.Mouse.GetPosition(Window.RenderWindow).X, SFML.Window.Mouse.GetPosition(Window.RenderWindow).Y);

        return
            Rectangle.Position.X <= Mouse.X && Mouse.X <= Rectangle.Position.X + Rectangle.Size.X &&
            Rectangle.Position.Y <= Mouse.Y && Mouse.Y <= Rectangle.Position.Y + Rectangle.Size.Y;
    }
}

public static class Buttons
{
    public static Button START = new Button
            (
            new Vector2f(500, 200), //size
            Window.Center() - new Vector2f(250, 0), // position
            new Color(32, 60, 186), // standart
            new Color(66, 95, 227), // hover
            Color.White, // text
            150, //symbol size
            "Fonts/impact.ttf", //font path
            "START" //text
            );

    public static Button YES = new Button
        (
        new Vector2f(300, 200),
        new Vector2f(100, 500),
        new Color(145, 17, 17),
        new Color(201, 42, 42),
        Color.White,
        120,
        "Fonts/impact.ttf",
        "YES"
        );

    public static Button NO = new Button
       (
       new Vector2f(300, 200),
       new Vector2f(600, 500),
       new Color(145, 17, 17),
       new Color(201, 42, 42),
       Color.White,
       120,
       "Fonts/impact.ttf",
       "NO"
       );
}