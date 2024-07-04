public static class Config
{
    public static int PlayerMaxHP = 10;
    public static int PlayerSpeed = 5;
    public static int PlayerShapeRadius = 50;

    public static int EnemyMaxHP = 5;
    public static int EnemySpeed = 3;
    public static int EnemyDamage = 1;
    public static int EnemyShapeRadius = 25;

    public static int BulletSpeed = 10;
    public static int BulletDamage = 1;
    public static int BulletShapeRadius = 15;
    public static int BulletDirectionCount = 1;
    public static bool IsBulletSpectral = false;

    public static void Initialize()
    {
        Player.Position = Window.Center();
    }
}