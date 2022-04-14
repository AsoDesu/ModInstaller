using Installer.util;
using RestSharp;

namespace Installer;

public class FabricInstaller
{
    public static string loaderName = $"fabric-loader-{Program.fabricVersion}-{Program.gameVersion}";
    public static string versionPath = $"{Program.mcDir}\\versions\\{loaderName}";
    
    public FabricInstaller()
    {
        if (Directory.Exists(versionPath))
        {
            log($"You already have fabric {Program.fabricVersion} installed!");
            return;
        }
        Directory.CreateDirectory(versionPath);
        File.Create($"{versionPath}\\{loaderName}.jar");
        
        var data = new ModDownloader().getString(
            $"https://meta.fabricmc.net/v2/versions/loader/{Program.gameVersion}/{Program.fabricVersion}/profile/json");
        File.WriteAllText($"{versionPath}\\{loaderName}.json", data);
    }

    private void log(string s)
    {
        Console.WriteLine("[Fabric Installer] " + s);
    }
    
}