using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scenaristar
{
    public partial class StarAppearenceForm : Form
    {
        public StarAppearenceForm(string selected, MainForm MF)
        {
            Loading = true;
            InitializeComponent();
            CenterToParent();

            Dictionary<string, string> ListSource = new Dictionary<string, string>();

            string[] Keys = new string[]
            {
                "",
                //-----------------------
                "ベビーディノパックン", //Peewee
                "ボスジュゲム", //Giga Lakitu
                "二脚ボス", //Digga Leg
                "子連れカメムシ", //Mandibug
                "ボスカメムシ", //Bugaboom
                "キングトッシン", //Rollodillo
                "ユッキーナ", // Sorbetti
                "ボスブッスン", //Glamdozer
                "サンディー", //Squizzard
                "オタロックタンク", //Prince Pikante
                "バッタンキング", //King Whomp
                "ベリードラゴン", //Gobblegut
                "ベリードラゴンＬｖ２", //Fiery Gobblegut
                "ディノパックンVs2", //Fiery Dino Piranha
                "クッパJrロボット", //Megahammer
                "クッパJrキャッスル", //Boomsday Machine
                "クッパ", //Bowser
                "クッパLv2", //Bowser
                "クッパLv3", //Bowser
                "クッパLv4", //Bowser
                //-----------------------
                "ゴールドワンワン", //Golden Chain Chomp
                "雪像クッパ", //Bowser Snow Statue
                "テレサチーフ", //Chief Boo
                //-----------------------
                "さすらいの遊び人(通常会話)", //The Chimp (NPC)
                "さすらいの遊び人(スコアアタック)", //The Chimp (Score Attack)
                "さすらいの遊び人(ムイムイアタック)", //The Chimp (Skating)
                "さすらいの遊び人(トゲピンアタック)", //The Chimp (Bowling)
                "パマタリアン", //Gearmo
                "パマタリアンハンター", //Gearmo Hunter
                "キノピオ", //Toad
                "モック", //Whittle
                "ピーチャン", //Jibberjay (NPC)
                "ピーチャンレーサー", //Jibberjay (Racer)
                "ペンギンコーチ", //Penguin Coach
                "ペンギン仙人", //Penguin Elder
                "いたずらウサギ", //Rabbit (runaway)
                "全滅監視チェッカー[パワースター]", //Extermination Checker
                "花さか監視[パワースター]", //Flower Monitor
                "フリップパネル監視者", //Flip-panel Observer
                "たまころ", //Star Ball
                "チコ集め", //Silver Stars
                "音符の妖精", //Rainbow Notes
                "１００枚コイン", //Purple Coins
                "クリスタルケージ[小]", //Crystal Cage (small)
                "クリスタルケージ[中]", //Crystal Cage (medium)
                "クリスタルケージ[大]", //Crystal Cage (large)
                "壊れる籠", //Glass Cage
                "壊れる籠[大]", //Glass Cage (large)
                "壊れる籠[回転タイプ]" //Glass Cage (rotating)
            };

            string[] Values = new string[]
            {
                "None",
                "Peewee Piranha",
                "Giga Lakitu",
                "Digga-Leg",
                "Mandibug Parent",
                "Bugaboom",
                "Rollodillo",
                "Sorbetti",
                "Glamdozer",
                "Squizzard",
                "Prince Pikante",
                "King Whomp",
                "Gobblegut",
                "Fiery Gobblegut",
                "Fiery Dino Piranha",
                "Megahammer",
                "Boomsday Machine",
                "Bowser W2",
                "Bowser W4",
                "Bowser W6",
                "Bowser (Unused)",
                //--------------------
                "Golden Chain Chomp",
                "Snow Bowser Statue",
                "Chief Boo",
                //-------------------
                "The Chimp (NPC)",
                "The Chimp (Score Attack)",
                "The Chimp (Skating)",
                "The Chimp (Bowling)",
                "Gearmo",
                "Gearmo Hunter",
                "Toad",
                "Whittle",
                "Jibberjay (NPC)",
                "Jibberjay (Racer)",
                "Penguin Coach",
                "Penguin Elder",
                "Rabbit (Runaway)",
                "Extermination Monitor",
                "Flower Monitor",
                "Flip Panel Observer",
                "Star Ball",
                "Silver Stars",
                "Rainbow Notes",
                "100 Purple coins",
                "Crystal Cage (Small)",
                "Crystal Cage (Medium)",
                "Crystal Cage (Large)",
                "Glass Cage",
                "Glass Cage (Large)",
                "Glass Cage (Rotating)",
            };

            for (int i = 0; i < Keys.Length; i++)
                ListSource.Add(Keys[i], Values[i]);

            AppearenceListBox.DataSource = new BindingSource(ListSource, null);
            AppearenceListBox.DisplayMember = "Value";
            AppearenceListBox.ValueMember = "Key";

            for (int i = 0; i < Keys.Length; i++)
            {
                if (selected == Keys[i])
                {
                    AppearenceListBox.SelectedIndex = i;
                    break;
                }
            }

            MainParent = MF;
            Loading = false;
        }

        MainForm MainParent;
        bool Loading;

        private void AppearenceListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Loading)
                return;
            MainParent.AppearenceTextBox.Text = AppearenceListBox.SelectedValue.ToString();
        }
    }
}
