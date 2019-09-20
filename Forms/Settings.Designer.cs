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
            this.cleanCategories = new System.Windows.Forms.Button();
            this.cleanCatLabel = new System.Windows.Forms.Label();
            this.changeObservedFolder = new System.Windows.Forms.Button();
            this.loadForm = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TESTCheckMail = new System.Windows.Forms.Button();
            this.TESTCheckConv = new System.Windows.Forms.Button();
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
            // loadForm
            // 
            this.loadForm.Location = new System.Drawing.Point(118, 378);
            this.loadForm.Name = "loadForm";
            this.loadForm.Size = new System.Drawing.Size(137, 40);
            this.loadForm.TabIndex = 3;
            this.loadForm.Text = "Load Form";
            this.loadForm.UseVisualStyleBackColor = true;
            this.loadForm.Click += new System.EventHandler(this.LoadForm_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(215, 334);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(388, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nie wiem w sumie do czego to, ale niech sobie będzie:";
            // 
            // TESTCheckMail
            // 
            this.TESTCheckMail.Location = new System.Drawing.Point(320, 378);
            this.TESTCheckMail.Name = "TESTCheckMail";
            this.TESTCheckMail.Size = new System.Drawing.Size(155, 40);
            this.TESTCheckMail.TabIndex = 5;
            this.TESTCheckMail.Text = "TEST Check Mail";
            this.TESTCheckMail.UseVisualStyleBackColor = true;
            this.TESTCheckMail.Click += new System.EventHandler(this.TESTCheckMail_Click);
            // 
            // TESTCheckConv
            // 
            this.TESTCheckConv.Location = new System.Drawing.Point(527, 378);
            this.TESTCheckConv.Name = "TESTCheckConv";
            this.TESTCheckConv.Size = new System.Drawing.Size(178, 40);
            this.TESTCheckConv.TabIndex = 6;
            this.TESTCheckConv.Text = "TEST Check Conv";
            this.TESTCheckConv.UseVisualStyleBackColor = true;
            this.TESTCheckConv.Click += new System.EventHandler(this.TESTCheckConv_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TESTCheckConv);
            this.Controls.Add(this.TESTCheckMail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.loadForm);
            this.Controls.Add(this.changeObservedFolder);
            this.Controls.Add(this.cleanCatLabel);
            this.Controls.Add(this.cleanCategories);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cleanCategories;
        private System.Windows.Forms.Label cleanCatLabel;
        private System.Windows.Forms.Button changeObservedFolder;
        private System.Windows.Forms.Button loadForm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button TESTCheckMail;
        private System.Windows.Forms.Button TESTCheckConv;
    }
}