using DarkModeForms;
using Hack.io.BCSV;
using Hack.io.Utility;

namespace Scenaristar;

public partial class TemplateForm : Form
{
    private readonly ScenarioEditorForm MF;
    private readonly BCSV TemplateDataTable;
    private readonly ImageList ScenarioImages = new() { ImageSize = new(64, 64) };

    public TemplateForm(ScenarioEditorForm owner, int Game, int GameSystem)
    {
        InitializeComponent();
        CenterToParent();
        MF = owner;


        StreamUtil.SetEndianBig(); //I'm keeping it Big Endian for the funny
        string TablePath = Path.Combine(Program.ASSET_PATH, "_TemplateTable.bcsv");
        if (!File.Exists(TablePath))
            throw new FileNotFoundException($"Failed to find {TablePath}");
        TemplateDataTable = new();
        FileUtil.LoadFile(TablePath, TemplateDataTable.Load);

        //Setup the templates
        uint NameHash = BCSV.StringToHash_JGadget("Name");
        uint DescriptionHash = BCSV.StringToHash_JGadget("Data");
        uint NeedsOwnerStarHash = BCSV.StringToHash_JGadget("Star");
        uint AllowTimeHash = BCSV.StringToHash_JGadget("Time");
        uint GameHash = BCSV.StringToHash_JGadget("Game");
        uint GameSystemHash = BCSV.StringToHash_JGadget("GameSystem");
        bool HasGameSystem = TemplateDataTable.ContainsField(GameSystemHash);
        for (int i = 0; i < TemplateDataTable.EntryCount; i++)
        {
            BCSV.Entry cur = TemplateDataTable[i];

            int curGame = (int)cur[TemplateDataTable[GameHash]];
            if (curGame == 0 || curGame == Game || Game == -1)
            {
                if (HasGameSystem)
                {
                    int curGameSystem = (int)cur[TemplateDataTable[GameSystemHash]];
                    if (curGameSystem != 0 && curGameSystem != GameSystem)
                        continue;
                }

                Template T = new()
                {
                    Name = (string)cur[TemplateDataTable[NameHash]],
                    Description = (string)cur[TemplateDataTable[DescriptionHash]],
                    NeedOwner = (int)cur[TemplateDataTable[NeedsOwnerStarHash]] > 0,
                    AllowTimer = (int)cur[TemplateDataTable[AllowTimeHash]] > 0,

                    PowerStarType = (string)cur[TemplateDataTable[ScenarioData.HASH_POWERSTARTYPE]],
                    Comet = (string)cur[TemplateDataTable[ScenarioData.HASH_COMET]],
                    PowerStarAppearObj = (string)cur[TemplateDataTable[ScenarioData.HASH_APPEARENCE]],
                    CometLimitTimer = (int)cur[TemplateDataTable[ScenarioData.HASH_COMETLIMITTIMER]],
                };
                ListViewItem LVI = new() { Tag = T, Text = T.Name, ImageIndex = ScenarioListView.Items.Count };
                Bitmap Base = MF.CreateScenarioBitmap(T.PowerStarType, T.Comet, T.PowerStarAppearObj, null);
                ScenarioImages.Images.Add(Base);
                ScenarioListView.Items.Add(LVI);
            }
        }


        ScenarioListView.LargeImageList = ScenarioImages;
        ScenarioListView.SmallImageList = ScenarioImages;
        StarGroupBox.Enabled = false;
        CometTimerGroupBox.Enabled = false;
        ProgramColors.ReloadTheme(this);
    }


    private void AddButton_Click(object sender, EventArgs e)
    {
        if (!IsSetOwnerStar())
        {
            MessageBox.Show("The selected template requires you to select a Star", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        DialogResult = DialogResult.OK;
        Close();
    }

    private void AbortButton_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }

    private void ScenarioListView_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ScenarioListView.SelectedItems.Count == 0)
        {
            OKButton.Enabled = false;
            return;
        }
        OKButton.Enabled = true;

        if (ScenarioListView.SelectedItems[0].Tag is Template T)
        {
            TemplateNameLabel.Text = T.Name;
            DescriptionTextBox.Text = T.Description;
            StarGroupBox.Enabled = T.NeedOwner;

            CometTimerGroupBox.Enabled = T.AllowTimer;
            CometMinutesNumericUpDown.Value = T.CometLimitTimer / 60;
            CometSecondsNumericUpDown.Value = T.CometLimitTimer % 60;
        }
    }

    private bool IsSetOwnerStar()
    {
        if (ScenarioListView.SelectedItems.Count == 0)
            return false;

        if (ScenarioListView.SelectedItems[0].Tag is Template T)
        {
            if (!T.NeedOwner)
                return true;

            for (int i = 0; i < StarCheckedListBox.Items.Count; i++)
            {
                if (StarCheckedListBox.GetItemChecked(i))
                    return true;
            }
        }
        return false;
    }

    private int TimeLimit => (int)((60 * CometMinutesNumericUpDown.Value) + CometSecondsNumericUpDown.Value);

    public ScenarioData.Scenario? CreateScenario()
    {
        ScenarioData.Scenario NEW = new();
        if (ScenarioListView.SelectedItems[0].Tag is Template T)
        {
            NEW.Name = T.Name;
            NEW.Appearence = T.PowerStarAppearObj;
            NEW.Comet = T.Comet;
            NEW.CometTimeLimit = TimeLimit;

            for (int i = 0; i < StarCheckedListBox.Items.Count; i++)
            {
                if (StarCheckedListBox.GetItemChecked(i))
                    NEW[i] = true;
            }
            return NEW;
        }
        return null;
    }

    struct Template
    {
        public string Name;
        public string Description;
        public bool NeedOwner, AllowTimer;
        public string PowerStarType;
        public string Comet;
        public string PowerStarAppearObj;
        public int CometLimitTimer;
    }
}
