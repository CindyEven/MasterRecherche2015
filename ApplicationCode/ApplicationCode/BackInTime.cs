using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplicationCode
{
    public sealed partial class BackInTime : Form
    {
        private static volatile BackInTime instance;
        private static object syncRoot = new Object();

        public List<ChoicePoint> choicepointsSorted = new List<ChoicePoint>();
        public struct ChoicePoint
        {
            public int id;
            public string title;
            public string[] choicelist;
        }

        private TeLLer teller = TeLLer.Instance;

        public static BackInTime Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new BackInTime();
                    }
                }

                return instance;
            }
        }

        private BackInTime()
        {
            InitializeComponent();
            FormClosing += new FormClosingEventHandler(FormClosingEvent);
        }

        public void SortChoicePoints(string choicepoints)
        {
            int from = 0;
            int to = 0;
            List<string> subChoicepoints = new List<string>();
            for (int i = 0; i < choicepoints.Length; i++)
            {
                if (choicepoints[i] == '(' && (choicepoints[i - 1] == '[' || choicepoints[i - 1] == ',')) from = i + 1;
                if (choicepoints[i] == ')') to = i;
                if (from != 0 && to != 0)
                {
                    int length = to - from;
                    subChoicepoints.Add(choicepoints.Substring(from, length));
                    from = to = 0;
                }
            }
            foreach (string sub in subChoicepoints)
            {
                ChoicePoint struc = new ChoicePoint();

                struc.id = (int)Char.GetNumericValue(sub[0]);

                //struc.title = sub.Substring(3, sub.IndexOf('"', 4) - 3);
                string fullTitle = sub.Substring(3, sub.IndexOf('"', 4) - 3);
                int firstSlash = fullTitle.IndexOf('/') +2;
                int lastSlash = fullTitle.LastIndexOf('/') -1;
                int length = fullTitle.Length - firstSlash;
                if (fullTitle.IndexOf('/') != fullTitle.LastIndexOf('/'))
                {
                    length = lastSlash - firstSlash;
                }
                struc.title = fullTitle.Substring(firstSlash, length);

                string listOfChoices = sub.Substring(sub.IndexOf("\",[\"") + 4);
                listOfChoices = listOfChoices.Replace("\"]", "");
                string[] stringSeparators = new string[] { "\",\"" };
                //struc.choicelist = listOfChoices.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                string[] choices = listOfChoices.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                if (!choices[0].Contains("agent"))
                {
                    for (int i = 0; i < choices.Length; i++)
                    {
                        choices[i] = choices[i].Remove(0, 10);
                    }
                    struc.choicelist = choices;
                    choicepointsSorted.Add(struc);
                }
                
            }

            UpdatePanel();
        }

        private void UpdatePanel()
        {
            int x1 = 12;
            int y = 42;

            for (int index = 0; index < choicepointsSorted.Count; index++)
            {
                /* CheckBox for the id + title */
                CheckBox cb = new CheckBox();
                cb.AutoSize = true;
                cb.Location = new System.Drawing.Point(x1, y);
                cb.Size = new System.Drawing.Size(80, 17);
                cb.Text = choicepointsSorted[index].id.ToString() + " : " + choicepointsSorted[index].title;
                cb.UseVisualStyleBackColor = true;
                cb.Tag = choicepointsSorted[index];
                cb.CheckedChanged += new EventHandler(CheckBox_Checked);
                this.AddCheckBox(cb);
                
                y += 20;

                /* List of choices */
                ListBox listBox = new System.Windows.Forms.ListBox();
                listBox.BackColor = System.Drawing.SystemColors.ButtonFace;
                listBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
                listBox.FormattingEnabled = true;
                listBox.Items.AddRange(choicepointsSorted[index].choicelist);
                listBox.Location = new System.Drawing.Point(13, y);
                listBox.Size = new System.Drawing.Size(408, 15 * choicepointsSorted[index].choicelist.Length);
                listBox.SelectionMode = SelectionMode.None;
                this.AddListBox(listBox);

                y += 15 * choicepointsSorted[index].choicelist.Length + 10;
            }
        }

        private void CheckBox_Checked(object sender, EventArgs e)
        {
            Module3 module3 = Application.OpenForms.OfType<Module3>().FirstOrDefault();
            module3.ClearChoices();

            CheckBox cb = (CheckBox)sender;
            ChoicePoint cp = (ChoicePoint)cb.Tag;
            teller.TeLLerInput("goto " + cp.id.ToString());
            this.Hide();
            // Delete the choices from last time
            choicepointsSorted.Clear();
            this.Invoke((MethodInvoker)(() => this.Controls.Clear()));
            this.Invoke((MethodInvoker)(() => this.Controls.Add(label3)));
        }

        // If the user close the form, this one is disposed and we can't show it anymore, //
        // we don't want that so instead we just hide it //
        private void FormClosingEvent(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                this.Controls.Clear();
                this.Controls.Add(label3);
                this.Hide();
                e.Cancel = true;
            }
        }

        delegate void AddCheckBoxCallback(CheckBox cb);
        private void AddCheckBox(CheckBox cb)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.InvokeRequired)
            {
                AddCheckBoxCallback d = new AddCheckBoxCallback(AddCheckBox);
                this.Invoke(d, new object[] { cb });
            }
            else
            {
                this.Controls.Add(cb);
            }
        }

        delegate void AddListBoxCallback(ListBox lb);
        private void AddListBox(ListBox lb)
        {
            if (this.InvokeRequired)
            {
                AddListBoxCallback d = new AddListBoxCallback(AddListBox);
                this.Invoke(d, new object[] { lb });
            }
            else
            {
                this.Controls.Add(lb);
            }
        }
    }
}
