using SFML.Audio;

public static class Sounds
{
    public static SoundBuffer ButtonPressSoundBuffer = null;
    public static Sound ButtonPress = null;

    public static SoundBuffer ShotSoundBuffer = null;
    public static Sound Shot = null;

    public static SoundBuffer HitSoundBuffer = null;
    public static Sound Hit = null;

    public static SoundBuffer MenuMusicSoundBuffer = null;
    public static Sound MenuMusic = null;

    public static SoundBuffer GameMusicSoundBuffer = null;
    public static Sound GameMusic = null;

    public static SoundBuffer GameOverMusicSoundBuffer = null;
    public static Sound GameOverMusic = null;

    public static void Initialize()
    {
        ButtonPressSoundBuffer = new SoundBuffer("Sounds/button-press.wav");
        ButtonPress = new Sound() { SoundBuffer = ButtonPressSoundBuffer, Loop = false };

        ShotSoundBuffer = new SoundBuffer("Sounds/shot.wav");
        Shot = new Sound() { SoundBuffer = ShotSoundBuffer, Loop = false };

        HitSoundBuffer = new SoundBuffer("Sounds/hit.wav");
        Hit = new Sound() { SoundBuffer = HitSoundBuffer, Loop = false };

        MenuMusicSoundBuffer = new SoundBuffer("Sounds/menu.mp3");
        MenuMusic = new Sound() { SoundBuffer = MenuMusicSoundBuffer, Loop = true };

        GameMusicSoundBuffer = new SoundBuffer("Sounds/game.mp3");
        GameMusic = new Sound() { SoundBuffer = GameMusicSoundBuffer, Loop = true };

        GameOverMusicSoundBuffer = new SoundBuffer("Sounds/game-over.mp3");
        GameOverMusic = new Sound() { SoundBuffer = GameOverMusicSoundBuffer, Loop = true };
    }
}