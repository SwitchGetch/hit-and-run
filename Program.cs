class Program
{
    static void Main(string[] args)
    {
        Window.Initialize(1000, 750);
        Config.Initialize();
        Sounds.Initialize();

        Menu.Start();
    }
}