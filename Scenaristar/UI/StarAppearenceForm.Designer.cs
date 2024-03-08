namespace Scenaristar
{
    partial class StarAppearenceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StarAppearenceForm));
            AppearenceListBox = new ListBox();
            SuspendLayout();
            // 
            // AppearenceListBox
            // 
            AppearenceListBox.BorderStyle = BorderStyle.None;
            AppearenceListBox.Dock = DockStyle.Fill;
            AppearenceListBox.FormattingEnabled = true;
            AppearenceListBox.IntegralHeight = false;
            AppearenceListBox.ItemHeight = 13;
            AppearenceListBox.Location = new Point(0, 0);
            AppearenceListBox.Name = "AppearenceListBox";
            AppearenceListBox.Size = new Size(344, 151);
            AppearenceListBox.TabIndex = 0;
            AppearenceListBox.SelectedIndexChanged += AppearenceListBox_SelectedIndexChanged;
            // 
            // StarAppearenceForm
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(344, 151);
            Controls.Add(AppearenceListBox);
            Font = new Font("Microsoft Sans Serif", 8.25F);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "StarAppearenceForm";
            Text = "Scenaristar - PowerStarAppearObj Selector";
            ResumeLayout(false);
        }

        #endregion

        private ListBox AppearenceListBox;
    }
}