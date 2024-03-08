namespace Scenaristar
{
    partial class ZoneForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZoneForm));
            label1 = new Label();
            NameTextBox = new DarkModeForms.ColorTextBox();
            AbortButton = new Button();
            OKButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(216, 13);
            label1.TabIndex = 0;
            label1.Text = "Type the name of the Zone in the box below";
            // 
            // NameTextBox
            // 
            NameTextBox.Location = new Point(12, 25);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(213, 20);
            NameTextBox.TabIndex = 1;
            // 
            // AbortButton
            // 
            AbortButton.FlatStyle = FlatStyle.Flat;
            AbortButton.Location = new Point(12, 51);
            AbortButton.Name = "AbortButton";
            AbortButton.Size = new Size(75, 23);
            AbortButton.TabIndex = 2;
            AbortButton.Text = "Cancel";
            AbortButton.UseVisualStyleBackColor = true;
            AbortButton.Click += AbortButton_Click;
            // 
            // OKButton
            // 
            OKButton.FlatStyle = FlatStyle.Flat;
            OKButton.Location = new Point(150, 51);
            OKButton.Name = "OKButton";
            OKButton.Size = new Size(75, 23);
            OKButton.TabIndex = 3;
            OKButton.Text = "OK";
            OKButton.UseVisualStyleBackColor = true;
            OKButton.Click += OKButton_Click;
            // 
            // ZoneForm
            // 
            AcceptButton = OKButton;
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = AbortButton;
            ClientSize = new Size(237, 80);
            Controls.Add(OKButton);
            Controls.Add(AbortButton);
            Controls.Add(NameTextBox);
            Controls.Add(label1);
            Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ZoneForm";
            Text = "Scenaristar - Add Zone";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button AbortButton;
        private Button OKButton;
        public DarkModeForms.ColorTextBox NameTextBox;
    }
}