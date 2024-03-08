using Hack.io.Interface;
using Hack.io.Utility;
using System.Text;

namespace Scenaristar;

/* == Format Specification ==
 * 
 * 0x00 = MAGIC (SCSS)
 * 0x04 = SETTINGSVERSION
 * 0x08 = Last used Game Mode (int)
 * 0x0C = Last used Icon Size (int)
 * 0x10 = Last Used Encoding (int)
 * 0x14 = Last used Theme Index (int)
 */

/// <summary>
/// Scenaristar Settings file
/// </summary>
internal class Settings : ILoadSaveFile
{
    public const string MAGIC = "SCSS";
    public const string SETTINGSVERSION_LATEST = SETTINGSVERSION_0001;
    public const string SETTINGSVERSION_0001 = "0001";

    private FileStream DiskAccess;
    public bool IsFirstLaunch;

    public int GameModeIndex = 1;
    public int IconSizeIndex = 1;
    public int EncodingIndex = 1;
    public int ThemeIndex = 0;

    public Settings(string Path)
    {
        if (!File.Exists(Path))
        {
            //First time usage woo
            IsFirstLaunch = true;
            DiskAccess = new(Path, FileMode.OpenOrCreate);
            Save(DiskAccess);
            DiskAccess.Close();
            return;
        }

        DiskAccess = new(Path, FileMode.Open);
        Load(DiskAccess);
        DiskAccess.Close();
    }

    public void OnChanged(object? sender, EventArgs e)
    {
        DiskAccess = new(DiskAccess.Name, FileMode.Create);
        Save(DiskAccess);
        DiskAccess.Close();
    }

    public void Load(Stream Strm)
    {
        try
        {
            StreamUtil.SetEndianLittle();
            FileUtil.ExceptionOnBadMagic(Strm, MAGIC);
            string Version = Strm.ReadString(4, Encoding.ASCII);

            if (Version.Equals(SETTINGSVERSION_0001))
            {
                GameModeIndex = Strm.ReadInt32();
                IconSizeIndex = Strm.ReadInt32();
                EncodingIndex = Strm.ReadInt32();
                ThemeIndex = Strm.ReadInt32();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Failed to load settings: {e.Message}");
            DiskAccess.Close();

            IsFirstLaunch = true;
            DiskAccess = new(DiskAccess.Name, FileMode.Create);
            Save(DiskAccess);
            DiskAccess.Close();
        }
    }

    public void Save(Stream Strm)
    {
        StreamUtil.SetEndianLittle();

        Strm.WriteString(MAGIC, Encoding.ASCII, null);
        Strm.WriteString(SETTINGSVERSION_LATEST, Encoding.ASCII, null);

        Strm.WriteInt32(GameModeIndex);
        Strm.WriteInt32(IconSizeIndex);
        Strm.WriteInt32(EncodingIndex);
        Strm.WriteInt32(ThemeIndex);
    }
}
