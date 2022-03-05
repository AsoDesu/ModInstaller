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
    
}