namespace WordGenerator.Controls
{
	partial class RawTextEditor
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.fileLoadCheckBox = new System.Windows.Forms.CheckBox();
            this.filePathTextBox = new System.Windows.Forms.TextBox();
            this.fileBrowseButton = new System.Windows.Forms.Button();
            this.fileLoadButton = new System.Windows.Forms.Button();
            this.fileLoadGroupBox = new System.Windows.Forms.GroupBox();
            this.fileLoadGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(15, 3);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(38, 13);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Name:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(81, 0);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(150, 20);
            this.nameTextBox.TabIndex = 1;
            this.nameTextBox.TextChanged += new System.EventHandler(this.nameTextBox_TextChanged);

            // 
            // fileLoadCheckBox
            // 
            this.fileLoadCheckBox.AutoSize = true;
            this.fileLoadCheckBox.Enabled = false;
            this.fileLoadCheckBox.Location = new System.Drawing.Point(6, 15);
            this.fileLoadCheckBox.Name = "fileLoadCheckBox";
            this.fileLoadCheckBox.Size = new System.Drawing.Size(95, 17);
            this.fileLoadCheckBox.TabIndex = 16;
            this.fileLoadCheckBox.Text = "Load From File";
            this.fileLoadCheckBox.UseVisualStyleBackColor = true;
            this.fileLoadCheckBox.Click += new System.EventHandler(this.fileLoadCheckBox_Click);
            // 
            // filePathTextBox
            // 
            this.filePathTextBox.Enabled = false;
            this.filePathTextBox.Location = new System.Drawing.Point(67, 38);
            this.filePathTextBox.Name = "filePathTextBox";
            this.filePathTextBox.Size = new System.Drawing.Size(141, 20);
            this.filePathTextBox.TabIndex = 17;
            this.filePathTextBox.Visible = false;
            // 
            // fileBrowseButton
            // 
            this.fileBrowseButton.Enabled = false;
            this.fileBrowseButton.Location = new System.Drawing.Point(6, 38);
            this.fileBrowseButton.Name = "fileBrowseButton";
            this.fileBrowseButton.Size = new System.Drawing.Size(57, 20);
            this.fileBrowseButton.TabIndex = 18;
            this.fileBrowseButton.Text = "Browse";
            this.fileBrowseButton.UseVisualStyleBackColor = true;
            this.fileBrowseButton.Visible = false;
            this.fileBrowseButton.Click += new System.EventHandler(this.fileBrowseButton_Click);
            // 
            // fileLoadButton
            // 
            this.fileLoadButton.Enabled = false;
            this.fileLoadButton.Location = new System.Drawing.Point(107, 12);
            this.fileLoadButton.Name = "fileLoadButton";
            this.fileLoadButton.Size = new System.Drawing.Size(96, 20);
            this.fileLoadButton.TabIndex = 19;
            this.fileLoadButton.Text = "Load";
            this.fileLoadButton.UseVisualStyleBackColor = true;
            this.fileLoadButton.Visible = false;
            this.fileLoadButton.Click += new System.EventHandler(this.fileLoadButton_Click);
            // 
            // fileLoadGroupBox
            // 
            this.fileLoadGroupBox.Controls.Add(this.fileLoadCheckBox);
            this.fileLoadGroupBox.Controls.Add(this.fileLoadButton);
            this.fileLoadGroupBox.Controls.Add(this.fileBrowseButton);
            this.fileLoadGroupBox.Controls.Add(this.filePathTextBox);
            this.fileLoadGroupBox.Location = new System.Drawing.Point(24, 20);
            this.fileLoadGroupBox.Name = "fileLoadGroupBox";
            this.fileLoadGroupBox.Size = new System.Drawing.Size(217, 39);
            this.fileLoadGroupBox.TabIndex = 20;
            this.fileLoadGroupBox.TabStop = false;
            // 
            // RawTextEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.fileLoadGroupBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.nameLabel);
            this.Name = "RawTextEditor";
            this.Size = new System.Drawing.Size(269, 790);
            this.fileLoadGroupBox.ResumeLayout(false);
            this.fileLoadGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.CheckBox fileLoadCheckBox;
        private System.Windows.Forms.TextBox filePathTextBox;
        private System.Windows.Forms.Button fileBrowseButton;
        private System.Windows.Forms.Button fileLoadButton;
        private System.Windows.Forms.GroupBox fileLoadGroupBox;
    }
}
