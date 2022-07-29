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
            "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAEAAAABACAYAAACqaXHeAAAA0klEQVR42u3YrwrCUBiH4V2MSVgzGwSTBpPBZlNMNptdNAvejcFLEUzewrGenbAxhLE/zwu/NA3fEwaaZZIkSZIkSX92vH1DvKrn8/2nsO35XRgAAADaXXpAemDdg9Pn6QAAANDu0oPGi1fpZvm9sPTg9PMAAADodvluFOJdD8/Cev9jCQCAgQOsL8tQNgAAAAyr9KUIAACAbr/Umv4+AAAAug2yeaxCPAAAAHS76WkS4lWBAAAAoF8AdUEAAADQb4CqP0AAAAAwLIAqEAAAADTaD2U8HMx4JY/+AAAAAElFTkSuQmCC";
        newProfile.lastUsed = DateTime.Now;
        newProfile.lastVersionId = $"{FabricInstaller.loaderName}";
        newProfile.name = "Nation SMP Bonded Life";
        newProfile.type = "custom";

        if (profiles.ContainsKey("nation-bonded"))
        {
            profiles.Remove("nation-bonded");
        }
        profiles.Add("nation-bonded", newProfile);

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