using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplicationCode
{
    public class Haptek
    {
        private string path = Application.StartupPath + "\\Resources";
        public AxACTIVEHAPTEKXLib.AxActiveHaptekX haptekPlayer;

        public Haptek(AxACTIVEHAPTEKXLib.AxActiveHaptekX _haptekPlayer)
        {
            this.haptekPlayer = _haptekPlayer;
        }
        public void InitScene(bool animated)
        {
            haptekPlayer.HyperText = @"\LoadBackGrnd[ file= [" + path + @"\back_degrade.jpg]]"; // load background
            if(animated) haptekPlayer.HyperText = @"\load[file=[" + path + @"\Lola_animated.htr]]";   // load character animated
            else haptekPlayer.HyperText = @"\load[file=[" + path + @"\Lola_motionless.haptar]]"; // load character not animated
            haptekPlayer.HyperText = @"\Translate[x= 0 y=-5 z=0]";                                   // place character
            haptekPlayer.HyperText = @"\Rotate[y= 10]";
        }

        public void InitScene(string characterName)
        {
            haptekPlayer.HyperText = @"\LoadBackGrnd[ file= [" + path + @"\back_degrade.jpg]]"; // load background
            //haptekPlayer.HyperText = @"\load[file=[" + path + @"\Lola_animated.htr]]";   // load character animated
            haptekPlayer.HyperText = @"\load[file=[" + path + @"\"+characterName+"_motionless.haptar]]"; // load character not animated
            haptekPlayer.HyperText = @"\Translate[x= 0 y=-5 z=0]";                                   // place character
            haptekPlayer.HyperText = @"\Rotate[y= 10]";
        }

        public void DeleteCharacter()
        {
            haptekPlayer.Query = "current figurename";
            string currentFigure = haptekPlayer.QueryReturn;
            haptekPlayer.HyperText = @"\DelPerson[figure= " + currentFigure + " i0= 1]";
        }

        public void SayText(string text)
        {
            haptekPlayer.HyperText = @"\Q2[s0= [" + text + "]]";
        }

        public bool CharacterSpeaking()
        {
            haptekPlayer.Query = "status tts busy";
            if (haptekPlayer.QueryReturn == "0") return false;
            else return true;
        }

        public void EmotionUP(string emo, int intensity)
        {
            HapFACS.HapFACSEmotion emFACS = new HapFACS.HapFACSEmotion();
            if (emo == "aHappy")
            {
                haptekPlayer.HyperText = emFACS.Happiness(intensity.ToString(), (intensity-10).ToString());
            }
            else if (emo == "aSad")
            {
                haptekPlayer.HyperText = emFACS.Sadness(intensity.ToString(), (intensity - 10).ToString());
            }
            else if (emo == "aAngry")
            {
                haptekPlayer.HyperText = emFACS.Anger(intensity.ToString(), (intensity - 10).ToString());
            }
            else
            {
                haptekPlayer.HyperText = emFACS.Neutral();
            }
        }

        public void EmotionDOWN(string emo, int intensity)
        {
            HapFACS.HapFACSEmotion emFACS = new HapFACS.HapFACSEmotion();
            if (emo == "aHappy")
            {
                haptekPlayer.HyperText = emFACS.Happiness(intensity.ToString(), (intensity+10).ToString());
            }
            else if (emo == "aSad")
            {
                haptekPlayer.HyperText = emFACS.Sadness(intensity.ToString(), (intensity + 10).ToString());
            }
            else if (emo == "aAngry")
            {
                haptekPlayer.HyperText = emFACS.Anger(intensity.ToString(), (intensity + 10).ToString());
            }
            else
            {
                haptekPlayer.HyperText = emFACS.Neutral();
            }
        }
        // for the module 1 we dont need to go increasingly
        public void Emotion(string emo)
        {
            HapFACS.HapFACSEmotion emFACS = new HapFACS.HapFACSEmotion();
            if (emo == "aHappy")
            {
                haptekPlayer.HyperText = emFACS.Happiness("75", "0");
            }
            else if (emo == "aSad")
            {
                haptekPlayer.HyperText = emFACS.Sadness("75", "0");
            }
            else if (emo == "aAngry")
            {
                haptekPlayer.HyperText = emFACS.Anger("75", "0");
            }
            else
            {
                haptekPlayer.HyperText = emFACS.Neutral();
            }

        }
    }
}
