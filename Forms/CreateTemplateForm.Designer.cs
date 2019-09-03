namespace FormPlugin.Forms
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.chooseTemplateLabel = new System.Windows.Forms.Label();
            this.chooseTemplateBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.questionTextBox = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.questionList = new System.Windows.Forms.ListView();
            this.warningLabelName = new System.Windows.Forms.Label();
            this.warningLabelEmpty = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Create Template",
            "Edit Template"});
            this.comboBox1.Location = new System.Drawing.Point(13, 13);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(219, 28);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // chooseTemplateLabel
            // 
            this.chooseTemplateLabel.AutoSize = true;
            this.chooseTemplateLabel.Location = new System.Drawing.Point(254, 21);
            this.chooseTemplateLabel.Name = "chooseTemplateLabel";
            this.chooseTemplateLabel.Size = new System.Drawing.Size(142, 20);
            this.chooseTemplateLabel.TabIndex = 1;
            this.chooseTemplateLabel.Text = "Choose Template: ";
            // 
            // chooseTemplateBox
            // 
            this.chooseTemplateBox.FormattingEnabled = true;
            this.chooseTemplateBox.Location = new System.Drawing.Point(427, 12);
            this.chooseTemplateBox.Name = "chooseTemplateBox";
            this.chooseTemplateBox.Size = new System.Drawing.Size(210, 28);
            this.chooseTemplateBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(284, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Write question and press \"Add\" button.";
            // 
            // questionTextBox
            // 
            this.questionTextBox.Location = new System.Drawing.Point(16, 104);
            this.questionTextBox.Multiline = true;
            this.questionTextBox.Name = "questionTextBox";
            this.questionTextBox.Size = new System.Drawing.Size(621, 137);
            this.questionTextBox.TabIndex = 4;
            // 
            // addButton
            // 
            this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addButton.Location = new System.Drawing.Point(737, 185);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(101, 56);
            this.addButton.TabIndex = 5;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(737, 488);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(101, 58);
            this.saveButton.TabIndex = 6;
            this.saveButton.Text = "Save Template";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 521);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Template Name: ";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.textBox2.Location = new System.Drawing.Point(173, 518);
            this.textBox2.MaximumSize = new System.Drawing.Size(10000, 10000);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(464, 26);
            this.textBox2.TabIndex = 8;
            this.textBox2.TextChanged += new System.EventHandler(this.TextBox2_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 254);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Yours question:";
            // 
            // questionList
            // 
            this.questionList.Location = new System.Drawing.Point(16, 286);
            this.questionList.Name = "questionList";
            this.questionList.Size = new System.Drawing.Size(621, 193);
            this.questionList.TabIndex = 13;
            this.questionList.UseCompatibleStateImageBehavior = false;
            // 
            // warningLabelName
            // 
            this.warningLabelName.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.warningLabelName.AutoSize = true;
            this.warningLabelName.ForeColor = System.Drawing.Color.Red;
            this.warningLabelName.Location = new System.Drawing.Point(363, 492);
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
            this.warningLabelEmpty.Location = new System.Drawing.Point(733, 400);
            this.warningLabelEmpty.Name = "warningLabelEmpty";
            this.warningLabelEmpty.Size = new System.Drawing.Size(0, 20);
            this.warningLabelEmpty.TabIndex = 15;
            this.warningLabelEmpty.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // CreateTemplateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 558);
            this.Controls.Add(this.warningLabelEmpty);
            this.Controls.Add(this.warningLabelName);
            this.Controls.Add(this.questionList);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.questionTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chooseTemplateBox);
            this.Controls.Add(this.chooseTemplateLabel);
            this.Controls.Add(this.comboBox1);
            this.MinimumSize = new System.Drawing.Size(875, 614);
            this.Name = "CreateTemplateForm";
            this.Text = "Create or Edit Template";
            this.SizeChanged += new System.EventHandler(this.ResizeEvent);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label chooseTemplateLabel;
        private System.Windows.Forms.ComboBox chooseTemplateBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox questionTextBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListView questionList;
        private System.Windows.Forms.Label warningLabelName;
        private System.Windows.Forms.Label warningLabelEmpty;
    }
}