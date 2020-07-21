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
            this.AppearenceListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // AppearenceListBox
            // 
            this.AppearenceListBox.FormattingEnabled = true;
            this.AppearenceListBox.Location = new System.Drawing.Point(12, 12);
            this.AppearenceListBox.Name = "AppearenceListBox";
            this.AppearenceListBox.Size = new System.Drawing.Size(320, 134);
            this.AppearenceListBox.TabIndex = 0;
            this.AppearenceListBox.SelectedIndexChanged += new System.EventHandler(this.AppearenceListBox_SelectedIndexChanged);
            // 
            // StarAppearenceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 151);
            this.Controls.Add(this.AppearenceListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StarAppearenceForm";
            this.Text = "Scenaristar - Star Appearence ID List";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox AppearenceListBox;
    }
}