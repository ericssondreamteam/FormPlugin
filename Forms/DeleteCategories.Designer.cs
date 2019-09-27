namespace FormPlugin.Forms
{
    partial class DeleteCategories
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Info = new System.Windows.Forms.Label();
            this.Start = new System.Windows.Forms.Label();
            this.Koniec = new System.Windows.Forms.Label();
            this.startDate = new System.Windows.Forms.DateTimePicker();
            this.finishDate = new System.Windows.Forms.DateTimePicker();
            this.deleteButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Info
            // 
            this.Info.AutoSize = true;
            this.Info.Location = new System.Drawing.Point(69, 52);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(450, 60);
            this.Info.TabIndex = 1;
            this.Info.Text = "Choose start date and end date. E-mails in the selected range \nwill be deprived o" +
    "f the categories assigned by our plugin \n(Good Response and Bad Response).\n";
            this.Info.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Start
            // 
            this.Start.AutoSize = true;
            this.Start.Location = new System.Drawing.Point(75, 157);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(87, 20);
            this.Start.TabIndex = 2;
            this.Start.Text = "Start Date:";
            // 
            // Koniec
            // 
            this.Koniec.AutoSize = true;
            this.Koniec.Location = new System.Drawing.Point(320, 157);
            this.Koniec.Name = "Koniec";
            this.Koniec.Size = new System.Drawing.Size(81, 20);
            this.Koniec.TabIndex = 3;
            this.Koniec.Text = "End Date:";
            this.Koniec.Click += new System.EventHandler(this.Koniec_Click);
            // 
            // startDate
            // 
            this.startDate.CustomFormat = "MM/dd/yyyy hh:mm:ss";
            this.startDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startDate.Location = new System.Drawing.Point(63, 180);
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(200, 26);
            this.startDate.TabIndex = 4;
            // 
            // finishDate
            // 
            this.finishDate.CustomFormat = "MM/dd/yyyy hh:mm:ss";
            this.finishDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.finishDate.Location = new System.Drawing.Point(313, 180);
            this.finishDate.Name = "finishDate";
            this.finishDate.Size = new System.Drawing.Size(200, 26);
            this.finishDate.TabIndex = 5;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(313, 280);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(115, 52);
            this.deleteButton.TabIndex = 7;
            this.deleteButton.Text = "Delete Categories";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(148, 280);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(115, 52);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(200, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Start Date < End Date";
            this.label2.Click += new System.EventHandler(this.Label2_Click);
            // 
            // DeleteCategories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(568, 368);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.finishDate);
            this.Controls.Add(this.startDate);
            this.Controls.Add(this.Koniec);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.Info);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(590, 424);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(590, 424);
            this.Name = "DeleteCategories";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DeleteCategories";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Info;
        private System.Windows.Forms.Label Start;
        private System.Windows.Forms.Label Koniec;
        private System.Windows.Forms.DateTimePicker startDate;
        private System.Windows.Forms.DateTimePicker finishDate;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label2;
    }
}