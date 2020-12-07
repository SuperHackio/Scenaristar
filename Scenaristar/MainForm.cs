using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hack.io.BCSV;
using GalaxyMaps;
using Hack.io.RARC;
using Hack.io.YAZ0;
using System.Reflection;
using Hack.io.Util;

namespace Scenaristar
{
    public partial class MainForm : Form
    {
        public MainForm(string[] args)
        {
            Loading = true;
            Startup = true;
            InitializeComponent();
            CenterToScreen();
            ScenarioListView.SetDoubleBuffered();
            Text = "Scenaristar - " + Application.ProductVersion;
            InfoToolStripStatusLabel.Text = "Welcome to Scenaristar!";
            ImageSizeToolStripComboBox.SelectedIndex = 0;
            ScenarioTypeComboBox.DataSource = Enum.GetValues(typeof(ScenarioSMG2.StarType));
            //CometComboBox.DataSource = Enum.GetValues(typeof(Scenario.CometType));

            string[] CometDescriptions = new string[]
            {
                "None",
                "Speedrun",
                "Purple Coins",
                "Daredevil",
                "Romp",
                "Cosmic Clones",
                "Double Time"
            };

            Dictionary<ScenarioSMG2.CometType, string> comboSource = new Dictionary<ScenarioSMG2.CometType, string>();
            int I = 0;
            foreach (ScenarioSMG2.CometType COMET in Enum.GetValues(typeof(ScenarioSMG2.CometType)))
            {
                comboSource.Add(COMET, CometDescriptions[I]);
                I++;
            }
            CometComboBox.DataSource = new BindingSource(comboSource, null);
            CometComboBox.DisplayMember = "Value";
            CometComboBox.ValueMember = "Key";
            Loading = false;
            Startup = false;

            if (args.Length != 0)
                OpenWith(args[0]);

            StatusTimer.Start();

#if DEBUG
            ScenarioNumNumericUpDown.Maximum = 8;
#endif
        }
        //InfoToolStripStatusLabel.Text = "";
        //InfoToolStripProgressBar.PerformStep();
        OpenFileDialog ofd = new OpenFileDialog() { Filter = "Supported Files | *.arc; *.rarc|Scenario Archive |*.rarc; *.arc" };
        SaveFileDialog sfd = new SaveFileDialog() { Filter = "Supported Files | *.arc; *.rarc|Scenario Archive |*.rarc; *.arc", OverwritePrompt = false };
        List<ScenarioSMG2> ScenarioList = new List<ScenarioSMG2>();
        BCSV ScenarioBCSV;
        BCSV ZonesBCSV;

        uint Zonecount;
        bool Loading = false, Startup = false, OriginalFile = true;
        string privfilename = null;
        string CurrentFileName
        {
            get
            {
                return privfilename;
            }
            set
            {
                privfilename = value;
                CurrentFileToolStripTextBox.Text = new FileInfo(value ?? "Unsaved File").Name;
            }
        }

        /// <summary>
        /// Array of Hashes that every Scenario BCSV will contain
        /// </summary>
        static uint[] FixedHashesSMG2 = new uint[]
        {
            0xED08B591, //ScenarioID
            0xCDB16E5B, //Scenario Name
            0x7DAF4852, //PowerStarID
            0x5A59AAD5, //Appearence
            0xCF03D8B1, //Star Type
            0x03E441D0, //Comet Type
            0x9009023A, //Comet Timer
            0x500B84C0, //Luigi Timer
            0xD6C80400 //Unknown
        };
        /// <summary>
        /// List of Zone names
        /// </summary>
        public List<string> Zones = new List<string>();

        private void SetAppStatus(bool Trigger)
        {
            ScenarioNameTextBox.Enabled = Trigger;
            ScenarioNumNumericUpDown.Enabled = Trigger;
            ScenarioTypeComboBox.Enabled = Trigger;
            CometComboBox.Enabled = Trigger;
            AppearenceTextBox.Enabled = Trigger;
            AppearenceButton.Enabled = Trigger;
            ZonesListBox.Enabled = Trigger;
            Star1CheckBox.Enabled = Trigger;
            Star2CheckBox.Enabled = Trigger;
            Star3CheckBox.Enabled = Trigger;
            Star4CheckBox.Enabled = Trigger;
            Star5CheckBox.Enabled = Trigger;
            Star6CheckBox.Enabled = Trigger;
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
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!OriginalFile)
            {
                if (MessageBox.Show("Are you sure you want to create a new file?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    return;
            }
            ScenarioList.Clear();
            Zones.Clear();
            StarLargeImageList.Images.Clear();
            StarSmallImageList.Images.Clear();
            ScenarioListView.Items.Clear();
            Zones.Add("UnknownGalaxy");
            ScenarioList.Add(new ScenarioSMG2() { Zones = new List<Zone>() { new Zone("UnknownGalaxy") } });
            for (int i = 0; i < ScenarioList.Count; i++)
            {
                CompileImage(i);
                ListViewItem LVI = new ListViewItem() { Tag = ScenarioList[i], Text = ScenarioList[i].Name, ImageIndex = i };
                ScenarioListView.Items.Add(LVI);
            }
            ZonesListBox.Items.Clear();
            for (int i = 0; i < Zones.Count; i++)
                ZonesListBox.Items.Add(Zones[i]);
            CurrentFileName = null;
            ScenarioListView.Items[0].Selected = true;
            ZonesListBox.SelectedIndex = 0;
            SaveToolStripMenuItem.Enabled = true;
            SaveAsToolStripMenuItem.Enabled = true;
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!OriginalFile)
            {
                if (MessageBox.Show("Are you sure you want to open a different file?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    return;
            }
            string prev = InfoToolStripStatusLabel.Text;
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

        private void OpenWith(string Filename)
        {
            ScenarioList.Clear();
            Zones.Clear();
            StarLargeImageList.Images.Clear();
            StarSmallImageList.Images.Clear();
            ScenarioListView.Items.Clear();
            FileInfo inuse = new FileInfo(Filename);
            if (inuse.IsFileLocked())
            {
                MessageBox.Show("The chosen file could not be accessed.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool ARC = new FileInfo(Filename).Extension == ".arc";
            bool RARC = new FileInfo(Filename).Extension == ".rarc";
            //bool BCSV = new FileInfo(Filename).Extension == ".bcsv";

            if (ARC || RARC)
            {
                InfoToolStripStatusLabel.Text = "Loading...";
                Refresh();
                RARC ScenarioArchive = YAZ0.Check(Filename) ? new RARC(new MemoryStream(YAZ0.Decompress(File.ReadAllBytes(Filename))), Filename) : new RARC(Filename);
                string ScenarioDataPath = ScenarioArchive.GetItemKeyFromNoCase("ScenarioData.bcsv");
                if (ScenarioDataPath is null)
                {
                    MessageBox.Show("This archive doesn't have any ScenarioData.bcsv files.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                ScenarioBCSV = (RARC.File)ScenarioArchive[ScenarioDataPath];


                string ZoneListPath = ScenarioArchive.GetItemKeyFromNoCase("ZoneList.bcsv");
                if (ZoneListPath is null)
                {
                    MessageBox.Show("This archive doesn't have any ZoneList.bcsv files.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                ZonesBCSV = (RARC.File)ScenarioArchive[ZoneListPath];

                for (int i = 0; i < ZonesBCSV.EntryCount; i++)
                {
                    if (ZonesBCSV.Entries[i].Data.TryGetValue(0x3666C077, out object result))
                        Zones.Add(result.ToString());
                    else
                    {
                        MessageBox.Show("Error in " + ZonesBCSV.FileName + Environment.NewLine + "Failed to get the requested Value from hash 0x3666C077. (Entry "+i+")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                
                for (int i = 0; i < ScenarioBCSV.EntryCount; i++)
                {
                    ScenarioSMG2 Addme = new ScenarioSMG2();
                    if (ScenarioBCSV[i].TryGetValue(FixedHashesSMG2[0], out object result))
                        Addme.Number = (int)result;
                    if (ScenarioBCSV[i].TryGetValue(FixedHashesSMG2[1], out result))
                        Addme.Name = result.ToString();
                    if (ScenarioBCSV[i].TryGetValue(FixedHashesSMG2[2], out result))
                        Addme.PowerStarID = (int)result;
                    if (ScenarioBCSV[i].TryGetValue(FixedHashesSMG2[3], out result))
                        Addme.Appearence = result.ToString();
                    if (ScenarioBCSV[i].TryGetValue(FixedHashesSMG2[4], out result))
                    {
                        string type = result.ToString();
                        if (Enum.TryParse(type, out ScenarioSMG2.StarType value))
                            Addme.Type = value;
                        else
                        {
                            MessageBox.Show("Scenario \""+Addme.Name+"\" has an "+(type.Equals("Red") ? "unsupported" : "invalid")+" star type of "+ type+Environment.NewLine+"It will be replaced with a Normal Star");
                            Addme.Type = ScenarioSMG2.StarType.Normal;
                            MessageBox.Show("Scenario \"" + Addme.Name + "\" has an " + (type.Equals("Blue") ? "unsupported" : "invalid") + " star type of " + type + Environment.NewLine + "It will be replaced with a Normal Star");
                            Addme.Type = ScenarioSMG2.StarType.Normal;
                        }
                    }
                    if (ScenarioBCSV[i].TryGetValue(FixedHashesSMG2[5], out result))
                        Addme.Comet = result.ToString() != "" ? (ScenarioSMG2.CometType)Enum.Parse(typeof(ScenarioSMG2.CometType), result.ToString(), true) : ScenarioSMG2.CometType.None;
                    if (ScenarioBCSV[i].TryGetValue(FixedHashesSMG2[6], out result))
                        Addme.TimeLimit = (int)result;
                    if (ScenarioBCSV[i].TryGetValue(FixedHashesSMG2[7], out result))
                        Addme.LuigiTimeLimit = (int)result;
                    if (ScenarioBCSV[i].TryGetValue(FixedHashesSMG2[8], out result))
                        Addme.Unknown = (int)result;
                    for (int j = 0; j < Zones.Count; j++)
                    {
                        if (ScenarioBCSV[i].TryGetValue(BCSV.FieldNameToHash(Zones[j]), out result))
                            Addme.Zones.Add(new Zone(Zones[j], (int)result));
                    }

                    ScenarioList.Add(Addme);
                }

                for (int i = 0; i < ScenarioList.Count; i++)
                {
                    CompileImage(i);
                    ListViewItem LVI = new ListViewItem() { Tag = ScenarioList[i], Text = ScenarioList[i].Name, ImageIndex = i };
                    ScenarioListView.Items.Add(LVI);
                }
                ZonesListBox.Items.Clear();
                for (int i = 0; i < Zones.Count; i++)
                        ZonesListBox.Items.Add(Zones[i]);
            }

            ScenarioListView.Items[0].Selected = true;
            ZonesListBox.SelectedIndex = 0;
            SaveToolStripMenuItem.Enabled = true;
            SaveAsToolStripMenuItem.Enabled = true;
            CurrentFileName = Filename;
            InfoToolStripStatusLabel.Text = new FileInfo(CurrentFileName ?? "Unsaved File").Name + " Loaded!";
            StatusResumeCountdown = 3;
            StatusTimer.Start();
            SetAppStatus(true);
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentFileName == null)
                SaveAsToolStripMenuItem_Click(sender, e);
            else
                Save();
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sfd.ShowDialog() == DialogResult.OK && sfd.FileName != "")
            {
                string previous = CurrentFileName;
                CurrentFileName = sfd.FileName;
                if (!Save())
                    CurrentFileName = previous;
            }
        }

        private bool Save()
        {
            StatusTimer.Stop();
            Zonecount = (uint)Zones.Count;
            if (new FileInfo(CurrentFileName).IsFileLocked())
            {
                InfoToolStripStatusLabel.Text = "Failed to access the Archive";
                StatusResumeCountdown = 3;
                StatusTimer.Start();
                return false;
            }
            RARC ScenarioArchive = YAZ0.Check(CurrentFileName) ? new RARC(new MemoryStream(YAZ0.Decompress(File.ReadAllBytes(CurrentFileName))), CurrentFileName) : new RARC(CurrentFileName);

            string ScenarioDataPath = ScenarioArchive.GetItemKeyFromNoCase("ScenarioData.bcsv");
            string ZoneListPath = ScenarioArchive.GetItemKeyFromNoCase("ZoneList.bcsv");
            if (ScenarioDataPath is null || ZoneListPath is null)
            {
                MessageBox.Show("The Chosen Archive is missing ScenarioData.bcsv and/or ZoneList.bcsv", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                InfoToolStripStatusLabel.Text = "Save Failed!";
                StatusTimer.Start();
                return false;
            }
            InfoToolStripStatusLabel.Text = "Building BCSV files...";

            ScenarioArchive[ScenarioDataPath] = null;
            ScenarioArchive["ScenarioData.bcsv"] = (RARC.File)SaveToBCSV();
            ScenarioArchive[ZoneListPath] = null;
            ScenarioArchive["ZoneList.bcsv"] = (RARC.File)SaveZonesBCSV();
            ScenarioArchive.Save(CurrentFileName);
            if (MessageBox.Show("Would you like to Yaz0 Encode your Archive?", "Yaz0", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                YAZ0.Compress(ScenarioArchive.FileName);
            InfoToolStripStatusLabel.Text = "Save Complete!";
            StatusResumeCountdown = 4;
            OriginalFile = true;
            StatusTimer.Start();
            return true;
        }

        private BCSV SaveToBCSV()
        {
            BCSV Save = new BCSV() { FileName = "ScenarioData.bcsv" };
            //Calculate the field types
            List<DataTypes> DataTypeList = new List<DataTypes>() { DataTypes.INT32, DataTypes.STRING, DataTypes.INT32, DataTypes.STRING, DataTypes.STRING, DataTypes.STRING, DataTypes.INT32, DataTypes.INT32, DataTypes.INT32 };
            DataTypeList.AddRange(new DataTypes[Zones.Count]);

            //Calculate the Fields
            Save.Fields = new Dictionary<uint, BCSVField>();
            for (int i = 0; i < FixedHashesSMG2.Length + Zones.Count; i++)
                Save.Add(new BCSVField() { HashName = i < FixedHashesSMG2.Length ? FixedHashesSMG2[i] : BCSV.FieldNameToHash(Zones[i - FixedHashesSMG2.Length]), DataType = DataTypeList[i], AutoRecalc = true });
            
            //Calculate the entries
            for (int i = 0; i < ScenarioList.Count; i++)
                Save.Add(new BCSVEntry() { Data = ScenarioList[i].MakeBCSVEntry(FixedHashesSMG2) });
            return Save;
        }
        private BCSV SaveZonesBCSV()
        {
            BCSV Save = new BCSV() { FileName = "ZoneList.bcsv" };
            Save.Add(new BCSVField { DataType = DataTypes.STRING, HashName = 0x3666c077, AutoRecalc = true });
            BCSVEntry[] EntryList = new BCSVEntry[Zonecount];
            for (int i = 0; i < Zonecount; i++)
                Save.Add(new BCSVEntry() { Data = new Dictionary<uint, object>() { { 0x3666c077, Zones[i] } } });
            return Save;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!OriginalFile)
            {
                switch (MessageBox.Show("You have unsaved changes!\nWould you like to save?", "Unsaved Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning))
                {
                    case DialogResult.Yes:
                        if (!Save())
                            e.Cancel = true;
                        break;
                    case DialogResult.No:
                        break;
                    case DialogResult.Cancel:
                    default:
                        e.Cancel = true;
                        break;
                }
            }
        }
        
        private void CompileImage(int ImageIndex)
        {
            List<Image> TMP = new List<Image>();
            foreach (Image I in StarLargeImageList.Images)
                TMP.Add(I);

            Bitmap Base = Properties.Resources.StarFrame;
            Graphics g = Graphics.FromImage(Base);

            switch (ScenarioList[ImageIndex].Type)
            {
                case ScenarioSMG2.StarType.Normal:
                    switch (ScenarioList[ImageIndex].Comet)
                    {
                        case ScenarioSMG2.CometType.None:
                            g.DrawImage(Properties.Resources.PowerStar, 48f, 122f);
                            break;
                        case ScenarioSMG2.CometType.Red:
                            g.DrawImage(Properties.Resources.SpeedyComet, 48f, 122f);
                            break;
                        case ScenarioSMG2.CometType.Purple:
                            g.DrawImage(Properties.Resources.PurpleComet, 48f, 122f);
                            g.DrawImage(Properties.Resources.PurpleCoin, 342f, 338f);
                            break;
                        case ScenarioSMG2.CometType.Dark:
                            g.DrawImage(Properties.Resources.DaredevilComet, 48f, 122f);
                            break;
                        case ScenarioSMG2.CometType.Exterminate:
                            g.DrawImage(Properties.Resources.ExterminateComet, 48f, 122f);
                            break;
                        case ScenarioSMG2.CometType.Mimic:
                            g.DrawImage(Properties.Resources.CloneComet, 48f, 122f);
                            break;
                        case ScenarioSMG2.CometType.Quick:
                            g.DrawImage(Properties.Resources.QuickComet, 48f, 122f);
                            break;
                    }
                    break;
                case ScenarioSMG2.StarType.Hidden:
                    g.DrawImage(Properties.Resources.HiddenStarOverlay, 48f, 122f);
                    break;
                case ScenarioSMG2.StarType.Green:
                    g.DrawImage(Properties.Resources.GreenStar, 48f, 122f);
                    break;
                case ScenarioSMG2.StarType.Red:
                    g.DrawImage(Properties.Resources.RedStar, 48f, 122f);
                    break;
                case ScenarioSMG2.StarType.Grand:
                    g.DrawImage(Properties.Resources.GrandStar, 48f, 122f);
                    break;
                case ScenarioSMG2.StarType.Blue:
                    g.DrawImage(Properties.Resources.BlueStar, 48f, 122f);
                    break;
                default:
                    break;
            }

            if (ScenarioList[ImageIndex].Comet != ScenarioSMG2.CometType.Purple)
            {
                switch (ScenarioList[ImageIndex].Appearence)
                {
                    case "":
                        break;
                    case "ベビーディノパックン":
                        g.DrawImage(Properties.Resources.Peewee, 342f, 338f);
                        break;
                    case "ボスジュゲム":
                        g.DrawImage(Properties.Resources.GigaLakitu, 342f, 338f);
                        break;
                    case "二脚ボス":
                        g.DrawImage(Properties.Resources.DiggaLeg, 356f, 338f);
                        break;
                    case "子連れカメムシ":
                        g.DrawImage(Properties.Resources.Mandibug, 342f, 338f);
                        break;
                    case "ボスカメムシ":
                        g.DrawImage(ResizeBitmap(Properties.Resources.Bugaboom, 185, 101), 308f, 346f);
                        break;
                    case "キングトッシン":
                        g.DrawImage(ResizeBitmap(Properties.Resources.Rollodillo, 179, 142), 311f, 320f);
                        break;
                    case "ユッキーナ":
                        g.DrawImage(ResizeBitmap(Properties.Resources.Sorbetti, 189, 152), 311f, 320f);
                        break;
                    case "ボスブッスン":
                        g.DrawImage(ResizeBitmap(Properties.Resources.Glamdozer, 173, 115), 313f, 333f);
                        break;
                    case "オタロックタンク":
                        g.DrawImage(ResizeBitmap(Properties.Resources.PrincePikante, 150, 156), 321f, 308f);
                        break;
                    case "バッタンキング":
                        g.DrawImage(ResizeBitmap(Properties.Resources.KingWhomp, 158, 158), 326f, 313f);
                        break;
                    case "ベリードラゴン":
                        g.DrawImage(ResizeBitmap(Properties.Resources.Gobblegut, 158, 173), 318f, 313f);
                        break;
                    case "ベリードラゴンＬｖ２":
                        g.DrawImage(ResizeBitmap(Properties.Resources.FieryGobblegut, 158, 173), 318f, 313f);
                        break;
                    case "ディノパックンVs2":
                        g.DrawImage(ResizeBitmap(Properties.Resources.FieryDinoPiranha, 166, 153), 317f, 319f);
                        break;
                    case "クッパJrキャッスル":
                        g.DrawImage(ResizeBitmap(Properties.Resources.BoomsdayMachine, 166, 153), 317f, 319f);
                        break;
                    case "クッパ":
                        g.DrawImage(Properties.Resources.Bowser, 348f, 340f);
                        break;
                    case "クッパLv2":
                        g.DrawImage(Properties.Resources.Bowser, 348f, 340f);
                        break;
                    case "クッパLv3":
                        g.DrawImage(Properties.Resources.Bowser, 348f, 340f);
                        break;
                    case "クッパLv4":
                        g.DrawImage(Properties.Resources.Bowser, 348f, 340f);
                        break;
                    case "ゴールドワンワン":
                        g.DrawImage(ResizeBitmap(Properties.Resources.GoldenChomp, 163, 161), 318f, 318f);
                        break;
                    case "テレサチーフ":
                        g.DrawImage(ResizeBitmap(Properties.Resources.Boo, 163, 161), 318f, 318f);
                        break;
                    case "さすらいの遊び人(通常会話)":
                        g.DrawImage(ResizeBitmap(Properties.Resources.TheChimp, 163, 161), 318f, 318f);
                        break;
                    case "さすらいの遊び人(スコアアタック)":
                        g.DrawImage(ResizeBitmap(Properties.Resources.TheChimp, 163, 161), 318f, 318f);
                        g.DrawImage(ResizeBitmap(Properties.Resources.ExterminationTarget, 66, 66), 398f, 308f);
                        break;
                    case "さすらいの遊び人(ムイムイアタック)":
                        g.DrawImage(ResizeBitmap(Properties.Resources.TheChimp, 163, 161), 318f, 318f);
                        g.DrawImage(ResizeBitmap(Properties.Resources.Gummit, 66, 66), 398f, 308f);
                        break;
                    case "さすらいの遊び人(トゲピンアタック)":
                        g.DrawImage(ResizeBitmap(Properties.Resources.TheChimp, 163, 161), 318f, 318f);
                        g.DrawImage(ResizeBitmap(Properties.Resources.Pinhead, 66, 66), 398f, 308f);
                        break;
                    case "パマタリアン":
                        g.DrawImage(ResizeBitmap(Properties.Resources.Gearmo, 163, 161), 318f, 318f);
                        break;
                    case "パマタリアンハンター":
                        g.DrawImage(ResizeBitmap(Properties.Resources.GearmoHunters, 192, 116), 305f, 341f);
                        break;
                    case "全滅監視チェッカー[パワースター]":
                        g.DrawImage(ResizeBitmap(Properties.Resources.ExterminationTarget, 175, 175), 313f, 313f);
                        break;
                    case "チコ集め":
                        g.DrawImage(Properties.Resources.SilverStar, 342f, 338f);
                        break;
                    case "１００枚コイン":
                        g.DrawImage(Properties.Resources.PurpleCoin, 342f, 338f);
                        break;
                    case "音符の妖精":
                        g.DrawImage(Properties.Resources.NoteFairy, 342f, 338f);
                        break;
                    case "キノピオ":
                        g.DrawImage(ResizeBitmap(Properties.Resources.CaptainToad, 150, 175), 325f, 310f);
                        break;
                }
            }

            if (ImageIndex == StarLargeImageList.Images.Count)
            {
                StarLargeImageList.Images.Add(Base);
                StarSmallImageList.Images.Add(Base);
            }
            else
            {
                StarLargeImageList.Images.Clear();
                StarSmallImageList.Images.Clear();

                for (int i = 0; i < ScenarioList.Count; i++)
                {
                    if (i == ImageIndex)
                    {
                        StarLargeImageList.Images.Add(Base);
                        StarSmallImageList.Images.Add(Base);
                    }
                    else
                    {
                        StarLargeImageList.Images.Add(TMP[i]);
                        StarSmallImageList.Images.Add(TMP[i]);
                    }
                }

                ScenarioListView.Refresh();
            }
        }

        private void Redraw(int Reselect = 0)
        {
            StarLargeImageList.Images.Clear();
            StarSmallImageList.Images.Clear();
            ScenarioListView.Items.Clear();

            for (int i = 0; i < ScenarioList.Count; i++)
            {
                CompileImage(i);
                ListViewItem LVI = new ListViewItem() { Tag = ScenarioList[i], Text = ScenarioList[i].Name, ImageIndex = i };
                ScenarioListView.Items.Add(LVI);
            }

            ScenarioListView.Items[Reselect].Selected = true;
            ScenarioListView.Items[Reselect].EnsureVisible();
        }

        public Bitmap ResizeBitmap(Bitmap bmp, int width, int height)
        {
            Bitmap result = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(result))
            {
                g.DrawImage(bmp, 0, 0, width, height);
            }

            return result;
        }

        private void ImageSizeToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ImageSizeToolStripComboBox.SelectedIndex == 0)
            {
                ScenarioListView.View = View.LargeIcon;
            }
            else
            {
                ScenarioListView.View = View.SmallIcon;
            }

            ScenarioListView.Refresh();
        }

        private void ScenarioListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ScenarioListView.SelectedItems.Count == 0)
            {
                SetAppStatus(false);
                return;
            }

            Loading = true;
            ScenarioSMG2 X = (ScenarioSMG2)ScenarioListView.SelectedItems[0].Tag;

            int tmp = ZonesListBox.SelectedIndex;
            ZonesListBox.SelectedIndex = -1;
            ScenarioNameTextBox.Text = X.Name;
            ScenarioNumNumericUpDown.Value = X.Number;
            StarIDNumericUpDown.Value = X.PowerStarID;
            ScenarioTypeComboBox.SelectedItem = X.Type;
            CometComboBox.SelectedIndex = (int)X.Comet;
            AppearenceTextBox.Text = X.Appearence;
            TimeLimitNumericUpDown.Value = X.TimeLimit;
            bool[] CHECK = X.CalculateStarID(X.PowerStarID, false);
            Star1CheckBox.Checked = CHECK[0];
            Star2CheckBox.Checked = CHECK[1];
            Star3CheckBox.Checked = CHECK[2];
            Star4CheckBox.Checked = CHECK[3];
            Star5CheckBox.Checked = CHECK[4];
            Star6CheckBox.Checked = CHECK[5];
            ZonesListBox.SelectedIndex = tmp;
            SetAppStatus(true);
            Loading = false;
            UpdateStatusBar(true);
        }

        private void AppearenceButton_Click(object sender, EventArgs e)
        {
            StarAppearenceForm Star = new StarAppearenceForm(AppearenceTextBox.Text, this);
            Star.ShowDialog();

            List<Image> TMP = new List<Image>();
            foreach (Image I in StarLargeImageList.Images)
                TMP.Add(I);
        }

        private void AppearenceTextBox_TextChanged(object sender, EventArgs e)
        {
            if (Loading)
                return;

            ScenarioSMG2 X = (ScenarioSMG2)ScenarioListView.SelectedItems[0].Tag;

            X.Appearence = AppearenceTextBox.Text;

            CompileImage(ScenarioListView.SelectedIndices[0]);
            Redraw(ScenarioListView.SelectedIndices[0]);
            OriginalFile = false;
        }

        private void ScenarioTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Loading)
                return;

            ScenarioSMG2 X = (ScenarioSMG2)ScenarioListView.SelectedItems[0].Tag;

            X.Type = (ScenarioSMG2.StarType)ScenarioTypeComboBox.SelectedValue;

            CompileImage(ScenarioListView.SelectedIndices[0]);
            Redraw(ScenarioListView.SelectedIndices[0]);
            OriginalFile = false;
        }

        private void CometComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Startup)
                switch ((ScenarioSMG2.CometType)CometComboBox.SelectedValue)
                {
                    case ScenarioSMG2.CometType.Red:
                        TimeLimitNumericUpDown.Enabled = true;
                        break;
                    case ScenarioSMG2.CometType.Purple:
                        TimeLimitNumericUpDown.Enabled = true;
                        break;
                    case ScenarioSMG2.CometType.Dark:
                        break;
                    case ScenarioSMG2.CometType.Exterminate:
                        TimeLimitNumericUpDown.Enabled = true;
                        break;
                    case ScenarioSMG2.CometType.Mimic:
                        break;
                    case ScenarioSMG2.CometType.Quick:
                        break;
                    default:
                        TimeLimitNumericUpDown.Enabled = false;
                        break;
                }

            if (Loading)
                return;

            ScenarioSMG2 X = (ScenarioSMG2)ScenarioListView.SelectedItems[0].Tag;

            X.Comet = (ScenarioSMG2.CometType)CometComboBox.SelectedValue;

            CompileImage(ScenarioListView.SelectedIndices[0]);
            Redraw(ScenarioListView.SelectedIndices[0]);
            OriginalFile = false;
        }

        private void ScenarioNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (Loading)
                return;

            ScenarioSMG2 X = (ScenarioSMG2)ScenarioListView.SelectedItems[0].Tag;

            X.Name = ScenarioNameTextBox.Text;
            Redraw(ScenarioListView.SelectedIndices[0]);
            OriginalFile = false;
        }

        private void ScenarioNumNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (Loading)
                return;

            ScenarioSMG2 X = (ScenarioSMG2)ScenarioListView.SelectedItems[0].Tag;

            X.Number = (int)ScenarioNumNumericUpDown.Value;
            OriginalFile = false;
        }

        private void TimeLimitNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (Loading)
                return;

            ScenarioSMG2 X = (ScenarioSMG2)ScenarioListView.SelectedItems[0].Tag;

            X.TimeLimit = (int)TimeLimitNumericUpDown.Value;
            OriginalFile = false;
        }

        private void ZonesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ZonesListBox.SelectedIndex == -1 || ScenarioListView.SelectedItems.Count == 0)
                return;
            Loading = true;
            ScenarioSMG2 X = (ScenarioSMG2)ScenarioListView.SelectedItems[0].Tag;
            Zone Z = X.Zones[ZonesListBox.SelectedIndex];

            LayerACheckBox.Checked = Z.Layers[0];
            LayerBCheckBox.Checked = Z.Layers[1];
            LayerCCheckBox.Checked = Z.Layers[2];
            LayerDCheckBox.Checked = Z.Layers[3];
            LayerECheckBox.Checked = Z.Layers[4];
            LayerFCheckBox.Checked = Z.Layers[5];
            LayerGCheckBox.Checked = Z.Layers[6];
            LayerHCheckBox.Checked = Z.Layers[7];
            LayerICheckBox.Checked = Z.Layers[8];
            LayerJCheckBox.Checked = Z.Layers[9];
            LayerKCheckBox.Checked = Z.Layers[10];
            LayerLCheckBox.Checked = Z.Layers[11];
            LayerMCheckBox.Checked = Z.Layers[12];
            LayerNCheckBox.Checked = Z.Layers[13];
            LayerOCheckBox.Checked = Z.Layers[14];
            LayerPCheckBox.Checked = Z.Layers[15];

            Loading = false;
        }

        private void StarCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Loading)
                return;

            ScenarioSMG2 X = (ScenarioSMG2)ScenarioListView.SelectedItems[0].Tag;
            X.CalculateStarID(new CheckBox[6] { Star1CheckBox, Star2CheckBox, Star3CheckBox, Star4CheckBox, Star5CheckBox, Star6CheckBox });
            StarIDNumericUpDown.Value = X.PowerStarID;
            OriginalFile = false;
        }

        private void LayerCheckBox_CheckedChanged(object sencer, EventArgs e)
        {
            if (Loading)
                return;

            ScenarioSMG2 X = (ScenarioSMG2)ScenarioListView.SelectedItems[0].Tag;
            Zone Z = X.Zones[ZonesListBox.SelectedIndex];

            Z.Layers[0] = LayerACheckBox.Checked;
            Z.Layers[1] = LayerBCheckBox.Checked;
            Z.Layers[2] = LayerCCheckBox.Checked;
            Z.Layers[3] = LayerDCheckBox.Checked;
            Z.Layers[4] = LayerECheckBox.Checked;
            Z.Layers[5] = LayerFCheckBox.Checked;
            Z.Layers[6] = LayerGCheckBox.Checked;
            Z.Layers[7] = LayerHCheckBox.Checked;
            Z.Layers[8] = LayerICheckBox.Checked;
            Z.Layers[9] = LayerJCheckBox.Checked;
            Z.Layers[10] = LayerKCheckBox.Checked;
            Z.Layers[11] = LayerLCheckBox.Checked;
            Z.Layers[12] = LayerMCheckBox.Checked;
            Z.Layers[13] = LayerNCheckBox.Checked;
            Z.Layers[14] = LayerOCheckBox.Checked;
            Z.Layers[15] = LayerPCheckBox.Checked;
            OriginalFile = false;
        }

        private void AddZoneButton_Click(object sender, EventArgs e)
        {
            ZoneForm AddZoneDialog = new ZoneForm();

            // Show testDialog as a modal dialog and determine if DialogResult = OK.
            if (AddZoneDialog.ShowDialog(this) == DialogResult.OK)
            {
                // Read the contents of testDialog's TextBox.
                string ZoneName = AddZoneDialog.NameTextBox.Text;
                AddZoneDialog.Dispose();

                Zones.Add(ZoneName);
                ZonesListBox.Items.Add(ZoneName);

                foreach (ScenarioSMG2 S in ScenarioList)
                    S.Zones.Add(new Zone(ZoneName));

                InfoToolStripStatusLabel.Text = $"Added Zone \"{ZoneName}\"";
                StatusResumeCountdown = 2;
                OriginalFile = false;
            }
        }

        private void SubtractZoneButton_Click(object sender, EventArgs e)
        {
            if (ZonesListBox.SelectedIndex == 0)
            {
                InfoToolStripStatusLabel.Text = "Cannot remove \"" + Zones[ZonesListBox.SelectedIndex] + "\" because it's a Galaxy";
                StatusResumeCountdown = 4;
                return;
            }

            if (Zones.Count - 1 == 0)
            {
                InfoToolStripStatusLabel.Text = "Cannot remove Zone \"" + Zones[ZonesListBox.SelectedIndex] + "\" because it's the last zone";
                StatusResumeCountdown = 4;
                return;
            }

            InfoToolStripStatusLabel.Text = "Removed Zone \"" + Zones[ZonesListBox.SelectedIndex] + "\"";
            OriginalFile = false;
            StatusResumeCountdown = 2;
            int REPLACE = ZonesListBox.SelectedIndex;
            Zones.RemoveAt(REPLACE);
            ZonesListBox.Items.RemoveAt(REPLACE);

            foreach (ScenarioSMG2 S in ScenarioList)
                S.Zones.RemoveAt(REPLACE);

            if (REPLACE > 0)
                ZonesListBox.SelectedIndex = REPLACE - 1;
            else
                ZonesListBox.SelectedIndex = 0;
        }

        private void RenameZoneButton_Click(object sender, EventArgs e)
        {
            if (ZonesListBox.SelectedIndex == -1)
                return;

            string original = Zones[ZonesListBox.SelectedIndex];
            ZoneForm AddZoneDialog = new ZoneForm();
            AddZoneDialog.NameTextBox.Text = original;
            if (AddZoneDialog.ShowDialog(this) == DialogResult.OK)
            {
                string ZoneName = AddZoneDialog.NameTextBox.Text;
                AddZoneDialog.Dispose();

                Zones[ZonesListBox.SelectedIndex] = ZoneName;
                ZonesListBox.Items[ZonesListBox.SelectedIndex] = ZoneName;

                foreach (ScenarioSMG2 S in ScenarioList)
                    S.Zones[ZonesListBox.SelectedIndex].Name = ZoneName;

                InfoToolStripStatusLabel.Text = $"Renamed \"{original}\" to \"{ZoneName}\"";
                StatusResumeCountdown = 4;
                OriginalFile = false;
            }
        }

        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScenarioSMG2 NEW = new ScenarioSMG2();
            foreach (string Zone in Zones)
                NEW.Zones.Add(new Zone(Zone));

            ScenarioList.Add(NEW);
            InfoToolStripStatusLabel.Text = "Added \"New Star\"";
            OriginalFile = false;
            StatusResumeCountdown = 3;
            if (ScenarioListView.SelectedIndices.Count != 0)
                Redraw(ScenarioListView.SelectedIndices[0]);
            else
                Redraw();
        }

        private void RemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ScenarioListView.SelectedIndices.Count == 0)
            {
                InfoToolStripStatusLabel.Text = "No Scenario is selected";
                StatusResumeCountdown = 4;
                return;
            }

            if (ScenarioList.Count == 1)
            {
                InfoToolStripStatusLabel.Text = "Cannot remove \"" + ScenarioList[ScenarioListView.SelectedIndices[0]].Name + "\" because it's the last Scenario";
                StatusResumeCountdown = 5;
                return;
            }

            InfoToolStripStatusLabel.Text = "Removed \"" + ScenarioList[ScenarioListView.SelectedIndices[0]].Name + "\"";
            OriginalFile = false;
            int tmp = ScenarioListView.SelectedIndices[0];
            ScenarioList.RemoveAt(tmp);
            if (tmp == 0)
                Redraw();
            else
                Redraw(tmp - 1);
        }

        #region Timer Stuff
        private const string UpdateName = "The Initial Release";

        private int StatusState = 0;
        private int Scrollnumber = 0;
        private int StatusResumeCountdown = 0;
        private const int MaxBeforeReset = 5;
        private readonly string[] Messages = new string[]
        {
            "Scenaristar " + Application.ProductVersion + ", \"" + UpdateName + "\"",
            "Scenaristar was made by Super Hackio",
            "Scenaristar is powered by the Hack.io Library"
        };
        private readonly string[] Flavour = new string[]
        {
            "Thank you for using Scenaristar!",
            "This is the start of the galaxy creation process, or is it the end?",
            "Legend has it that Red and Blue Stars are new Scenario Types",
            "Can you imagine a world where Super Mario Galaxy doesn't exist?",
            "Big Yeet"
        };

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
                if (ScenarioListView.SelectedIndices.Count != 0)
                    InfoToolStripStatusLabel.Text = "Editing " + new FileInfo(CurrentFileName ?? "Unsaved File").Name.Replace("Scenario.arc", "") + ", " + ScenarioList[ScenarioListView.SelectedIndices[0]].Name + (". It's a " + ScenarioList[ScenarioListView.SelectedIndices[0]].Type.ToString() + " star with ") + (ScenarioList[ScenarioListView.SelectedIndices[0]].Comet == ScenarioSMG2.CometType.None ? "No Comet" : ("a " + CometComboBox.Text + " Comet"));
                else if (ScenarioList.Count > 0)
                    InfoToolStripStatusLabel.Text = "Editing " + new FileInfo(CurrentFileName ?? "Unsaved File").Name.Replace("Scenario.arc", "") + ". Select a scenario to start editing";
                else
                    InfoToolStripStatusLabel.Text = "No File Loaded. Create a new file, or open an existing file to get started";
            }

            if (StatusState > MaxBeforeReset)
            {
                StatusState = 0;
                if (new Random().Next(0, 100) < 100)
                {
                    InfoToolStripStatusLabel.Text = Flavour[new Random().Next(0, Flavour.Length)];
                    StatusResumeCountdown = 1;
                }
            }
            InfoToolStripStatusLabel.Text += "   ";
        }

        private void InfoToolStripStatusLabel_TextChanged(object sender, EventArgs e)
        {
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

            if (Scrollnumber == InfoToolStripStatusLabel.Text.Length-1)
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
            List<char> String = new List<char>();
            List<char> NewString = new List<char>();
            String.AddRange(InfoToolStripStatusLabel.Text.ToCharArray());

            for (int i = 1; i < String.Count; i++)
            {
                NewString.Add(String[i]);
            }
            NewString.Add(String[0]);

            string a = "";
            foreach (char C in NewString)
            {
                a += C;
            }

            InfoToolStripStatusLabel.Text = a;
            Scrollnumber++;
        }
        #endregion

        private void MoveZoneUpButton_Click(object sender, EventArgs e)
        {
            if (ZonesListBox.SelectedIndex < 2)
                return;

            int selected = ScenarioListView.SelectedIndices[0];
            int i = ZonesListBox.SelectedIndex;
            ScenarioSMG2 X = null;
            for (int o = 0; o < ScenarioListView.Items.Count; o++)
            {
                ScenarioListView.SelectedItems.Clear();
                ScenarioListView.Items[o].Selected = true;
                X = (ScenarioSMG2)ScenarioListView.SelectedItems[0].Tag;
                RearrangeZones(X.Zones[i], X.Zones[i - 1], true);
            }
            ZonesListBox.SelectedIndex = i - 1;
            ScenarioListView.SelectedItems.Clear();
            ScenarioListView.Items[selected].Selected = true;
            OriginalFile = false;
        }

        private void MoveZoneDownButton_Click(object sender, EventArgs e)
        {
            if (ZonesListBox.SelectedIndex == ZonesListBox.Items.Count - 1 || ZonesListBox.SelectedIndex == 0)
                return;

            int selected = ScenarioListView.SelectedIndices[0];
            int i = ZonesListBox.SelectedIndex;
            ScenarioSMG2 X = null;
            for (int o = 0; o < ScenarioListView.Items.Count; o++)
            {
                ScenarioListView.SelectedItems.Clear();
                ScenarioListView.Items[o].Selected = true;
                X = (ScenarioSMG2)ScenarioListView.SelectedItems[0].Tag;
                RearrangeZones(X.Zones[i], X.Zones[i + 1], false);
            }
            ZonesListBox.SelectedIndex = i + 1;
            ScenarioListView.SelectedItems.Clear();
            ScenarioListView.Items[selected].Selected = true;
            OriginalFile = false;
        }

        /// <summary>
        /// Rearranges the Zones
        /// </summary>
        /// <param name="Source">Zone to move</param>
        /// <param name="Location">Zone to move before/after</param>
        /// <param name="Direction">True - Move Up | False - Move down</param>
        /// <param name="X">Scenario to edit</param>
        private void RearrangeZones(Zone Source, Zone Location, bool Direction)
        {
            ScenarioSMG2 X = (ScenarioSMG2)ScenarioListView.SelectedItems[0].Tag;
            LinkedList<Zone> Reorganize = new LinkedList<Zone>();
            
            foreach (Zone Cam in X.Zones)
            {
                Reorganize.AddLast(Cam);
            }

            LinkedListNode<Zone> MovingNode = Reorganize.Find(Source);
            LinkedListNode<Zone> TargetNode = Reorganize.Find(Location);

            if (Direction)
            {
                Reorganize.Remove(MovingNode);
                Reorganize.AddBefore(TargetNode, Source);
            }
            else
            {
                Reorganize.Remove(MovingNode);
                Reorganize.AddAfter(TargetNode, Source);
            }
            X.Zones.Clear();

            foreach (Zone Cam in Reorganize)
            {
                X.Zones.Add(Cam);
            }
            
            ZonesListBox.Items.Clear();
            Zones.Clear();
            foreach (Zone Cam in X.Zones)
            {
                ZonesListBox.Items.Add(Cam.Name);
                Zones.Add(Cam.Name);
            }
        }
    }

    public static class ControlEx
    {
        public static void SetDoubleBuffered(this Control control)
        {
            // set instance non-public property with name "DoubleBuffered" to true
            typeof(Control).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, control, new object[] { true });
        }
    }
}
