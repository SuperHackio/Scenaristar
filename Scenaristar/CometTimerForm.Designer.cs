namespace Scenaristar
{
    partial class CometTimerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CometTimerForm));
            this.label3 = new System.Windows.Forms.Label();
            this.CometSecondsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.CometMinutesNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.OKButton = new System.Windows.Forms.Button();
            this.AbortButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CometSecondsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CometMinutesNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(129, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Seconds";
            // 
            // CometSecondsNumericUpDown
            // 
            this.CometSecondsNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CometSecondsNumericUpDown.Location = new System.Drawing.Point(184, 12);
            this.CometSecondsNumericUpDown.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.CometSecondsNumericUpDown.Name = "CometSecondsNumericUpDown";
            this.CometSecondsNumericUpDown.Size = new System.Drawing.Size(61, 20);
            this.CometSecondsNumericUpDown.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Minutes";
            // 
            // CometMinutesNumericUpDown
            // 
            this.CometMinutesNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CometMinutesNumericUpDown.Location = new System.Drawing.Point(62, 12);
            this.CometMinutesNumericUpDown.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.CometMinutesNumericUpDown.Name = "CometMinutesNumericUpDown";
            this.CometMinutesNumericUpDown.Size = new System.Drawing.Size(61, 20);
            this.CometMinutesNumericUpDown.TabIndex = 25;
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(170, 38);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 29;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // AbortButton
            // 
            this.AbortButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.AbortButton.Location = new System.Drawing.Point(15, 38);
            this.AbortButton.Name = "AbortButton";
            this.AbortButton.Size = new System.Drawing.Size(75, 23);
            this.AbortButton.TabIndex = 30;
            this.AbortButton.Text = "Cancel";
            this.AbortButton.UseVisualStyleBackColor = true;
            this.AbortButton.Click += new System.EventHandler(this.AbortButton_Click);
            // 
            // CometTimerForm
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.AbortButton;
            this.ClientSize = new System.Drawing.Size(257, 73);
            this.Controls.Add(this.AbortButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CometSecondsNumericUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CometMinutesNumericUpDown);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CometTimerForm";
            this.Text = "Scenaristar - Comet Timer";
            ((System.ComponentModel.ISupportInitialize)(this.CometSecondsNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CometMinutesNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown CometSecondsNumericUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown CometMinutesNumericUpDown;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button AbortButton;
    }
}