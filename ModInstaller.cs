using Installer.util;

namespace Installer;

public class ModInstaller
{
    public static string nationDir = $"{Program.roaming}\\.nationsmp\\smp";
    public static string modsDir = $"{nationDir}\\mods";
    public static string configDir = $"{nationDir}\\config";

    public void install()
    {
        if (!Directory.Exists(nationDir))
        {
            log("Creating the profile folder!");
            Directory.CreateDirectory(nationDir);
        }

        if (!Directory.Exists(modsDir))
        {
            log("Creating the mods folder!");
            Directory.CreateDirectory(modsDir);
        }

        ModDownloader downloader = new ModDownloader();
        String[] modList = downloader.getModList();

        for (var i = 0; i < modList.Length; i++)
        {
            String[] v = modList[i].Split(",");
            String name = v[1];
            String url = v[0];
            log($"Downloading {name}");
            byte[] modjar = downloader.downloadMod(url);
            File.WriteAllBytes($"{modsDir}\\{name}.jar", modjar);
        }
        
        log("Setting default Minimap config");
        if (!Directory.Exists(configDir))
        {
            log("Creating Config Directory");
            Directory.CreateDirectory(configDir);
        }
        File.WriteAllText($"{configDir}\\xaerominimap.txt", downloader.getString("https://aspiring-luxurious-metatarsal.glitch.me/xaerominimap.txt"));

        log($"Finished installing mods!");
    }
    
    private void log(string s)
    {
        Console.WriteLine("[Mod Installer] " + s);
    }
}