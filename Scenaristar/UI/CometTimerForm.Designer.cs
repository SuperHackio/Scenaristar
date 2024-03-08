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
            CometMinutesNumericUpDown = new DarkModeForms.ColorNumericUpDown();
            CometSecondsNumericUpDown = new DarkModeForms.ColorNumericUpDown();
            label1 = new Label();
            label2 = new Label();
            AbortButton = new Button();
            OKButton = new Button();
            ((System.ComponentModel.ISupportInitialize)CometMinutesNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CometSecondsNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // CometMinutesNumericUpDown
            // 
            CometMinutesNumericUpDown.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            CometMinutesNumericUpDown.BorderColor = Color.FromArgb(200, 200, 200);
            CometMinutesNumericUpDown.Location = new Point(62, 12);
            CometMinutesNumericUpDown.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            CometMinutesNumericUpDown.Name = "CometMinutesNumericUpDown";
            CometMinutesNumericUpDown.Size = new Size(61, 20);
            CometMinutesNumericUpDown.TabIndex = 0;
            CometMinutesNumericUpDown.TextValue = new decimal(new int[] { 0, 0, 0, 0 });
            // 
            // CometSecondsNumericUpDown
            // 
            CometSecondsNumericUpDown.BorderColor = Color.FromArgb(200, 200, 200);
            CometSecondsNumericUpDown.Location = new Point(184, 12);
            CometSecondsNumericUpDown.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            CometSecondsNumericUpDown.Name = "CometSecondsNumericUpDown";
            CometSecondsNumericUpDown.Size = new Size(61, 20);
            CometSecondsNumericUpDown.TabIndex = 1;
            CometSecondsNumericUpDown.TextValue = new decimal(new int[] { 0, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 14);
            label1.Name = "label1";
            label1.Size = new Size(44, 13);
            label1.TabIndex = 2;
            label1.Text = "Minutes";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(129, 14);
            label2.Name = "label2";
            label2.Size = new Size(49, 13);
            label2.TabIndex = 3;
            label2.Text = "Seconds";
            // 
            // AbortButton
            // 
            AbortButton.FlatStyle = FlatStyle.Flat;
            AbortButton.Location = new Point(12, 38);
            AbortButton.Name = "AbortButton";
            AbortButton.Size = new Size(75, 23);
            AbortButton.TabIndex = 4;
            AbortButton.Text = "Cancel";
            AbortButton.UseVisualStyleBackColor = true;
            AbortButton.Click += AbortButton_Click;
            // 
            // OKButton
            // 
            OKButton.FlatStyle = FlatStyle.Flat;
            OKButton.Location = new Point(170, 38);
            OKButton.Name = "OKButton";
            OKButton.Size = new Size(75, 23);
            OKButton.TabIndex = 5;
            OKButton.Text = "OK";
            OKButton.UseVisualStyleBackColor = true;
            OKButton.Click += OKButton_Click;
            // 
            // CometTimerForm
            // 
            AcceptButton = OKButton;
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = AbortButton;
            ClientSize = new Size(257, 73);
            Controls.Add(OKButton);
            Controls.Add(AbortButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(CometSecondsNumericUpDown);
            Controls.Add(CometMinutesNumericUpDown);
            Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CometTimerForm";
            Text = "Scenaristar - Comet Timer";
            ((System.ComponentModel.ISupportInitialize)CometMinutesNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)CometSecondsNumericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DarkModeForms.ColorNumericUpDown CometMinutesNumericUpDown;
        private DarkModeForms.ColorNumericUpDown CometSecondsNumericUpDown;
        private Label label1;
        private Label label2;
        private Button AbortButton;
        private Button OKButton;
    }
}