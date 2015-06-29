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
    public partial class Module2 : Form
    {
        private Haptek haptek;

        private string[] dialoglines;
        private List<string[]> dialoglinessplited = new List<string[]>();
        private int i = 0;

        public Module2()
        {
            InitializeComponent();
            haptek = new Haptek(axActiveHaptekX);
            haptek.InitScene(true);
            label_feedback.Text = "";
            groupBox_Question.Visible = false;
            groupBox_Explications.Visible = true;
            groupBox_Finish.Visible = false;

            dialoglines = System.IO.File.ReadAllLines(Application.StartupPath + "\\Resources" + @"\scenarModule2.txt");
            foreach (string line in dialoglines)
            {
                dialoglinessplited.Add(line.Split('/'));
            }
        }

        private void btn_OK_Click(object sender, System.EventArgs e)
        {
            groupBox_Question.Visible = true;
            groupBox_Explications.Visible = false;
            groupBox_Finish.Visible = false;
            LoadQuestion();
        }

        private void btn_valider_Click(object sender, System.EventArgs e)
        {
            showFeedback(CheckAnswer());
            listBox.ClearSelected();
            i++;
            if (i < dialoglinessplited.Count)
            {
                LoadQuestion();
            }
            else
            {
                Delayed(2500, () => groupBox_Question.Visible = false);
                Delayed(2500, () => groupBox_Explications.Visible = false);
                Delayed(2500, () => groupBox_Finish.Visible = true);
            }
        }

        private void btn_finish_Click(object sender, System.EventArgs e)
        {
            Menu menu = Application.OpenForms.OfType<Menu>().FirstOrDefault();
            if (menu == null)
            {
                menu = new Menu();
                menu.Show();
            }
            this.Close();
        }

        private void LoadQuestion()
        {
            btn_valider.Enabled = true;
            patientAnswer.Text = "";
            if (dialoglinessplited[i][0] == "A")  // If it's the agent turn to talk 
            {
                haptek.Emotion("neutral");
                haptek.SayText(dialoglinessplited[i][1]);
                haptek.Emotion(dialoglinessplited[i][2]);
                
            }
            else // If it's the patient turn to talk
            {
                btn_valider.Enabled = false;
                patientAnswer.Text = dialoglinessplited[i][1];
                i++;
                Delayed(3000, () => LoadQuestion());
            }
        }

        private bool CheckAnswer()
        {
            string answer = listBox.SelectedItem.ToString();
            if (answer == "La joie") answer = "aHappy";
            if (answer == "La tristesse") answer = "aSad";
            if (answer == "La colère") answer = "aAngry";
            if (answer == "Neutre") answer = "aNeutral";
            return answer == dialoglinessplited[i][2];
        }

        private void showFeedback(bool repOK)
        {
            if (repOK)
            {
                label_feedback.Text = "Bonne réponse !";
                Delayed(2500, () => label_feedback.Text = "");
            }
            else
            {
                label_feedback.Text = "Mauvaise réponse.";
                Delayed(2500, () => label_feedback.Text = "");
            }
        }

        public void Delayed(int delay, Action action)
        {
            Timer timer = new Timer();
            timer.Interval = delay;
            timer.Tick += (s, e) =>
            {
                action();
                timer.Stop();
            };
            timer.Start();
        }
    }
}
