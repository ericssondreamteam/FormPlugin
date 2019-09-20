namespace FormPlugin.Forms
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SendForm));
            this.cleanCategories = new System.Windows.Forms.Button();
            this.cleanCatLabel = new System.Windows.Forms.Label();
            this.changeObservedFolder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cleanCategories
            // 
            this.cleanCategories.Location = new System.Drawing.Point(517, 182);
            this.cleanCategories.Name = "cleanCategories";
            this.cleanCategories.Size = new System.Drawing.Size(137, 78);
            this.cleanCategories.TabIndex = 0;
            this.cleanCategories.Text = "Clean Categories";
            this.cleanCategories.UseVisualStyleBackColor = true;
            this.cleanCategories.Click += new System.EventHandler(this.CleanCategories_Click);
            // 
            // cleanCatLabel
            // 
            this.cleanCatLabel.AutoSize = true;
            this.cleanCatLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cleanCatLabel.ForeColor = System.Drawing.Color.DarkBlue;
            this.cleanCatLabel.Location = new System.Drawing.Point(419, 119);
            this.cleanCatLabel.Name = "cleanCatLabel";
            this.cleanCatLabel.Size = new System.Drawing.Size(362, 40);
            this.cleanCatLabel.TabIndex = 1;
            this.cleanCatLabel.Text = "Clean categories \n(Only \"Bad Response\" or \"Good Response\":";
            this.cleanCatLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // changeObservedFolder
            // 
            this.changeObservedFolder.Location = new System.Drawing.Point(118, 182);
            this.changeObservedFolder.Name = "changeObservedFolder";
            this.changeObservedFolder.Size = new System.Drawing.Size(137, 78);
            this.changeObservedFolder.TabIndex = 2;
            this.changeObservedFolder.Text = "Change Observed Folder";
            this.changeObservedFolder.UseVisualStyleBackColor = true;
            this.changeObservedFolder.Click += new System.EventHandler(this.ChangeObservedFolder_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.changeObservedFolder);
            this.Controls.Add(this.cleanCatLabel);
            this.Controls.Add(this.cleanCategories);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cleanCategories;
        private System.Windows.Forms.Label cleanCatLabel;
        private System.Windows.Forms.Button changeObservedFolder;
    }
}