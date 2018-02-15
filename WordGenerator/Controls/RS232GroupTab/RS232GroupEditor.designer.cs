namespace WordGenerator.Controls.Temporary
{
    partial class RS232GroupEditor
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
			this.groupChannelSelectorPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.newGroupButton = new System.Windows.Forms.Button();
			this.rs232GroupSelector = new System.Windows.Forms.ComboBox();
			this.renameTextBox = new System.Windows.Forms.TextBox();
			this.renameButton = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.descBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.plus = new System.Windows.Forms.Button();
			this.minus = new System.Windows.Forms.Button();
			this.runOrderPanel = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.replacementGroupSelector = new System.Windows.Forms.ComboBox();
			this.replaceGroupButton = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.Editor1 = new WordGenerator.Controls.RawTextEditor();
			this.Collection1 = new WordGenerator.Controls.RawTextCollection();
			this.runOrderPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupChannelSelectorPanel
			// 
			this.groupChannelSelectorPanel.AutoScroll = true;
			this.groupChannelSelectorPanel.Location = new System.Drawing.Point(3, 313);
			this.groupChannelSelectorPanel.Name = "groupChannelSelectorPanel";
			this.groupChannelSelectorPanel.Size = new System.Drawing.Size(244, 477);
			this.groupChannelSelectorPanel.TabIndex = 0;
			// 
			// newGroupButton
			// 
			this.newGroupButton.Location = new System.Drawing.Point(3, 56);
			this.newGroupButton.Name = "newGroupButton";
			this.newGroupButton.Size = new System.Drawing.Size(110, 26);
			this.newGroupButton.TabIndex = 3;
			this.newGroupButton.Text = "Create New Group";
			this.newGroupButton.UseVisualStyleBackColor = true;
			this.newGroupButton.Click += new System.EventHandler(this.button1_Click);
			// 
			// rs232GroupSelector
			// 
			this.rs232GroupSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.rs232GroupSelector.FormattingEnabled = true;
			this.rs232GroupSelector.Location = new System.Drawing.Point(3, 3);
			this.rs232GroupSelector.Name = "rs232GroupSelector";
			this.rs232GroupSelector.Size = new System.Drawing.Size(110, 21);
			this.rs232GroupSelector.TabIndex = 6;
			this.rs232GroupSelector.DropDown += new System.EventHandler(this.comboBox1_DropDown);
			this.rs232GroupSelector.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			this.rs232GroupSelector.DropDownClosed += new System.EventHandler(this.rs232GroupSelector_DropDownClosed);
			// 
			// renameTextBox
			// 
			this.renameTextBox.Location = new System.Drawing.Point(3, 30);
			this.renameTextBox.Name = "renameTextBox";
			this.renameTextBox.Size = new System.Drawing.Size(92, 20);
			this.renameTextBox.TabIndex = 7;
			this.renameTextBox.TextChanged += new System.EventHandler(this.renameTextBox_TextChanged);
			// 
			// renameButton
			// 
			this.renameButton.Location = new System.Drawing.Point(101, 29);
			this.renameButton.Name = "renameButton";
			this.renameButton.Size = new System.Drawing.Size(66, 21);
			this.renameButton.TabIndex = 8;
			this.renameButton.Text = "Rename";
			this.renameButton.UseVisualStyleBackColor = true;
			this.renameButton.Click += new System.EventHandler(this.renameButton_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(3, 88);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(110, 27);
			this.button1.TabIndex = 9;
			this.button1.Text = "Delete This Group";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click_1);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(3, 121);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(110, 27);
			this.button2.TabIndex = 10;
			this.button2.Text = "Output Now";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// descBox
			// 
			this.descBox.Location = new System.Drawing.Point(3, 177);
			this.descBox.Multiline = true;
			this.descBox.Name = "descBox";
			this.descBox.Size = new System.Drawing.Size(164, 110);
			this.descBox.TabIndex = 11;
			this.descBox.TextChanged += new System.EventHandler(this.descBox_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 161);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(63, 13);
			this.label1.TabIndex = 12;
			this.label1.Text = "Description:";
			// 
			// plus
			// 
			this.plus.Location = new System.Drawing.Point(119, 3);
			this.plus.Name = "plus";
			this.plus.Size = new System.Drawing.Size(22, 22);
			this.plus.TabIndex = 13;
			this.plus.Text = "+";
			this.plus.UseVisualStyleBackColor = true;
			this.plus.Click += new System.EventHandler(this.plus_Click);
			// 
			// minus
			// 
			this.minus.Location = new System.Drawing.Point(147, 3);
			this.minus.Name = "minus";
			this.minus.Size = new System.Drawing.Size(22, 22);
			this.minus.TabIndex = 14;
			this.minus.Text = "-";
			this.minus.UseVisualStyleBackColor = true;
			this.minus.Click += new System.EventHandler(this.minus_Click);
			// 
			// runOrderPanel
			// 
			this.runOrderPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.runOrderPanel.AutoScroll = true;
			this.runOrderPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.runOrderPanel.Controls.Add(this.label3);
			this.runOrderPanel.Controls.Add(this.label2);
			this.runOrderPanel.Location = new System.Drawing.Point(6, 796);
			this.runOrderPanel.Name = "runOrderPanel";
			this.runOrderPanel.Size = new System.Drawing.Size(1234, 73);
			this.runOrderPanel.TabIndex = 19;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(2, 28);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(118, 13);
			this.label3.TabIndex = 1;
			this.label3.Text = "(click to be transported)";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(127, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "RS232 Group Run Order:";
			// 
			// replacementGroupSelector
			// 
			this.replacementGroupSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.replacementGroupSelector.Enabled = false;
			this.replacementGroupSelector.FormattingEnabled = true;
			this.replacementGroupSelector.Location = new System.Drawing.Point(101, 289);
			this.replacementGroupSelector.MaxDropDownItems = 100;
			this.replacementGroupSelector.Name = "replacementGroupSelector";
			this.replacementGroupSelector.Size = new System.Drawing.Size(122, 21);
			this.replacementGroupSelector.TabIndex = 22;
			this.replacementGroupSelector.DropDown += new System.EventHandler(this.replacementSelector_DropDown_1);
			this.replacementGroupSelector.SelectedValueChanged += new System.EventHandler(this.replacementGroupSelector_SelectedValueChanged);
			// 
			// replaceGroupButton
			// 
			this.replaceGroupButton.Enabled = false;
			this.replaceGroupButton.Location = new System.Drawing.Point(3, 289);
			this.replaceGroupButton.Name = "replaceGroupButton";
			this.replaceGroupButton.Size = new System.Drawing.Size(92, 22);
			this.replaceGroupButton.TabIndex = 21;
			this.replaceGroupButton.Text = "Replace Group";
			this.replaceGroupButton.UseVisualStyleBackColor = true;
			this.replaceGroupButton.Click += new System.EventHandler(this.replaceGroupButton_Click);
			// 
			// button3
			// 
			this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button3.Location = new System.Drawing.Point(119, 56);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(76, 34);
			this.button3.TabIndex = 23;
			this.button3.Text = "Delete Unused Groups";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// Editor1
			// 
			this.Editor1.AutoScroll = true;
			this.Editor1.Enabled = false;
			this.Editor1.Location = new System.Drawing.Point(253, 0);
			this.Editor1.Name = "Editor1";
			this.Editor1.Size = new System.Drawing.Size(248, 790);
			this.Editor1.TabIndex = 2;
			// 
			// Collection1
			// 
			this.Collection1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.Collection1.AutoScroll = true;
			this.Collection1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Collection1.Location = new System.Drawing.Point(507, 1);
			this.Collection1.Name = "Collection1";
			this.Collection1.Size = new System.Drawing.Size(899, 789);
			this.Collection1.TabIndex = 1;
			// 
			// RS232GroupEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.button3);
			this.Controls.Add(this.replacementGroupSelector);
			this.Controls.Add(this.replaceGroupButton);
			this.Controls.Add(this.runOrderPanel);
			this.Controls.Add(this.minus);
			this.Controls.Add(this.plus);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.descBox);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.renameButton);
			this.Controls.Add(this.renameTextBox);
			this.Controls.Add(this.rs232GroupSelector);
			this.Controls.Add(this.newGroupButton);
			this.Controls.Add(this.Editor1);
			this.Controls.Add(this.Collection1);
			this.Controls.Add(this.groupChannelSelectorPanel);
			this.Name = "RS232GroupEditor";
			this.Size = new System.Drawing.Size(1409, 918);
			this.VisibleChanged += new System.EventHandler(this.RS232GroupEditor_VisibleChanged);
			this.runOrderPanel.ResumeLayout(false);
			this.runOrderPanel.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.FlowLayoutPanel groupChannelSelectorPanel;
		// For waveforms
		//private WordGenerator.Controls.WaveformGraphCollection Collection1;
		//private WordGenerator.Controls.WaveformEditor Editor1;
		// For rawtexts
		private WordGenerator.Controls.RawTextCollection Collection1;
		private WordGenerator.Controls.RawTextEditor Editor1;
        private System.Windows.Forms.Button newGroupButton;
        private System.Windows.Forms.ComboBox rs232GroupSelector;
        private System.Windows.Forms.TextBox renameTextBox;
        private System.Windows.Forms.Button renameButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox descBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button plus;
        private System.Windows.Forms.Button minus;
        private System.Windows.Forms.Panel runOrderPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox replacementGroupSelector;
        private System.Windows.Forms.Button replaceGroupButton;
        private System.Windows.Forms.Button button3;

    }
}
