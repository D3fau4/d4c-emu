using System.Security.Cryptography;
using LibHac;
using LibHac.Common.Keys;
using LibHac.FsSystem;
using LibHac.Tools.Fs;

namespace d4c.HOS;

public class Horizon
{
    public static Horizon? hos;
    public HorizonClient horizon;
    public KeySet keys;
    public SwitchFs ncafolder;
    public string NcaFolderPath;

    public Horizon(string path, string ncasfolder = "contents")
    {
        keys = ExternalKeyReader.ReadKeyFile(path);
        keys.DeriveKeys();
        var tmp = HorizonFactory.CreateWithDefaultFsConfig(new HorizonConfiguration(), new InMemoryFileSystem(), keys);
        horizon = tmp.CreatePrivilegedHorizonClient();

        // Load NCAS
        Console.WriteLine("Loading ncas...");
        var LocalFS = new LocalFileSystem(ncasfolder);
        ncafolder = SwitchFs.OpenNcaDirectory(keys, LocalFS);
        Console.WriteLine("Loaded!");
        NcaFolderPath = ncasfolder;
        hos = this;
    }

    public static bool ValidDeviceID(ulong deviceid)
    {
        var fab = (uint) (deviceid >> 50) & 0x3F;
        var clot0 = (uint) (deviceid >> 24) & 0x3FFFFFF;
        var wafer = (uint) (deviceid >> 18) & 0x3F;
        var x_coord = (uint) (deviceid >> 9) & 0x1FF;
        var y_coord = (int) (deviceid >> 0) & 0x1FF;

        if (fab != 25)
            return false;
        if (wafer < 0 || wafer > 25)
            return false;
        if (x_coord < -9f || x_coord > 15)
            return false;
        if (y_coord < 0 || y_coord > 26)
            return false;

        return true;
    }

    public static string SHA256CheckSum(string filePath)
    {
        using (var hash = SHA256.Create())
        {
            using (var fileStream = File.OpenRead(filePath))
            {
                return BitConverter.ToString(hash.ComputeHash(fileStream)).Replace("-", "");
            }
        }
    }
}