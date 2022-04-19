using System.Security.Cryptography;
using LibHac;
using LibHac.Common;
using LibHac.Common.Keys;
using LibHac.Fs;
using LibHac.Fs.Fsa;
using LibHac.FsSystem;
using LibHac.Tools.Fs;
using LibHac.Tools.FsSystem;
using LibHac.Tools.Ncm;
using LibHac.Util;

namespace d4c.HOS;

public class Horizon
{
    public HorizonClient horizon;
    public KeySet keys;
    public string NcaFolderPath;
    public static Horizon? hos;
    public SwitchFs ncafolder;

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
        UInt32 fab = (UInt32)(deviceid >> 50) & 0x3F;
        UInt32 clot0 = (UInt32)(deviceid >> 24) & 0x3FFFFFF;
        UInt32 wafer = (UInt32)(deviceid >> 18) & 0x3F;
        UInt32 x_coord = (UInt32)(deviceid >> 9) & 0x1FF;
        Int32 y_coord = (Int32)(deviceid >> 0) & 0x1FF;

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
        using (SHA256 SHA256 = SHA256Managed.Create())
        {
            using (FileStream fileStream = File.OpenRead(filePath))
                return BitConverter.ToString(SHA256.ComputeHash(fileStream)).Replace("-","");
        }
    }
}