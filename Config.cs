class _Config
{
    public int PlayerMaxHP = 10;
    public int PlayerSpeed = 4;
    public int PlayerShapeRadius = 50;

    public int EnemyMaxHP = 5;
    public int EnemySpeed = 2;
    public int EnemyDamage = 1;
    public int EnemyShapeRadius = 25;

    public int BulletSpeed = 8;
    public int BulletDamage = 1;
    public int BulletShapeRadius = 15;
    public int BulletDirectionCount = 1;

    public bool Piercing = true;
    public bool MachineGunMode = true;
    public bool HoldDownAbility = false;
    public bool AutoRotationMode = false;
    public int AutoRotationSpeed = 1;

    public bool ShowLine = true;
    public bool ShowLifeBar = true;
    public bool PlaySound = false;
}

public static class Config
{
    public static int PlayerMaxHP = 10;
    public static int PlayerSpeed = 4;
    public static int PlayerShapeRadius = 50;

    public static int EnemyMaxHP = 5;
    public static int EnemySpeed = 2;
    public static int EnemyDamage = 1;
    public static int EnemyShapeRadius = 25;

    public static int BulletSpeed = 8;
    public static int BulletDamage = 1;
    public static int BulletShapeRadius = 15;
    public static int BulletDirectionCount = 1;

    public static bool Piercing = true;
    public static bool MachineGunMode = true;
    public static bool HoldDownAbility = false;
    public static bool AutoRotationMode = false;
    public static int AutoRotationSpeed = 1;

    public static bool ShowLine = true;
    public static bool ShowLifeBar = true;
    public static bool PlaySound = false;

    public static void Initialize()
    {
        if (File.Exists("config.json")) Download();
        else Upload();

        Player.Position = Window.Center();
    }

    public static void Download()
    {
        _Config _Config = Newtonsoft.Json.JsonConvert.DeserializeObject<_Config>(File.ReadAllText("config.json"));

        PlayerMaxHP = _Config.PlayerMaxHP;
        PlayerSpeed = _Config.PlayerSpeed;
        PlayerShapeRadius = _Config.PlayerShapeRadius;

        EnemyMaxHP = _Config.EnemyMaxHP;
        EnemySpeed = _Config.EnemySpeed;
        EnemyDamage = _Config.EnemyDamage;
        EnemyShapeRadius = _Config.EnemyShapeRadius;

        BulletSpeed = _Config.BulletSpeed;
        BulletDamage = _Config.BulletDamage;
        BulletShapeRadius = _Config.BulletShapeRadius;
        BulletDirectionCount = _Config.BulletDirectionCount;

        Piercing = _Config.Piercing;
        MachineGunMode = _Config.MachineGunMode;
        HoldDownAbility = _Config.HoldDownAbility;
        AutoRotationMode = _Config.AutoRotationMode;
        AutoRotationSpeed = _Config.AutoRotationSpeed;

        ShowLine = _Config.ShowLine;
        ShowLifeBar = _Config.ShowLifeBar;
        PlaySound = _Config.PlaySound;
    }

    public static void Upload()
    {
        _Config _Config = new _Config()
        {
            PlayerMaxHP = PlayerMaxHP,
            PlayerSpeed = PlayerSpeed,
            PlayerShapeRadius = PlayerShapeRadius,

            EnemyMaxHP = EnemyMaxHP,
            EnemySpeed = EnemySpeed,
            EnemyDamage = EnemyDamage,
            EnemyShapeRadius = EnemyShapeRadius,

            BulletSpeed = BulletSpeed,
            BulletDamage = BulletDamage,
            BulletShapeRadius = BulletShapeRadius,
            BulletDirectionCount = BulletDirectionCount,

            Piercing = Piercing,
            MachineGunMode = MachineGunMode,
            HoldDownAbility = HoldDownAbility,
            AutoRotationMode = AutoRotationMode,
            AutoRotationSpeed = AutoRotationSpeed,

            ShowLine = ShowLine,
            ShowLifeBar = ShowLifeBar,
            PlaySound = PlaySound
        };

        File.WriteAllText("config.json", Newtonsoft.Json.JsonConvert.SerializeObject(_Config));
    }
}