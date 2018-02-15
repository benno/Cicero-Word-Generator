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
    public partial class RawTextCollection : UserControl
    {
        private List<RawTextField> rawTextFields;

		private RawTextEditor rawTextEditor;

		public bool updateAllFieldsEachTime = false;


		public RawTextCollection()
        {
            InitializeComponent();
            this.AutoScroll = true;
            this.VScroll = true;
            rawTextFields = new List<RawTextField>();
            rawTextEditor = new RawTextEditor();
        }

        public void redrawAllFields()
        {
            try
            {
				foreach (RawTextField gr in rawTextFields)
                {
                    gr.updateField(this, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Caught exception when attempting to redraw rawtext field collection " + ex.Message);
            }
        }

        public void setRawTextEditor(RawTextEditor rawTextEditor)
        {
			this.rawTextEditor = rawTextEditor;
			foreach (RawTextField rtf in rawTextFields)
            {
                rtf.setRawTextEditor(rawTextEditor);
            }
        }

        public void deactivateAllFields()
        {
            this.SuspendLayout();
            foreach (RawTextField rtf in rawTextFields)
            {
				rtf.Deactivate();
            }
            this.ResumeLayout();
        }

        public void setChannelNames(List<string> channelNames)
        {
			for (int i = 0; i < rawTextFields.Count; i++)
            {
				rawTextFields[i].setChannelName(channelNames[i]);
            }
        }

        public void setRawTexts(List<RawText> rawtexts)
        {
            this.setRawTexts(rawtexts, null);
        }

        public void setRawTexts(List<RawText> rawtexts, List<bool> rawTextsEditable) 
        {
            bool allEditable = false;
			if (rawTextsEditable == null)
            {
                allEditable = true;
            }

            this.SuspendLayout();
            if (WordGenerator.MainClientForm.instance!=null)
                WordGenerator.MainClientForm.instance.cursorWait();
            try
            {
                List<RawTextField> fieldsToAdd = new List<RawTextField>();

                if (rawTextFields != null)
                {
					foreach (RawTextField rtf in rawTextFields)
                    {
                        this.flowLayoutPanel1.Controls.Remove(rtf);
                        rtf.Dispose();
                    }
                }

				rawTextFields.Clear();
                if (rawtexts == null || rawtexts.Count == 0)
                {
                    if (WordGenerator.MainClientForm.instance != null)
                        WordGenerator.MainClientForm.instance.cursorWaitRelease();
                    return;
                }

                for (int i = 0; i < rawtexts.Count; i++)
                {
                    bool editable;
                    if (allEditable)
                    {
                        editable = true;
                    }
                    else
                    {
						editable = rawTextsEditable[i];
                    }

                    rawTextFields.Add(new RawTextField(rawtexts[i], rawTextEditor, editable));
					rawTextFields[i].Deactivate();
					rawTextFields[i].Visible = true;
					rawTextFields[i].gotClicked += new EventHandler(RawTextFieldCollection_gotClicked);
                }

                this.flowLayoutPanel1.Controls.AddRange(rawTextFields.ToArray());

                this.setRawTextEditor(rawTextEditor);

                this.ResumeLayout();



                this.Refresh();
            }
            finally
            {
                if (WordGenerator.MainClientForm.instance!=null)
                    WordGenerator.MainClientForm.instance.cursorWaitRelease();
            }

        }

		void RawTextFieldCollection_gotClicked(object sender, EventArgs e)
        {
            if (WordGenerator.MainClientForm.instance != null)
                WordGenerator.MainClientForm.instance.cursorWait();
            try
            {
                RawTextField rtf = sender as RawTextField;
                if (rtf == null)
                {
                    WordGenerator.MainClientForm.instance.cursorWaitRelease();
                    return;
                }

                if (!rawTextFields.Contains(rtf))
                {
                    WordGenerator.MainClientForm.instance.cursorWaitRelease();
                    return;
                }

                foreach (RawTextField field in rawTextFields)
                    field.Deactivate();

                rtf.Activate();
                //rawTextEditor.clearUpdateFieldEventHandler();
                if (!updateAllFieldsEachTime)
                    rawTextEditor.updateField += rtf.updateField;
                else
                    foreach (RawTextField field in rawTextFields)
                        rawTextEditor.updateField += field.updateField;

				rawTextEditor.setRawText(rtf.getRawText());
            }
            finally
            {
                if (WordGenerator.MainClientForm.instance != null)
                    WordGenerator.MainClientForm.instance.cursorWaitRelease();
            }
        }




        private Point computeRawTextFieldLocation(int i)
        {
			int number = this.Size.Width/250;
            int x = (i % number) * 250;
            int y = (int)(i / number) * 250;
            return new Point(x, y);
        }

    }
}
