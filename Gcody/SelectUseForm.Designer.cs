namespace Gcody
{
    partial class SelectUseForm
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
            this.PreselectedButton = new System.Windows.Forms.Button();
            this.MarkerButton = new System.Windows.Forms.Button();
            this.PlasmaButton = new System.Windows.Forms.Button();
            this.OxygenButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PreselectedButton
            // 
            this.PreselectedButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PreselectedButton.Location = new System.Drawing.Point(13, 13);
            this.PreselectedButton.Name = "PreselectedButton";
            this.PreselectedButton.Size = new System.Drawing.Size(75, 75);
            this.PreselectedButton.TabIndex = 0;
            this.PreselectedButton.Text = "Preselected";
            this.PreselectedButton.UseVisualStyleBackColor = true;
            this.PreselectedButton.Click += new System.EventHandler(this.PreselectedButton_Click);
            // 
            // MarkerButton
            // 
            this.MarkerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MarkerButton.Location = new System.Drawing.Point(13, 94);
            this.MarkerButton.Name = "MarkerButton";
            this.MarkerButton.Size = new System.Drawing.Size(75, 75);
            this.MarkerButton.TabIndex = 1;
            this.MarkerButton.Text = "Marker";
            this.MarkerButton.UseVisualStyleBackColor = true;
            this.MarkerButton.Click += new System.EventHandler(this.MarkerButton_Click);
            // 
            // PlasmaButton
            // 
            this.PlasmaButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PlasmaButton.Location = new System.Drawing.Point(94, 13);
            this.PlasmaButton.Name = "PlasmaButton";
            this.PlasmaButton.Size = new System.Drawing.Size(75, 75);
            this.PlasmaButton.TabIndex = 2;
            this.PlasmaButton.Text = "Plasma";
            this.PlasmaButton.UseVisualStyleBackColor = true;
            this.PlasmaButton.Click += new System.EventHandler(this.PlasmaButton_Click);
            // 
            // OxygenButton
            // 
            this.OxygenButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.OxygenButton.Location = new System.Drawing.Point(94, 94);
            this.OxygenButton.Name = "OxygenButton";
            this.OxygenButton.Size = new System.Drawing.Size(75, 75);
            this.OxygenButton.TabIndex = 3;
            this.OxygenButton.Text = "Oxygen";
            this.OxygenButton.UseVisualStyleBackColor = true;
            this.OxygenButton.Click += new System.EventHandler(this.OxygenButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CancelButton.Location = new System.Drawing.Point(13, 175);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(156, 75);
            this.CancelButton.TabIndex = 4;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SelectUseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(178, 259);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OxygenButton);
            this.Controls.Add(this.PlasmaButton);
            this.Controls.Add(this.MarkerButton);
            this.Controls.Add(this.PreselectedButton);
            this.Name = "SelectUseForm";
            this.Text = "SelectUseForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button PreselectedButton;
        private System.Windows.Forms.Button MarkerButton;
        private System.Windows.Forms.Button PlasmaButton;
        private System.Windows.Forms.Button OxygenButton;
        private System.Windows.Forms.Button CancelButton;
    }
}