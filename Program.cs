class Program
{
    static void Main(string[] args)
    {
        Window.Initialize(1000, 750);

        Sounds.Initialize();

        Menu.Start();
    }
}