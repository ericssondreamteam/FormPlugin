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
            this.TESTCheckMail = new System.Windows.Forms.Button();
            this.TESTCheckConv = new System.Windows.Forms.Button();
            this.CreateForm = new System.Windows.Forms.Button();
            this.infoCreateTemp = new System.Windows.Forms.Label();
            this.infoChangeMain = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cleanCategories
            // 
            this.cleanCategories.Location = new System.Drawing.Point(40, 200);
            this.cleanCategories.Name = "cleanCategories";
            this.cleanCategories.Size = new System.Drawing.Size(140, 55);
            this.cleanCategories.TabIndex = 0;
            this.cleanCategories.Text = "Clean categories";
            this.cleanCategories.UseVisualStyleBackColor = true;
            this.cleanCategories.Click += new System.EventHandler(this.CleanCategories_Click);
            this.cleanCategories.MouseLeave += new System.EventHandler(this.CleanCategories_MouseLeave);
            this.cleanCategories.MouseHover += new System.EventHandler(this.CleanCategories_MouseHover);
            // 
            // cleanCatLabel
            // 
            this.cleanCatLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cleanCatLabel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.cleanCatLabel.Location = new System.Drawing.Point(190, 205);
            this.cleanCatLabel.Name = "cleanCatLabel";
            this.cleanCatLabel.Size = new System.Drawing.Size(387, 40);
            this.cleanCatLabel.TabIndex = 1;
            this.cleanCatLabel.Text = "Clean categories \n(Only \"Bad Response\" or \"Good Response\")";
            this.cleanCatLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // changeObservedFolder
            // 
            this.changeObservedFolder.Location = new System.Drawing.Point(40, 40);
            this.changeObservedFolder.Name = "changeObservedFolder";
            this.changeObservedFolder.Size = new System.Drawing.Size(140, 55);
            this.changeObservedFolder.TabIndex = 2;
            this.changeObservedFolder.Text = "Change folder";
            this.changeObservedFolder.UseVisualStyleBackColor = true;
            this.changeObservedFolder.Click += new System.EventHandler(this.ChangeObservedFolder_Click);
            this.changeObservedFolder.MouseLeave += new System.EventHandler(this.ChangeObservedFolder_MouseLeave);
            this.changeObservedFolder.MouseHover += new System.EventHandler(this.ChangeObservedFolder_MouseHover);
            // 
            // loadForm
            // 
            this.loadForm.Location = new System.Drawing.Point(77, 332);
            this.loadForm.Name = "loadForm";
            this.loadForm.Size = new System.Drawing.Size(140, 50);
            this.loadForm.TabIndex = 3;
            this.loadForm.Text = "Load Form";
            this.loadForm.UseVisualStyleBackColor = true;
            this.loadForm.Click += new System.EventHandler(this.LoadForm_Click);
            // 
            // TESTCheckMail
            // 
            this.TESTCheckMail.Location = new System.Drawing.Point(369, 334);
            this.TESTCheckMail.Name = "TESTCheckMail";
            this.TESTCheckMail.Size = new System.Drawing.Size(140, 50);
            this.TESTCheckMail.TabIndex = 5;
            this.TESTCheckMail.Text = "TEST Check Mail";
            this.TESTCheckMail.UseVisualStyleBackColor = true;
            this.TESTCheckMail.Click += new System.EventHandler(this.TESTCheckMail_Click);
            // 
            // TESTCheckConv
            // 
            this.TESTCheckConv.Location = new System.Drawing.Point(223, 334);
            this.TESTCheckConv.Name = "TESTCheckConv";
            this.TESTCheckConv.Size = new System.Drawing.Size(140, 50);
            this.TESTCheckConv.TabIndex = 5;
            this.TESTCheckConv.Text = "TEST Check Conv";
            this.TESTCheckConv.UseVisualStyleBackColor = true;
            this.TESTCheckConv.Click += new System.EventHandler(this.TESTCheckConv_Click);
            // 
            // CreateForm
            // 
            this.CreateForm.Location = new System.Drawing.Point(40, 120);
            this.CreateForm.Name = "CreateForm";
            this.CreateForm.Size = new System.Drawing.Size(140, 55);
            this.CreateForm.TabIndex = 7;
            this.CreateForm.Text = "New template";
            this.CreateForm.UseVisualStyleBackColor = true;
            this.CreateForm.Click += new System.EventHandler(this.CreateForm_Click);
            this.CreateForm.MouseLeave += new System.EventHandler(this.CreateForm_MouseLeave);
            this.CreateForm.MouseHover += new System.EventHandler(this.CreateForm_MouseHover);
            // 
            // infoCreateTemp
            // 
            this.infoCreateTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoCreateTemp.ForeColor = System.Drawing.Color.MidnightBlue;
            this.infoCreateTemp.Location = new System.Drawing.Point(190, 125);
            this.infoCreateTemp.Name = "infoCreateTemp";
            this.infoCreateTemp.Size = new System.Drawing.Size(387, 40);
            this.infoCreateTemp.TabIndex = 1;
            this.infoCreateTemp.Text = "Create new template for email \nor edit existing one";
            this.infoCreateTemp.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // infoChangeMain
            // 
            this.infoChangeMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoChangeMain.ForeColor = System.Drawing.Color.MidnightBlue;
            this.infoChangeMain.Location = new System.Drawing.Point(190, 45);
            this.infoChangeMain.Name = "infoChangeMain";
            this.infoChangeMain.Size = new System.Drawing.Size(387, 40);
            this.infoChangeMain.TabIndex = 9;
            this.infoChangeMain.Text = "Change main folder in which \ncategories will be marked";
            this.infoChangeMain.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(40, 302);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(150, 24);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "Show all options";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 396);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.infoChangeMain);
            this.Controls.Add(this.infoCreateTemp);
            this.Controls.Add(this.CreateForm);
            this.Controls.Add(this.TESTCheckConv);
            this.Controls.Add(this.TESTCheckMail);
            this.Controls.Add(this.loadForm);
            this.Controls.Add(this.changeObservedFolder);
            this.Controls.Add(this.cleanCatLabel);
            this.Controls.Add(this.cleanCategories);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(611, 452);
            this.MinimumSize = new System.Drawing.Size(611, 452);
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
        private System.Windows.Forms.Button TESTCheckMail;
        private System.Windows.Forms.Button TESTCheckConv;
        private System.Windows.Forms.Button CreateForm;
        private System.Windows.Forms.Label infoCreateTemp;
        private System.Windows.Forms.Label infoChangeMain;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}