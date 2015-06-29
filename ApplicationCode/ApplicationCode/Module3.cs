using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplicationCode
{
    public partial class Module3 : Form
    {
        public Haptek haptek;

        public string patientEmotion = "pNeutral";

        EmotionRecognition emoRecoObject;
        Thread emoRecoThread;

        private TeLLer teller = TeLLer.Instance;
        public List<string> tellerChoiceList = new List<string>();

        //TeLLerOutputGestion tellerOutputGestionObject;
        //Thread tellerOutputGestionThread;

        public Module3()
        {
            InitializeComponent();
            haptek = new Haptek(axActiveHaptekX);
            haptek.InitScene(true);
            groupBox_Question.Visible = false;
            groupBox_Explications.Visible = true;
            groupBox_Finish.Visible = false;

            FormClosing += new FormClosingEventHandler(FormClosingEvent);
            Application.ApplicationExit += new EventHandler(this.OnApplicationExit);
        }

        /* Anime the character */
        public void Play(string text, string emo)
        {
            haptek.Emotion("neutral");  // used to initialise the character face to a neutral position
            haptek.SayText(text);
            haptek.Emotion(emo);
        }

        /* Display the list of sentences among which the user can choose */
        public void Display()
        {
            int i = 0;
            if (tellerChoiceList.Count > 0)
            {
                foreach (string choice in tellerChoiceList)
                {
                    RadioButton radioButtonA = new RadioButton();
                    radioButtonA.Text = choice;
                    radioButtonA.TabIndex = i;
                    radioButtonA.AutoSize = true;
                    radioButtonA.Location = new System.Drawing.Point(7, i * 20 + 20);
                    this.AddRadioButton(radioButtonA);
                    i++;
                    radioButtonA.CheckedChanged += new EventHandler(RadioButton_Checked);
                }
            }
        }

        delegate void AddRadioButtonCallback(RadioButton rb);
        private void AddRadioButton(RadioButton rb)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.groupBox_Question.InvokeRequired)
            {
                AddRadioButtonCallback d = new AddRadioButtonCallback(AddRadioButton);
                this.Invoke(d, new object[] { rb });
            }
            else
            {
                this.groupBox_Question.Controls.Add(rb);
            }
        }

        private void RadioButton_Checked(object sender, EventArgs e)
        {
            RadioButton radio = ((RadioButton)sender);
            if (radio.Checked)
            {
                teller.TeLLerInput("-pSad pAngry pHappy pNeutral"); // To update the patient's emotion in the env. we delete the old one
                teller.TeLLerInput("+"+patientEmotion);             // and add the new one
                teller.TeLLerInput(radio.TabIndex.ToString());
                ClearChoices();
            }
        }

        public void ClearChoices()
        {
            tellerChoiceList.Clear();
            groupBox_Question.Controls.Clear();
            groupBox_Question.Controls.Add(btn_BackInTime);
        }
        public void StoryEnded()
        {
            groupBox_Question.Invoke((MethodInvoker)(() => groupBox_Question.Visible = false));
            groupBox_Explications.Invoke((MethodInvoker)(() => groupBox_Explications.Visible = false));
            groupBox_Finish.Invoke((MethodInvoker)(() => groupBox_Finish.Visible = true));
        }

        private void btn_OK_Click(object sender, System.EventArgs e)
        {
            groupBox_Question.Visible = true;
            groupBox_Explications.Visible = false;
            groupBox_Finish.Visible = false;
            // Once the introduction is done we can start the thread & process :
            StartEmotionRecognition();
            teller.StartTeLLer(this);
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

        private void StartEmotionRecognition()
        {
            // Create the thread object. This does not start the thread.
            emoRecoObject = new EmotionRecognition(this);
            emoRecoThread = new Thread(emoRecoObject.RunEmotionRecognition);

            // Start the emoReco thread.
            emoRecoThread.Start();
            Console.WriteLine("form thread: Starting emoReco thread...");

            // Loop until emoReco thread activates.
            while (!emoRecoThread.IsAlive) ;

            // Put the form thread to sleep for 1 millisecond to
            // allow the emoReco thread to do some work:
            Thread.Sleep(1);
        }

        private void FormClosingEvent(object sender, FormClosingEventArgs e)
        {
            // Request that the emoReco thread stop itself:
            emoRecoObject.RequestStop();

            // Use the Join method to block the current thread 
            // until the object's thread terminates.
            emoRecoThread.Join();
            Console.WriteLine("form closing: emoReco thread has terminated.");

            // Request that the processus TeLLer stop itself:
            teller.StopTeLLer();
            Console.WriteLine("form closing: teller has terminated.");
        }
        private void OnApplicationExit(object sender, EventArgs e)
        {
            // Request that the emoReco thread stop itself:
            emoRecoObject.RequestStop();
            // Use the Join method to block the current thread 
            // until the object's thread terminates.
            emoRecoThread.Join();
            Console.WriteLine("appli exit : emoReco thread has terminated.");

            // Request that the processus TeLLer stop itself:
            teller.StopTeLLer();
            Console.WriteLine("appli exit: teller has terminated.");
        }

        private void btn_BackInTime_Click(object sender, EventArgs e)
        {
            teller.TeLLerInput("choicepoints");
            BackInTime BinT = BackInTime.Instance;
            BinT.Show();
            BinT.BringToFront();
        }


    }
}
