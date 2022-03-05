using Installer.util;

namespace Installer;

public class ModInstaller
{
    public static string nationDir = $"{Program.roaming}\\.nationsmp\\origins3";
    public static string modsDir = $"{nationDir}\\mods";

    public static string[] mods =
    {
        "https://media.forgecdn.net/files/3561/745/Origins-1.18-1.3.1.jar",
        "https://media.forgecdn.net/files/3646/247/extraorigins-1.18-9.jar",
        "https://media.forgecdn.net/files/3584/152/genesis-1.18.1-1.0.0.jar",
        "https://media.forgecdn.net/files/3542/968/moborigins-1.8.0.jar",
        "https://media.forgecdn.net/files/3630/305/voicechat-fabric-1.18.1-2.2.16.jar",
        "https://media.forgecdn.net/files/3577/68/Pehkui-3.1.0%2B1.14.4-1.18.1.jar",
        "https://media.forgecdn.net/files/3671/143/fabric-api-0.46.6%2B1.18.jar",
        "https://cdn.modrinth.com/data/AANobbMI/versions/mc1.18.1-0.4.0-alpha6/sodium-fabric-mc1.18.1-0.4.0-alpha6+build.14.jar",
        "https://cdn.modrinth.com/data/yBW8D80W/versions/2.1.0+1.17/lambdynamiclights-2.1.0+1.17.jar",
        "https://cdn.modrinth.com/data/aXf2OSFU/versions/5.0.0-beta.3+1.17.1/okzoomer-5.0.0-beta.3+1.17.1.jar",
        "https://media.forgecdn.net/files/3641/132/cloth-config-6.2.57-fabric.jar"
    };
    
    public static string[] names =
    {
        "Origins",
        "ExtraOrigins",
        "Genesis",
        "MobOrigins",
        "VoiceChat",
        "dep-Pehkui",
        "dep-FabricAPI",
        "Sodium",
        "DynamicLights",
        "Zoom",
        "dep-ClothConfig"
    };
    
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

        for (var i = 0; i < mods.Length; i++)
        {
            log($"Downloading {names[i]}");
            string mod = mods[i];
            string name = names[i];

            byte[] modjar = downloader.downloadMod(mod);
            File.WriteAllBytes($"{modsDir}\\{name}.jar", modjar);
        }
        
        log($"Finished installing mods!");
    }
    
    private void log(string s)
    {
        Console.WriteLine("[Mod Installer] " + s);
    }
}