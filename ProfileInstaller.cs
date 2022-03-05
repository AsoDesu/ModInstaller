using System.Diagnostics;
using System.Text.Json;

namespace Installer;

public class ProfileInstaller
{
    public static string profileFile = $"{Program.mcDir}\\launcher_profiles.json";
    
    public static string optionsFile = $"{Program.mcDir}\\options.txt";
    public static string serverDat = $"{Program.mcDir}\\servers.dat";

    public void Install()
    {
        log("Generating new profiles.json file");
        string prof = File.ReadAllText(profileFile);
        var json = JsonSerializer.Deserialize<LauncherProfiles>(prof)!;
        Dictionary<string, Profile> profiles = json.profiles;

        Profile newProfile = new Profile();
        newProfile.created = DateTime.Now;
        newProfile.gameDir = ModInstaller.nationDir;
        newProfile.icon =
            "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAsklEQVQ4y2NgGNTAMDnlv5yHKRiTrBGE/Zrb4Jhog2AaU2fXYmCYi3BqBknCNJ/+c/f/1idR/zsOR/0vXONJnCEgCWTN0y9mgxWHT3RGMURAx/A/Vs0g00EKkDVLawtgGAJSh2EIzACQIhAGOZ0sA0AKQApBGpANgIUFCGM1AD0QkV0B8g6ID5PDqhnZFciGwJwOEsNrOwyAJNETEcxAgpqRDYEZBMMwMZKSNEwTyRpJAQAl0P1Xps3F9QAAAABJRU5ErkJggg==";
        newProfile.lastUsed = DateTime.Now;
        newProfile.lastVersionId = $"{FabricInstaller.loaderName}";
        newProfile.name = "Nation Origins 3";
        newProfile.type = "custom";

        if (profiles.ContainsKey("nation-origins-3"))
        {
            profiles.Remove("nation-origins-3");
        }
        profiles.Add("nation-origins-3", newProfile);

        log("Saved profiles.json!");
        json.profiles = profiles;
        File.WriteAllBytes(profileFile, JsonSerializer.SerializeToUtf8Bytes(json));
        
        // Copy options.txt
        if (File.Exists(optionsFile))
        {
            log("Copying options.txt");
            File.Delete($"{ModInstaller.nationDir}\\options.txt");
            File.Copy(optionsFile, $"{ModInstaller.nationDir}\\options.txt");
        }
    }
    
    private void log(string s)
    {
        Console.WriteLine("[Fabric Installer] " + s);
    }
}