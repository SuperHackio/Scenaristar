using DarkModeForms;
using System.Globalization;

namespace Scenaristar;

internal static class Program
{
    public static string SETTINGS_PATH => GetFromAppPath("Settings.usrs");
    public static string PRESETS_PATH => GetFromAppPath("Presets");
    public static string ASSET_PATH => GetFromAppPath("Assets");
    public const string UPDATEALERT_URL = "https://raw.githubusercontent.com/SuperHackio/Scenaristar/master/Scenaristar/UpdateAlert.txt";
    public const string GIT_RELEASE_URL = "https://github.com/SuperHackio/Scenaristar/releases";

    public static Settings Settings { get; private set; } = new(SETTINGS_PATH);
    public static bool IsGameFileLittleEndian { get; set; } = false;
    public static bool IsUnsavedChanges { get; set; } = false;
    private static ScenarioEditorForm? Editor;

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(string[] args)
    {
        ApplicationConfiguration.Initialize();
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        // Prevents floats being written to the .dae with commas instead of periods on European systems.
        CultureInfo.CurrentCulture = new("", false);

        if (args.Any(A => A.Equals("-le")))
        {
            IsGameFileLittleEndian = true;
            args = args.Where(A => !A.Equals("-le")).ToArray();
        }

        Editor = new(args);
        ReloadTheme();
        Application.Run(Editor);
    }

    public static void ReloadTheme()
    {
        if (Editor is null)
            return;
        Editor.SuspendLayout();
        ProgramColors.ReloadTheme(Editor);
        Editor.ResumeLayout();
    }
    public static string GetFromAppPath(string Target) => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Target);
}