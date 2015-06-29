using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace ApplicationCode
{
    // TeLLer is Singleton
    public class TeLLer
    {
        private static TeLLer instance;

        private TeLLer() { }

        public static TeLLer Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TeLLer();
                }
                return instance;
            }
        }

        private Process pTeLLer;
        private StreamWriter tellerStreamWriter;
        private string path = Application.StartupPath + "\\Resources";
        private Module3 form;

        List<string> agentChoices = new List<string>();
        public Queue tellerQ = new Queue();

        public void StartTeLLer(Module3 _form)
        {
            this.form = _form;
            try
            {
                int cp = CultureInfo.CurrentCulture.TextInfo.OEMCodePage;
                pTeLLer = new Process();
                pTeLLer.StartInfo.FileName = path+"\\TeLLer\\dist\\build\\TeLLer\\TeLLer.exe";
                pTeLLer.StartInfo.UseShellExecute = false;
                pTeLLer.StartInfo.RedirectStandardOutput = true;
                pTeLLer.OutputDataReceived += new DataReceivedEventHandler(TeLLerOutputHandler);
                pTeLLer.StartInfo.RedirectStandardInput = true;
                pTeLLer.StartInfo.CreateNoWindow = true;
                pTeLLer.StartInfo.StandardOutputEncoding = Encoding.GetEncoding(cp);  // Need it to be able to use french accents
                pTeLLer.Start();
                tellerStreamWriter = pTeLLer.StandardInput;
                pTeLLer.BeginOutputReadLine();
                // TeLLer commands to load a file (l) and to start (s) :
                tellerStreamWriter.WriteLine("l " + path + @"\scenar02");
                tellerStreamWriter.WriteLine("s");
            }
            catch (Exception e) { throw new NotImplementedException(); }
        }

        private void TeLLerOutputHandler(object sender, DataReceivedEventArgs e)
        {
            Console.WriteLine("TeLLer output : "+e.Data);
            if (e.Data != null)
            {
                if (e.Data.StartsWith("Action performed") && e.Data.Contains("agent"))
                {
                    int _from = e.Data.IndexOf('/') + 2;
                    string a = e.Data.Substring(_from);
                    int pos = a.LastIndexOf('/');
                    if (pos > 0)
                    {
                        form.Play(a.Substring(0, pos), a.Substring(pos + 2));
                    }

                    /* Supposedly the CharacterSpeaking() should be working but it doesnt
                     * so instead we use a trashy solution ... : */
                    Thread.Sleep(3500);
                    //while (form.haptek.CharacterSpeaking())
                    //{
                    //    Thread.Sleep(250);
                    //}
                    TeLLerInput("");
                }

                /* Patient turn to speak : display the choices */
                if (Regex.IsMatch(e.Data, @"^\d") && e.Data.Contains("patient"))
                {
                    int _from = e.Data.IndexOf('(') + 1;
                    int _to = e.Data.LastIndexOf(')');
                    int _length = _to - _from;
                    string output = e.Data.Substring(_from, _length);
                    form.tellerChoiceList.Add(output.Substring(output.LastIndexOf("/") + 2));
                    form.Display();
                }

                /* The patient "spoke", we informe TeLLer : */
                if (e.Data.StartsWith("Action performed") && e.Data.Contains("patient"))
                {
                    TeLLerInput("");
                }

                /* If the agent has the choice between 2 actions, we select the first choice */
                if (Regex.IsMatch(e.Data, @"^\d") && e.Data.Contains("agent"))
                {
                    agentChoices.Add(e.Data);
                    // we always chose the first choice when its an action for the agent :
                    //if (e.Data.StartsWith("0")) TeLLerInput("0");
                }
                /*All the choices for the agent are listed, now we can choose one*/
                if (e.Data == "p) Print environment")
                {
                    int nbChoices = agentChoices.Count;
                    if (nbChoices > 0)
                    {
                        int rnd = new Random().Next(nbChoices);
                        TeLLerInput(rnd.ToString());
                        agentChoices.Clear();
                    }
                }

                /* Get the previous choices points */
                if (e.Data.StartsWith("[("))
                {
                    BackInTime BinT = BackInTime.Instance;
                    BinT.SortChoicePoints(e.Data);
                }

                /* If the story is finished : */
                if (e.Data.Contains("End of story"))
                {
                    form.StoryEnded();
                }
            }
        }

        public void Dequeue()
        {
            while (tellerQ.Count > 0)
            {
                Console.WriteLine(tellerQ.Dequeue());
            }
        }

        public void TeLLerInput(string input)
        {
            Console.WriteLine("TeLLer input : " + input);
            tellerStreamWriter.WriteLine(input);
        }

        public void StopTeLLer()
        {
            tellerStreamWriter.Close();
            if (!pTeLLer.HasExited) pTeLLer.Kill();
        }
    }
}
