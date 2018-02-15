using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DataStructures;

namespace WordGenerator.Controls
{

    /// <summary>
    /// The RawText UI Widget, which allows us to create a text input specially for raw text inputting 
    /// </summary>
    public class RawTextField : UserControl
    {
        private System.Windows.Forms.Label channelLabel;
		private System.Windows.Forms.TextBox textField;
		private bool editable;

		private RawTextEditor rawTextEditor;

       
        /// <summary>
        /// This event gets raised if the raw text field gets clicked on. It is meant to be caught by the raw text collection.
        /// </summary>
        public event EventHandler gotClicked;


		private static readonly int g_control_size = 248;

        

        public RawTextField()
        {
            // Copied, with adaptations, from old WaveformGraph.Designer InitializeComponent
            #region InitializeComponent

			this.channelLabel = new Label();
			this.textField = new TextBox();

			// 
			// channelLabel
			// 
			this.channelLabel.AutoSize = true;
			this.channelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.channelLabel.Location = new System.Drawing.Point(0, 0);
			this.channelLabel.Name = "channelLabel";
			this.channelLabel.Size = new System.Drawing.Size(104, 20);
			this.channelLabel.TabIndex = 2;
			this.channelLabel.Text = "";
			this.channelLabel.Click += new EventHandler(clicked);
			// 
			// textField
			// 
			this.textField.AutoSize = true;
			this.textField.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textField.Location = new System.Drawing.Point(0, 20);
			this.textField.Name = "textField";
			this.textField.Multiline = true;
			this.textField.ScrollBars = ScrollBars.Vertical;
			this.textField.AcceptsReturn = true;
			this.textField.AcceptsTab = true;
			this.textField.WordWrap = true;
			this.textField.Size = new System.Drawing.Size(g_control_size, g_control_size-20);
			this.textField.TabIndex = 3;
			this.textField.Text = "";
			this.textField.MouseClick += new MouseEventHandler(clicked);
			this.textField.GotFocus += new EventHandler(clicked);
			this.textField.TextChanged += new EventHandler(textField_TextChanged);

			// 
			// RawTextField
			// 
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.channelLabel);
			this.Controls.Add(this.textField);
			this.Name = "RawTextField";
			this.Size = new System.Drawing.Size(g_control_size, g_control_size);
			this.Click += new EventHandler(clicked);
			this.ResumeLayout(false);
			this.PerformLayout();

            #endregion
            
        }

        public RawTextField(RawText rawtext, RawTextEditor rawTextEditor, bool rawtextEditable)
            : this()
        {
            setRawText(rawtext);
			setRawTextEditor(rawTextEditor);
			this.editable = rawtextEditable;
        }

        public void Activate()
        {
            if (editable)
            {
                this.BackColor = Color.Tan;
                this.channelLabel.BackColor = Color.Tomato;
            }
        }

        public void Deactivate()
        {
            if (editable)
            {
                this.BackColor = Color.White;
                this.channelLabel.BackColor = Color.White;
            }
        }

        void clicked(object sender, EventArgs e)
        {
            if (gotClicked != null)
            {
                gotClicked(sender, e);
            }
        }

        private RawText rawText;

        public void setRawText(RawText rawtext)
        {
			this.rawText = rawtext;
			this.updateField(this, null);
        }

        public RawText getRawText()
        {
			return this.rawText;
        }

		public void setRawTextEditor(RawTextEditor rawTextEditor)
		{
			this.rawTextEditor = rawTextEditor;
		}

        public void setChannelName(string channelName) {
            this.channelLabel.Text = channelName;
        }


        public void updateField(Object sender, EventArgs e) {
			if (rawText != null)
			{
				this.channelLabel.Text = rawText.RawTextName;
				this.textField.Text = rawText.RawTextValue;
			}
			else
			{
				this.channelLabel.Text = "";
				this.textField.Text = "";
			}
            
            this.Refresh();
        }

		private void textField_TextChanged(object sender, EventArgs e)
		{
			try
			{
				if (rawText != null)
					rawText.RawTextValue = textField.Text;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Caught exception when trying to change the rawtext value: " + ex.Message);
			}
		}
    }
}
