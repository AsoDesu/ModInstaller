// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class Profile
{
    public DateTime created { get; set; }
    public string gameDir { get; set; }
    public string icon { get; set; }
    public DateTime lastUsed { get; set; }
    public string lastVersionId { get; set; }
    public string name { get; set; }
    public string type { get; set; }
}

public class Settings
{
    public bool crashAssistance { get; set; }
    public bool enableAdvanced { get; set; }
    public bool enableAnalytics { get; set; }
    public bool enableHistorical { get; set; }
    public bool enableReleases { get; set; }
    public bool enableSnapshots { get; set; }
    public bool keepLauncherOpen { get; set; }
    public string profileSorting { get; set; }
    public bool showGameLog { get; set; }
    public bool showMenu { get; set; }
    public bool soundOn { get; set; }
}

public class LauncherProfiles
{
    public Dictionary<string, Profile> profiles { get; set; }
    public Settings settings { get; set; }
    public int version { get; set; }
}