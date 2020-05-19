namespace Gcody
{
    partial class MainForm
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.UpButton = new System.Windows.Forms.Button();
            this.DownButton = new System.Windows.Forms.Button();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.EnterButton = new System.Windows.Forms.Button();
            this.TechnologyButton = new System.Windows.Forms.Button();
            this.G1Button = new System.Windows.Forms.Button();
            this.UseButton = new System.Windows.Forms.Button();
            this.G0Button = new System.Windows.Forms.Button();
            this.G2Button = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UpButton
            // 
            this.UpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UpButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UpButton.Location = new System.Drawing.Point(697, 338);
            this.UpButton.Name = "UpButton";
            this.UpButton.Size = new System.Drawing.Size(75, 75);
            this.UpButton.TabIndex = 5;
            this.UpButton.Text = "▲";
            this.UpButton.UseVisualStyleBackColor = true;
            this.UpButton.Click += new System.EventHandler(this.UpButton_Click);
            // 
            // DownButton
            // 
            this.DownButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DownButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DownButton.Location = new System.Drawing.Point(697, 419);
            this.DownButton.Name = "DownButton";
            this.DownButton.Size = new System.Drawing.Size(75, 75);
            this.DownButton.TabIndex = 6;
            this.DownButton.Text = "▼";
            this.DownButton.UseVisualStyleBackColor = true;
            this.DownButton.Click += new System.EventHandler(this.DownButton_Click);
            // 
            // richTextBox
            // 
            this.richTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.richTextBox.Location = new System.Drawing.Point(12, 12);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox.Size = new System.Drawing.Size(679, 482);
            this.richTextBox.TabIndex = 3;
            this.richTextBox.Text = "N0001 PROGRAM\nN0002 INIT\nN0003 \nN0004 \nN0005 \nN0006 DONE\nN0007 ENDPROGRAM";
            this.richTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.richTextBox_KeyUp);
            // 
            // EnterButton
            // 
            this.EnterButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EnterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.EnterButton.Location = new System.Drawing.Point(697, 500);
            this.EnterButton.Name = "EnterButton";
            this.EnterButton.Size = new System.Drawing.Size(75, 75);
            this.EnterButton.TabIndex = 7;
            this.EnterButton.Text = "ENTER";
            this.EnterButton.UseVisualStyleBackColor = true;
            this.EnterButton.Click += new System.EventHandler(this.EnterButton_Click);
            // 
            // TechnologyButton
            // 
            this.TechnologyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TechnologyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TechnologyButton.Location = new System.Drawing.Point(697, 53);
            this.TechnologyButton.Name = "TechnologyButton";
            this.TechnologyButton.Size = new System.Drawing.Size(75, 35);
            this.TechnologyButton.TabIndex = 1;
            this.TechnologyButton.Text = "TECH";
            this.TechnologyButton.UseVisualStyleBackColor = true;
            this.TechnologyButton.Click += new System.EventHandler(this.TechnologyButton_Click);
            // 
            // G1Button
            // 
            this.G1Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.G1Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.G1Button.Location = new System.Drawing.Point(697, 175);
            this.G1Button.Name = "G1Button";
            this.G1Button.Size = new System.Drawing.Size(75, 75);
            this.G1Button.TabIndex = 3;
            this.G1Button.Text = "G1";
            this.G1Button.UseVisualStyleBackColor = true;
            this.G1Button.Click += new System.EventHandler(this.G1Button_Click);
            // 
            // UseButton
            // 
            this.UseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UseButton.Location = new System.Drawing.Point(697, 12);
            this.UseButton.Name = "UseButton";
            this.UseButton.Size = new System.Drawing.Size(75, 35);
            this.UseButton.TabIndex = 0;
            this.UseButton.Text = "USE";
            this.UseButton.UseVisualStyleBackColor = true;
            this.UseButton.Click += new System.EventHandler(this.UseButton_Click);
            // 
            // G0Button
            // 
            this.G0Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.G0Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.G0Button.Location = new System.Drawing.Point(697, 94);
            this.G0Button.Name = "G0Button";
            this.G0Button.Size = new System.Drawing.Size(75, 75);
            this.G0Button.TabIndex = 2;
            this.G0Button.Text = "G0";
            this.G0Button.UseVisualStyleBackColor = true;
            this.G0Button.Click += new System.EventHandler(this.G0Button_Click);
            // 
            // G2Button
            // 
            this.G2Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.G2Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.G2Button.Location = new System.Drawing.Point(697, 256);
            this.G2Button.Name = "G2Button";
            this.G2Button.Size = new System.Drawing.Size(75, 75);
            this.G2Button.TabIndex = 4;
            this.G2Button.Text = "G2";
            this.G2Button.UseVisualStyleBackColor = true;
            this.G2Button.Click += new System.EventHandler(this.G2Button_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SaveButton.Location = new System.Drawing.Point(355, 501);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(336, 75);
            this.SaveButton.TabIndex = 8;
            this.SaveButton.Text = "SAVE";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // LoadButton
            // 
            this.LoadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LoadButton.Location = new System.Drawing.Point(13, 501);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(336, 74);
            this.LoadButton.TabIndex = 9;
            this.LoadButton.Text = "LOAD";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 587);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.G2Button);
            this.Controls.Add(this.G0Button);
            this.Controls.Add(this.UseButton);
            this.Controls.Add(this.G1Button);
            this.Controls.Add(this.TechnologyButton);
            this.Controls.Add(this.EnterButton);
            this.Controls.Add(this.richTextBox);
            this.Controls.Add(this.DownButton);
            this.Controls.Add(this.UpButton);
            this.MinimumSize = new System.Drawing.Size(300, 626);
            this.Name = "MainForm";
            this.Text = "GCode";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button UpButton;
        private System.Windows.Forms.Button DownButton;
        private System.Windows.Forms.RichTextBox richTextBox;
        private System.Windows.Forms.Button EnterButton;
        private System.Windows.Forms.Button TechnologyButton;
        private System.Windows.Forms.Button G1Button;
        private System.Windows.Forms.Button UseButton;
        private System.Windows.Forms.Button G0Button;
        private System.Windows.Forms.Button G2Button;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button LoadButton;
    }
}

