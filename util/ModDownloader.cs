namespace Installer.util;
using RestSharp;

public class ModDownloader
{
    public byte[] downloadMod(string url)
    {
        var client = new RestClient();
        var req = new RestRequest(url);
        
        var response = client.ExecuteAsync(req);
        return response.Result.RawBytes;
    }

    public String[] getModList()
    {
        var lines = getString("https://aspiring-luxurious-metatarsal.glitch.me/modlist.txt").Split("\n");
        return lines;
    }

    public String getString(String url)
    {
        var client = new RestClient();
        var req = new RestRequest(url);
        
        var response = client.ExecuteAsync(req);
        return response.Result.Content;
    }
    
}