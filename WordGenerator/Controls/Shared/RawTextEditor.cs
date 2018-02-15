using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DataStructures;

namespace WordGenerator.Controls
{
    public partial class RawTextEditor : UserControl
    {
        private RawText currentRawText;

        public RawText CurrentRawText
        {
            get { return currentRawText; }
        }


        public event EventHandler copyDuration;



        public RawText getSelectedRawText()
        {
            return currentRawText;
        }

		private List<Variable> variables;

		//REO 10/2008
		//how much the Open File Container box expands when "load from file" is selected
		private static readonly Size fileControlBoxOpenDelta = new Size(0, 27);
		//this is how much the file container box is actually expanded
		private int fileControlOffsetY = 0;
		//here we keep track of the state of the file container box
		private bool fileControlBoxOpen = false;

        /// <summary>
        /// This event gets raised whenever the raw text object wants its associated field to be updated.
        /// </summary>
        public event EventHandler updateField;

        public void updateGUI(Object sender, EventArgs e)
        {
            if (updateField != null)
                updateField(sender, e);
            this.Invalidate();
        }

        public void clearUpdateFieldEventHandler()
        {
            updateField = null;
        }

        public RawTextEditor()
        {
            InitializeComponent();
        }


        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
				if (currentRawText != null)
					currentRawText.RawTextName = nameTextBox.Text;
                updateGUI(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Caught exception when trying to change rawtext name: " + ex.Message);
            }
        }



        public void setRawText(RawText rawtext)
        {
			this.currentRawText = rawtext;
            layoutNewRawText();

        }

        private void layoutNewRawText()
        {
            if (currentRawText != null)
            {
                this.Enabled = true;
                nameTextBox.Text = currentRawText.RawTextName;
            }
            else
            {
                nameTextBox.Text = "";
                this.Enabled = false;
            }

            layOutParameters();
        }

        public void layOutParameters()
        {

            this.SuspendLayout();

            this.ResumeLayout();
        }

        /// <summary>
        /// REO 10/2008
        /// </summary>
        private void enableLoadFileControls()
        {
            fileLoadCheckBox.Enabled = true;
            fileLoadCheckBox.Checked = currentRawText.DataFromFile;

			if (currentRawText.DataFromFile)
            {
                showLoadFileControls();
            }
        }

        //REO 10/2008
        private void showLoadFileControls()
        {
            if (!fileControlBoxOpen)
            {
                fileLoadGroupBox.Size += fileControlBoxOpenDelta;
                fileControlBoxOpen = true;
                fileControlOffsetY += fileControlBoxOpenDelta.Height;
            }
            fileBrowseButton.Visible = true;
            fileBrowseButton.Enabled = true;
            fileLoadButton.Visible = true;
            fileLoadButton.Enabled = true;
            filePathTextBox.Enabled = true;
            filePathTextBox.Visible = true;
			filePathTextBox.Text = currentRawText.DataFileName;

        }

        //REO 10/2008
        private void disableLoadFileControls()
        {
            hideLoadFileControls();
            fileLoadCheckBox.Enabled = false;
            fileLoadCheckBox.Checked = false;
        }

        //REO 10/2008
        private void hideLoadFileControls()
        {
            if (this.fileControlBoxOpen)
            {
                fileLoadGroupBox.Size -= fileControlBoxOpenDelta;
                fileControlBoxOpen = false;
                fileControlOffsetY -= fileControlBoxOpenDelta.Height;
            }
            fileBrowseButton.Visible = false;
            fileBrowseButton.Enabled = false;
            fileLoadButton.Visible = false;
            fileLoadButton.Enabled = false;
            filePathTextBox.Enabled = false;
            filePathTextBox.Visible = false;
            filePathTextBox.Text = null;
        }



        public void setVariables(List<Variable> variables)
        {
            this.variables = variables;
        }

        //REO 10/2008
        private void fileBrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Select Rawtext File";
            fdlg.Filter = "All files (*.*)|*.*";
            fdlg.FilterIndex = 1;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                filePathTextBox.Text = fdlg.FileName;
            }
        }

        //REO 10/2008
        private void fileLoadCheckBox_Click(object sender, EventArgs e)
        {
            currentRawText.DataFromFile = fileLoadCheckBox.Checked;

            layOutParameters();
        }

        //REO 10/2008
        private void fileLoadButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader(filePathTextBox.Text))
                {
					// TODO 2017.07.05 BR: Load file contents into RawText object
                    updateField(this, null);
                }
            }
            catch (Exception ex)
            {
                // Let the user know what went wrong.
                MessageBox.Show("The file could not be read:\n" + ex.Message);
            }
        }


        
    }
}
