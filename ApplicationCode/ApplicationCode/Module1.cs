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
    public partial class Module1 : Form
    {
        private Haptek haptek;

        private List<string> emotionsList = new List<string>(new string[] { "aHappy", "aSad", "aAngry", "aNeutral" });
        private List<string> emotionsToDo = new List<string>();
        private string currentEmo;
        
        public Module1()
        {
            InitializeComponent();
            haptek = new Haptek(axActiveHaptekX);
            haptek.InitScene(false);
            label_feedback.Text = "";
            groupBox_Question.Visible = false;
            groupBox_Explications.Visible = true;
            groupBox_Finish.Visible = false;

            emotionsToDo = emotionsList;
        }

        private void LoadQuestion()
        {
            Random rnd = new Random();
            int id = rnd.Next(emotionsToDo.Count);
            currentEmo = emotionsToDo[id];
            haptek.Emotion("aNeutral"); 
            haptek.Emotion(currentEmo);
            emotionsToDo.Remove(currentEmo);
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
            if (emotionsToDo.Count > 0)
            {
                showFeedback(CheckAnswer());
                listBox.ClearSelected();
                currentEmo = "";
                LoadQuestion();
            }
            else
            {
                showFeedback(CheckAnswer());
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

        private bool CheckAnswer()
        {
            string answer = listBox.SelectedItem.ToString();
            if (answer == "La joie") answer = "aHappy";
            if (answer == "La tristesse") answer = "aSad";
            if (answer == "La colère") answer = "aAngry";
            if (answer == "Neutre") answer = "aNeutral";
            return answer == currentEmo;
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
