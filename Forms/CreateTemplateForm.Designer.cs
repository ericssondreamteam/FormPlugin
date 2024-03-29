﻿namespace FormPlugin.Forms
{
    partial class CreateTemplateForm
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon"))); this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.chooseTemplateLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.warningLabelName = new System.Windows.Forms.Label();
            this.warningLabelEmpty = new System.Windows.Forms.Label();
            this.browseButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.questionList = new System.Windows.Forms.ListBox();
            this.deleteQuestionButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.questionTextBox = new System.Windows.Forms.RichTextBox();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.upButton = new System.Windows.Forms.PictureBox();
            this.downButton = new System.Windows.Forms.PictureBox();
            this.styleButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.upButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.downButton)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Create Template",
            "Edit Template"});
            this.comboBox1.Location = new System.Drawing.Point(16, 18);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(219, 28);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // chooseTemplateLabel
            // 
            this.chooseTemplateLabel.AutoSize = true;
            this.chooseTemplateLabel.Location = new System.Drawing.Point(348, 21);
            this.chooseTemplateLabel.Name = "chooseTemplateLabel";
            this.chooseTemplateLabel.Size = new System.Drawing.Size(142, 20);
            this.chooseTemplateLabel.TabIndex = 1;
            this.chooseTemplateLabel.Text = "Choose Template: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(284, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Write question and press \"Add\" button.";
            // 
            // addButton
            // 
            this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addButton.Location = new System.Drawing.Point(643, 104);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(101, 30);
            this.addButton.TabIndex = 5;
            this.addButton.Text = "Add new";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(643, 461);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(101, 32);
            this.saveButton.TabIndex = 6;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 468);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Template Name: ";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.textBox2.Location = new System.Drawing.Point(137, 466);
            this.textBox2.MaximumSize = new System.Drawing.Size(10000, 10000);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(500, 26);
            this.textBox2.TabIndex = 8;
            this.textBox2.TextChanged += new System.EventHandler(this.TextBox2_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Yours question:";
            // 
            // warningLabelName
            // 
            this.warningLabelName.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.warningLabelName.AutoSize = true;
            this.warningLabelName.ForeColor = System.Drawing.Color.Red;
            this.warningLabelName.Location = new System.Drawing.Point(163, 443);
            this.warningLabelName.Margin = new System.Windows.Forms.Padding(0);
            this.warningLabelName.Name = "warningLabelName";
            this.warningLabelName.Size = new System.Drawing.Size(0, 20);
            this.warningLabelName.TabIndex = 14;
            // 
            // warningLabelEmpty
            // 
            this.warningLabelEmpty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.warningLabelEmpty.AutoSize = true;
            this.warningLabelEmpty.ForeColor = System.Drawing.Color.Red;
            this.warningLabelEmpty.Location = new System.Drawing.Point(141, 195);
            this.warningLabelEmpty.Name = "warningLabelEmpty";
            this.warningLabelEmpty.Size = new System.Drawing.Size(0, 20);
            this.warningLabelEmpty.TabIndex = 15;
            this.warningLabelEmpty.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(489, 16);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(101, 30);
            this.browseButton.TabIndex = 17;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(348, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "witam";
            // 
            // questionList
            // 
            this.questionList.FormattingEnabled = true;
            this.questionList.ItemHeight = 20;
            this.questionList.Location = new System.Drawing.Point(16, 218);
            this.questionList.Name = "questionList";
            this.questionList.Size = new System.Drawing.Size(621, 204);
            this.questionList.TabIndex = 19;
            this.questionList.SelectedIndexChanged += new System.EventHandler(this.QuestionList_SelectedIndexChanged);
            // 
            // deleteQuestionButton
            // 
            this.deleteQuestionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteQuestionButton.Location = new System.Drawing.Point(643, 371);
            this.deleteQuestionButton.Name = "deleteQuestionButton";
            this.deleteQuestionButton.Size = new System.Drawing.Size(101, 30);
            this.deleteQuestionButton.TabIndex = 19;
            this.deleteQuestionButton.Text = "Delete";
            this.deleteQuestionButton.UseVisualStyleBackColor = true;
            this.deleteQuestionButton.Click += new System.EventHandler(this.DeleteQuestionButton_Click);
            // 
            // editButton
            // 
            this.editButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.editButton.Location = new System.Drawing.Point(643, 144);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(101, 30);
            this.editButton.TabIndex = 22;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // questionTextBox
            // 
            this.questionTextBox.Location = new System.Drawing.Point(16, 104);
            this.questionTextBox.Name = "questionTextBox";
            this.questionTextBox.Size = new System.Drawing.Size(621, 70);
            this.questionTextBox.TabIndex = 23;
            this.questionTextBox.Text = "\n";
            this.questionTextBox.TextChanged += new System.EventHandler(this.QuestionTextBox_TextChanged);
            // 
            // fontDialog1
            // 
            this.fontDialog1.Apply += new System.EventHandler(this.FontDialog1_Apply);
            // 
            // upButton
            // 
            this.upButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.upButton.Image = ((System.Drawing.Image)(resources.GetObject("upButton.Image")));
            this.upButton.InitialImage = ((System.Drawing.Image)(resources.GetObject("upButton.InitialImage")));
            this.upButton.Location = new System.Drawing.Point(664, 247);
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(60, 56);
            this.upButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.upButton.TabIndex = 25;
            this.upButton.TabStop = false;
            this.upButton.Click += new System.EventHandler(this.UpButton_Click);
            this.upButton.MouseHover += new System.EventHandler(this.UpButton_MouseHover);
            // 
            // downButton
            // 
            this.downButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.downButton.Image = ((System.Drawing.Image)(resources.GetObject("downButton.Image")));
            this.downButton.InitialImage = ((System.Drawing.Image)(resources.GetObject("downButton.InitialImage")));
            this.downButton.Location = new System.Drawing.Point(664, 309);
            this.downButton.Name = "downButton";
            this.downButton.Size = new System.Drawing.Size(60, 56);
            this.downButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.downButton.TabIndex = 26;
            this.downButton.TabStop = false;
            this.downButton.Click += new System.EventHandler(this.DownButton_Click);
            // 
            // styleButton
            // 
            this.styleButton.Location = new System.Drawing.Point(643, 18);
            this.styleButton.Name = "styleButton";
            this.styleButton.Size = new System.Drawing.Size(101, 30);
            this.styleButton.TabIndex = 27;
            this.styleButton.Text = "Styles";
            this.styleButton.UseVisualStyleBackColor = true;
            this.styleButton.Click += new System.EventHandler(this.StyleButton_Click);
            // 
            // CreateTemplateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 534);
            this.Controls.Add(this.styleButton);
            this.Controls.Add(this.downButton);
            this.Controls.Add(this.upButton);
            this.Controls.Add(this.questionTextBox);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.questionList);
            this.Controls.Add(this.deleteQuestionButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chooseTemplateLabel);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.warningLabelName);
            this.Controls.Add(this.warningLabelEmpty);
            this.MinimumSize = new System.Drawing.Size(855, 590);
            this.Name = "CreateTemplateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create or Edit";
            this.SizeChanged += new System.EventHandler(this.ResizeEvent);
            ((System.ComponentModel.ISupportInitialize)(this.upButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.downButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label chooseTemplateLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label warningLabelName;
        private System.Windows.Forms.Label warningLabelEmpty;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox questionList;
        private System.Windows.Forms.Button deleteQuestionButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.RichTextBox questionTextBox;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.PictureBox upButton;
        private System.Windows.Forms.PictureBox downButton;
        private System.Windows.Forms.Button styleButton;
    }
}