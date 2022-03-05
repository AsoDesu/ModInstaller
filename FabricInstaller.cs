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
        
        var client = new RestClient("https://meta.fabricmc.net/v2/versions");
        var req = new RestRequest($"/loader/{Program.gameVersion}/{Program.fabricVersion}/profile/json");
        
        var response = client.GetAsync<Object>(req);
        File.WriteAllText($"{versionPath}\\{loaderName}.json", response.Result.ToString());
    }

    private void log(string s)
    {
        Console.WriteLine("[Fabric Installer] " + s);
    }
    
}