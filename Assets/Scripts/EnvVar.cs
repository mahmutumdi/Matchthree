using Settings;

public static class EnvVar
{
    public const string ProjectSettingsPath = "Settings/" + nameof(ProjectSettings);
    public const string LanaguageSOPath = "Localization/" + "Language Data";
    
    public const string LoginSceneName = "Login";
    public const string MenuSceneName = "Menu";
    public const string MainSceneName = "Main";
    
    public const string LanguagePrefKey = "Language";
    public const string MusicPrefKey = "Music";
    public const string SoundPrefKey = "Sound";
    public const string VibrationPrefKey = "Vibration";
    public const string HighScorePrefKey = "HighScore";
    
    public const string Music1Name = "music1";
    
    public const float TileHalfExtends = 0.5000f;
    
    public const int BorderSpriteLayer = 3;
    public const int MaskBGSpriteLayer = 2;
    public const int HintSpriteLayer = 1;
    public const int TileSpriteLayer = 0;
    public const int TileBGSpriteLayer = -1;
    
    public const int horizontalPowerupThreshold= 3;
    public const int bombPowerupThreshold = 4;
    public const int verticalPowerupThreshold = 5;
    
    
}