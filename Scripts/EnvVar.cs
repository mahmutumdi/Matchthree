using Localization;
using Settings;

public static class EnvVar
{
    public const string SettingsPath = "Settings/"; 
    public const string ProjectSettingsPath = "Settings/" + nameof(ProjectSettings);
    public const string AudioSettingsPath = "Settings/" + nameof(AudioSettings);
    public const string LocalizationSettingsPath = "Settings/" + nameof(LanguageScriptableObject);
    
    public const string LoginSceneName = "Login";
    public const string MenuSceneName = "Menu";
    public const string MainSceneName = "Main";
    
    public const float TileHalfExtends = 0.5000f;
    
    public const int BorderSpriteLayer = 3;
    public const int MaskBGSpriteLayer = 2;
    public const int HintSpriteLayer = 1;
    public const int TileSpriteLayer = 0;
    public const int TileBGSpriteLayer = -1;
    
    public const int bombPowerupThreshold= 4;
    public const int horizontalPowerupThreshold = 6;
    public const int verticalPowerupThreshold = 7;
    
}