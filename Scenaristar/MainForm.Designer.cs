namespace Scenaristar
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainFormMenuStrip = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImageSizeToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.CurrentFileToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.InfoStatusStrip = new System.Windows.Forms.StatusStrip();
            this.InfoToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ScenarioListView = new System.Windows.Forms.ListView();
            this.StarLargeImageList = new System.Windows.Forms.ImageList(this.components);
            this.StarSmallImageList = new System.Windows.Forms.ImageList(this.components);
            this.ScenarioNameLabel = new System.Windows.Forms.Label();
            this.ScenarioNameTextBox = new System.Windows.Forms.TextBox();
            this.ScenarioNumLabel = new System.Windows.Forms.Label();
            this.ScenarioNumNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.StarIDNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.StarIDLabel = new System.Windows.Forms.Label();
            this.ScenarioTypeComboBox = new System.Windows.Forms.ComboBox();
            this.ScenarioTypeLabel = new System.Windows.Forms.Label();
            this.CometLabel = new System.Windows.Forms.Label();
            this.CometComboBox = new System.Windows.Forms.ComboBox();
            this.AppearenceLabel = new System.Windows.Forms.Label();
            this.AppearenceTextBox = new System.Windows.Forms.TextBox();
            this.AppearenceButton = new System.Windows.Forms.Button();
            this.StarGroupBox = new System.Windows.Forms.GroupBox();
            this.Star6CheckBox = new System.Windows.Forms.CheckBox();
            this.Star5CheckBox = new System.Windows.Forms.CheckBox();
            this.Star4CheckBox = new System.Windows.Forms.CheckBox();
            this.Star3CheckBox = new System.Windows.Forms.CheckBox();
            this.Star2CheckBox = new System.Windows.Forms.CheckBox();
            this.Star1CheckBox = new System.Windows.Forms.CheckBox();
            this.ZonesListBox = new System.Windows.Forms.ListBox();
            this.TimeLimitNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.TimelimitLabal = new System.Windows.Forms.Label();
            this.LayerGroupBox = new System.Windows.Forms.GroupBox();
            this.RenameZoneButton = new System.Windows.Forms.Button();
            this.SubtractZoneButton = new System.Windows.Forms.Button();
            this.AddZoneButton = new System.Windows.Forms.Button();
            this.LayerPCheckBox = new System.Windows.Forms.CheckBox();
            this.LayerOCheckBox = new System.Windows.Forms.CheckBox();
            this.LayerNCheckBox = new System.Windows.Forms.CheckBox();
            this.LayerMCheckBox = new System.Windows.Forms.CheckBox();
            this.LayerLCheckBox = new System.Windows.Forms.CheckBox();
            this.LayerKCheckBox = new System.Windows.Forms.CheckBox();
            this.LayerJCheckBox = new System.Windows.Forms.CheckBox();
            this.LayerICheckBox = new System.Windows.Forms.CheckBox();
            this.LayerHCheckBox = new System.Windows.Forms.CheckBox();
            this.LayerGCheckBox = new System.Windows.Forms.CheckBox();
            this.LayerFCheckBox = new System.Windows.Forms.CheckBox();
            this.LayerECheckBox = new System.Windows.Forms.CheckBox();
            this.LayerDCheckBox = new System.Windows.Forms.CheckBox();
            this.LayerCCheckBox = new System.Windows.Forms.CheckBox();
            this.LayerBCheckBox = new System.Windows.Forms.CheckBox();
            this.LayerACheckBox = new System.Windows.Forms.CheckBox();
            this.StatusTimer = new System.Windows.Forms.Timer(this.components);
            this.StatusStripTimer = new System.Windows.Forms.Timer(this.components);
            this.MoveZoneUpButton = new System.Windows.Forms.Button();
            this.MoveZoneDownButton = new System.Windows.Forms.Button();
            this.MainFormMenuStrip.SuspendLayout();
            this.InfoStatusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScenarioNumNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StarIDNumericUpDown)).BeginInit();
            this.StarGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TimeLimitNumericUpDown)).BeginInit();
            this.LayerGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainFormMenuStrip
            // 
            this.MainFormMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.EditToolStripMenuItem,
            this.ImageSizeToolStripComboBox,
            this.CurrentFileToolStripTextBox});
            this.MainFormMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainFormMenuStrip.Name = "MainFormMenuStrip";
            this.MainFormMenuStrip.Size = new System.Drawing.Size(624, 27);
            this.MainFormMenuStrip.TabIndex = 0;
            this.MainFormMenuStrip.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewToolStripMenuItem,
            this.OpenToolStripMenuItem,
            this.SaveToolStripMenuItem,
            this.SaveAsToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(37, 23);
            this.FileToolStripMenuItem.Text = "File";
            // 
            // NewToolStripMenuItem
            // 
            this.NewToolStripMenuItem.Name = "NewToolStripMenuItem";
            this.NewToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.NewToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.NewToolStripMenuItem.Text = "&New";
            this.NewToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItem_Click);
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.OpenToolStripMenuItem.Text = "&Open";
            this.OpenToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.Enabled = false;
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.SaveToolStripMenuItem.Text = "&Save";
            this.SaveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // SaveAsToolStripMenuItem
            // 
            this.SaveAsToolStripMenuItem.Enabled = false;
            this.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem";
            this.SaveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.SaveAsToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.SaveAsToolStripMenuItem.Text = "Save &As";
            this.SaveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // EditToolStripMenuItem
            // 
            this.EditToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddToolStripMenuItem,
            this.RemoveToolStripMenuItem});
            this.EditToolStripMenuItem.Name = "EditToolStripMenuItem";
            this.EditToolStripMenuItem.Size = new System.Drawing.Size(39, 23);
            this.EditToolStripMenuItem.Text = "Edit";
            // 
            // AddToolStripMenuItem
            // 
            this.AddToolStripMenuItem.Name = "AddToolStripMenuItem";
            this.AddToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.AddToolStripMenuItem.Text = "&Add Scenario";
            this.AddToolStripMenuItem.Click += new System.EventHandler(this.AddToolStripMenuItem_Click);
            // 
            // RemoveToolStripMenuItem
            // 
            this.RemoveToolStripMenuItem.Name = "RemoveToolStripMenuItem";
            this.RemoveToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.RemoveToolStripMenuItem.Text = "&Remove Scenario";
            this.RemoveToolStripMenuItem.Click += new System.EventHandler(this.RemoveToolStripMenuItem_Click);
            // 
            // ImageSizeToolStripComboBox
            // 
            this.ImageSizeToolStripComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ImageSizeToolStripComboBox.Items.AddRange(new object[] {
            "Large Icons",
            "Small Icons"});
            this.ImageSizeToolStripComboBox.Name = "ImageSizeToolStripComboBox";
            this.ImageSizeToolStripComboBox.Size = new System.Drawing.Size(100, 23);
            this.ImageSizeToolStripComboBox.ToolTipText = "Change the Size of the Scenario Icons";
            this.ImageSizeToolStripComboBox.SelectedIndexChanged += new System.EventHandler(this.ImageSizeToolStripComboBox_SelectedIndexChanged);
            // 
            // CurrentFileToolStripTextBox
            // 
            this.CurrentFileToolStripTextBox.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.CurrentFileToolStripTextBox.Name = "CurrentFileToolStripTextBox";
            this.CurrentFileToolStripTextBox.ReadOnly = true;
            this.CurrentFileToolStripTextBox.Size = new System.Drawing.Size(350, 23);
            // 
            // InfoStatusStrip
            // 
            this.InfoStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InfoToolStripStatusLabel});
            this.InfoStatusStrip.Location = new System.Drawing.Point(0, 419);
            this.InfoStatusStrip.Name = "InfoStatusStrip";
            this.InfoStatusStrip.Size = new System.Drawing.Size(624, 22);
            this.InfoStatusStrip.SizingGrip = false;
            this.InfoStatusStrip.TabIndex = 1;
            this.InfoStatusStrip.Text = "Status Strip lol";
            // 
            // InfoToolStripStatusLabel
            // 
            this.InfoToolStripStatusLabel.Name = "InfoToolStripStatusLabel";
            this.InfoToolStripStatusLabel.Size = new System.Drawing.Size(91, 17);
            this.InfoToolStripStatusLabel.Text = "Program Status:";
            this.InfoToolStripStatusLabel.TextChanged += new System.EventHandler(this.InfoToolStripStatusLabel_TextChanged);
            // 
            // ScenarioListView
            // 
            this.ScenarioListView.HideSelection = false;
            this.ScenarioListView.LargeImageList = this.StarLargeImageList;
            this.ScenarioListView.Location = new System.Drawing.Point(12, 27);
            this.ScenarioListView.MultiSelect = false;
            this.ScenarioListView.Name = "ScenarioListView";
            this.ScenarioListView.Size = new System.Drawing.Size(243, 389);
            this.ScenarioListView.SmallImageList = this.StarSmallImageList;
            this.ScenarioListView.TabIndex = 2;
            this.ScenarioListView.UseCompatibleStateImageBehavior = false;
            this.ScenarioListView.SelectedIndexChanged += new System.EventHandler(this.ScenarioListView_SelectedIndexChanged);
            // 
            // StarLargeImageList
            // 
            this.StarLargeImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.StarLargeImageList.ImageSize = new System.Drawing.Size(177, 177);
            this.StarLargeImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // StarSmallImageList
            // 
            this.StarSmallImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.StarSmallImageList.ImageSize = new System.Drawing.Size(64, 64);
            this.StarSmallImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // ScenarioNameLabel
            // 
            this.ScenarioNameLabel.AutoSize = true;
            this.ScenarioNameLabel.Location = new System.Drawing.Point(258, 33);
            this.ScenarioNameLabel.Name = "ScenarioNameLabel";
            this.ScenarioNameLabel.Size = new System.Drawing.Size(83, 13);
            this.ScenarioNameLabel.TabIndex = 3;
            this.ScenarioNameLabel.Text = "Scenario Name:";
            // 
            // ScenarioNameTextBox
            // 
            this.ScenarioNameTextBox.Enabled = false;
            this.ScenarioNameTextBox.Location = new System.Drawing.Point(347, 30);
            this.ScenarioNameTextBox.Name = "ScenarioNameTextBox";
            this.ScenarioNameTextBox.Size = new System.Drawing.Size(265, 20);
            this.ScenarioNameTextBox.TabIndex = 4;
            this.ScenarioNameTextBox.TextChanged += new System.EventHandler(this.ScenarioNameTextBox_TextChanged);
            // 
            // ScenarioNumLabel
            // 
            this.ScenarioNumLabel.AutoSize = true;
            this.ScenarioNumLabel.Location = new System.Drawing.Point(258, 58);
            this.ScenarioNumLabel.Name = "ScenarioNumLabel";
            this.ScenarioNumLabel.Size = new System.Drawing.Size(92, 13);
            this.ScenarioNumLabel.TabIndex = 5;
            this.ScenarioNumLabel.Text = "Scenario Number:";
            // 
            // ScenarioNumNumericUpDown
            // 
            this.ScenarioNumNumericUpDown.Enabled = false;
            this.ScenarioNumNumericUpDown.Location = new System.Drawing.Point(356, 56);
            this.ScenarioNumNumericUpDown.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.ScenarioNumNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ScenarioNumNumericUpDown.Name = "ScenarioNumNumericUpDown";
            this.ScenarioNumNumericUpDown.Size = new System.Drawing.Size(48, 20);
            this.ScenarioNumNumericUpDown.TabIndex = 6;
            this.ScenarioNumNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ScenarioNumNumericUpDown.ValueChanged += new System.EventHandler(this.ScenarioNumNumericUpDown_ValueChanged);
            // 
            // StarIDNumericUpDown
            // 
            this.StarIDNumericUpDown.Enabled = false;
            this.StarIDNumericUpDown.Location = new System.Drawing.Point(515, 56);
            this.StarIDNumericUpDown.Name = "StarIDNumericUpDown";
            this.StarIDNumericUpDown.Size = new System.Drawing.Size(97, 20);
            this.StarIDNumericUpDown.TabIndex = 8;
            // 
            // StarIDLabel
            // 
            this.StarIDLabel.AutoSize = true;
            this.StarIDLabel.Location = new System.Drawing.Point(466, 58);
            this.StarIDLabel.Name = "StarIDLabel";
            this.StarIDLabel.Size = new System.Drawing.Size(43, 13);
            this.StarIDLabel.TabIndex = 7;
            this.StarIDLabel.Text = "Star ID:";
            // 
            // ScenarioTypeComboBox
            // 
            this.ScenarioTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ScenarioTypeComboBox.Enabled = false;
            this.ScenarioTypeComboBox.FormattingEnabled = true;
            this.ScenarioTypeComboBox.Location = new System.Drawing.Point(356, 82);
            this.ScenarioTypeComboBox.Name = "ScenarioTypeComboBox";
            this.ScenarioTypeComboBox.Size = new System.Drawing.Size(100, 21);
            this.ScenarioTypeComboBox.TabIndex = 9;
            this.ScenarioTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.ScenarioTypeComboBox_SelectedIndexChanged);
            // 
            // ScenarioTypeLabel
            // 
            this.ScenarioTypeLabel.AutoSize = true;
            this.ScenarioTypeLabel.Location = new System.Drawing.Point(258, 85);
            this.ScenarioTypeLabel.Name = "ScenarioTypeLabel";
            this.ScenarioTypeLabel.Size = new System.Drawing.Size(79, 13);
            this.ScenarioTypeLabel.TabIndex = 10;
            this.ScenarioTypeLabel.Text = "Scenario Type:";
            // 
            // CometLabel
            // 
            this.CometLabel.AutoSize = true;
            this.CometLabel.Location = new System.Drawing.Point(466, 85);
            this.CometLabel.Name = "CometLabel";
            this.CometLabel.Size = new System.Drawing.Size(40, 13);
            this.CometLabel.TabIndex = 12;
            this.CometLabel.Text = "Comet:";
            // 
            // CometComboBox
            // 
            this.CometComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CometComboBox.Enabled = false;
            this.CometComboBox.FormattingEnabled = true;
            this.CometComboBox.Location = new System.Drawing.Point(512, 82);
            this.CometComboBox.Name = "CometComboBox";
            this.CometComboBox.Size = new System.Drawing.Size(100, 21);
            this.CometComboBox.TabIndex = 11;
            this.CometComboBox.SelectedIndexChanged += new System.EventHandler(this.CometComboBox_SelectedIndexChanged);
            // 
            // AppearenceLabel
            // 
            this.AppearenceLabel.AutoSize = true;
            this.AppearenceLabel.Location = new System.Drawing.Point(258, 112);
            this.AppearenceLabel.Name = "AppearenceLabel";
            this.AppearenceLabel.Size = new System.Drawing.Size(98, 13);
            this.AppearenceLabel.TabIndex = 13;
            this.AppearenceLabel.Text = "Power Star Trigger:";
            // 
            // AppearenceTextBox
            // 
            this.AppearenceTextBox.Enabled = false;
            this.AppearenceTextBox.Location = new System.Drawing.Point(362, 109);
            this.AppearenceTextBox.Name = "AppearenceTextBox";
            this.AppearenceTextBox.Size = new System.Drawing.Size(208, 20);
            this.AppearenceTextBox.TabIndex = 14;
            this.AppearenceTextBox.TextChanged += new System.EventHandler(this.AppearenceTextBox_TextChanged);
            // 
            // AppearenceButton
            // 
            this.AppearenceButton.Enabled = false;
            this.AppearenceButton.Location = new System.Drawing.Point(576, 109);
            this.AppearenceButton.Name = "AppearenceButton";
            this.AppearenceButton.Size = new System.Drawing.Size(36, 20);
            this.AppearenceButton.TabIndex = 15;
            this.AppearenceButton.Text = "•••";
            this.AppearenceButton.UseVisualStyleBackColor = true;
            this.AppearenceButton.Click += new System.EventHandler(this.AppearenceButton_Click);
            // 
            // StarGroupBox
            // 
            this.StarGroupBox.Controls.Add(this.Star6CheckBox);
            this.StarGroupBox.Controls.Add(this.Star5CheckBox);
            this.StarGroupBox.Controls.Add(this.Star4CheckBox);
            this.StarGroupBox.Controls.Add(this.Star3CheckBox);
            this.StarGroupBox.Controls.Add(this.Star2CheckBox);
            this.StarGroupBox.Controls.Add(this.Star1CheckBox);
            this.StarGroupBox.Location = new System.Drawing.Point(261, 161);
            this.StarGroupBox.Name = "StarGroupBox";
            this.StarGroupBox.Size = new System.Drawing.Size(195, 65);
            this.StarGroupBox.TabIndex = 16;
            this.StarGroupBox.TabStop = false;
            this.StarGroupBox.Text = "Stars in this Scenario";
            // 
            // Star6CheckBox
            // 
            this.Star6CheckBox.AutoSize = true;
            this.Star6CheckBox.Enabled = false;
            this.Star6CheckBox.Location = new System.Drawing.Point(126, 42);
            this.Star6CheckBox.Name = "Star6CheckBox";
            this.Star6CheckBox.Size = new System.Drawing.Size(54, 17);
            this.Star6CheckBox.TabIndex = 5;
            this.Star6CheckBox.Text = "Star 6";
            this.Star6CheckBox.UseVisualStyleBackColor = true;
            this.Star6CheckBox.CheckedChanged += new System.EventHandler(this.StarCheckBox_CheckedChanged);
            // 
            // Star5CheckBox
            // 
            this.Star5CheckBox.AutoSize = true;
            this.Star5CheckBox.Enabled = false;
            this.Star5CheckBox.Location = new System.Drawing.Point(66, 42);
            this.Star5CheckBox.Name = "Star5CheckBox";
            this.Star5CheckBox.Size = new System.Drawing.Size(54, 17);
            this.Star5CheckBox.TabIndex = 4;
            this.Star5CheckBox.Text = "Star 5";
            this.Star5CheckBox.UseVisualStyleBackColor = true;
            this.Star5CheckBox.CheckedChanged += new System.EventHandler(this.StarCheckBox_CheckedChanged);
            // 
            // Star4CheckBox
            // 
            this.Star4CheckBox.AutoSize = true;
            this.Star4CheckBox.Enabled = false;
            this.Star4CheckBox.Location = new System.Drawing.Point(6, 42);
            this.Star4CheckBox.Name = "Star4CheckBox";
            this.Star4CheckBox.Size = new System.Drawing.Size(54, 17);
            this.Star4CheckBox.TabIndex = 3;
            this.Star4CheckBox.Text = "Star 4";
            this.Star4CheckBox.UseVisualStyleBackColor = true;
            this.Star4CheckBox.CheckedChanged += new System.EventHandler(this.StarCheckBox_CheckedChanged);
            // 
            // Star3CheckBox
            // 
            this.Star3CheckBox.AutoSize = true;
            this.Star3CheckBox.Enabled = false;
            this.Star3CheckBox.Location = new System.Drawing.Point(126, 19);
            this.Star3CheckBox.Name = "Star3CheckBox";
            this.Star3CheckBox.Size = new System.Drawing.Size(54, 17);
            this.Star3CheckBox.TabIndex = 2;
            this.Star3CheckBox.Text = "Star 3";
            this.Star3CheckBox.UseVisualStyleBackColor = true;
            this.Star3CheckBox.CheckedChanged += new System.EventHandler(this.StarCheckBox_CheckedChanged);
            // 
            // Star2CheckBox
            // 
            this.Star2CheckBox.AutoSize = true;
            this.Star2CheckBox.Enabled = false;
            this.Star2CheckBox.Location = new System.Drawing.Point(66, 19);
            this.Star2CheckBox.Name = "Star2CheckBox";
            this.Star2CheckBox.Size = new System.Drawing.Size(54, 17);
            this.Star2CheckBox.TabIndex = 1;
            this.Star2CheckBox.Text = "Star 2";
            this.Star2CheckBox.UseVisualStyleBackColor = true;
            this.Star2CheckBox.CheckedChanged += new System.EventHandler(this.StarCheckBox_CheckedChanged);
            // 
            // Star1CheckBox
            // 
            this.Star1CheckBox.AutoSize = true;
            this.Star1CheckBox.Enabled = false;
            this.Star1CheckBox.Location = new System.Drawing.Point(6, 19);
            this.Star1CheckBox.Name = "Star1CheckBox";
            this.Star1CheckBox.Size = new System.Drawing.Size(54, 17);
            this.Star1CheckBox.TabIndex = 0;
            this.Star1CheckBox.Text = "Star 1";
            this.Star1CheckBox.UseVisualStyleBackColor = true;
            this.Star1CheckBox.CheckedChanged += new System.EventHandler(this.StarCheckBox_CheckedChanged);
            // 
            // ZonesListBox
            // 
            this.ZonesListBox.Enabled = false;
            this.ZonesListBox.FormattingEnabled = true;
            this.ZonesListBox.HorizontalScrollbar = true;
            this.ZonesListBox.Location = new System.Drawing.Point(462, 139);
            this.ZonesListBox.Name = "ZonesListBox";
            this.ZonesListBox.Size = new System.Drawing.Size(150, 251);
            this.ZonesListBox.TabIndex = 17;
            this.ZonesListBox.SelectedIndexChanged += new System.EventHandler(this.ZonesListBox_SelectedIndexChanged);
            // 
            // TimeLimitNumericUpDown
            // 
            this.TimeLimitNumericUpDown.Enabled = false;
            this.TimeLimitNumericUpDown.Location = new System.Drawing.Point(356, 135);
            this.TimeLimitNumericUpDown.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.TimeLimitNumericUpDown.Name = "TimeLimitNumericUpDown";
            this.TimeLimitNumericUpDown.Size = new System.Drawing.Size(100, 20);
            this.TimeLimitNumericUpDown.TabIndex = 19;
            this.TimeLimitNumericUpDown.ValueChanged += new System.EventHandler(this.TimeLimitNumericUpDown_ValueChanged);
            // 
            // TimelimitLabal
            // 
            this.TimelimitLabal.AutoSize = true;
            this.TimelimitLabal.Location = new System.Drawing.Point(258, 137);
            this.TimelimitLabal.Name = "TimelimitLabal";
            this.TimelimitLabal.Size = new System.Drawing.Size(90, 13);
            this.TimelimitLabal.TabIndex = 18;
            this.TimelimitLabal.Text = "Comet Time Limit:";
            // 
            // LayerGroupBox
            // 
            this.LayerGroupBox.Controls.Add(this.RenameZoneButton);
            this.LayerGroupBox.Controls.Add(this.SubtractZoneButton);
            this.LayerGroupBox.Controls.Add(this.AddZoneButton);
            this.LayerGroupBox.Controls.Add(this.LayerPCheckBox);
            this.LayerGroupBox.Controls.Add(this.LayerOCheckBox);
            this.LayerGroupBox.Controls.Add(this.LayerNCheckBox);
            this.LayerGroupBox.Controls.Add(this.LayerMCheckBox);
            this.LayerGroupBox.Controls.Add(this.LayerLCheckBox);
            this.LayerGroupBox.Controls.Add(this.LayerKCheckBox);
            this.LayerGroupBox.Controls.Add(this.LayerJCheckBox);
            this.LayerGroupBox.Controls.Add(this.LayerICheckBox);
            this.LayerGroupBox.Controls.Add(this.LayerHCheckBox);
            this.LayerGroupBox.Controls.Add(this.LayerGCheckBox);
            this.LayerGroupBox.Controls.Add(this.LayerFCheckBox);
            this.LayerGroupBox.Controls.Add(this.LayerECheckBox);
            this.LayerGroupBox.Controls.Add(this.LayerDCheckBox);
            this.LayerGroupBox.Controls.Add(this.LayerCCheckBox);
            this.LayerGroupBox.Controls.Add(this.LayerBCheckBox);
            this.LayerGroupBox.Controls.Add(this.LayerACheckBox);
            this.LayerGroupBox.Location = new System.Drawing.Point(261, 232);
            this.LayerGroupBox.Name = "LayerGroupBox";
            this.LayerGroupBox.Size = new System.Drawing.Size(195, 184);
            this.LayerGroupBox.TabIndex = 20;
            this.LayerGroupBox.TabStop = false;
            this.LayerGroupBox.Text = "Zone Layers";
            // 
            // RenameZoneButton
            // 
            this.RenameZoneButton.Enabled = false;
            this.RenameZoneButton.Location = new System.Drawing.Point(6, 126);
            this.RenameZoneButton.Name = "RenameZoneButton";
            this.RenameZoneButton.Size = new System.Drawing.Size(183, 23);
            this.RenameZoneButton.TabIndex = 24;
            this.RenameZoneButton.Text = "Rename Zone";
            this.RenameZoneButton.UseVisualStyleBackColor = true;
            this.RenameZoneButton.Click += new System.EventHandler(this.RenameZoneButton_Click);
            // 
            // SubtractZoneButton
            // 
            this.SubtractZoneButton.Enabled = false;
            this.SubtractZoneButton.Location = new System.Drawing.Point(101, 155);
            this.SubtractZoneButton.Name = "SubtractZoneButton";
            this.SubtractZoneButton.Size = new System.Drawing.Size(88, 23);
            this.SubtractZoneButton.TabIndex = 23;
            this.SubtractZoneButton.Text = "Subtract Zone";
            this.SubtractZoneButton.UseVisualStyleBackColor = true;
            this.SubtractZoneButton.Click += new System.EventHandler(this.SubtractZoneButton_Click);
            // 
            // AddZoneButton
            // 
            this.AddZoneButton.Enabled = false;
            this.AddZoneButton.Location = new System.Drawing.Point(6, 155);
            this.AddZoneButton.Name = "AddZoneButton";
            this.AddZoneButton.Size = new System.Drawing.Size(89, 23);
            this.AddZoneButton.TabIndex = 22;
            this.AddZoneButton.Text = "Add Zone";
            this.AddZoneButton.UseVisualStyleBackColor = true;
            this.AddZoneButton.Click += new System.EventHandler(this.AddZoneButton_Click);
            // 
            // LayerPCheckBox
            // 
            this.LayerPCheckBox.AutoSize = true;
            this.LayerPCheckBox.Enabled = false;
            this.LayerPCheckBox.Location = new System.Drawing.Point(155, 88);
            this.LayerPCheckBox.Name = "LayerPCheckBox";
            this.LayerPCheckBox.Size = new System.Drawing.Size(33, 17);
            this.LayerPCheckBox.TabIndex = 21;
            this.LayerPCheckBox.Text = "P";
            this.LayerPCheckBox.UseVisualStyleBackColor = true;
            this.LayerPCheckBox.CheckedChanged += new System.EventHandler(this.LayerCheckBox_CheckedChanged);
            // 
            // LayerOCheckBox
            // 
            this.LayerOCheckBox.AutoSize = true;
            this.LayerOCheckBox.Enabled = false;
            this.LayerOCheckBox.Location = new System.Drawing.Point(110, 88);
            this.LayerOCheckBox.Name = "LayerOCheckBox";
            this.LayerOCheckBox.Size = new System.Drawing.Size(34, 17);
            this.LayerOCheckBox.TabIndex = 20;
            this.LayerOCheckBox.Text = "O";
            this.LayerOCheckBox.UseVisualStyleBackColor = true;
            this.LayerOCheckBox.CheckedChanged += new System.EventHandler(this.LayerCheckBox_CheckedChanged);
            // 
            // LayerNCheckBox
            // 
            this.LayerNCheckBox.AutoSize = true;
            this.LayerNCheckBox.Enabled = false;
            this.LayerNCheckBox.Location = new System.Drawing.Point(56, 88);
            this.LayerNCheckBox.Name = "LayerNCheckBox";
            this.LayerNCheckBox.Size = new System.Drawing.Size(34, 17);
            this.LayerNCheckBox.TabIndex = 19;
            this.LayerNCheckBox.Text = "N";
            this.LayerNCheckBox.UseVisualStyleBackColor = true;
            this.LayerNCheckBox.CheckedChanged += new System.EventHandler(this.LayerCheckBox_CheckedChanged);
            // 
            // LayerMCheckBox
            // 
            this.LayerMCheckBox.AutoSize = true;
            this.LayerMCheckBox.Enabled = false;
            this.LayerMCheckBox.Location = new System.Drawing.Point(6, 88);
            this.LayerMCheckBox.Name = "LayerMCheckBox";
            this.LayerMCheckBox.Size = new System.Drawing.Size(35, 17);
            this.LayerMCheckBox.TabIndex = 18;
            this.LayerMCheckBox.Text = "M";
            this.LayerMCheckBox.UseVisualStyleBackColor = true;
            this.LayerMCheckBox.CheckedChanged += new System.EventHandler(this.LayerCheckBox_CheckedChanged);
            // 
            // LayerLCheckBox
            // 
            this.LayerLCheckBox.AutoSize = true;
            this.LayerLCheckBox.Enabled = false;
            this.LayerLCheckBox.Location = new System.Drawing.Point(155, 65);
            this.LayerLCheckBox.Name = "LayerLCheckBox";
            this.LayerLCheckBox.Size = new System.Drawing.Size(32, 17);
            this.LayerLCheckBox.TabIndex = 17;
            this.LayerLCheckBox.Text = "L";
            this.LayerLCheckBox.UseVisualStyleBackColor = true;
            this.LayerLCheckBox.CheckedChanged += new System.EventHandler(this.LayerCheckBox_CheckedChanged);
            // 
            // LayerKCheckBox
            // 
            this.LayerKCheckBox.AutoSize = true;
            this.LayerKCheckBox.Enabled = false;
            this.LayerKCheckBox.Location = new System.Drawing.Point(110, 65);
            this.LayerKCheckBox.Name = "LayerKCheckBox";
            this.LayerKCheckBox.Size = new System.Drawing.Size(33, 17);
            this.LayerKCheckBox.TabIndex = 16;
            this.LayerKCheckBox.Text = "K";
            this.LayerKCheckBox.UseVisualStyleBackColor = true;
            this.LayerKCheckBox.CheckedChanged += new System.EventHandler(this.LayerCheckBox_CheckedChanged);
            // 
            // LayerJCheckBox
            // 
            this.LayerJCheckBox.AutoSize = true;
            this.LayerJCheckBox.Enabled = false;
            this.LayerJCheckBox.Location = new System.Drawing.Point(56, 65);
            this.LayerJCheckBox.Name = "LayerJCheckBox";
            this.LayerJCheckBox.Size = new System.Drawing.Size(31, 17);
            this.LayerJCheckBox.TabIndex = 15;
            this.LayerJCheckBox.Text = "J";
            this.LayerJCheckBox.UseVisualStyleBackColor = true;
            this.LayerJCheckBox.CheckedChanged += new System.EventHandler(this.LayerCheckBox_CheckedChanged);
            // 
            // LayerICheckBox
            // 
            this.LayerICheckBox.AutoSize = true;
            this.LayerICheckBox.Enabled = false;
            this.LayerICheckBox.Location = new System.Drawing.Point(6, 65);
            this.LayerICheckBox.Name = "LayerICheckBox";
            this.LayerICheckBox.Size = new System.Drawing.Size(29, 17);
            this.LayerICheckBox.TabIndex = 14;
            this.LayerICheckBox.Text = "I";
            this.LayerICheckBox.UseVisualStyleBackColor = true;
            this.LayerICheckBox.CheckedChanged += new System.EventHandler(this.LayerCheckBox_CheckedChanged);
            // 
            // LayerHCheckBox
            // 
            this.LayerHCheckBox.AutoSize = true;
            this.LayerHCheckBox.Enabled = false;
            this.LayerHCheckBox.Location = new System.Drawing.Point(155, 42);
            this.LayerHCheckBox.Name = "LayerHCheckBox";
            this.LayerHCheckBox.Size = new System.Drawing.Size(34, 17);
            this.LayerHCheckBox.TabIndex = 13;
            this.LayerHCheckBox.Text = "H";
            this.LayerHCheckBox.UseVisualStyleBackColor = true;
            this.LayerHCheckBox.CheckedChanged += new System.EventHandler(this.LayerCheckBox_CheckedChanged);
            // 
            // LayerGCheckBox
            // 
            this.LayerGCheckBox.AutoSize = true;
            this.LayerGCheckBox.Enabled = false;
            this.LayerGCheckBox.Location = new System.Drawing.Point(110, 42);
            this.LayerGCheckBox.Name = "LayerGCheckBox";
            this.LayerGCheckBox.Size = new System.Drawing.Size(34, 17);
            this.LayerGCheckBox.TabIndex = 12;
            this.LayerGCheckBox.Text = "G";
            this.LayerGCheckBox.UseVisualStyleBackColor = true;
            this.LayerGCheckBox.CheckedChanged += new System.EventHandler(this.LayerCheckBox_CheckedChanged);
            // 
            // LayerFCheckBox
            // 
            this.LayerFCheckBox.AutoSize = true;
            this.LayerFCheckBox.Enabled = false;
            this.LayerFCheckBox.Location = new System.Drawing.Point(56, 42);
            this.LayerFCheckBox.Name = "LayerFCheckBox";
            this.LayerFCheckBox.Size = new System.Drawing.Size(32, 17);
            this.LayerFCheckBox.TabIndex = 11;
            this.LayerFCheckBox.Text = "F";
            this.LayerFCheckBox.UseVisualStyleBackColor = true;
            this.LayerFCheckBox.CheckedChanged += new System.EventHandler(this.LayerCheckBox_CheckedChanged);
            // 
            // LayerECheckBox
            // 
            this.LayerECheckBox.AutoSize = true;
            this.LayerECheckBox.Enabled = false;
            this.LayerECheckBox.Location = new System.Drawing.Point(6, 42);
            this.LayerECheckBox.Name = "LayerECheckBox";
            this.LayerECheckBox.Size = new System.Drawing.Size(33, 17);
            this.LayerECheckBox.TabIndex = 10;
            this.LayerECheckBox.Text = "E";
            this.LayerECheckBox.UseVisualStyleBackColor = true;
            this.LayerECheckBox.CheckedChanged += new System.EventHandler(this.LayerCheckBox_CheckedChanged);
            // 
            // LayerDCheckBox
            // 
            this.LayerDCheckBox.AutoSize = true;
            this.LayerDCheckBox.Enabled = false;
            this.LayerDCheckBox.Location = new System.Drawing.Point(155, 19);
            this.LayerDCheckBox.Name = "LayerDCheckBox";
            this.LayerDCheckBox.Size = new System.Drawing.Size(34, 17);
            this.LayerDCheckBox.TabIndex = 9;
            this.LayerDCheckBox.Text = "D";
            this.LayerDCheckBox.UseVisualStyleBackColor = true;
            this.LayerDCheckBox.CheckedChanged += new System.EventHandler(this.LayerCheckBox_CheckedChanged);
            // 
            // LayerCCheckBox
            // 
            this.LayerCCheckBox.AutoSize = true;
            this.LayerCCheckBox.Enabled = false;
            this.LayerCCheckBox.Location = new System.Drawing.Point(110, 19);
            this.LayerCCheckBox.Name = "LayerCCheckBox";
            this.LayerCCheckBox.Size = new System.Drawing.Size(33, 17);
            this.LayerCCheckBox.TabIndex = 8;
            this.LayerCCheckBox.Text = "C";
            this.LayerCCheckBox.UseVisualStyleBackColor = true;
            this.LayerCCheckBox.CheckedChanged += new System.EventHandler(this.LayerCheckBox_CheckedChanged);
            // 
            // LayerBCheckBox
            // 
            this.LayerBCheckBox.AutoSize = true;
            this.LayerBCheckBox.Enabled = false;
            this.LayerBCheckBox.Location = new System.Drawing.Point(56, 19);
            this.LayerBCheckBox.Name = "LayerBCheckBox";
            this.LayerBCheckBox.Size = new System.Drawing.Size(33, 17);
            this.LayerBCheckBox.TabIndex = 7;
            this.LayerBCheckBox.Text = "B";
            this.LayerBCheckBox.UseVisualStyleBackColor = true;
            this.LayerBCheckBox.CheckedChanged += new System.EventHandler(this.LayerCheckBox_CheckedChanged);
            // 
            // LayerACheckBox
            // 
            this.LayerACheckBox.AutoSize = true;
            this.LayerACheckBox.Enabled = false;
            this.LayerACheckBox.Location = new System.Drawing.Point(6, 19);
            this.LayerACheckBox.Name = "LayerACheckBox";
            this.LayerACheckBox.Size = new System.Drawing.Size(33, 17);
            this.LayerACheckBox.TabIndex = 6;
            this.LayerACheckBox.Text = "A";
            this.LayerACheckBox.UseVisualStyleBackColor = true;
            this.LayerACheckBox.CheckedChanged += new System.EventHandler(this.LayerCheckBox_CheckedChanged);
            // 
            // StatusTimer
            // 
            this.StatusTimer.Interval = 5000;
            this.StatusTimer.Tick += new System.EventHandler(this.StatusTimer_Tick);
            // 
            // StatusStripTimer
            // 
            this.StatusStripTimer.Interval = 150;
            this.StatusStripTimer.Tick += new System.EventHandler(this.StatusStripTimer_Tick);
            // 
            // MoveZoneUpButton
            // 
            this.MoveZoneUpButton.Location = new System.Drawing.Point(462, 393);
            this.MoveZoneUpButton.Name = "MoveZoneUpButton";
            this.MoveZoneUpButton.Size = new System.Drawing.Size(72, 23);
            this.MoveZoneUpButton.TabIndex = 21;
            this.MoveZoneUpButton.Text = "Up";
            this.MoveZoneUpButton.UseVisualStyleBackColor = true;
            this.MoveZoneUpButton.Click += new System.EventHandler(this.MoveZoneUpButton_Click);
            // 
            // MoveZoneDownButton
            // 
            this.MoveZoneDownButton.Location = new System.Drawing.Point(540, 393);
            this.MoveZoneDownButton.Name = "MoveZoneDownButton";
            this.MoveZoneDownButton.Size = new System.Drawing.Size(72, 23);
            this.MoveZoneDownButton.TabIndex = 22;
            this.MoveZoneDownButton.Text = "Down";
            this.MoveZoneDownButton.UseVisualStyleBackColor = true;
            this.MoveZoneDownButton.Click += new System.EventHandler(this.MoveZoneDownButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.MoveZoneDownButton);
            this.Controls.Add(this.MoveZoneUpButton);
            this.Controls.Add(this.LayerGroupBox);
            this.Controls.Add(this.TimeLimitNumericUpDown);
            this.Controls.Add(this.TimelimitLabal);
            this.Controls.Add(this.ZonesListBox);
            this.Controls.Add(this.StarGroupBox);
            this.Controls.Add(this.AppearenceButton);
            this.Controls.Add(this.AppearenceTextBox);
            this.Controls.Add(this.AppearenceLabel);
            this.Controls.Add(this.CometLabel);
            this.Controls.Add(this.CometComboBox);
            this.Controls.Add(this.ScenarioTypeLabel);
            this.Controls.Add(this.ScenarioTypeComboBox);
            this.Controls.Add(this.StarIDNumericUpDown);
            this.Controls.Add(this.StarIDLabel);
            this.Controls.Add(this.ScenarioNumNumericUpDown);
            this.Controls.Add(this.ScenarioNumLabel);
            this.Controls.Add(this.ScenarioNameTextBox);
            this.Controls.Add(this.ScenarioNameLabel);
            this.Controls.Add(this.ScenarioListView);
            this.Controls.Add(this.InfoStatusStrip);
            this.Controls.Add(this.MainFormMenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainFormMenuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Scenaristar";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.MainFormMenuStrip.ResumeLayout(false);
            this.MainFormMenuStrip.PerformLayout();
            this.InfoStatusStrip.ResumeLayout(false);
            this.InfoStatusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScenarioNumNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StarIDNumericUpDown)).EndInit();
            this.StarGroupBox.ResumeLayout(false);
            this.StarGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TimeLimitNumericUpDown)).EndInit();
            this.LayerGroupBox.ResumeLayout(false);
            this.LayerGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainFormMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        private System.Windows.Forms.StatusStrip InfoStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel InfoToolStripStatusLabel;
        private System.Windows.Forms.ListView ScenarioListView;
        private System.Windows.Forms.ImageList StarLargeImageList;
        private System.Windows.Forms.ToolStripComboBox ImageSizeToolStripComboBox;
        private System.Windows.Forms.ImageList StarSmallImageList;
        private System.Windows.Forms.ToolStripMenuItem EditToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RemoveToolStripMenuItem;
        private System.Windows.Forms.Label ScenarioNameLabel;
        private System.Windows.Forms.TextBox ScenarioNameTextBox;
        private System.Windows.Forms.Label ScenarioNumLabel;
        private System.Windows.Forms.NumericUpDown ScenarioNumNumericUpDown;
        private System.Windows.Forms.NumericUpDown StarIDNumericUpDown;
        private System.Windows.Forms.Label StarIDLabel;
        private System.Windows.Forms.ComboBox ScenarioTypeComboBox;
        private System.Windows.Forms.Label ScenarioTypeLabel;
        private System.Windows.Forms.Label CometLabel;
        private System.Windows.Forms.ComboBox CometComboBox;
        private System.Windows.Forms.Label AppearenceLabel;
        private System.Windows.Forms.Button AppearenceButton;
        public System.Windows.Forms.TextBox AppearenceTextBox;
        private System.Windows.Forms.GroupBox StarGroupBox;
        private System.Windows.Forms.ListBox ZonesListBox;
        private System.Windows.Forms.NumericUpDown TimeLimitNumericUpDown;
        private System.Windows.Forms.Label TimelimitLabal;
        private System.Windows.Forms.CheckBox Star6CheckBox;
        private System.Windows.Forms.CheckBox Star5CheckBox;
        private System.Windows.Forms.CheckBox Star4CheckBox;
        private System.Windows.Forms.CheckBox Star3CheckBox;
        private System.Windows.Forms.CheckBox Star2CheckBox;
        private System.Windows.Forms.CheckBox Star1CheckBox;
        private System.Windows.Forms.GroupBox LayerGroupBox;
        private System.Windows.Forms.Button SubtractZoneButton;
        private System.Windows.Forms.Button AddZoneButton;
        private System.Windows.Forms.CheckBox LayerPCheckBox;
        private System.Windows.Forms.CheckBox LayerOCheckBox;
        private System.Windows.Forms.CheckBox LayerNCheckBox;
        private System.Windows.Forms.CheckBox LayerMCheckBox;
        private System.Windows.Forms.CheckBox LayerLCheckBox;
        private System.Windows.Forms.CheckBox LayerKCheckBox;
        private System.Windows.Forms.CheckBox LayerJCheckBox;
        private System.Windows.Forms.CheckBox LayerICheckBox;
        private System.Windows.Forms.CheckBox LayerHCheckBox;
        private System.Windows.Forms.CheckBox LayerGCheckBox;
        private System.Windows.Forms.CheckBox LayerFCheckBox;
        private System.Windows.Forms.CheckBox LayerECheckBox;
        private System.Windows.Forms.CheckBox LayerDCheckBox;
        private System.Windows.Forms.CheckBox LayerCCheckBox;
        private System.Windows.Forms.CheckBox LayerBCheckBox;
        private System.Windows.Forms.CheckBox LayerACheckBox;
        private System.Windows.Forms.Timer StatusTimer;
        private System.Windows.Forms.Timer StatusStripTimer;
        private System.Windows.Forms.Button MoveZoneUpButton;
        private System.Windows.Forms.Button MoveZoneDownButton;
        private System.Windows.Forms.Button RenameZoneButton;
        private System.Windows.Forms.ToolStripMenuItem NewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox CurrentFileToolStripTextBox;
    }
}

