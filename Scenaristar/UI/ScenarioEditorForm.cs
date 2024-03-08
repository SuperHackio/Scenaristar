using DarkModeForms;
using Hack.io.BCSV;
using Hack.io.RARC;
using Hack.io.Utility;
using Hack.io.YAZ0;
using System.Runtime.InteropServices;

namespace Scenaristar;

public partial class ScenarioEditorForm : Form
{
    private string? privfilename = null;
    private bool IsLoadingFile = false;
    private bool IsIgnoreChanges = false;
    private readonly bool IsBooting = false;
    private const string FileDialogFilter = "Supported Files | *.arc; *.rarc|Scenario Archive |*.rarc; *.arc";
    private readonly OpenFileDialog ofd = new() { Filter = FileDialogFilter };
    private readonly SaveFileDialog sfd = new() { Filter = FileDialogFilter, OverwritePrompt = false };
    private readonly ImageList ScenarioImages = new();
    private readonly BCSV GraphicTableData, PowerStarTypeTableData, CometTypeTableData, AppearanceTableData;

    public string? CurrentFileName
    {
        get => privfilename;
        set
        {
            privfilename = value;
            CurrentFileToolStripTextBox.Text = new FileInfo(value ?? "Unsaved File").Name;
        }
    }
    
    private bool IsSMG1 => GameModeToolStripComboBox.SelectedIndex == 0;
    private bool IsSMG2 => GameModeToolStripComboBox.SelectedIndex == 1;
    private bool IsUsePowerStarColor => InternalIsPowerStarColor();

    public ScenarioEditorForm(string[] args)
    {
        IsBooting = true;
        InitializeComponent();
        CenterToScreen();
        ScenarioListView.SetDoubleBuffered();
        ScenarioNumNumericUpDown.ValueChange2 += ScenarioNumNumericUpDown_ValueChanged;
        TimeLimitNumericUpDown.ValueChange2 += TimeLimitNumericUpDown_ValueChanged;

        StreamUtil.SetEndianBig(); //I'm keeping it Big Endian for the funny

        string GraphicTablePath = Path.Combine(Program.ASSET_PATH, "_GraphicTable.bcsv");
        if (!File.Exists(GraphicTablePath))
            throw new FileNotFoundException($"Failed to find {GraphicTablePath}");
        GraphicTableData = new();
        FileUtil.LoadFile(GraphicTablePath, GraphicTableData.Load);

        string StarTypeTablePath = Path.Combine(Program.ASSET_PATH, "_PowerStarTypeTable.bcsv");
        if (!File.Exists(StarTypeTablePath))
            throw new FileNotFoundException($"Failed to find {StarTypeTablePath}");
        PowerStarTypeTableData = new();
        FileUtil.LoadFile(StarTypeTablePath, PowerStarTypeTableData.Load);

        string CometTablePath = Path.Combine(Program.ASSET_PATH, "_CometTable.bcsv");
        if (!File.Exists(CometTablePath))
            throw new FileNotFoundException($"Failed to find {CometTablePath}");
        CometTypeTableData = new();
        FileUtil.LoadFile(CometTablePath, CometTypeTableData.Load);

        string AppearanceTablePath = Path.Combine(Program.ASSET_PATH, "_AppearPowerStarObjTable.bcsv");
        if (!File.Exists(AppearanceTablePath))
            throw new FileNotFoundException($"Failed to find {AppearanceTablePath}");
        AppearanceTableData = new();
        FileUtil.LoadFile(AppearanceTablePath, AppearanceTableData.Load);



        Text = "Scenaristar - " + UpdateInformation.ApplicationVersion;
        InfoToolStripStatusLabel.Text = "Welcome to Scenaristar!";

        // Setup default values in Combo Boxes        
        GameModeToolStripComboBox.SelectedIndex = Program.Settings.GameModeIndex; //Default to SMG2
        ImageSizeToolStripComboBox.SelectedIndex = Program.Settings.IconSizeIndex; //Default to Large
        CompressToolStripComboBox.SelectedIndex = Program.Settings.EncodingIndex; //Default to YAZ0 enabled
        ThemeToolStripComboBox.SelectedIndex = Program.Settings.ThemeIndex; //Default to Light for the funny
        ProgramColors.IsDarkMode = ThemeToolStripComboBox.SelectedIndex == 1;

        ScenarioListView.LargeImageList = ScenarioImages;
        ScenarioListView.SmallImageList = ScenarioImages;

        if (args.Length != 0)
            OpenWith(args[0]);
        else
            InitGUIForGame(); //OpenWith will re-init but if that's not needed then why bother doing it an extra time?

        StatusTimer.Start();
        IsBooting = false;
        ImageSizeToolStripComboBox_SelectedIndexChanged(this, EventArgs.Empty);
    }

    private void InitGUIForGame()
    {
        if (IsLoadingFile)
            return;

        IsIgnoreChanges = true;
        string TempStarType = GetSelectionInComboBox(ScenarioTypeComboBox);
        if (string.IsNullOrWhiteSpace(TempStarType))
            TempStarType = "Normal";
        string TempCometType = GetSelectionInComboBox(CometComboBox);

        // Unlike previous versions of Scenaristar, the combo box options are no longer hardcoded
        Dictionary<string, string> StarComboSource =
            CreateFieldDictionaryValidateGameAndSystem<string, string>(PowerStarTypeTableData, "PowerStarType", "Data", GameModeToolStripComboBox.SelectedIndex + 1, IsUsePowerStarColor ? 2 : 1);
        Dictionary<string, string> CometComboSource =
            CreateFieldDictionaryValidateGameAndSystem<string, string>(CometTypeTableData, "Comet", "Data", GameModeToolStripComboBox.SelectedIndex + 1, IsUsePowerStarColor ? 2 : 1);

        ScenarioTypeComboBox.DataSource = new BindingSource(StarComboSource, null);
        ScenarioTypeComboBox.DisplayMember = "Value";
        ScenarioTypeComboBox.ValueMember = "Key";

        CometComboBox.DataSource = new BindingSource(CometComboSource, null);
        CometComboBox.DisplayMember = "Value";
        CometComboBox.ValueMember = "Key";

        SetSelectionInComboBox(ScenarioTypeComboBox, TempStarType);
        SetSelectionInComboBox(CometComboBox, TempCometType);

        IsIgnoreChanges = false;
    }

    private void SetAppStatus(bool Trigger)
    {
        SuspendLayout();
        ScenarioNameTextBox.Enabled = Trigger;
        ScenarioNumNumericUpDown.Enabled = Trigger;
        ScenarioTypeComboBox.Enabled = Trigger;
        CometComboBox.Enabled = Trigger;
        AppearenceTextBox.Enabled = Trigger;
        AppearenceButton.Enabled = Trigger;
        CometTimerButton.Enabled = Trigger && IsSMG2;
        TimeLimitNumericUpDown.Enabled = Trigger && IsSMG2;
        ZonesListBox.Enabled = Trigger;
        StarCheckedListBox.Enabled = Trigger;
        LayerACheckBox.Enabled = Trigger;
        LayerBCheckBox.Enabled = Trigger;
        LayerCCheckBox.Enabled = Trigger;
        LayerDCheckBox.Enabled = Trigger;
        LayerECheckBox.Enabled = Trigger;
        LayerFCheckBox.Enabled = Trigger;
        LayerGCheckBox.Enabled = Trigger;
        LayerHCheckBox.Enabled = Trigger;
        LayerICheckBox.Enabled = Trigger;
        LayerJCheckBox.Enabled = Trigger;
        LayerKCheckBox.Enabled = Trigger;
        LayerLCheckBox.Enabled = Trigger;
        LayerMCheckBox.Enabled = Trigger;
        LayerNCheckBox.Enabled = Trigger;
        LayerOCheckBox.Enabled = Trigger;
        LayerPCheckBox.Enabled = Trigger;
        AddZoneButton.Enabled = Trigger;
        SubtractZoneButton.Enabled = Trigger;
        RenameZoneButton.Enabled = Trigger;
        MoveScenarioUpToolStripMenuItem.Enabled = Trigger;
        MoveScenarioDownToolStripMenuItem.Enabled = Trigger;
        ResumeLayout();
    }

    private void CreateAllScenarioImage()
    {
        for (int i = 0; i < ScenarioImages.Images.Count; i++)
        {
            var x = ScenarioImages.Images[i];
            x.Dispose();
        }
        ScenarioImages.Images.Clear();

        for (int i = 0; i < ScenarioListView.Items.Count; i++)
            CreateScenarioImage(i);

        GC.Collect();
    }

    private void CreateScenarioImage(int ListViewIndex)
    {
        var x = ScenarioListView.Items[ListViewIndex].Tag;
        if (x is null)
            return; //What
        ScenarioData.Scenario CurScenarioEntry = (ScenarioData.Scenario)x;

        Bitmap Base = CreateScenarioBitmap(CurScenarioEntry.Type, CurScenarioEntry.Comet, CurScenarioEntry.Appearence, CurScenarioEntry.PowerStarColor);


        if (ListViewIndex >= ScenarioImages.Images.Count)
            ScenarioImages.Images.Add(Base);
        else
        {
            List<Image> images = new(ScenarioImages.Images.Count);
            for (int i = 0; i < ScenarioImages.Images.Count; i++)
                images.Add(ScenarioImages.Images[i]);

            images[ListViewIndex].Dispose();
            images[ListViewIndex] = Base;

            ScenarioImages.Images.Clear();
            for (int i = 0; i < images.Count; i++)
            {
                ScenarioImages.Images.Add(images[i]);
            }
            GC.Collect();
        }
    }

    public Bitmap CreateScenarioBitmap(string Type, string Comet, string Appearence, int? PowerStarColor)
    {
        Bitmap? Base = LoadImageFromResources(DarkModeForms.ProgramColors.IsDarkMode ? "StarFrameDark" : "StarFrame");
        Base ??= new Bitmap(512, 512);
        using Graphics g = Graphics.FromImage(Base);

        // Generate Star Icon & Comet
        string PowerStarTypeString = $"{Type}Star";
        string PowerStarParamString = $"{PowerStarTypeString}_{PowerStarColor ?? -1}";
        string CometTypeString;
        if (Type.Equals("Normal"))
            CometTypeString = string.IsNullOrWhiteSpace(Comet) ? "" : $"Comet_{Comet}";
        else if (Type.Equals("Green") && IsSMG2)
            CometTypeString = "Comet_GreenStar";
        else
            CometTypeString = "";


        string? ResourceName = GetDataByName<string>(GraphicTableData, PowerStarTypeString, "ResourceName", GameModeToolStripComboBox.SelectedIndex + 1, IsUsePowerStarColor ? 2 : 1);
        string? ResourceNameParam = GetDataByName<string>(GraphicTableData, PowerStarParamString, "ResourceName", GameModeToolStripComboBox.SelectedIndex + 1, IsUsePowerStarColor ? 2 : 1);
        string? ResourceNameTail = string.IsNullOrWhiteSpace(CometTypeString) ? null : GetDataByName<string>(GraphicTableData, CometTypeString, "ResourceName", GameModeToolStripComboBox.SelectedIndex + 1, IsUsePowerStarColor ? 2 : 1);

        string? FinalResourceNamePowerStar = ResourceNameParam ?? ResourceName;


        PointF PowerStarDrawPoint = new(170f, 230f);
        Bitmap? StarGraphic = null, TailGraphic = null;

        if (FinalResourceNamePowerStar is not null)
        {
            StarGraphic = LoadImageFromResources(FinalResourceNamePowerStar);
            if (ResourceNameTail is not null)
                TailGraphic = LoadImageFromResources(ResourceNameTail);
            if (StarGraphic is not null)
            {
                PointF BottomLeft = new(PowerStarDrawPoint.X - StarGraphic.Width / 2, PowerStarDrawPoint.Y + StarGraphic.Height / 2);

                if (TailGraphic is not null)
                {
                    g.DrawImage(TailGraphic, BottomLeft.X, BottomLeft.Y - TailGraphic.Height);
                }
                g.DrawImage(StarGraphic, BottomLeft.X, BottomLeft.Y - StarGraphic.Height);
            }
        }

        TailGraphic?.Dispose();
        StarGraphic?.Dispose();

        // Power Star Appearance graphic
        PointF AppearPoint = new(400, 400);

        string Appearance = Appearence;
        if ((Comet.Equals("Purple") || Comet.Equals("Black")) && IsSMG1)
            Appearance = "１００枚コイン";
        string? ResourceNameAppearance = GetDataByName<string>(AppearanceTableData, Appearance, "ResourceName", GameModeToolStripComboBox.SelectedIndex + 1, IsUsePowerStarColor ? 2 : 1, "AppearPowerStarObj");

        if (string.IsNullOrWhiteSpace(ResourceNameAppearance))
            ResourceNameAppearance = null;

        // It's done like this for SMG2 because SMG2 can allow other things to spawn the 100 purple coins star
        // With GLE that's ManualPurpleCoin
        if (Comet.Equals("Purple") && IsSMG2)
            ResourceNameAppearance ??= GetDataByName<string>(AppearanceTableData, "１００枚コイン", "ResourceName", GameModeToolStripComboBox.SelectedIndex + 1, IsUsePowerStarColor ? 2 : 1, "AppearPowerStarObj"); ;

        if (ResourceNameAppearance is not null)
        {
            Bitmap? Graphic = LoadImageFromResources(ResourceNameAppearance);
            if (Graphic is not null)
            {
                float ShrinkerX = 0.9f;
                float ShrinkerY = 0.9f;
                float ShrinkX = Graphic.Width * (1 - ShrinkerX);
                float ShrinkY = Graphic.Height * (1 - ShrinkerY);
                g.DrawImage(Graphic,
                    AppearPoint.X - (Graphic.Width / 2) + ShrinkX,
                    AppearPoint.Y - (Graphic.Height / 2) + ShrinkY,
                    Graphic.Width - (ShrinkX * 2),
                    Graphic.Height - (ShrinkY * 2));
                Graphic.Dispose();
            }
        }

        return Base;

        static Bitmap? LoadImageFromResources(string ImageName, string Ext = ".png")
        {
            string fullpath = Path.Combine(Program.ASSET_PATH, ImageName + Ext);
            if (!File.Exists(fullpath))
                return null;
            Bitmap bm = (Bitmap)Image.FromFile(fullpath);
            return bm;
        }
    }

    private void OpenWith(string Filepath)
    {
        if (Program.IsGameFileLittleEndian)
            StreamUtil.SetEndianLittle();
        else
            StreamUtil.SetEndianBig();

        FileInfo inuse = new(Filepath);
        if (inuse.IsFileLocked())
        {
            MessageBox.Show("The chosen file could not be accessed.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        IsLoadingFile = true;
        Console.WriteLine("Loading as an Archive:");
        List<(Func<Stream, bool> CheckFunc, Func<byte[], byte[]> DecodeFunction)> DecompFuncs =
        [
            (YAZ0.Check, YAZ0.Decompress)
        ];
        RARC Archive = new();
        int encodingselection = FileUtil.LoadFileWithDecompression(Filepath, Archive.Load, [.. DecompFuncs]);
        if (encodingselection == -1)
            FileUtil.LoadFile(Filepath, Archive.Load);
        if (Archive.Root is null)
        {
            Console.WriteLine("Load Failed! Could not decompress or load the archive!");
            return;
        }

        string? ScenarioDataPath = Archive.GetItemKeyFromNoCase("ScenarioData.bcsv");
        string? ZoneListPath = Archive.GetItemKeyFromNoCase("ZoneList.bcsv");
        string? GalaxyInfoPath = Archive.GetItemKeyFromNoCase("GalaxyInfo.bcsv"); //Basically only using this to see if we should recommend SMG1/2 mode or not

        if (ScenarioDataPath is null)
        {
            MessageBox.Show("There is no ScenarioData.bcsv inside this archive!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        if (ZoneListPath is null)
        {
            MessageBox.Show("There is no ZoneList.bcsv inside this archive!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }


        bool IsArchiveSMG1 = GalaxyInfoPath is null;

        if (!IsSMG1 && IsArchiveSMG1)
        {
            DialogResult result = MessageBox.Show("The Scenario you are opening is detected to be SMG1, but your Game Mode is set to SMG2. Would you like to switch?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                GameModeToolStripComboBox.SelectedIndex = 0;
        }
        else if (!IsSMG2 && !IsArchiveSMG1)
        {
            DialogResult result = MessageBox.Show("The Scenario you are opening is detected to be SMG2, but your Game Mode is set to SMG1. Would you like to switch?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                GameModeToolStripComboBox.SelectedIndex = 1;
        }

        object? c = Archive[ScenarioDataPath]; //It shouldn't be possible for this to be null right now
        if (c is null)
        {
            Console.WriteLine("YOU SHOULD NOT SEE THIS MESSAGE");
            return;
        }
        RARC.File cc = (RARC.File)c;
        BCSV ScenarioDataBcsv = new();
        ScenarioDataBcsv.Load((MemoryStream)cc);

        object? c2 = Archive[ZoneListPath]; //It shouldn't be possible for this to be null right now
        if (c2 is null)
        {
            Console.WriteLine("YOU SHOULD NOT SEE THIS MESSAGE");
            return;
        }
        RARC.File cc2 = (RARC.File)c2;
        BCSV ZoneListBcsv = new();
        ZoneListBcsv.Load((MemoryStream)cc2);

        ScenarioData CurrentScenario = new(ScenarioDataBcsv, ZoneListBcsv);


        ScenarioListView.Items.Clear();
        for (int i = 0; i < CurrentScenario.Count; i++)
        {
            ListViewItem LVI = new() { Tag = CurrentScenario[i], Text = CurrentScenario[i].Name, ImageIndex = i };
            ScenarioListView.Items.Add(LVI);
        }
        CreateAllScenarioImage();
        ZonesListBox.Items.Clear();
        for (int j = 0; j < ZoneListBcsv.EntryCount; j++)
        {
            BCSV.Entry curZoneEntry = ZoneListBcsv[j];
            string ZoneName = (string)curZoneEntry[ZoneListBcsv[ScenarioData.HASH_ZONENAME]];
            ZonesListBox.Items.Add(ZoneName);
        }

        if (ScenarioListView.Items.Count > 0)
            ScenarioListView.Items[0].Selected = true;
        else
            SetAppStatus(false);
        if (ZonesListBox.Items.Count > 0)
            ZonesListBox.SelectedIndex = 0;
        SaveToolStripMenuItem.Enabled = true;
        SaveAsToolStripMenuItem.Enabled = true;
        AddScenarioToolStripMenuItem.Enabled = true;
        RemoveScenarioToolStripMenuItem.Enabled = true;
        TemplatesToolStripMenuItem.Enabled = true;
        CurrentFileName = Filepath;
        InfoToolStripStatusLabel.Text = new FileInfo(CurrentFileName ?? "Unsaved File").Name + " Loaded!";
        StatusResumeCountdown = 3;
        StatusTimer.Start();
        Program.IsUnsavedChanges = false;
        IsLoadingFile = false;
        InitGUIForGame();
    }

    private void Save(string Filepath)
    {
        if (Program.IsGameFileLittleEndian)
            StreamUtil.SetEndianLittle();
        else
            StreamUtil.SetEndianBig();

        FileInfo inuse = new(Filepath);
        if (!inuse.Exists)
        {
            MessageBox.Show("The provided path does not exist.\nScenaristar cannot create new archives, only inject into existing archives.\nIf you want a new archive, create a copy of an existing one, then save over that.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        if (inuse.IsFileLocked())
        {
            MessageBox.Show("The chosen file could not be accessed.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        List<(Func<Stream, bool> CheckFunc, Func<byte[], byte[]> DecodeFunction)> DecompFuncs =
        [
            (YAZ0.Check, YAZ0.Decompress)
        ];
        RARC Archive = new();
        int encodingselection = FileUtil.LoadFileWithDecompression(Filepath, Archive.Load, [.. DecompFuncs]);
        if (encodingselection == -1)
            FileUtil.LoadFile(Filepath, Archive.Load);
        if (Archive.Root is null)
        {
            Console.WriteLine("Load Failed! Could not decompress or load the archive!");
            return;
        }

        string? ScenarioDataPath = Archive.GetItemKeyFromNoCase("ScenarioData.bcsv");
        string? ZoneListPath = Archive.GetItemKeyFromNoCase("ZoneList.bcsv");
        string? GalaxyInfoPath = Archive.GetItemKeyFromNoCase("GalaxyInfo.bcsv"); //Basically only using this to see if we should recommend SMG1/2 mode or not

        if (ScenarioDataPath is null)
        {
            MessageBox.Show("There is no ScenarioData.bcsv inside this archive!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        if (ZoneListPath is null)
        {
            MessageBox.Show("There is no ZoneList.bcsv inside this archive!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        bool IsArchiveSMG1 = GalaxyInfoPath is null;

        IsLoadingFile = true;
        if (!IsSMG1 && IsArchiveSMG1)
        {
            DialogResult result = MessageBox.Show("The Archive you are saving to is detected to be SMG1, but your Game Mode is set to SMG2. Would you like to switch?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                GameModeToolStripComboBox.SelectedIndex = 0;
        }
        else if (!IsSMG2 && !IsArchiveSMG1)
        {
            DialogResult result = MessageBox.Show("The Archive you are saving to is detected to be SMG2, but your Game Mode is set to SMG1. Would you like to switch?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                GameModeToolStripComboBox.SelectedIndex = 1;
        }
        IsLoadingFile = false;

        //TODO: Scenario validation



        // ========================
        // Write the file yipee

        ScenarioData AllScenarioData = [];
        List<string> ZoneNames = [];
        for (int i = 0; i < ScenarioListView.Items.Count; i++)
        {
            if (ScenarioListView.Items[i].Tag is ScenarioData.Scenario X)
                AllScenarioData.Add(X);
            else
                throw new Exception("MASSIVE ERROR HOW DID THIS HAPPEN???!?");
        }
        for (int i = 0; i < ZonesListBox.Items.Count; i++)
        {
            ZoneNames.Add(ZonesListBox.Items[i].ToString() ?? throw new InvalidDataException());
        }

        AllScenarioData.CreateBcsvFiles(IsSMG2, CollectionsMarshal.AsSpan(ZoneNames), out BCSV ScenarioDataBcsv, out BCSV ZoneListBcsv);

        {
            MemoryStream ms = new();
            ScenarioDataBcsv.Save(ms);
            RARC.File Dest = new();
            Dest.Load(ms);
            Archive[ScenarioDataPath] = Dest;
        }
        {
            MemoryStream ms = new();
            ZoneListBcsv.Save(ms);
            RARC.File Dest = new();
            Dest.Load(ms);
            Archive[ZoneListPath] = Dest;
        }

        FileUtil.SaveFile(Filepath, Archive.Save);
        if (CompressToolStripComboBox.SelectedIndex == 1)
        {
            StatusTimer.Stop();
            InfoToolStripStatusLabel.Text = "YAZ0 Encoding...";

            FileInfo FI = new(Filepath);
            byte[] Original = File.ReadAllBytes(FI.FullName);
            byte[] Compressed = YAZ0.Compress(Original);
            File.WriteAllBytes(FI.FullName, Compressed);

            StatusTimer.Start();
        }

        CurrentFileName = Filepath;

        InfoToolStripStatusLabel.Text = "Save Complete!";
        StatusResumeCountdown = 4;
        Program.IsUnsavedChanges = false;
    }

    private bool InternalIsPowerStarColor()
    {
        for (int i = 0; i < ScenarioListView.Items.Count; i++)
        {
            var x = ScenarioListView.Items[i].Tag;
            if (x is null)
                continue; //What
            ScenarioData.Scenario CurScenarioEntry = (ScenarioData.Scenario)x;
            if (CurScenarioEntry.PowerStarColor != null)
                return true;
        }
        return false;
    }

    #region Asset BCSV Data Readers
    private static Dictionary<K, V> CreateFieldDictionaryValidateGameAndSystem<K, V>(BCSV Bcsv, string KeyField, string ValueField, int Game, int GameSystem)
        where K : notnull
        where V : notnull
    {
        Dictionary<K, V> Data = [];

        uint KeyHash = BCSV.StringToHash_JGadget(KeyField);
        uint ValueHash = BCSV.StringToHash_JGadget(ValueField);
        uint GameHash = BCSV.StringToHash_JGadget("Game");
        uint GameSystemHash = BCSV.StringToHash_JGadget("GameSystem");

        bool HasGameSystem = Bcsv.ContainsField(GameSystemHash);

        for (int i = 0; i < Bcsv.EntryCount; i++)
        {
            BCSV.Entry cur = Bcsv[i];

            int curGame = (int)cur[Bcsv[GameHash]];
            if (curGame == 0 || curGame == Game || Game == -1)
            {
                if (HasGameSystem)
                {
                    int curGameSystem = (int)cur[Bcsv[GameSystemHash]];
                    if (curGameSystem != 0 && curGameSystem != GameSystem)
                        continue;
                }

                K Key = (K)cur[Bcsv[KeyHash]];
                V Value = (V)cur[Bcsv[ValueHash]];
                Data.Add(Key, Value);
            }
        }

        return Data;
    }

    private static T? GetDataByName<T>(BCSV Bcsv, string Name, string Field, int Game, int GameSystem, string NameField = "Name")
        where T : notnull
    {
        uint NameHash = BCSV.StringToHash_JGadget(NameField);
        uint ValueHash = BCSV.StringToHash_JGadget(Field);
        uint GameHash = BCSV.StringToHash_JGadget("Game");
        uint GameSystemHash = BCSV.StringToHash_JGadget("GameSystem");

        bool HasGameSystem = Bcsv.ContainsField(GameSystemHash);
        for (int i = 0; i < Bcsv.EntryCount; i++)
        {
            BCSV.Entry cur = Bcsv[i];

            int curGame = (int)cur[Bcsv[GameHash]];
            if (curGame == 0 || curGame == Game || Game == -1)
            {
                if (HasGameSystem)
                {
                    int curGameSystem = (int)cur[Bcsv[GameSystemHash]];
                    if (curGameSystem != 0 && curGameSystem != GameSystem)
                        continue;
                }

                string CurName = (string)cur[Bcsv[NameHash]];
                if (CurName.Equals(Name))
                    return (T)cur[Bcsv[ValueHash]];
            }
        }

        return default;
    }
    #endregion

    private static void SetSelectionInComboBox(ComboBox cb, string Text)
    {
        if (cb.DataSource is not null and BindingSource { DataSource: Dictionary<string, string> dict })
            foreach (KeyValuePair<string, string> item in dict)
            {
                if (Text.Equals(item.Key))
                {
                    cb.SelectedItem = item;
                    return;
                }
            }

        cb.SelectedItem = null;
        cb.Text = Text;
        return;
    }

    private static string GetSelectionInComboBox(ComboBox cb)
    {
        if (cb.SelectedItem != null)
            return ((dynamic)cb.SelectedItem).Key;

        return cb.Text;
    }

    private void ScenarioListView_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (IsIgnoreChanges)
            return;

        if (ScenarioListView.SelectedItems.Count == 0)
        {
            SetAppStatus(false);
            return;
        }

        IsIgnoreChanges = true;
        SuspendLayout();

        var x = ScenarioListView.SelectedItems[0].Tag;
        if (x is null)
        {
            return; // Should be impossible...
        }
        ScenarioData.Scenario Current = (ScenarioData.Scenario)x;


        int tmp = ZonesListBox.SelectedIndex;

        ZonesListBox.SelectedIndex = -1;
        ScenarioNameTextBox.Text = Current.Name;
        ScenarioNumNumericUpDown.Value = Current.ScenarioNo;
        SetSelectionInComboBox(ScenarioTypeComboBox, Current.Type);
        SetSelectionInComboBox(CometComboBox, Current.Comet);
        AppearenceTextBox.Text = Current.Appearence;
        TimeLimitNumericUpDown.Value = Current.CometTimeLimit;

        for (int i = 0; i < StarCheckedListBox.Items.Count; i++)
        {
            StarCheckedListBox.SetItemChecked(i, Current[i]);
        }

        ZonesListBox.SelectedIndex = tmp;
        SetAppStatus(true);
        ResumeLayout();
        IsIgnoreChanges = false;
        UpdateStatusBar(true);
    }

    private void ZonesListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (IsIgnoreChanges)
            return;
        if (ZonesListBox.SelectedIndex == -1 || ScenarioListView.SelectedItems.Count == 0)
        {
            LayerACheckBox.Checked = LayerACheckBox.Enabled = false;
            LayerBCheckBox.Checked = LayerBCheckBox.Enabled = false;
            LayerCCheckBox.Checked = LayerCCheckBox.Enabled = false;
            LayerDCheckBox.Checked = LayerDCheckBox.Enabled = false;
            LayerECheckBox.Checked = LayerECheckBox.Enabled = false;
            LayerFCheckBox.Checked = LayerFCheckBox.Enabled = false;
            LayerGCheckBox.Checked = LayerGCheckBox.Enabled = false;
            LayerHCheckBox.Checked = LayerHCheckBox.Enabled = false;
            LayerICheckBox.Checked = LayerICheckBox.Enabled = false;
            LayerJCheckBox.Checked = LayerJCheckBox.Enabled = false;
            LayerKCheckBox.Checked = LayerKCheckBox.Enabled = false;
            LayerLCheckBox.Checked = LayerLCheckBox.Enabled = false;
            LayerMCheckBox.Checked = LayerMCheckBox.Enabled = false;
            LayerNCheckBox.Checked = LayerNCheckBox.Enabled = false;
            LayerOCheckBox.Checked = LayerOCheckBox.Enabled = false;
            LayerPCheckBox.Checked = LayerPCheckBox.Enabled = false;
            return;
        }
        IsIgnoreChanges = true;

        var x = ScenarioListView.SelectedItems[0].Tag;
        if (x is null)
        {
            return; // Should be impossible...
        }
        ScenarioData.Scenario Current = (ScenarioData.Scenario)x;
        var CurZone = Current.Zones[ZonesListBox.SelectedIndex];

        LayerACheckBox.Checked = CurZone[0];
        LayerACheckBox.Enabled = true;
        LayerBCheckBox.Checked = CurZone[1];
        LayerBCheckBox.Enabled = true;
        LayerCCheckBox.Checked = CurZone[2];
        LayerCCheckBox.Enabled = true;
        LayerDCheckBox.Checked = CurZone[3];
        LayerDCheckBox.Enabled = true;
        LayerECheckBox.Checked = CurZone[4];
        LayerECheckBox.Enabled = true;
        LayerFCheckBox.Checked = CurZone[5];
        LayerFCheckBox.Enabled = true;
        LayerGCheckBox.Checked = CurZone[6];
        LayerGCheckBox.Enabled = true;
        LayerHCheckBox.Checked = CurZone[7];
        LayerHCheckBox.Enabled = true;
        LayerICheckBox.Checked = CurZone[8];
        LayerICheckBox.Enabled = true;
        LayerJCheckBox.Checked = CurZone[9];
        LayerJCheckBox.Enabled = true;
        LayerKCheckBox.Checked = CurZone[10];
        LayerKCheckBox.Enabled = true;
        LayerLCheckBox.Checked = CurZone[11];
        LayerLCheckBox.Enabled = true;
        LayerMCheckBox.Checked = CurZone[12];
        LayerMCheckBox.Enabled = true;
        LayerNCheckBox.Checked = CurZone[13];
        LayerNCheckBox.Enabled = true;
        LayerOCheckBox.Checked = CurZone[14];
        LayerOCheckBox.Enabled = true;
        LayerPCheckBox.Checked = CurZone[15];
        LayerPCheckBox.Enabled = true;


        IsIgnoreChanges = false;
    }

    #region FileToolStripMenuItem
    private void NewToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (Program.IsUnsavedChanges)
        {
            if (MessageBox.Show("Are you sure you want to open a different file?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
        }

        ScenarioListView.Clear();
        ZonesListBox.Items.Clear();
        ZonesListBox.Items.Add("UnknownGalaxy");
        AddScenarioToolStripMenuItem_Click(sender, e);
        CurrentFileName = null;
        ZonesListBox.SelectedIndex = 0;
        SaveToolStripMenuItem.Enabled = true;
        SaveAsToolStripMenuItem.Enabled = true;
        AddScenarioToolStripMenuItem.Enabled = true;
        RemoveScenarioToolStripMenuItem.Enabled = true;
        TemplatesToolStripMenuItem.Enabled = true;
    }

    private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (Program.IsUnsavedChanges)
        {
            if (MessageBox.Show("Are you sure you want to open a different file?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
        }
        string? prev = InfoToolStripStatusLabel.Text;
        StatusTimer.Stop();
        InfoToolStripStatusLabel.Text = "Choosing Archive...";
        if (ofd.ShowDialog() == DialogResult.OK && ofd.FileName != "")
        {
            OpenWith(ofd.FileName);
        }
        else
            InfoToolStripStatusLabel.Text = prev;

        StatusTimer.Start();
    }

    private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(CurrentFileName))
            SaveAsToolStripMenuItem_Click(sender, e);
        else
            Save(CurrentFileName);
    }

    private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (sfd.ShowDialog() != DialogResult.OK || string.IsNullOrWhiteSpace(sfd.FileName))
            return;

        Save(sfd.FileName);
    }
    #endregion

    #region EditToolStripMenuItem
    private void AddScenarioToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (ScenarioListView.Items.Count >= 32)
        {
            MessageBox.Show("You've reached the Maximum number of Scenarios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        ScenarioData.Scenario NEW = new();

        foreach (var item in ZonesListBox.Items)
        {
            ScenarioData.Zone NEWZONE = new() { Name = item.ToString() ?? throw new Exception() };
            NEW.Zones.Add(NEWZONE);
        }

        NEW.ScenarioNo = ScenarioListView.Items.Count + 1;
        if (NEW.ScenarioNo <= 32 && NEW.ScenarioNo > 0) //dunno how it's be 0...
            NEW[NEW.ScenarioNo - 1] = true;

        int Index = ScenarioListView.Items.Count;
        ListViewItem LVI = new() { Tag = NEW, Text = NEW.Name, ImageIndex = Index };
        ScenarioListView.Items.Add(LVI);
        InfoToolStripStatusLabel.Text = $"Added \"{NEW.Name}\"";
        Program.IsUnsavedChanges = true;
        StatusResumeCountdown = 3;
        CreateScenarioImage(Index);
        ScenarioListView.SelectedItems.Clear();
        LVI.Selected = true;
    }

    private void RemoveScenarioToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (ScenarioListView.SelectedIndices.Count == 0)
        {
            InfoToolStripStatusLabel.Text = "No Scenario is selected";
            StatusResumeCountdown = 4;
            return;
        }
        if (ScenarioListView.SelectedItems[0].Tag is ScenarioData.Scenario X)
        {
            InfoToolStripStatusLabel.Text = "Removed \"" + X.Name + "\"";
            Program.IsUnsavedChanges = true;
        }

        int tmp = ScenarioListView.SelectedIndices[0];
        ScenarioListView.Items.RemoveAt(tmp);
    }

    private void MoveScenarioUpToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (ScenarioListView.SelectedItems.Count == 0)
            return;

        IsIgnoreChanges = true;

        int index = ScenarioListView.SelectedIndices[0];
        int dest = index == 0 ? ScenarioListView.Items.Count - 1 : index - 1;

        ScenarioListView.BeginUpdate();
        ListViewItem LVI = ScenarioListView.Items[index];
        //ScenarioListView.Items.RemoveAt(index-1);
        //ScenarioListView.Items.Insert(dest+1, LVI);
        List<ListViewItem> LVIs = new(ScenarioListView.Items.Count);
        for (int i = 0; i < ScenarioListView.Items.Count; i++)
            if (i != index)
                LVIs.Add(ScenarioListView.Items[i]);


        ScenarioListView.Items.Clear();
        int LVIIndex = 0;
        for (int i = 0; i < LVIs.Count + 1; i++)
        {
            ListViewItem itm;
            if (i != dest)
                itm = LVIs[LVIIndex++];
            else
                itm = LVI;

            itm.ImageIndex = i;
            ScenarioListView.Items.Add(itm);
        }
        CreateAllScenarioImage();
        ScenarioListView.EndUpdate();
        IsIgnoreChanges = false;
    }

    private void MoveScenarioDownToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (ScenarioListView.SelectedItems.Count == 0)
            return;

        IsIgnoreChanges = true;

        int index = ScenarioListView.SelectedIndices[0];
        int dest = index == ScenarioListView.Items.Count - 1 ? 0 : index + 1;

        ScenarioListView.BeginUpdate();
        ListViewItem LVI = ScenarioListView.Items[index];
        //ScenarioListView.Items.RemoveAt(index-1);
        //ScenarioListView.Items.Insert(dest+1, LVI);
        List<ListViewItem> LVIs = new(ScenarioListView.Items.Count);
        for (int i = 0; i < ScenarioListView.Items.Count; i++)
            if (i != index)
                LVIs.Add(ScenarioListView.Items[i]);


        ScenarioListView.Items.Clear();
        int LVIIndex = 0;
        for (int i = 0; i < LVIs.Count + 1; i++)
        {
            ListViewItem itm;
            if (i != dest)
                itm = LVIs[LVIIndex++];
            else
                itm = LVI;

            itm.ImageIndex = i;
            ScenarioListView.Items.Add(itm);
        }
        CreateAllScenarioImage();
        ScenarioListView.EndUpdate();
        IsIgnoreChanges = false;
    }

    private void TemplatesToolStripMenuItem_Click(object sender, EventArgs e)
    {
        TemplateForm TF = new(this, GameModeToolStripComboBox.SelectedIndex + 1, IsUsePowerStarColor ? 2 : 1);
        if (TF.ShowDialog() == DialogResult.OK)
        {
            if (ScenarioListView.Items.Count >= 32)
            {
                MessageBox.Show("You've reached the Maximum number of Scenarios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ScenarioData.Scenario? NEWr = TF.CreateScenario();
            if (NEWr is null)
                return; //ERROR

            ScenarioData.Scenario NEW = NEWr.Value;

            foreach (var item in ZonesListBox.Items)
            {
                ScenarioData.Zone NEWZONE = new() { Name = item.ToString() ?? throw new Exception() };
                NEW.Zones.Add(NEWZONE);
            }

            NEW.ScenarioNo = ScenarioListView.Items.Count + 1;
            if (NEW.ScenarioNo <= 32 && NEW.ScenarioNo > 0) //dunno how it's be 0...
                NEW[NEW.ScenarioNo - 1] = true;

            int Index = ScenarioListView.Items.Count;
            ListViewItem LVI = new() { Tag = NEW, Text = NEW.Name, ImageIndex = Index };
            ScenarioListView.Items.Add(LVI);
            InfoToolStripStatusLabel.Text = $"Added \"{NEW.Name}\"";
            Program.IsUnsavedChanges = true;
            StatusResumeCountdown = 3;
            CreateScenarioImage(Index);
            ScenarioListView.SelectedItems.Clear();
            LVI.Selected = true;
        }
    }
    #endregion

    #region SettingsToolStripMenuItem
    private void GameModeToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (IsBooting || IsLoadingFile)
            return;

        InitGUIForGame();
        ImageSizeToolStripComboBox_SelectedIndexChanged(sender, e);

        if (ScenarioListView.SelectedItems.Count > 0)
        {
            CometTimerButton.Enabled = IsSMG2;
            TimeLimitNumericUpDown.Enabled = IsSMG2;
        }
        Program.Settings.GameModeIndex = GameModeToolStripComboBox.SelectedIndex;
        Program.Settings.OnChanged(sender, e);
    }

    private void ImageSizeToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (IsBooting || IsLoadingFile)
            return;

        int Size = ImageSizeToolStripComboBox.SelectedIndex == 1 ? 177 : 64;
        ScenarioImages.ImageSize = new Size(Size, Size);
        ScenarioListView.View = ImageSizeToolStripComboBox.SelectedIndex == 1 ? View.LargeIcon : View.SmallIcon;
        CreateAllScenarioImage();
        Program.Settings.IconSizeIndex = ImageSizeToolStripComboBox.SelectedIndex;
        Program.Settings.OnChanged(sender, e);
    }

    private void CompressToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (IsBooting || IsLoadingFile)
            return;

        Program.Settings.EncodingIndex = CompressToolStripComboBox.SelectedIndex;
        Program.Settings.OnChanged(sender, e);
    }

    private void ThemeToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (IsBooting || IsLoadingFile)
            return;

        ProgramColors.IsDarkMode = ThemeToolStripComboBox.SelectedIndex == 1;
        Program.ReloadTheme();
        SettingsToolStripMenuItem.HideDropDown();
        ImageSizeToolStripComboBox_SelectedIndexChanged(sender, e);
        Program.Settings.ThemeIndex = ThemeToolStripComboBox.SelectedIndex;
        Program.Settings.OnChanged(sender, e);
    }
    #endregion

    #region Timer Stuff
    private const string UpdateName = "The Lights Out Update";

    private int StatusState = 0;
    private int Scrollnumber = 0;
    private int StatusResumeCountdown = 0;
    private const int MaxBeforeReset = 5;
    private readonly string[] Messages =
    [
        "Scenaristar " + UpdateInformation.ApplicationVersion + ", \"" + UpdateName + "\"",
        "Scenaristar was made by Super Hackio",
        "Scenaristar is powered by the Hack.io Libraries"
    ];
    private readonly string[] Flavour =
    [
        "Thank you for using Scenaristar!",
        "This is the start of the galaxy creation process, or is it the end?",
        "Legend has it that \"Grand\" and \"Seeker\" are new Scenario Types",
        "Can you imagine a world where Super Mario Galaxy doesn't exist?",
        "Big Yeet",
        "Evas ot tegrof tnod!",
        "Have you tried the Dark theme yet?",
        "Have you tried the Light theme yet?",
        "Need to make a commonly used scenario setup? Try the Templates!",
    ];

    private void StatusTimer_Tick(object sender, EventArgs e)
    {
        StatusState++;
        UpdateStatusBar();
    }

    private void UpdateStatusBar(bool Force = false)
    {
        if (!Force && StatusResumeCountdown > 0)
        {
            StatusResumeCountdown--;
            if (StatusResumeCountdown > 0)
                return;
        }

        if (StatusState < Messages.Length)
            InfoToolStripStatusLabel.Text = Messages[StatusState];
        else
        {
            if (ScenarioListView.Items.Count == 0 && !EditToolStripMenuItem.Enabled)
                InfoToolStripStatusLabel.Text = "No File Loaded. Create a new file, or open an existing file to get started";
            else
            {
                string FileData = new FileInfo(CurrentFileName ?? "Unsaved File").Name.Replace("Scenario.arc", "");
                string Tailer;

                if (ScenarioListView.Items.Count == 0)
                    Tailer = ". Add a Scenario to start editing";
                else if (ScenarioListView.SelectedIndices.Count != 0)
                {
                    var x = ScenarioListView.SelectedItems[0].Tag ?? throw new InvalidOperationException("Cannot cast TAG to ScenarioData.");
                    ScenarioData.Scenario curScenario = (ScenarioData.Scenario)x;
                    string StarTypeString;
                    if (string.IsNullOrWhiteSpace(curScenario.Comet))
                        StarTypeString = $"{curScenario.Type} star.";
                    else
                        StarTypeString = $"{CometComboBox.Text} comet.";
                    Tailer = $", {curScenario.Name}. It's a {StarTypeString}";
                }
                else
                    Tailer = ". Select a scenario to start editing";
                InfoToolStripStatusLabel.Text = $"Editing {FileData}{Tailer}";
            }
        }

        if (StatusState > MaxBeforeReset)
        {
            StatusState = 0;
            Random rng = new();
            if (rng.Next(0, 100) < 100)
            {
                InfoToolStripStatusLabel.Text = Flavour[rng.Next(0, Flavour.Length)];
                StatusResumeCountdown = 1;
            }
        }
        InfoToolStripStatusLabel.Text += "   ";
    }

    private void InfoToolStripStatusLabel_TextChanged(object sender, EventArgs e)
    {
        if (InfoToolStripStatusLabel.Text is null)
            return;

        if (InfoToolStripStatusLabel.Text.Length > 80 && Scrollnumber == -1)
        {
            StatusStripTimer.Start();
            Delay = 25;
            Scrollnumber = 0;
        }
        else if (InfoToolStripStatusLabel.Text.Length < 80)
        {
            StatusStripTimer.Stop();
            Scrollnumber = -1;
        }

        if (Scrollnumber == InfoToolStripStatusLabel.Text.Length - 1)
        {
            StatusStripTimer.Stop();
            Scrollnumber = -1;
        }
    }

    private int Delay = 0;
    private void StatusStripTimer_Tick(object sender, EventArgs e)
    {
        StatusResumeCountdown = 2;
        if (Delay > 0)
        {
            Delay--;
            return;
        }
        List<char> String = [];
        List<char> NewString = [];
        string curText = InfoToolStripStatusLabel?.Text ?? "";
        String.AddRange(curText.ToCharArray());

        for (int i = 1; i < String.Count; i++)
            NewString.Add(String[i]);
        NewString.Add(String[0]);

        string a = "";
        foreach (char C in NewString)
            a += C;

        if (InfoToolStripStatusLabel is not null)
            InfoToolStripStatusLabel.Text = a;
        Scrollnumber++;
    }
    #endregion

    private void ScenarioNameTextBox_TextChanged(object sender, EventArgs e)
    {
        if (IsIgnoreChanges)
            return;

        if (ScenarioListView.SelectedItems[0].Tag is ScenarioData.Scenario X)
        {
            X.Name = ScenarioNameTextBox.Text;
            ScenarioListView.SelectedItems[0].Text = ScenarioNameTextBox.Text;
            Program.IsUnsavedChanges = true;
            ScenarioListView.SelectedItems[0].Tag = X;
        }
    }

    private void ScenarioNumNumericUpDown_ValueChanged(EventArgs e)
    {
        if (IsIgnoreChanges)
            return;

        if (ScenarioListView.SelectedItems[0].Tag is ScenarioData.Scenario X)
        {
            X.ScenarioNo = (int)ScenarioNumNumericUpDown.Value;
            Program.IsUnsavedChanges = true;
            ScenarioListView.SelectedItems[0].Tag = X;
        }
    }

    private void TimeLimitNumericUpDown_ValueChanged(EventArgs e)
    {
        if (IsIgnoreChanges)
            return;

        if (ScenarioListView.SelectedItems[0].Tag is ScenarioData.Scenario X)
        {
            X.CometTimeLimit = (int)TimeLimitNumericUpDown.Value;
            Program.IsUnsavedChanges = true;
            ScenarioListView.SelectedItems[0].Tag = X;
        }
    }

    private void CometTimerButton_Click(object sender, EventArgs e)
    {
        CometTimerForm CTF = new((int)TimeLimitNumericUpDown.Value);
        if (CTF.ShowDialog() == DialogResult.OK)
        {
            TimeLimitNumericUpDown.Value = CTF.TimeLimit;
        }
    }

    private void ScenarioTypeComboBox_SelectionChanged(object sender, EventArgs e)
    {
        if (IsIgnoreChanges)
            return;

        if (ScenarioListView.SelectedItems[0].Tag is ScenarioData.Scenario X)
        {
            X.Type = GetSelectionInComboBox(ScenarioTypeComboBox);
            Program.IsUnsavedChanges = true;
            ScenarioListView.SelectedItems[0].Tag = X;
            CreateScenarioImage(ScenarioListView.SelectedItems[0].Index);
        }
    }

    private void CometComboBox_SelectionChanged(object sender, EventArgs e)
    {
        if (IsIgnoreChanges)
            return;

        if (ScenarioListView.SelectedItems[0].Tag is ScenarioData.Scenario X)
        {
            X.Comet = GetSelectionInComboBox(CometComboBox);
            Program.IsUnsavedChanges = true;
            ScenarioListView.SelectedItems[0].Tag = X;
            CreateScenarioImage(ScenarioListView.SelectedItems[0].Index);
        }
    }

    private void AppearenceTextBox_TextChanged(object sender, EventArgs e)
    {
        if (IsIgnoreChanges)
            return;

        if (ScenarioListView.SelectedItems[0].Tag is ScenarioData.Scenario X)
        {
            X.Appearence = AppearenceTextBox.Text;
            Program.IsUnsavedChanges = true;
            ScenarioListView.SelectedItems[0].Tag = X;
            CreateScenarioImage(ScenarioListView.SelectedItems[0].Index);
        }
    }

    private void AppearenceButton_Click(object sender, EventArgs e)
    {
        Dictionary<string, string> listing = CreateFieldDictionaryValidateGameAndSystem<string, string>(AppearanceTableData, "AppearPowerStarObj", "Data", GameModeToolStripComboBox.SelectedIndex + 1, IsUsePowerStarColor ? 1 : 0);
        StarAppearenceForm Star = new(this, listing);
        Star.ShowDialog();
    }


    private void LayerCheckBox_CheckedChanged(object sencer, EventArgs e)
    {
        if (IsIgnoreChanges)
            return;

        if (ScenarioListView.SelectedItems.Count == 0)
            return;

        if (ScenarioListView.SelectedItems[0].Tag is ScenarioData.Scenario X)
        {
            ScenarioData.Zone Z = X.Zones[ZonesListBox.SelectedIndex];

            Z[0] = LayerACheckBox.Checked;
            Z[1] = LayerBCheckBox.Checked;
            Z[2] = LayerCCheckBox.Checked;
            Z[3] = LayerDCheckBox.Checked;
            Z[4] = LayerECheckBox.Checked;
            Z[5] = LayerFCheckBox.Checked;
            Z[6] = LayerGCheckBox.Checked;
            Z[7] = LayerHCheckBox.Checked;
            Z[8] = LayerICheckBox.Checked;
            Z[9] = LayerJCheckBox.Checked;
            Z[10] = LayerKCheckBox.Checked;
            Z[11] = LayerLCheckBox.Checked;
            Z[12] = LayerMCheckBox.Checked;
            Z[13] = LayerNCheckBox.Checked;
            Z[14] = LayerOCheckBox.Checked;
            Z[15] = LayerPCheckBox.Checked;
            X.Zones[ZonesListBox.SelectedIndex] = Z;
            ScenarioListView.SelectedItems[0].Tag = X;
            Program.IsUnsavedChanges = true;
        }
    }

    private void StarCheckedListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (IsIgnoreChanges)
            return;

        if (ScenarioListView.SelectedItems[0].Tag is ScenarioData.Scenario X)
        {
            for (int i = 0; i < StarCheckedListBox.Items.Count; i++)
            {
                X[i] = StarCheckedListBox.GetItemChecked(i);
            }
            ScenarioListView.SelectedItems[0].Tag = X;
            Program.IsUnsavedChanges = true;
        }
    }

    private void RenameZoneButton_Click(object sender, EventArgs e)
    {
        if (ZonesListBox.SelectedIndex == -1)
            return;

        string original = ZonesListBox.SelectedItem?.ToString() ?? "ERROR"; // should never error...
        ZoneForm AddZoneDialog = new() { Text = "Scenaristar - Rename Zone" };
        AddZoneDialog.NameTextBox.Text = original;
        if (AddZoneDialog.ShowDialog(this) == DialogResult.OK)
        {
            IsIgnoreChanges = true;
            string ZoneName = AddZoneDialog.NameTextBox.Text;
            AddZoneDialog.Dispose();

            int INDEX = ZonesListBox.SelectedIndex;
            ZonesListBox.Items[INDEX] = ZoneName;

            for (int i = 0; i < ScenarioListView.Items.Count; i++)
            {
                ListViewItem LVI = ScenarioListView.Items[i];
                if (LVI.Tag is ScenarioData.Scenario X)
                {
                    ScenarioData.Zone Z = X.Zones[INDEX];
                    Z.Name = ZoneName;
                    X.Zones[INDEX] = Z;
                    ScenarioListView.Items[i].Tag = X;
                }
            }

            InfoToolStripStatusLabel.Text = $"Renamed \"{original}\" to \"{ZoneName}\"";
            StatusResumeCountdown = 4;
            Program.IsUnsavedChanges = true;
            IsIgnoreChanges = false;
        }
    }

    private void AddZoneButton_Click(object sender, EventArgs e)
    {
        ZoneForm AddZoneDialog = new();

        // Show testDialog as a modal dialog and determine if DialogResult = OK.
        if (AddZoneDialog.ShowDialog(this) == DialogResult.OK)
        {
            string ZoneName = AddZoneDialog.NameTextBox.Text;
            if (ZonesListBox.Items.Contains(ZoneName))
            {
                MessageBox.Show("Duplicate Zone Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                InfoToolStripStatusLabel.Text = $"Cannot add duplicate Zone \"{ZoneName}\"";
                StatusResumeCountdown = 4;
                return;
            }

            // Read the contents of testDialog's TextBox.
            IsIgnoreChanges = true;
            AddZoneDialog.Dispose();

            ZonesListBox.Items.Add(ZoneName);

            for (int i = 0; i < ScenarioListView.Items.Count; i++)
            {
                ListViewItem LVI = ScenarioListView.Items[i];
                if (LVI.Tag is ScenarioData.Scenario X)
                {
                    X.Zones.Add(new() { Name = ZoneName });
                    ScenarioListView.Items[i].Tag = X;
                }
            }

            InfoToolStripStatusLabel.Text = $"Added Zone \"{ZoneName}\"";
            StatusResumeCountdown = 2;
            Program.IsUnsavedChanges = true;
            IsIgnoreChanges = false;
        }
    }

    private void SubtractZoneButton_Click(object sender, EventArgs e)
    {
        if (ZonesListBox.SelectedIndex == 0)
        {
            InfoToolStripStatusLabel.Text = "Cannot remove \"" + ZonesListBox.SelectedItem + "\" because it's a Galaxy";
            StatusResumeCountdown = 4;
            return;
        }

        if (ZonesListBox.Items.Count - 1 == 0)
        {
            InfoToolStripStatusLabel.Text = "Cannot remove Zone \"" + ZonesListBox.SelectedItem + "\" because it's the last zone";
            StatusResumeCountdown = 4;
            return;
        }

        IsIgnoreChanges = true;
        InfoToolStripStatusLabel.Text = "Removed Zone \"" + ZonesListBox.SelectedItem + "\"";
        StatusResumeCountdown = 2;
        int REPLACE = ZonesListBox.SelectedIndex;
        ZonesListBox.Items.RemoveAt(REPLACE);

        for (int i = 0; i < ScenarioListView.Items.Count; i++)
        {
            ListViewItem LVI = ScenarioListView.Items[i];
            if (LVI.Tag is ScenarioData.Scenario X)
            {
                X.Zones.RemoveAt(REPLACE);
                ScenarioListView.Items[i].Tag = X;
            }
        }

        if (REPLACE > 0)
            ZonesListBox.SelectedIndex = REPLACE - 1;
        else
            ZonesListBox.SelectedIndex = 0;
        Program.IsUnsavedChanges = true;
        IsIgnoreChanges = false;
    }

    private void MoveZoneUpButton_Click(object sender, EventArgs e)
    {
        if (ZonesListBox.SelectedIndex < 2)
            return;

        IsIgnoreChanges = true;

        int ix = ZonesListBox.SelectedIndex;
        for (int i = 0; i < ScenarioListView.Items.Count; i++)
        {
            ListViewItem LVI = ScenarioListView.Items[i];
            if (LVI.Tag is ScenarioData.Scenario X)
            {
                X.Zones.Move(ix, ix - 1);
                ScenarioListView.Items[i].Tag = X;
            }
        }
        object? item = ZonesListBox.Items[ix];
        ZonesListBox.Items.RemoveAt(ix);
        ZonesListBox.Items.Insert(ix - 1, item);

        ZonesListBox.SelectedIndex = ix - 1;
        Program.IsUnsavedChanges = true;
        IsIgnoreChanges = false;
    }

    private void MoveZoneDownButton_Click(object sender, EventArgs e)
    {
        if (ZonesListBox.SelectedIndex == ZonesListBox.Items.Count - 1 || ZonesListBox.SelectedIndex == 0)
            return;

        IsIgnoreChanges = true;

        int ix = ZonesListBox.SelectedIndex;
        for (int i = 0; i < ScenarioListView.Items.Count; i++)
        {
            ListViewItem LVI = ScenarioListView.Items[i];
            if (LVI.Tag is ScenarioData.Scenario X)
            {
                X.Zones.Move(ix, ix + 1);
                ScenarioListView.Items[i].Tag = X;
            }
        }
        object? item = ZonesListBox.Items[ix];
        ZonesListBox.Items.RemoveAt(ix);
        ZonesListBox.Items.Insert(ix + 1, item);

        ZonesListBox.SelectedIndex = ix + 1;
        Program.IsUnsavedChanges = true;
        IsIgnoreChanges = false;
    }
}
