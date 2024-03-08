using DarkModeForms;

namespace Scenaristar
{
    partial class ScenarioEditorForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScenarioEditorForm));
            ScenarioMenuStrip = new MenuStrip();
            FileToolStripMenuItem = new ToolStripMenuItem();
            NewToolStripMenuItem = new ToolStripMenuItem();
            OpenToolStripMenuItem = new ToolStripMenuItem();
            SaveToolStripMenuItem = new ToolStripMenuItem();
            SaveAsToolStripMenuItem = new ToolStripMenuItem();
            EditToolStripMenuItem = new ToolStripMenuItem();
            AddScenarioToolStripMenuItem = new ToolStripMenuItem();
            RemoveScenarioToolStripMenuItem = new ToolStripMenuItem();
            MoveScenarioUpToolStripMenuItem = new ToolStripMenuItem();
            MoveScenarioDownToolStripMenuItem = new ToolStripMenuItem();
            TemplatesToolStripMenuItem = new ToolStripMenuItem();
            SettingsToolStripMenuItem = new ToolStripMenuItem();
            GameModeToolStripComboBox = new ToolStripColorComboBox();
            ImageSizeToolStripComboBox = new ToolStripColorComboBox();
            CompressToolStripComboBox = new ToolStripColorComboBox();
            ThemeToolStripComboBox = new ToolStripColorComboBox();
            CurrentFileToolStripTextBox = new ToolStripTextBox();
            InfoStatusStrip = new StatusStrip();
            InfoToolStripStatusLabel = new ToolStripStatusLabel();
            ScenarioListView = new ListView();
            ScenarioNameTextBox = new ColorTextBox();
            ScenarioNumNumericUpDown = new ColorNumericUpDown();
            TimeLimitNumericUpDown = new ColorNumericUpDown();
            CometTimerButton = new Button();
            ZonesListBox = new ListBox();
            ScenarioTypeComboBox = new ColorComboBox();
            CometComboBox = new ColorComboBox();
            AppearenceTextBox = new ColorTextBox();
            AppearenceButton = new Button();
            LayerGroupBox = new GroupBox();
            SubtractZoneButton = new Button();
            AddZoneButton = new Button();
            RenameZoneButton = new Button();
            LayerPCheckBox = new CheckBox();
            LayerOCheckBox = new CheckBox();
            LayerNCheckBox = new CheckBox();
            LayerMCheckBox = new CheckBox();
            LayerLCheckBox = new CheckBox();
            LayerKCheckBox = new CheckBox();
            LayerJCheckBox = new CheckBox();
            LayerICheckBox = new CheckBox();
            LayerHCheckBox = new CheckBox();
            LayerGCheckBox = new CheckBox();
            LayerFCheckBox = new CheckBox();
            LayerECheckBox = new CheckBox();
            LayerDCheckBox = new CheckBox();
            LayerCCheckBox = new CheckBox();
            LayerBCheckBox = new CheckBox();
            LayerACheckBox = new CheckBox();
            MoveZoneUpButton = new Button();
            MoveZoneDownButton = new Button();
            StarGroupBox = new GroupBox();
            StarCheckedListBox = new CheckedListBox();
            ScenarioNameLabel = new Label();
            ScenarioNumLabel = new Label();
            TimelimitLabal = new Label();
            ScenarioTypeLabel = new Label();
            CometLabel = new Label();
            AppearenceLabel = new Label();
            StatusTimer = new System.Windows.Forms.Timer(components);
            StatusStripTimer = new System.Windows.Forms.Timer(components);
            ScenarioMenuStrip.SuspendLayout();
            InfoStatusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ScenarioNumNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TimeLimitNumericUpDown).BeginInit();
            LayerGroupBox.SuspendLayout();
            StarGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // ScenarioMenuStrip
            // 
            ScenarioMenuStrip.Items.AddRange(new ToolStripItem[] { FileToolStripMenuItem, EditToolStripMenuItem, SettingsToolStripMenuItem, CurrentFileToolStripTextBox });
            ScenarioMenuStrip.Location = new Point(0, 0);
            ScenarioMenuStrip.Name = "ScenarioMenuStrip";
            ScenarioMenuStrip.Size = new Size(624, 27);
            ScenarioMenuStrip.TabIndex = 0;
            ScenarioMenuStrip.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            FileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { NewToolStripMenuItem, OpenToolStripMenuItem, SaveToolStripMenuItem, SaveAsToolStripMenuItem });
            FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            FileToolStripMenuItem.Size = new Size(37, 23);
            FileToolStripMenuItem.Text = "&File";
            // 
            // NewToolStripMenuItem
            // 
            NewToolStripMenuItem.Name = "NewToolStripMenuItem";
            NewToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            NewToolStripMenuItem.Size = new Size(186, 22);
            NewToolStripMenuItem.Text = "&New";
            NewToolStripMenuItem.Click += NewToolStripMenuItem_Click;
            // 
            // OpenToolStripMenuItem
            // 
            OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            OpenToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            OpenToolStripMenuItem.Size = new Size(186, 22);
            OpenToolStripMenuItem.Text = "&Open";
            OpenToolStripMenuItem.Click += OpenToolStripMenuItem_Click;
            // 
            // SaveToolStripMenuItem
            // 
            SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            SaveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            SaveToolStripMenuItem.Size = new Size(186, 22);
            SaveToolStripMenuItem.Text = "&Save";
            SaveToolStripMenuItem.Click += SaveToolStripMenuItem_Click;
            // 
            // SaveAsToolStripMenuItem
            // 
            SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem";
            SaveAsToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.S;
            SaveAsToolStripMenuItem.Size = new Size(186, 22);
            SaveAsToolStripMenuItem.Text = "Save &As";
            SaveAsToolStripMenuItem.Click += SaveAsToolStripMenuItem_Click;
            // 
            // EditToolStripMenuItem
            // 
            EditToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { AddScenarioToolStripMenuItem, RemoveScenarioToolStripMenuItem, MoveScenarioUpToolStripMenuItem, MoveScenarioDownToolStripMenuItem, TemplatesToolStripMenuItem });
            EditToolStripMenuItem.Name = "EditToolStripMenuItem";
            EditToolStripMenuItem.Size = new Size(39, 23);
            EditToolStripMenuItem.Text = "&Edit";
            // 
            // AddScenarioToolStripMenuItem
            // 
            AddScenarioToolStripMenuItem.Enabled = false;
            AddScenarioToolStripMenuItem.Name = "AddScenarioToolStripMenuItem";
            AddScenarioToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.A;
            AddScenarioToolStripMenuItem.Size = new Size(251, 22);
            AddScenarioToolStripMenuItem.Text = "&Add Scenario";
            AddScenarioToolStripMenuItem.Click += AddScenarioToolStripMenuItem_Click;
            // 
            // RemoveScenarioToolStripMenuItem
            // 
            RemoveScenarioToolStripMenuItem.Enabled = false;
            RemoveScenarioToolStripMenuItem.Name = "RemoveScenarioToolStripMenuItem";
            RemoveScenarioToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Delete;
            RemoveScenarioToolStripMenuItem.Size = new Size(251, 22);
            RemoveScenarioToolStripMenuItem.Text = "&Remove Scenario";
            RemoveScenarioToolStripMenuItem.Click += RemoveScenarioToolStripMenuItem_Click;
            // 
            // MoveScenarioUpToolStripMenuItem
            // 
            MoveScenarioUpToolStripMenuItem.Enabled = false;
            MoveScenarioUpToolStripMenuItem.Name = "MoveScenarioUpToolStripMenuItem";
            MoveScenarioUpToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Up;
            MoveScenarioUpToolStripMenuItem.Size = new Size(251, 22);
            MoveScenarioUpToolStripMenuItem.Text = "Move Scenario &Up";
            MoveScenarioUpToolStripMenuItem.Click += MoveScenarioUpToolStripMenuItem_Click;
            // 
            // MoveScenarioDownToolStripMenuItem
            // 
            MoveScenarioDownToolStripMenuItem.Enabled = false;
            MoveScenarioDownToolStripMenuItem.Name = "MoveScenarioDownToolStripMenuItem";
            MoveScenarioDownToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Down;
            MoveScenarioDownToolStripMenuItem.Size = new Size(251, 22);
            MoveScenarioDownToolStripMenuItem.Text = "Move Scenario &Down";
            MoveScenarioDownToolStripMenuItem.Click += MoveScenarioDownToolStripMenuItem_Click;
            // 
            // TemplatesToolStripMenuItem
            // 
            TemplatesToolStripMenuItem.Enabled = false;
            TemplatesToolStripMenuItem.Name = "TemplatesToolStripMenuItem";
            TemplatesToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.T;
            TemplatesToolStripMenuItem.Size = new Size(251, 22);
            TemplatesToolStripMenuItem.Text = "&Templates...";
            TemplatesToolStripMenuItem.Click += TemplatesToolStripMenuItem_Click;
            // 
            // SettingsToolStripMenuItem
            // 
            SettingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { GameModeToolStripComboBox, ImageSizeToolStripComboBox, CompressToolStripComboBox, ThemeToolStripComboBox });
            SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem";
            SettingsToolStripMenuItem.Size = new Size(61, 23);
            SettingsToolStripMenuItem.Text = "&Settings";
            // 
            // GameModeToolStripComboBox
            // 
            GameModeToolStripComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            GameModeToolStripComboBox.FlatStyle = FlatStyle.Flat;
            GameModeToolStripComboBox.Items.AddRange(new object[] { "Super Mario Galaxy", "Super Mario Galaxy 2" });
            GameModeToolStripComboBox.Name = "GameModeToolStripComboBox";
            GameModeToolStripComboBox.Size = new Size(150, 23);
            GameModeToolStripComboBox.SelectedIndexChanged += GameModeToolStripComboBox_SelectedIndexChanged;
            // 
            // ImageSizeToolStripComboBox
            // 
            ImageSizeToolStripComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ImageSizeToolStripComboBox.FlatStyle = FlatStyle.Flat;
            ImageSizeToolStripComboBox.Items.AddRange(new object[] { "Small Icons", "Large Icons" });
            ImageSizeToolStripComboBox.Name = "ImageSizeToolStripComboBox";
            ImageSizeToolStripComboBox.Size = new Size(150, 23);
            ImageSizeToolStripComboBox.ToolTipText = "Change the Size of the Scenario Icons";
            ImageSizeToolStripComboBox.SelectedIndexChanged += ImageSizeToolStripComboBox_SelectedIndexChanged;
            // 
            // CompressToolStripComboBox
            // 
            CompressToolStripComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            CompressToolStripComboBox.FlatStyle = FlatStyle.Flat;
            CompressToolStripComboBox.Items.AddRange(new object[] { "None", "YAZ0" });
            CompressToolStripComboBox.Name = "CompressToolStripComboBox";
            CompressToolStripComboBox.Size = new Size(150, 23);
            CompressToolStripComboBox.SelectedIndexChanged += CompressToolStripComboBox_SelectedIndexChanged;
            // 
            // ThemeToolStripComboBox
            // 
            ThemeToolStripComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ThemeToolStripComboBox.FlatStyle = FlatStyle.Flat;
            ThemeToolStripComboBox.Items.AddRange(new object[] { "Light", "Dark" });
            ThemeToolStripComboBox.Name = "ThemeToolStripComboBox";
            ThemeToolStripComboBox.Size = new Size(150, 23);
            ThemeToolStripComboBox.SelectedIndexChanged += ThemeToolStripComboBox_SelectedIndexChanged;
            // 
            // CurrentFileToolStripTextBox
            // 
            CurrentFileToolStripTextBox.Alignment = ToolStripItemAlignment.Right;
            CurrentFileToolStripTextBox.Name = "CurrentFileToolStripTextBox";
            CurrentFileToolStripTextBox.ReadOnly = true;
            CurrentFileToolStripTextBox.Size = new Size(350, 23);
            CurrentFileToolStripTextBox.TextBoxTextAlign = HorizontalAlignment.Right;
            // 
            // InfoStatusStrip
            // 
            InfoStatusStrip.Items.AddRange(new ToolStripItem[] { InfoToolStripStatusLabel });
            InfoStatusStrip.Location = new Point(0, 419);
            InfoStatusStrip.Name = "InfoStatusStrip";
            InfoStatusStrip.Size = new Size(624, 22);
            InfoStatusStrip.SizingGrip = false;
            InfoStatusStrip.TabIndex = 1;
            // 
            // InfoToolStripStatusLabel
            // 
            InfoToolStripStatusLabel.Name = "InfoToolStripStatusLabel";
            InfoToolStripStatusLabel.Size = new Size(91, 17);
            InfoToolStripStatusLabel.Text = "Program Status:";
            // 
            // ScenarioListView
            // 
            ScenarioListView.BorderStyle = BorderStyle.FixedSingle;
            ScenarioListView.Dock = DockStyle.Left;
            ScenarioListView.FullRowSelect = true;
            ScenarioListView.Location = new Point(0, 27);
            ScenarioListView.MultiSelect = false;
            ScenarioListView.Name = "ScenarioListView";
            ScenarioListView.Size = new Size(252, 392);
            ScenarioListView.TabIndex = 2;
            ScenarioListView.UseCompatibleStateImageBehavior = false;
            ScenarioListView.SelectedIndexChanged += ScenarioListView_SelectedIndexChanged;
            // 
            // ScenarioNameTextBox
            // 
            ScenarioNameTextBox.Enabled = false;
            ScenarioNameTextBox.Location = new Point(356, 30);
            ScenarioNameTextBox.Name = "ScenarioNameTextBox";
            ScenarioNameTextBox.Size = new Size(256, 20);
            ScenarioNameTextBox.TabIndex = 3;
            ScenarioNameTextBox.TextChanged += ScenarioNameTextBox_TextChanged;
            // 
            // ScenarioNumNumericUpDown
            // 
            ScenarioNumNumericUpDown.BorderColor = Color.FromArgb(200, 200, 200);
            ScenarioNumNumericUpDown.Enabled = false;
            ScenarioNumNumericUpDown.Location = new Point(356, 56);
            ScenarioNumNumericUpDown.Maximum = new decimal(new int[] { 32, 0, 0, 0 });
            ScenarioNumNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            ScenarioNumNumericUpDown.Name = "ScenarioNumNumericUpDown";
            ScenarioNumNumericUpDown.Size = new Size(48, 20);
            ScenarioNumNumericUpDown.TabIndex = 4;
            ScenarioNumNumericUpDown.TextValue = new decimal(new int[] { 1, 0, 0, 0 });
            ScenarioNumNumericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // TimeLimitNumericUpDown
            // 
            TimeLimitNumericUpDown.BorderColor = Color.FromArgb(200, 200, 200);
            TimeLimitNumericUpDown.Enabled = false;
            TimeLimitNumericUpDown.Location = new Point(512, 56);
            TimeLimitNumericUpDown.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            TimeLimitNumericUpDown.Name = "TimeLimitNumericUpDown";
            TimeLimitNumericUpDown.Size = new Size(58, 20);
            TimeLimitNumericUpDown.TabIndex = 5;
            TimeLimitNumericUpDown.TextValue = new decimal(new int[] { 0, 0, 0, 0 });
            // 
            // CometTimerButton
            // 
            CometTimerButton.Enabled = false;
            CometTimerButton.FlatStyle = FlatStyle.Flat;
            CometTimerButton.Location = new Point(576, 56);
            CometTimerButton.Name = "CometTimerButton";
            CometTimerButton.Size = new Size(36, 20);
            CometTimerButton.TabIndex = 6;
            CometTimerButton.Text = "•••";
            CometTimerButton.UseVisualStyleBackColor = true;
            CometTimerButton.Click += CometTimerButton_Click;
            // 
            // ZonesListBox
            // 
            ZonesListBox.Enabled = false;
            ZonesListBox.FormattingEnabled = true;
            ZonesListBox.ItemHeight = 13;
            ZonesListBox.Location = new Point(462, 139);
            ZonesListBox.Name = "ZonesListBox";
            ZonesListBox.Size = new Size(150, 251);
            ZonesListBox.TabIndex = 7;
            ZonesListBox.SelectedIndexChanged += ZonesListBox_SelectedIndexChanged;
            // 
            // ScenarioTypeComboBox
            // 
            ScenarioTypeComboBox.AutoCompleteMode = AutoCompleteMode.Append;
            ScenarioTypeComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            ScenarioTypeComboBox.BorderColor = Color.FromArgb(200, 200, 200);
            ScenarioTypeComboBox.Enabled = false;
            ScenarioTypeComboBox.FlatStyle = FlatStyle.Flat;
            ScenarioTypeComboBox.FormattingEnabled = true;
            ScenarioTypeComboBox.Location = new Point(356, 82);
            ScenarioTypeComboBox.Name = "ScenarioTypeComboBox";
            ScenarioTypeComboBox.Size = new Size(76, 21);
            ScenarioTypeComboBox.TabIndex = 8;
            ScenarioTypeComboBox.SelectedIndexChanged += ScenarioTypeComboBox_SelectionChanged;
            ScenarioTypeComboBox.TextUpdate += ScenarioTypeComboBox_SelectionChanged;
            // 
            // CometComboBox
            // 
            CometComboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            CometComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            CometComboBox.BorderColor = Color.FromArgb(200, 200, 200);
            CometComboBox.Enabled = false;
            CometComboBox.FlatStyle = FlatStyle.Flat;
            CometComboBox.FormattingEnabled = true;
            CometComboBox.Location = new Point(484, 82);
            CometComboBox.Name = "CometComboBox";
            CometComboBox.Size = new Size(128, 21);
            CometComboBox.TabIndex = 9;
            CometComboBox.SelectedIndexChanged += CometComboBox_SelectionChanged;
            CometComboBox.TextUpdate += CometComboBox_SelectionChanged;
            // 
            // AppearenceTextBox
            // 
            AppearenceTextBox.Enabled = false;
            AppearenceTextBox.Location = new Point(356, 109);
            AppearenceTextBox.Name = "AppearenceTextBox";
            AppearenceTextBox.Size = new Size(214, 20);
            AppearenceTextBox.TabIndex = 10;
            AppearenceTextBox.TextChanged += AppearenceTextBox_TextChanged;
            // 
            // AppearenceButton
            // 
            AppearenceButton.Enabled = false;
            AppearenceButton.FlatStyle = FlatStyle.Flat;
            AppearenceButton.Location = new Point(576, 109);
            AppearenceButton.Name = "AppearenceButton";
            AppearenceButton.Size = new Size(36, 20);
            AppearenceButton.TabIndex = 11;
            AppearenceButton.Text = "•••";
            AppearenceButton.UseVisualStyleBackColor = true;
            AppearenceButton.Click += AppearenceButton_Click;
            // 
            // LayerGroupBox
            // 
            LayerGroupBox.Controls.Add(SubtractZoneButton);
            LayerGroupBox.Controls.Add(AddZoneButton);
            LayerGroupBox.Controls.Add(RenameZoneButton);
            LayerGroupBox.Controls.Add(LayerPCheckBox);
            LayerGroupBox.Controls.Add(LayerOCheckBox);
            LayerGroupBox.Controls.Add(LayerNCheckBox);
            LayerGroupBox.Controls.Add(LayerMCheckBox);
            LayerGroupBox.Controls.Add(LayerLCheckBox);
            LayerGroupBox.Controls.Add(LayerKCheckBox);
            LayerGroupBox.Controls.Add(LayerJCheckBox);
            LayerGroupBox.Controls.Add(LayerICheckBox);
            LayerGroupBox.Controls.Add(LayerHCheckBox);
            LayerGroupBox.Controls.Add(LayerGCheckBox);
            LayerGroupBox.Controls.Add(LayerFCheckBox);
            LayerGroupBox.Controls.Add(LayerECheckBox);
            LayerGroupBox.Controls.Add(LayerDCheckBox);
            LayerGroupBox.Controls.Add(LayerCCheckBox);
            LayerGroupBox.Controls.Add(LayerBCheckBox);
            LayerGroupBox.Controls.Add(LayerACheckBox);
            LayerGroupBox.Location = new Point(261, 249);
            LayerGroupBox.Name = "LayerGroupBox";
            LayerGroupBox.Size = new Size(195, 167);
            LayerGroupBox.TabIndex = 12;
            LayerGroupBox.TabStop = false;
            LayerGroupBox.Text = "Zone Layers";
            // 
            // SubtractZoneButton
            // 
            SubtractZoneButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            SubtractZoneButton.Enabled = false;
            SubtractZoneButton.FlatStyle = FlatStyle.Flat;
            SubtractZoneButton.Location = new Point(101, 138);
            SubtractZoneButton.Name = "SubtractZoneButton";
            SubtractZoneButton.Size = new Size(88, 23);
            SubtractZoneButton.TabIndex = 18;
            SubtractZoneButton.Text = "Subtract Zone";
            SubtractZoneButton.UseVisualStyleBackColor = true;
            SubtractZoneButton.Click += SubtractZoneButton_Click;
            // 
            // AddZoneButton
            // 
            AddZoneButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            AddZoneButton.Enabled = false;
            AddZoneButton.FlatStyle = FlatStyle.Flat;
            AddZoneButton.Location = new Point(6, 138);
            AddZoneButton.Name = "AddZoneButton";
            AddZoneButton.Size = new Size(89, 23);
            AddZoneButton.TabIndex = 17;
            AddZoneButton.Text = "Add Zone";
            AddZoneButton.UseVisualStyleBackColor = true;
            AddZoneButton.Click += AddZoneButton_Click;
            // 
            // RenameZoneButton
            // 
            RenameZoneButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            RenameZoneButton.Enabled = false;
            RenameZoneButton.FlatStyle = FlatStyle.Flat;
            RenameZoneButton.Location = new Point(6, 109);
            RenameZoneButton.Name = "RenameZoneButton";
            RenameZoneButton.Size = new Size(183, 23);
            RenameZoneButton.TabIndex = 16;
            RenameZoneButton.Text = "Rename Zone";
            RenameZoneButton.UseVisualStyleBackColor = true;
            RenameZoneButton.Click += RenameZoneButton_Click;
            // 
            // LayerPCheckBox
            // 
            LayerPCheckBox.AutoSize = true;
            LayerPCheckBox.Enabled = false;
            LayerPCheckBox.Location = new Point(155, 88);
            LayerPCheckBox.Name = "LayerPCheckBox";
            LayerPCheckBox.Size = new Size(33, 17);
            LayerPCheckBox.TabIndex = 15;
            LayerPCheckBox.Text = "P";
            LayerPCheckBox.UseVisualStyleBackColor = true;
            LayerPCheckBox.CheckedChanged += LayerCheckBox_CheckedChanged;
            // 
            // LayerOCheckBox
            // 
            LayerOCheckBox.AutoSize = true;
            LayerOCheckBox.Enabled = false;
            LayerOCheckBox.Location = new Point(106, 88);
            LayerOCheckBox.Name = "LayerOCheckBox";
            LayerOCheckBox.Size = new Size(34, 17);
            LayerOCheckBox.TabIndex = 14;
            LayerOCheckBox.Text = "O";
            LayerOCheckBox.UseVisualStyleBackColor = true;
            LayerOCheckBox.CheckedChanged += LayerCheckBox_CheckedChanged;
            // 
            // LayerNCheckBox
            // 
            LayerNCheckBox.AutoSize = true;
            LayerNCheckBox.Enabled = false;
            LayerNCheckBox.Location = new Point(56, 88);
            LayerNCheckBox.Name = "LayerNCheckBox";
            LayerNCheckBox.Size = new Size(34, 17);
            LayerNCheckBox.TabIndex = 13;
            LayerNCheckBox.Text = "N";
            LayerNCheckBox.UseVisualStyleBackColor = true;
            LayerNCheckBox.CheckedChanged += LayerCheckBox_CheckedChanged;
            // 
            // LayerMCheckBox
            // 
            LayerMCheckBox.AutoSize = true;
            LayerMCheckBox.Enabled = false;
            LayerMCheckBox.Location = new Point(6, 88);
            LayerMCheckBox.Name = "LayerMCheckBox";
            LayerMCheckBox.Size = new Size(35, 17);
            LayerMCheckBox.TabIndex = 12;
            LayerMCheckBox.Text = "M";
            LayerMCheckBox.UseVisualStyleBackColor = true;
            LayerMCheckBox.CheckedChanged += LayerCheckBox_CheckedChanged;
            // 
            // LayerLCheckBox
            // 
            LayerLCheckBox.AutoSize = true;
            LayerLCheckBox.Enabled = false;
            LayerLCheckBox.Location = new Point(155, 65);
            LayerLCheckBox.Name = "LayerLCheckBox";
            LayerLCheckBox.Size = new Size(32, 17);
            LayerLCheckBox.TabIndex = 11;
            LayerLCheckBox.Text = "L";
            LayerLCheckBox.UseVisualStyleBackColor = true;
            LayerLCheckBox.CheckedChanged += LayerCheckBox_CheckedChanged;
            // 
            // LayerKCheckBox
            // 
            LayerKCheckBox.AutoSize = true;
            LayerKCheckBox.Enabled = false;
            LayerKCheckBox.Location = new Point(106, 65);
            LayerKCheckBox.Name = "LayerKCheckBox";
            LayerKCheckBox.Size = new Size(33, 17);
            LayerKCheckBox.TabIndex = 10;
            LayerKCheckBox.Text = "K";
            LayerKCheckBox.UseVisualStyleBackColor = true;
            LayerKCheckBox.CheckedChanged += LayerCheckBox_CheckedChanged;
            // 
            // LayerJCheckBox
            // 
            LayerJCheckBox.AutoSize = true;
            LayerJCheckBox.Enabled = false;
            LayerJCheckBox.Location = new Point(56, 65);
            LayerJCheckBox.Name = "LayerJCheckBox";
            LayerJCheckBox.Size = new Size(31, 17);
            LayerJCheckBox.TabIndex = 9;
            LayerJCheckBox.Text = "J";
            LayerJCheckBox.UseVisualStyleBackColor = true;
            LayerJCheckBox.CheckedChanged += LayerCheckBox_CheckedChanged;
            // 
            // LayerICheckBox
            // 
            LayerICheckBox.AutoSize = true;
            LayerICheckBox.Enabled = false;
            LayerICheckBox.Location = new Point(6, 65);
            LayerICheckBox.Name = "LayerICheckBox";
            LayerICheckBox.Size = new Size(29, 17);
            LayerICheckBox.TabIndex = 8;
            LayerICheckBox.Text = "I";
            LayerICheckBox.UseVisualStyleBackColor = true;
            LayerICheckBox.CheckedChanged += LayerCheckBox_CheckedChanged;
            // 
            // LayerHCheckBox
            // 
            LayerHCheckBox.AutoSize = true;
            LayerHCheckBox.Enabled = false;
            LayerHCheckBox.Location = new Point(155, 42);
            LayerHCheckBox.Name = "LayerHCheckBox";
            LayerHCheckBox.Size = new Size(34, 17);
            LayerHCheckBox.TabIndex = 7;
            LayerHCheckBox.Text = "H";
            LayerHCheckBox.UseVisualStyleBackColor = true;
            LayerHCheckBox.CheckedChanged += LayerCheckBox_CheckedChanged;
            // 
            // LayerGCheckBox
            // 
            LayerGCheckBox.AutoSize = true;
            LayerGCheckBox.Enabled = false;
            LayerGCheckBox.Location = new Point(106, 42);
            LayerGCheckBox.Name = "LayerGCheckBox";
            LayerGCheckBox.Size = new Size(34, 17);
            LayerGCheckBox.TabIndex = 6;
            LayerGCheckBox.Text = "G";
            LayerGCheckBox.UseVisualStyleBackColor = true;
            LayerGCheckBox.CheckedChanged += LayerCheckBox_CheckedChanged;
            // 
            // LayerFCheckBox
            // 
            LayerFCheckBox.AutoSize = true;
            LayerFCheckBox.Enabled = false;
            LayerFCheckBox.Location = new Point(56, 42);
            LayerFCheckBox.Name = "LayerFCheckBox";
            LayerFCheckBox.Size = new Size(32, 17);
            LayerFCheckBox.TabIndex = 5;
            LayerFCheckBox.Text = "F";
            LayerFCheckBox.UseVisualStyleBackColor = true;
            LayerFCheckBox.CheckedChanged += LayerCheckBox_CheckedChanged;
            // 
            // LayerECheckBox
            // 
            LayerECheckBox.AutoSize = true;
            LayerECheckBox.Enabled = false;
            LayerECheckBox.Location = new Point(6, 42);
            LayerECheckBox.Name = "LayerECheckBox";
            LayerECheckBox.Size = new Size(33, 17);
            LayerECheckBox.TabIndex = 4;
            LayerECheckBox.Text = "E";
            LayerECheckBox.UseVisualStyleBackColor = true;
            LayerECheckBox.CheckedChanged += LayerCheckBox_CheckedChanged;
            // 
            // LayerDCheckBox
            // 
            LayerDCheckBox.AutoSize = true;
            LayerDCheckBox.Enabled = false;
            LayerDCheckBox.Location = new Point(155, 19);
            LayerDCheckBox.Name = "LayerDCheckBox";
            LayerDCheckBox.Size = new Size(34, 17);
            LayerDCheckBox.TabIndex = 3;
            LayerDCheckBox.Text = "D";
            LayerDCheckBox.UseVisualStyleBackColor = true;
            LayerDCheckBox.CheckedChanged += LayerCheckBox_CheckedChanged;
            // 
            // LayerCCheckBox
            // 
            LayerCCheckBox.AutoSize = true;
            LayerCCheckBox.Enabled = false;
            LayerCCheckBox.Location = new Point(106, 19);
            LayerCCheckBox.Name = "LayerCCheckBox";
            LayerCCheckBox.Size = new Size(33, 17);
            LayerCCheckBox.TabIndex = 2;
            LayerCCheckBox.Text = "C";
            LayerCCheckBox.UseVisualStyleBackColor = true;
            LayerCCheckBox.CheckedChanged += LayerCheckBox_CheckedChanged;
            // 
            // LayerBCheckBox
            // 
            LayerBCheckBox.AutoSize = true;
            LayerBCheckBox.Enabled = false;
            LayerBCheckBox.Location = new Point(56, 19);
            LayerBCheckBox.Name = "LayerBCheckBox";
            LayerBCheckBox.Size = new Size(33, 17);
            LayerBCheckBox.TabIndex = 1;
            LayerBCheckBox.Text = "B";
            LayerBCheckBox.UseVisualStyleBackColor = true;
            LayerBCheckBox.CheckedChanged += LayerCheckBox_CheckedChanged;
            // 
            // LayerACheckBox
            // 
            LayerACheckBox.AutoSize = true;
            LayerACheckBox.Enabled = false;
            LayerACheckBox.Location = new Point(6, 19);
            LayerACheckBox.Name = "LayerACheckBox";
            LayerACheckBox.Size = new Size(33, 17);
            LayerACheckBox.TabIndex = 0;
            LayerACheckBox.Text = "A";
            LayerACheckBox.UseVisualStyleBackColor = true;
            LayerACheckBox.CheckedChanged += LayerCheckBox_CheckedChanged;
            // 
            // MoveZoneUpButton
            // 
            MoveZoneUpButton.FlatStyle = FlatStyle.Flat;
            MoveZoneUpButton.Location = new Point(462, 393);
            MoveZoneUpButton.Name = "MoveZoneUpButton";
            MoveZoneUpButton.Size = new Size(72, 23);
            MoveZoneUpButton.TabIndex = 13;
            MoveZoneUpButton.Text = "Up";
            MoveZoneUpButton.UseVisualStyleBackColor = true;
            MoveZoneUpButton.Click += MoveZoneUpButton_Click;
            // 
            // MoveZoneDownButton
            // 
            MoveZoneDownButton.FlatStyle = FlatStyle.Flat;
            MoveZoneDownButton.Location = new Point(540, 393);
            MoveZoneDownButton.Name = "MoveZoneDownButton";
            MoveZoneDownButton.Size = new Size(72, 23);
            MoveZoneDownButton.TabIndex = 14;
            MoveZoneDownButton.Text = "Down";
            MoveZoneDownButton.UseVisualStyleBackColor = true;
            MoveZoneDownButton.Click += MoveZoneDownButton_Click;
            // 
            // StarGroupBox
            // 
            StarGroupBox.Controls.Add(StarCheckedListBox);
            StarGroupBox.Location = new Point(261, 133);
            StarGroupBox.Name = "StarGroupBox";
            StarGroupBox.Size = new Size(195, 110);
            StarGroupBox.TabIndex = 15;
            StarGroupBox.TabStop = false;
            StarGroupBox.Text = "Star Declaration";
            // 
            // StarCheckedListBox
            // 
            StarCheckedListBox.CheckOnClick = true;
            StarCheckedListBox.ColumnWidth = 92;
            StarCheckedListBox.Dock = DockStyle.Fill;
            StarCheckedListBox.Enabled = false;
            StarCheckedListBox.FormattingEnabled = true;
            StarCheckedListBox.IntegralHeight = false;
            StarCheckedListBox.Items.AddRange(new object[] { "Star 1", "Star 2", "Star 3", "Star 4", "Star 5", "Star 6", "Star 7", "Star 8", "Star 9", "Star 10", "Star 11", "Star 12", "Star 13", "Star 14", "Star 15", "Star 16", "Star 17", "Star 18", "Star 19", "Star 20", "Star 21", "Star 22", "Star 23", "Star 24", "Star 25", "Star 26", "Star 27", "Star 28", "Star 29", "Star 30", "Star 31", "Star 32" });
            StarCheckedListBox.Location = new Point(3, 16);
            StarCheckedListBox.MultiColumn = true;
            StarCheckedListBox.Name = "StarCheckedListBox";
            StarCheckedListBox.ScrollAlwaysVisible = true;
            StarCheckedListBox.Size = new Size(189, 91);
            StarCheckedListBox.TabIndex = 0;
            StarCheckedListBox.SelectedIndexChanged += StarCheckedListBox_SelectedIndexChanged;
            // 
            // ScenarioNameLabel
            // 
            ScenarioNameLabel.AutoSize = true;
            ScenarioNameLabel.Location = new Point(258, 33);
            ScenarioNameLabel.Name = "ScenarioNameLabel";
            ScenarioNameLabel.Size = new Size(83, 13);
            ScenarioNameLabel.TabIndex = 16;
            ScenarioNameLabel.Text = "Scenario Name:";
            // 
            // ScenarioNumLabel
            // 
            ScenarioNumLabel.AutoSize = true;
            ScenarioNumLabel.Location = new Point(258, 58);
            ScenarioNumLabel.Name = "ScenarioNumLabel";
            ScenarioNumLabel.Size = new Size(92, 13);
            ScenarioNumLabel.TabIndex = 17;
            ScenarioNumLabel.Text = "Scenario Number:";
            // 
            // TimelimitLabal
            // 
            TimelimitLabal.AutoSize = true;
            TimelimitLabal.Location = new Point(416, 58);
            TimelimitLabal.Name = "TimelimitLabal";
            TimelimitLabal.Size = new Size(90, 13);
            TimelimitLabal.TabIndex = 18;
            TimelimitLabal.Text = "Comet Time Limit:";
            // 
            // ScenarioTypeLabel
            // 
            ScenarioTypeLabel.AutoSize = true;
            ScenarioTypeLabel.Location = new Point(258, 85);
            ScenarioTypeLabel.Name = "ScenarioTypeLabel";
            ScenarioTypeLabel.Size = new Size(79, 13);
            ScenarioTypeLabel.TabIndex = 19;
            ScenarioTypeLabel.Text = "Scenario Type:";
            // 
            // CometLabel
            // 
            CometLabel.AutoSize = true;
            CometLabel.Location = new Point(438, 85);
            CometLabel.Name = "CometLabel";
            CometLabel.Size = new Size(40, 13);
            CometLabel.TabIndex = 20;
            CometLabel.Text = "Comet:";
            // 
            // AppearenceLabel
            // 
            AppearenceLabel.AutoSize = true;
            AppearenceLabel.Location = new Point(258, 112);
            AppearenceLabel.Name = "AppearenceLabel";
            AppearenceLabel.Size = new Size(98, 13);
            AppearenceLabel.TabIndex = 21;
            AppearenceLabel.Text = "Power Star Trigger:";
            // 
            // StatusTimer
            // 
            StatusTimer.Interval = 5000;
            StatusTimer.Tick += StatusTimer_Tick;
            // 
            // StatusStripTimer
            // 
            StatusStripTimer.Interval = 150;
            StatusStripTimer.Tick += StatusStripTimer_Tick;
            // 
            // ScenarioEditorForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(624, 441);
            Controls.Add(AppearenceLabel);
            Controls.Add(CometLabel);
            Controls.Add(ScenarioTypeLabel);
            Controls.Add(TimelimitLabal);
            Controls.Add(ScenarioNumLabel);
            Controls.Add(ScenarioNameLabel);
            Controls.Add(StarGroupBox);
            Controls.Add(MoveZoneDownButton);
            Controls.Add(MoveZoneUpButton);
            Controls.Add(LayerGroupBox);
            Controls.Add(AppearenceButton);
            Controls.Add(AppearenceTextBox);
            Controls.Add(CometComboBox);
            Controls.Add(ScenarioTypeComboBox);
            Controls.Add(ZonesListBox);
            Controls.Add(CometTimerButton);
            Controls.Add(TimeLimitNumericUpDown);
            Controls.Add(ScenarioNumNumericUpDown);
            Controls.Add(ScenarioNameTextBox);
            Controls.Add(ScenarioListView);
            Controls.Add(InfoStatusStrip);
            Controls.Add(ScenarioMenuStrip);
            Font = new Font("Microsoft Sans Serif", 8.25F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = ScenarioMenuStrip;
            MaximizeBox = false;
            Name = "ScenarioEditorForm";
            Text = "Scenaristar";
            ScenarioMenuStrip.ResumeLayout(false);
            ScenarioMenuStrip.PerformLayout();
            InfoStatusStrip.ResumeLayout(false);
            InfoStatusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ScenarioNumNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)TimeLimitNumericUpDown).EndInit();
            LayerGroupBox.ResumeLayout(false);
            LayerGroupBox.PerformLayout();
            StarGroupBox.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip ScenarioMenuStrip;
        private ToolStripMenuItem FileToolStripMenuItem;
        private ToolStripMenuItem EditToolStripMenuItem;
        private StatusStrip InfoStatusStrip;
        private ToolStripStatusLabel InfoToolStripStatusLabel;
        private ListView ScenarioListView;
        private ToolStripMenuItem SettingsToolStripMenuItem;
        private ToolStripColorComboBox GameModeToolStripComboBox;
        private ToolStripColorComboBox ImageSizeToolStripComboBox;
        private ToolStripColorComboBox CompressToolStripComboBox;
        private ToolStripTextBox CurrentFileToolStripTextBox;
        private ColorTextBox ScenarioNameTextBox;
        private ColorNumericUpDown ScenarioNumNumericUpDown;
        private ColorNumericUpDown TimeLimitNumericUpDown;
        private Button CometTimerButton;
        private ListBox ZonesListBox;
        private ColorComboBox ScenarioTypeComboBox;
        private ColorComboBox CometComboBox;
        private Button AppearenceButton;
        private GroupBox LayerGroupBox;
        private Button MoveZoneUpButton;
        private Button MoveZoneDownButton;
        private GroupBox StarGroupBox;
        private Label ScenarioNameLabel;
        private Label ScenarioNumLabel;
        private Label TimelimitLabal;
        private Label ScenarioTypeLabel;
        private Label CometLabel;
        private Label AppearenceLabel;
        private CheckBox LayerPCheckBox;
        private CheckBox LayerOCheckBox;
        private CheckBox LayerNCheckBox;
        private CheckBox LayerMCheckBox;
        private CheckBox LayerLCheckBox;
        private CheckBox LayerKCheckBox;
        private CheckBox LayerJCheckBox;
        private CheckBox LayerICheckBox;
        private CheckBox LayerHCheckBox;
        private CheckBox LayerGCheckBox;
        private CheckBox LayerFCheckBox;
        private CheckBox LayerECheckBox;
        private CheckBox LayerDCheckBox;
        private CheckBox LayerCCheckBox;
        private CheckBox LayerBCheckBox;
        private CheckBox LayerACheckBox;
        private Button SubtractZoneButton;
        private Button AddZoneButton;
        private Button RenameZoneButton;
        private ToolStripMenuItem NewToolStripMenuItem;
        private ToolStripMenuItem OpenToolStripMenuItem;
        private ToolStripMenuItem SaveToolStripMenuItem;
        private ToolStripMenuItem SaveAsToolStripMenuItem;
        private ToolStripMenuItem AddScenarioToolStripMenuItem;
        private ToolStripMenuItem RemoveScenarioToolStripMenuItem;
        private ToolStripMenuItem MoveScenarioUpToolStripMenuItem;
        private ToolStripMenuItem MoveScenarioDownToolStripMenuItem;
        private ToolStripMenuItem TemplatesToolStripMenuItem;
        private ToolStripColorComboBox ThemeToolStripComboBox;
        private System.Windows.Forms.Timer StatusTimer;
        private System.Windows.Forms.Timer StatusStripTimer;
        private CheckedListBox StarCheckedListBox;
        public ColorTextBox AppearenceTextBox;
    }
}
