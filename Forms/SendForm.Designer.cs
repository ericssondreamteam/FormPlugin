namespace FormPlugin.Forms
{
    partial class SendForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.allReceivers = new System.Windows.Forms.Label();
            this.questionList = new System.Windows.Forms.ListBox();
            this.editButton = new System.Windows.Forms.Button();
            this.deleteQuestionButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.questionTextBox = new System.Windows.Forms.RichTextBox();
            this.labelWarningError = new System.Windows.Forms.Label();
            this.info = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(237, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "First choose template to send:";
            this.label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(186, 398);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(292, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "Do you want to send mail?";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(230, 453);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 38);
            this.button1.TabIndex = 3;
            this.button1.Text = "Yes";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(358, 453);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 38);
            this.button2.TabIndex = 4;
            this.button2.Text = "No";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button3.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.button3.Location = new System.Drawing.Point(252, 46);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(191, 29);
            this.button3.TabIndex = 5;
            this.button3.Text = "Choose template";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // allReceivers
            // 
            this.allReceivers.AutoSize = true;
            this.allReceivers.Location = new System.Drawing.Point(12, 9);
            this.allReceivers.Name = "allReceivers";
            this.allReceivers.Size = new System.Drawing.Size(0, 20);
            this.allReceivers.TabIndex = 6;
            // 
            // questionList
            // 
            this.questionList.FormattingEnabled = true;
            this.questionList.ItemHeight = 20;
            this.questionList.Location = new System.Drawing.Point(78, 232);
            this.questionList.Name = "questionList";
            this.questionList.Size = new System.Drawing.Size(365, 124);
            this.questionList.TabIndex = 20;
            this.questionList.SelectedIndexChanged += new System.EventHandler(this.QuestionList_SelectedIndexChanged);
            // 
            // editButton
            // 
            this.editButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.editButton.Location = new System.Drawing.Point(449, 168);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(101, 29);
            this.editButton.TabIndex = 25;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // deleteQuestionButton
            // 
            this.deleteQuestionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteQuestionButton.Location = new System.Drawing.Point(449, 276);
            this.deleteQuestionButton.Name = "deleteQuestionButton";
            this.deleteQuestionButton.Size = new System.Drawing.Size(101, 38);
            this.deleteQuestionButton.TabIndex = 24;
            this.deleteQuestionButton.Text = "Delete";
            this.deleteQuestionButton.UseVisualStyleBackColor = true;
            this.deleteQuestionButton.Click += new System.EventHandler(this.DeleteQuestionButton_Click);
            // 
            // addButton
            // 
            this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addButton.Location = new System.Drawing.Point(449, 133);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(101, 29);
            this.addButton.TabIndex = 23;
            this.addButton.Text = "Add new";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // questionTextBox
            // 
            this.questionTextBox.Location = new System.Drawing.Point(79, 134);
            this.questionTextBox.Name = "questionTextBox";
            this.questionTextBox.Size = new System.Drawing.Size(364, 63);
            this.questionTextBox.TabIndex = 26;
            this.questionTextBox.Text = "\n";
            this.questionTextBox.TextChanged += new System.EventHandler(this.QuestionTextBox_TextChanged);
            // 
            // labelWarningError
            // 
            this.labelWarningError.AutoSize = true;
            this.labelWarningError.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWarningError.ForeColor = System.Drawing.SystemColors.InfoText;
            this.labelWarningError.Location = new System.Drawing.Point(94, 108);
            this.labelWarningError.Name = "labelWarningError";
            this.labelWarningError.Size = new System.Drawing.Size(123, 17);
            this.labelWarningError.TabIndex = 27;
            this.labelWarningError.Text = "labelWarningError";
            // 
            // info
            // 
            this.info.AutoSize = true;
            this.info.Location = new System.Drawing.Point(241, 82);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(51, 20);
            this.info.TabIndex = 28;
            this.info.Text = "label3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label3.Location = new System.Drawing.Point(94, 212);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 17);
            this.label3.TabIndex = 29;
            this.label3.Text = "All recipients: ";
            // 
            // SendForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 544);
            this.Controls.Add(this.questionTextBox);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.deleteQuestionButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.questionList);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelWarningError);
            this.Controls.Add(this.info);
            this.Controls.Add(this.allReceivers);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(705, 600);
            this.Name = "SendForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SendForm";
            this.Load += new System.EventHandler(this.SendForm_Load);
            this.SizeChanged += new System.EventHandler(this.SendForm_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label allReceivers;
        private System.Windows.Forms.ListBox questionList;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button deleteQuestionButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.RichTextBox questionTextBox;
        private System.Windows.Forms.Label labelWarningError;
        private System.Windows.Forms.Label info;
        private System.Windows.Forms.Label label3;
    }
}