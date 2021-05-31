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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TemplateForm));
            this.ScenarioListView = new System.Windows.Forms.ListView();
            this.StarSmallImageList = new System.Windows.Forms.ImageList(this.components);
            this.StarGroupBox = new System.Windows.Forms.GroupBox();
            this.Star1CheckBox = new System.Windows.Forms.RadioButton();
            this.Star2CheckBox = new System.Windows.Forms.RadioButton();
            this.Star3CheckBox = new System.Windows.Forms.RadioButton();
            this.Star4CheckBox = new System.Windows.Forms.RadioButton();
            this.Star5CheckBox = new System.Windows.Forms.RadioButton();
            this.Star6CheckBox = new System.Windows.Forms.RadioButton();
            this.Star7CheckBox = new System.Windows.Forms.RadioButton();
            this.Star8CheckBox = new System.Windows.Forms.RadioButton();
            this.TemplateNameLabel = new System.Windows.Forms.Label();
            this.DescriptionTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CometMinutesNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.CometTimerGroupBox = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CometSecondsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.AddButton = new System.Windows.Forms.Button();
            this.AbortButton = new System.Windows.Forms.Button();
            this.StarGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CometMinutesNumericUpDown)).BeginInit();
            this.CometTimerGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CometSecondsNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // ScenarioListView
            // 
            this.ScenarioListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ScenarioListView.HideSelection = false;
            this.ScenarioListView.Location = new System.Drawing.Point(12, 12);
            this.ScenarioListView.MultiSelect = false;
            this.ScenarioListView.Name = "ScenarioListView";
            this.ScenarioListView.Size = new System.Drawing.Size(243, 347);
            this.ScenarioListView.SmallImageList = this.StarSmallImageList;
            this.ScenarioListView.TabIndex = 3;
            this.ScenarioListView.UseCompatibleStateImageBehavior = false;
            this.ScenarioListView.View = System.Windows.Forms.View.SmallIcon;
            this.ScenarioListView.SelectedIndexChanged += new System.EventHandler(this.ScenarioListView_SelectedIndexChanged);
            // 
            // StarSmallImageList
            // 
            this.StarSmallImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.StarSmallImageList.ImageSize = new System.Drawing.Size(64, 64);
            this.StarSmallImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // StarGroupBox
            // 
            this.StarGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StarGroupBox.Controls.Add(this.Star1CheckBox);
            this.StarGroupBox.Controls.Add(this.Star2CheckBox);
            this.StarGroupBox.Controls.Add(this.Star3CheckBox);
            this.StarGroupBox.Controls.Add(this.Star4CheckBox);
            this.StarGroupBox.Controls.Add(this.Star5CheckBox);
            this.StarGroupBox.Controls.Add(this.Star6CheckBox);
            this.StarGroupBox.Controls.Add(this.Star7CheckBox);
            this.StarGroupBox.Controls.Add(this.Star8CheckBox);
            this.StarGroupBox.Enabled = false;
            this.StarGroupBox.Location = new System.Drawing.Point(261, 207);
            this.StarGroupBox.Name = "StarGroupBox";
            this.StarGroupBox.Size = new System.Drawing.Size(246, 66);
            this.StarGroupBox.TabIndex = 17;
            this.StarGroupBox.TabStop = false;
            this.StarGroupBox.Text = "Star Selection";
            // 
            // Star1CheckBox
            // 
            this.Star1CheckBox.AutoSize = true;
            this.Star1CheckBox.Location = new System.Drawing.Point(6, 19);
            this.Star1CheckBox.Name = "Star1CheckBox";
            this.Star1CheckBox.Size = new System.Drawing.Size(53, 17);
            this.Star1CheckBox.TabIndex = 0;
            this.Star1CheckBox.Text = "Star 1";
            this.Star1CheckBox.UseVisualStyleBackColor = true;
            // 
            // Star2CheckBox
            // 
            this.Star2CheckBox.AutoSize = true;
            this.Star2CheckBox.Location = new System.Drawing.Point(66, 19);
            this.Star2CheckBox.Name = "Star2CheckBox";
            this.Star2CheckBox.Size = new System.Drawing.Size(53, 17);
            this.Star2CheckBox.TabIndex = 1;
            this.Star2CheckBox.Text = "Star 2";
            this.Star2CheckBox.UseVisualStyleBackColor = true;
            // 
            // Star3CheckBox
            // 
            this.Star3CheckBox.AutoSize = true;
            this.Star3CheckBox.Location = new System.Drawing.Point(126, 19);
            this.Star3CheckBox.Name = "Star3CheckBox";
            this.Star3CheckBox.Size = new System.Drawing.Size(53, 17);
            this.Star3CheckBox.TabIndex = 2;
            this.Star3CheckBox.Text = "Star 3";
            this.Star3CheckBox.UseVisualStyleBackColor = true;
            // 
            // Star4CheckBox
            // 
            this.Star4CheckBox.AutoSize = true;
            this.Star4CheckBox.Location = new System.Drawing.Point(185, 19);
            this.Star4CheckBox.Name = "Star4CheckBox";
            this.Star4CheckBox.Size = new System.Drawing.Size(53, 17);
            this.Star4CheckBox.TabIndex = 3;
            this.Star4CheckBox.Text = "Star 4";
            this.Star4CheckBox.UseVisualStyleBackColor = true;
            // 
            // Star5CheckBox
            // 
            this.Star5CheckBox.AutoSize = true;
            this.Star5CheckBox.Location = new System.Drawing.Point(6, 42);
            this.Star5CheckBox.Name = "Star5CheckBox";
            this.Star5CheckBox.Size = new System.Drawing.Size(53, 17);
            this.Star5CheckBox.TabIndex = 4;
            this.Star5CheckBox.Text = "Star 5";
            this.Star5CheckBox.UseVisualStyleBackColor = true;
            // 
            // Star6CheckBox
            // 
            this.Star6CheckBox.AutoSize = true;
            this.Star6CheckBox.Location = new System.Drawing.Point(66, 42);
            this.Star6CheckBox.Name = "Star6CheckBox";
            this.Star6CheckBox.Size = new System.Drawing.Size(53, 17);
            this.Star6CheckBox.TabIndex = 5;
            this.Star6CheckBox.Text = "Star 6";
            this.Star6CheckBox.UseVisualStyleBackColor = true;
            // 
            // Star7CheckBox
            // 
            this.Star7CheckBox.AutoSize = true;
            this.Star7CheckBox.Location = new System.Drawing.Point(126, 42);
            this.Star7CheckBox.Name = "Star7CheckBox";
            this.Star7CheckBox.Size = new System.Drawing.Size(53, 17);
            this.Star7CheckBox.TabIndex = 6;
            this.Star7CheckBox.Text = "Star 7";
            this.Star7CheckBox.UseVisualStyleBackColor = true;
            this.Star7CheckBox.Visible = false;
            // 
            // Star8CheckBox
            // 
            this.Star8CheckBox.AutoSize = true;
            this.Star8CheckBox.Location = new System.Drawing.Point(185, 42);
            this.Star8CheckBox.Name = "Star8CheckBox";
            this.Star8CheckBox.Size = new System.Drawing.Size(53, 17);
            this.Star8CheckBox.TabIndex = 7;
            this.Star8CheckBox.Text = "Star 8";
            this.Star8CheckBox.UseVisualStyleBackColor = true;
            this.Star8CheckBox.Visible = false;
            // 
            // TemplateNameLabel
            // 
            this.TemplateNameLabel.AutoSize = true;
            this.TemplateNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.TemplateNameLabel.Location = new System.Drawing.Point(261, 12);
            this.TemplateNameLabel.Name = "TemplateNameLabel";
            this.TemplateNameLabel.Size = new System.Drawing.Size(179, 17);
            this.TemplateNameLabel.TabIndex = 18;
            this.TemplateNameLabel.Text = "Pick a Template on the left!";
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DescriptionTextBox.Location = new System.Drawing.Point(261, 67);
            this.DescriptionTextBox.Multiline = true;
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.ReadOnly = true;
            this.DescriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DescriptionTextBox.Size = new System.Drawing.Size(246, 134);
            this.DescriptionTextBox.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(261, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Template Description:";
            // 
            // CometMinutesNumericUpDown
            // 
            this.CometMinutesNumericUpDown.Location = new System.Drawing.Point(56, 19);
            this.CometMinutesNumericUpDown.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.CometMinutesNumericUpDown.Name = "CometMinutesNumericUpDown";
            this.CometMinutesNumericUpDown.Size = new System.Drawing.Size(61, 20);
            this.CometMinutesNumericUpDown.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Minutes";
            // 
            // CometTimerGroupBox
            // 
            this.CometTimerGroupBox.Controls.Add(this.label3);
            this.CometTimerGroupBox.Controls.Add(this.CometSecondsNumericUpDown);
            this.CometTimerGroupBox.Controls.Add(this.label1);
            this.CometTimerGroupBox.Controls.Add(this.CometMinutesNumericUpDown);
            this.CometTimerGroupBox.Enabled = false;
            this.CometTimerGroupBox.Location = new System.Drawing.Point(261, 279);
            this.CometTimerGroupBox.Name = "CometTimerGroupBox";
            this.CometTimerGroupBox.Size = new System.Drawing.Size(246, 51);
            this.CometTimerGroupBox.TabIndex = 23;
            this.CometTimerGroupBox.TabStop = false;
            this.CometTimerGroupBox.Text = "Timer Settings";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(124, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Seconds";
            // 
            // CometSecondsNumericUpDown
            // 
            this.CometSecondsNumericUpDown.Location = new System.Drawing.Point(179, 19);
            this.CometSecondsNumericUpDown.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.CometSecondsNumericUpDown.Name = "CometSecondsNumericUpDown";
            this.CometSecondsNumericUpDown.Size = new System.Drawing.Size(61, 20);
            this.CometSecondsNumericUpDown.TabIndex = 23;
            // 
            // AddButton
            // 
            this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AddButton.Enabled = false;
            this.AddButton.Location = new System.Drawing.Point(388, 336);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(119, 23);
            this.AddButton.TabIndex = 24;
            this.AddButton.Text = "Add Template";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // AbortButton
            // 
            this.AbortButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AbortButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.AbortButton.Location = new System.Drawing.Point(261, 336);
            this.AbortButton.Name = "AbortButton";
            this.AbortButton.Size = new System.Drawing.Size(119, 23);
            this.AbortButton.TabIndex = 25;
            this.AbortButton.Text = "Cancel";
            this.AbortButton.UseVisualStyleBackColor = true;
            this.AbortButton.Click += new System.EventHandler(this.AbortButton_Click);
            // 
            // TemplateForm
            // 
            this.AcceptButton = this.AddButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.AbortButton;
            this.ClientSize = new System.Drawing.Size(519, 371);
            this.Controls.Add(this.AbortButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.CometTimerGroupBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DescriptionTextBox);
            this.Controls.Add(this.TemplateNameLabel);
            this.Controls.Add(this.StarGroupBox);
            this.Controls.Add(this.ScenarioListView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TemplateForm";
            this.Text = "Scenaristar - Templates";
            this.StarGroupBox.ResumeLayout(false);
            this.StarGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CometMinutesNumericUpDown)).EndInit();
            this.CometTimerGroupBox.ResumeLayout(false);
            this.CometTimerGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CometSecondsNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView ScenarioListView;
        private System.Windows.Forms.GroupBox StarGroupBox;
        private System.Windows.Forms.RadioButton Star8CheckBox;
        private System.Windows.Forms.RadioButton Star7CheckBox;
        private System.Windows.Forms.RadioButton Star6CheckBox;
        private System.Windows.Forms.RadioButton Star5CheckBox;
        private System.Windows.Forms.RadioButton Star4CheckBox;
        private System.Windows.Forms.RadioButton Star3CheckBox;
        private System.Windows.Forms.RadioButton Star2CheckBox;
        private System.Windows.Forms.RadioButton Star1CheckBox;
        private System.Windows.Forms.Label TemplateNameLabel;
        private System.Windows.Forms.TextBox DescriptionTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ImageList StarSmallImageList;
        private System.Windows.Forms.NumericUpDown CometMinutesNumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox CometTimerGroupBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown CometSecondsNumericUpDown;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button AbortButton;
    }
}