using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataStructures;

namespace WordGenerator.Controls
{
    public partial class VariablePreviewEditorForm : Form
    {
        private List<VariablePreviewEditor> eds;

        public VariablePreviewEditorForm()
        {
            InitializeComponent();
        }

        public VariablePreviewEditorForm(List<Variable> variables) : this()
        {
            eds = new List<VariablePreviewEditor>();

			// 2017.10.12 BR: Sort the variables in the preview form
			List<Variable> SortedList = variables.OrderBy(o => o.VariableName).ToList();
			foreach (Variable var in SortedList)
            {
                VariablePreviewEditor ed = new VariablePreviewEditor(var);
                eds.Add(ed);
                this.variablePreviewEditorPanel.Controls.Add(ed);
            }
        }

        /// <summary>
        /// Returns the number of variable values that changed.
        /// </summary>
        /// <param name="sequence"></param>
        /// <returns></returns>
        public int refresh(SequenceData sequence)
        {
            Func<int> refreshFunc = () =>
            {
                int ans = 0;
                foreach (VariablePreviewEditor ed in eds)
                {
                    if (ed.refresh())
                        ans++;
                }

                // Force the sequence to re-calculate all equation based derived variables, with this
                // line of code that ends up calling setIterationNumber in sequence data
                sequence.ListIterationNumber = sequence.ListIterationNumber;


                foreach (VariablePreviewEditor ed in eds)
                {
                    ed.refresh();
                }

                return ans;
            };

            return (int) Invoke(refreshFunc);
        }
    }
}
