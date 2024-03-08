namespace Scenaristar
{
    partial class TemplateForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TemplateForm));
            ScenarioListView = new ListView();
            AbortButton = new Button();
            OKButton = new Button();
            TemplateNameLabel = new Label();
            DescriptionTextBox = new DarkModeForms.ColorTextBox();
            CometTimerGroupBox = new GroupBox();
            CometSecondsNumericUpDown = new DarkModeForms.ColorNumericUpDown();
            label3 = new Label();
            label2 = new Label();
            CometMinutesNumericUpDown = new DarkModeForms.ColorNumericUpDown();
            label1 = new Label();
            StarGroupBox = new GroupBox();
            StarCheckedListBox = new CheckedListBox();
            CometTimerGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)CometSecondsNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CometMinutesNumericUpDown).BeginInit();
            StarGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // ScenarioListView
            // 
            ScenarioListView.BorderStyle = BorderStyle.FixedSingle;
            ScenarioListView.Dock = DockStyle.Left;
            ScenarioListView.FullRowSelect = true;
            ScenarioListView.Location = new Point(0, 0);
            ScenarioListView.MultiSelect = false;
            ScenarioListView.Name = "ScenarioListView";
            ScenarioListView.Size = new Size(252, 371);
            ScenarioListView.TabIndex = 3;
            ScenarioListView.UseCompatibleStateImageBehavior = false;
            ScenarioListView.View = View.SmallIcon;
            ScenarioListView.SelectedIndexChanged += ScenarioListView_SelectedIndexChanged;
            // 
            // AbortButton
            // 
            AbortButton.FlatStyle = FlatStyle.Flat;
            AbortButton.Location = new Point(261, 336);
            AbortButton.Name = "AbortButton";
            AbortButton.Size = new Size(119, 23);
            AbortButton.TabIndex = 4;
            AbortButton.Text = "Cancel";
            AbortButton.UseVisualStyleBackColor = true;
            AbortButton.Click += AbortButton_Click;
            // 
            // OKButton
            // 
            OKButton.FlatStyle = FlatStyle.Flat;
            OKButton.Location = new Point(388, 336);
            OKButton.Name = "OKButton";
            OKButton.Size = new Size(119, 23);
            OKButton.TabIndex = 5;
            OKButton.Text = "Add Template";
            OKButton.UseVisualStyleBackColor = true;
            OKButton.Click += AddButton_Click;
            // 
            // TemplateNameLabel
            // 
            TemplateNameLabel.AutoSize = true;
            TemplateNameLabel.Font = new Font("Microsoft Sans Serif", 10.25F);
            TemplateNameLabel.Location = new Point(261, 12);
            TemplateNameLabel.Name = "TemplateNameLabel";
            TemplateNameLabel.Size = new Size(179, 17);
            TemplateNameLabel.TabIndex = 6;
            TemplateNameLabel.Text = "Pick a Template on the left!";
            // 
            // DescriptionTextBox
            // 
            DescriptionTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            DescriptionTextBox.Location = new Point(261, 67);
            DescriptionTextBox.Multiline = true;
            DescriptionTextBox.Name = "DescriptionTextBox";
            DescriptionTextBox.ReadOnly = true;
            DescriptionTextBox.ScrollBars = ScrollBars.Vertical;
            DescriptionTextBox.Size = new Size(246, 134);
            DescriptionTextBox.TabIndex = 8;
            // 
            // CometTimerGroupBox
            // 
            CometTimerGroupBox.Controls.Add(CometSecondsNumericUpDown);
            CometTimerGroupBox.Controls.Add(label3);
            CometTimerGroupBox.Controls.Add(label2);
            CometTimerGroupBox.Controls.Add(CometMinutesNumericUpDown);
            CometTimerGroupBox.Location = new Point(261, 287);
            CometTimerGroupBox.Name = "CometTimerGroupBox";
            CometTimerGroupBox.Size = new Size(246, 43);
            CometTimerGroupBox.TabIndex = 9;
            CometTimerGroupBox.TabStop = false;
            CometTimerGroupBox.Text = "Timer Settings";
            // 
            // CometSecondsNumericUpDown
            // 
            CometSecondsNumericUpDown.BorderColor = Color.FromArgb(200, 200, 200);
            CometSecondsNumericUpDown.Location = new Point(179, 19);
            CometSecondsNumericUpDown.Maximum = new decimal(new int[] { 59, 0, 0, 0 });
            CometSecondsNumericUpDown.Name = "CometSecondsNumericUpDown";
            CometSecondsNumericUpDown.Size = new Size(61, 20);
            CometSecondsNumericUpDown.TabIndex = 3;
            CometSecondsNumericUpDown.TextValue = new decimal(new int[] { 0, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(124, 21);
            label3.Name = "label3";
            label3.Size = new Size(49, 13);
            label3.TabIndex = 2;
            label3.Text = "Seconds";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 21);
            label2.Name = "label2";
            label2.Size = new Size(44, 13);
            label2.TabIndex = 1;
            label2.Text = "Minutes";
            // 
            // CometMinutesNumericUpDown
            // 
            CometMinutesNumericUpDown.BorderColor = Color.FromArgb(200, 200, 200);
            CometMinutesNumericUpDown.Location = new Point(56, 19);
            CometMinutesNumericUpDown.Maximum = new decimal(new int[] { 32767, 0, 0, 0 });
            CometMinutesNumericUpDown.Name = "CometMinutesNumericUpDown";
            CometMinutesNumericUpDown.Size = new Size(61, 20);
            CometMinutesNumericUpDown.TabIndex = 0;
            CometMinutesNumericUpDown.TextValue = new decimal(new int[] { 0, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(261, 51);
            label1.Name = "label1";
            label1.Size = new Size(110, 13);
            label1.TabIndex = 10;
            label1.Text = "Template Description:";
            // 
            // StarGroupBox
            // 
            StarGroupBox.Controls.Add(StarCheckedListBox);
            StarGroupBox.Location = new Point(261, 207);
            StarGroupBox.Name = "StarGroupBox";
            StarGroupBox.Size = new Size(246, 74);
            StarGroupBox.TabIndex = 16;
            StarGroupBox.TabStop = false;
            StarGroupBox.Text = "Owner Star Selection";
            // 
            // StarCheckedListBox
            // 
            StarCheckedListBox.CheckOnClick = true;
            StarCheckedListBox.ColumnWidth = 59;
            StarCheckedListBox.Dock = DockStyle.Fill;
            StarCheckedListBox.FormattingEnabled = true;
            StarCheckedListBox.IntegralHeight = false;
            StarCheckedListBox.Items.AddRange(new object[] { "Star 1", "Star 2", "Star 3", "Star 4", "Star 5", "Star 6", "Star 7", "Star 8", "Star 9", "Star 10", "Star 11", "Star 12", "Star 13", "Star 14", "Star 15", "Star 16", "Star 17", "Star 18", "Star 19", "Star 20", "Star 21", "Star 22", "Star 23", "Star 24", "Star 25", "Star 26", "Star 27", "Star 28", "Star 29", "Star 30", "Star 31", "Star 32" });
            StarCheckedListBox.Location = new Point(3, 16);
            StarCheckedListBox.MultiColumn = true;
            StarCheckedListBox.Name = "StarCheckedListBox";
            StarCheckedListBox.ScrollAlwaysVisible = true;
            StarCheckedListBox.Size = new Size(240, 55);
            StarCheckedListBox.TabIndex = 0;
            // 
            // TemplateForm
            // 
            AcceptButton = OKButton;
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = AbortButton;
            ClientSize = new Size(519, 371);
            Controls.Add(StarGroupBox);
            Controls.Add(label1);
            Controls.Add(CometTimerGroupBox);
            Controls.Add(DescriptionTextBox);
            Controls.Add(TemplateNameLabel);
            Controls.Add(OKButton);
            Controls.Add(AbortButton);
            Controls.Add(ScenarioListView);
            Font = new Font("Microsoft Sans Serif", 8.25F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TemplateForm";
            Text = "Scenaristar - Templates";
            CometTimerGroupBox.ResumeLayout(false);
            CometTimerGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)CometSecondsNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)CometMinutesNumericUpDown).EndInit();
            StarGroupBox.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView ScenarioListView;
        private Button AbortButton;
        private Button OKButton;
        private Label TemplateNameLabel;
        private DarkModeForms.ColorTextBox DescriptionTextBox;
        private GroupBox CometTimerGroupBox;
        private DarkModeForms.ColorNumericUpDown CometSecondsNumericUpDown;
        private Label label3;
        private Label label2;
        private DarkModeForms.ColorNumericUpDown CometMinutesNumericUpDown;
        private Label label1;
        private GroupBox StarGroupBox;
        private CheckedListBox StarCheckedListBox;
    }
}