using GalaxyMaps;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GalaxyMaps.GalaxyScenario;

namespace Scenaristar
{
    public partial class TemplateForm : Form
    {
        List<GalaxyScenario> Scenarios;
        int TemplateID => ScenarioListView.SelectedIndices.Count > 0 ? ScenarioListView.SelectedIndices[0] : -1;

        public TemplateForm(List<GalaxyScenario> s)
        {
            InitializeComponent();
            Scenarios = s;
#if DEBUG
            Star7CheckBox.Visible = true;
            Star8CheckBox.Visible = true;
#endif

            for (int i = 0; i < Templates.Length; i++)
            {
                CompileImage(i);
                ListViewItem LVI = new ListViewItem() { Text = Templates[i].Name, ImageIndex = i };
                ScenarioListView.Items.Add(LVI);
            }
        }

        public GalaxyScenario GetScenarioTemplate(List<string> Zones, ref List<GalaxyScenario> Scenarios)
        {
            if (ScenarioListView.SelectedItems.Count == 0)
                return null;

            GalaxyScenario NEW = new GalaxyScenario();
            foreach (string Zone in Zones)
                NEW.Zones.Add(new Zone(Zone));

            int ID = ScenarioListView.SelectedIndices[0];
            NEW.Type = Templates[ID].Type;
            NEW.Comet = Templates[ID].Comet;
            NEW.TimeLimit = Templates[ID].TimeLimit;
            NEW.Name = Templates[ID].Name;
            NEW.Appearence = Templates[ID].Appearence;
            NEW.Number = Scenarios.Count + 1;
            if (NEW.Number > 8)
                NEW.Number = 8;
            NEW.SetUseStar(NEW.Number, true);

            if (Templates[ID].NeedsPickStar)
            {
                for (int i = 0; i < Scenarios.Count; i++)
                {
                    if (GetSelectedStar() == i+1)
                    {
                        Scenarios[i].SetUseStar(NEW.Number, true);
                        break;
                    }
                }
            }

            return NEW;
        }


        private void CompileImage(int TemplateIndex)
        {
            Bitmap Base = Properties.Resources.StarFrame;
            Graphics g = Graphics.FromImage(Base);

            switch (Templates[TemplateIndex].Type)
            {
                case StarType.Normal:
                    switch (Templates[TemplateIndex].Comet)
                    {
                        case CometType.None:
                            g.DrawImage(Properties.Resources.PowerStar, 48f, 122f);
                            break;
                        case CometType.Red:
                            g.DrawImage(Properties.Resources.SpeedyComet, 48f, 101f);
                            break;
                        case CometType.Purple:
                            g.DrawImage(Properties.Resources.PurpleComet, 48f, 101f);
                            g.DrawImage(Properties.Resources.PurpleCoin, 342f, 338f);
                            break;
                        case CometType.Dark:
                            g.DrawImage(Properties.Resources.DaredevilComet, 48f, 101f);
                            break;
                        case CometType.Exterminate:
                            g.DrawImage(Properties.Resources.ExterminateComet, 48f, 101f);
                            break;
                        case CometType.Mimic:
                            g.DrawImage(Properties.Resources.CloneComet, 48f, 101f);
                            break;
                        case CometType.Quick:
                            g.DrawImage(Properties.Resources.QuickComet, 48f, 101f);
                            break;
                    }
                    break;
                case StarType.Hidden:
                case StarType.Seeker:
                    g.DrawImage(Properties.Resources.HiddenStarOverlay, 48f, 122f);
                    break;
                case StarType.Green:
                    g.DrawImage(Properties.Resources.GreenStar, 48f, 98f);
                    break;
#if DEBUG
                //case StarType.Red:
                //    g.DrawImage(Properties.Resources.RedStar, 48f, 122f);
                //    break;
                case StarType.Grand:
                    g.DrawImage(Properties.Resources.GrandStar, 23f, 101f);
                    break;
                //case StarType.Blue:
                //    g.DrawImage(Properties.Resources.BlueStar, 48f, 122f);
                //    break; 
#endif
                default:
                    break;
            }

            if (Templates[TemplateIndex].Comet != CometType.Purple)
            {
                switch (Templates[TemplateIndex].Appearence)
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

            StarSmallImageList.Images.Add(Base);
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

        private void ScenarioListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ScenarioListView.SelectedItems.Count == 0)
            {
                AddButton.Enabled = false;
                return;
            }
            AddButton.Enabled = true;

            TemplateNameLabel.Text = Templates[TemplateID].Name;
            DescriptionTextBox.Text = Templates[TemplateID].Description;
            StarGroupBox.Enabled = Templates[TemplateID].NeedsPickStar;
            for (int i = 0; i < StarGroupBox.Controls.Count; i++)
            {
                StarGroupBox.Controls[i].Enabled = false;
                for (int y = 0; y < Scenarios.Count; y++)
                {
                    if (Scenarios[y].Number == i+1)
                    {
                        if (Scenarios[y].Type == StarType.Green && (Templates[TemplateID].Type == StarType.Green || Templates[TemplateID].Type == StarType.Hidden))
                            break;
                        if (Scenarios[y].Type == StarType.Hidden && (Templates[TemplateID].Type == StarType.Hidden || Templates[TemplateID].Type == StarType.Green))
                            break;
                        StarGroupBox.Controls[i].Enabled = true;
                        break;
                    }
                }
            }
            switch (Templates[TemplateID].Comet)
            {
                case CometType.Red:
                case CometType.Purple:
                case CometType.Exterminate:
                case CometType.Dark:
                case CometType.Mimic:
                case CometType.Quick:
                    CometTimerGroupBox.Enabled = true;
                    CometMinutesNumericUpDown.Value = Templates[TemplateID].TimeLimit / 60;
                    CometSecondsNumericUpDown.Value = Templates[TemplateID].TimeLimit % 60;
                    break;
                default:
                    CometTimerGroupBox.Enabled = false;
                    break;
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (Templates[TemplateID].NeedsPickStar && GetSelectedStar() == 0)
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

        private int GetSelectedStar()
        {
            for (int i = 0; i < StarGroupBox.Controls.Count; i++)
            {
                if (StarGroupBox.Controls[i] is RadioButton RB && RB.Checked)
                    return i + 1;
            }
            return 0;
        }

        public static readonly ScenarioTemplate[] Templates = new ScenarioTemplate[]
        {
            new ScenarioTemplate() { Name = "Normal Star Template", Description = "Just a normal Star. Useful for most yellow power star missions." },
            new ScenarioTemplate() { Name = "Hidden Star Template", Description = "A template for Hidden Power Stars. Use the Star picker below to assign the Hidden Star to a Normal Star.", Type = StarType.Hidden, NeedsPickStar = true },
            new ScenarioTemplate() { Name = "Green Star Template", Description = "A template for Green Stars. Use the Star Picker below to assign the star you want to load when you pick this green star from the scenario select in game.", Type = StarType.Green, NeedsPickStar = true },
            new ScenarioTemplate() { Name = "Fixed-Timer Speedrun Comet", Description = "Designed for Speedrun comets that do not use Plus Clocks. Use the Timer Settings below to fine-tune the time", Type = StarType.Normal, Comet = CometType.Red, TimeLimit = 120 },
            new ScenarioTemplate() { Name = "Plus Clock Speedrun Comet", Description = "Designed for Speedrun comets that start you with little time, where you race to the next Plus Clock. Use the Timer Settings below to fine-tune the starting time", Type = StarType.Normal, Comet = CometType.Red, TimeLimit = 30 },
            new ScenarioTemplate() { Name = "Purple Coin Comet", Description = "A Standard Purple Coin comet. Use the Timer Settings below to make it a timed comet", Type = StarType.Normal, Comet = CometType.Purple },
            new ScenarioTemplate() { Name = "Daredevil Comet", Description = "A Standard Daredevil comet. Use the Timer Settings below to make it a timed comet", Type = StarType.Normal, Comet = CometType.Dark },
            new ScenarioTemplate() { Name = "Romp Comet", Description = "A Romp Comet. Set the timer using the Timer Settings below", Type = StarType.Normal, Comet = CometType.Exterminate, TimeLimit = 30, Appearence = "全滅監視チェッカー[パワースター]" },
            new ScenarioTemplate() { Name = "Cosmic Clones Comet", Description = "A Standard Cosmic Clones comet. Use the Timer Settings below to make it a timed comet", Type = StarType.Normal, Comet = CometType.Mimic },
            new ScenarioTemplate() { Name = "Double Time Comet", Description = "A Standard Double Time comet (It makes some enemies move faster). Use the Timer Settings below to make it a timed comet", Type = StarType.Normal, Comet = CometType.Quick },
        };

        public class ScenarioTemplate
        {
            public string Name;
            public string Description;
            public StarType Type = StarType.Normal;
            public CometType Comet = CometType.None;

            public string Appearence = "";
            public int TimeLimit;

            public bool NeedsPickStar;
        }
    }
}
