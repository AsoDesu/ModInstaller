using Installer.util;

namespace Installer;

public class ModInstaller
{
    public static string nationDir = $"{Program.roaming}\\.nationsmp\\bonded";
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

        log($"Finished installing mods!");
    }
    
    private void log(string s)
    {
        Console.WriteLine("[Mod Installer] " + s);
    }
}