using System.Net.Mime;
using Microsoft.Extensions.Logging;

namespace Installer;

internal class Program
{
    public static string roaming;
    public static string mcDir;
    public static string gameVersion = "1.18.2";
    public static string fabricVersion = "0.13.3";

    public static void Main(string[] args)
    {
        Console.Title = "Nation SMP Mod Installer";
        roaming = $"C:\\Users\\{Environment.UserName}\\AppData\\Roaming";
        mcDir = $"{roaming}\\.minecraft";

        if (!Directory.Exists(mcDir))
        {
            Console.WriteLine("Couldn't find your .minecraft location..");
            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();
            Environment.Exit(1);
        }
        
        Console.WriteLine($"Minecraft Directory: {mcDir}");
        Console.WriteLine($"Game Version: {gameVersion}");
        Console.WriteLine($"Fabric Loader Version: {fabricVersion}");
        Console.WriteLine("Downloading Fabric...");
        
        new FabricInstaller();
        new ModInstaller().install();
        new ProfileInstaller().Install();

        Console.WriteLine("Finished installing mods! Happy Modding!!");
        Console.WriteLine("Press enter to exit...");
        Console.ReadLine();
        Environment.Exit(0);
    }
}