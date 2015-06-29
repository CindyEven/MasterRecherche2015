using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationCode
{
    class EmotionRecognition
    {
        private Module3 form_module3;
        private volatile bool _shouldStop;

        public string captureDeviceName = null;
        public string moduleName = "FCT Emotion Recognition";

        private string[] EmotionLabels = { "ANGER", "CONTEMPT", "DISGUST", "FEAR", "JOY", "SADNESS", "SURPRISE" };
        private string[] SentimentLabels = { "NEGATIVE", "POSITIVE", "NEUTRAL" };
        private string[] myEmotionLabels = { "pAngry", "pHappy", "pSad" };

        public int NUM_EMOTIONS = 10;
        public int NUM_PRIMARY_EMOTIONS = 7;

        public bool warningNumFaces = false;
        public bool warningNoFaceDetected = false;

        public EmotionRecognition(Module3 form)
        {
            this.form_module3 = form;
            SelectCaptureDevice();
        }

        private void SelectCaptureDevice()
        {
            PXCMSession session;
            pxcmStatus sts = PXCMSession.CreateInstance(out session);
            if (sts < pxcmStatus.PXCM_STATUS_NO_ERROR)
            {
                Console.WriteLine("Failed to create an SDK session");
                return;
            }

            PXCMSession.ImplDesc desc = new PXCMSession.ImplDesc();
            desc.group = PXCMSession.ImplGroup.IMPL_GROUP_SENSOR;
            desc.subgroup = PXCMSession.ImplSubgroup.IMPL_SUBGROUP_VIDEO_CAPTURE;
            for (uint i = 0; ; i++)
            {
                PXCMSession.ImplDesc desc1;
                if (session.QueryImpl(ref desc, i, out desc1) < pxcmStatus.PXCM_STATUS_NO_ERROR) break;
                PXCMCapture capture;
                if (session.CreateImpl<PXCMCapture>(ref desc1, PXCMCapture.CUID, out capture) < pxcmStatus.PXCM_STATUS_NO_ERROR) continue;
                for (uint j = 0; ; j++)
                {
                    PXCMCapture.DeviceInfo dinfo;
                    if (capture.QueryDevice(j, out dinfo) < pxcmStatus.PXCM_STATUS_NO_ERROR) break;
                    captureDeviceName = dinfo.name.get();
                }
                capture.Dispose();
            }
            session.Dispose();
        }


        public void RunEmotionRecognition()
        {
            PXCMSession session;
            pxcmStatus sts = PXCMSession.CreateInstance(out session);
            if (sts < pxcmStatus.PXCM_STATUS_NO_ERROR)
            {
                Console.WriteLine("Failed to create an SDK session");
                return;
            }

            // Set Module //
            PXCMSession.ImplDesc desc = new PXCMSession.ImplDesc();
            desc.friendlyName.set(moduleName);

            PXCMEmotion emotionDet;
            sts = session.CreateImpl<PXCMEmotion>(ref desc, PXCMEmotion.CUID, out emotionDet);
            if (sts < pxcmStatus.PXCM_STATUS_NO_ERROR)
            {
                Console.WriteLine("Failed to create the emotionDet module");
                session.Dispose();
                return;
            }

            UtilMCapture capture = null;
            capture = new UtilMCapture(session);
            capture.SetFilter(captureDeviceName);

            Console.WriteLine("Pair moudle with I/O");
            for (uint i = 0; ; i++)
            {
                PXCMEmotion.ProfileInfo pinfo;
                sts = emotionDet.QueryProfile(i, out pinfo);
                if (sts < pxcmStatus.PXCM_STATUS_NO_ERROR) break;
                sts = capture.LocateStreams(ref pinfo.inputs);
                if (sts < pxcmStatus.PXCM_STATUS_NO_ERROR) continue;
                sts = emotionDet.SetProfile(ref pinfo);
                if (sts >= pxcmStatus.PXCM_STATUS_NO_ERROR) break;
            }
            if (sts < pxcmStatus.PXCM_STATUS_NO_ERROR)
            {
                Console.WriteLine("Failed to pair the emotionDet module with I/O");
                capture.Dispose();
                emotionDet.Dispose();
                session.Dispose();
                return;
            }

            Console.WriteLine("Streaming");
            PXCMImage[] images = new PXCMImage[PXCMCapture.VideoStream.STREAM_LIMIT];
            PXCMScheduler.SyncPoint[] sps = new PXCMScheduler.SyncPoint[2];
            while (!_shouldStop)
            {
                PXCMImage.Dispose(images);
                PXCMScheduler.SyncPoint.Dispose(sps);
                sts = capture.ReadStreamAsync(images, out sps[0]);
                if (sts < pxcmStatus.PXCM_STATUS_NO_ERROR) break;

                sts = emotionDet.ProcessImageAsync(images, out sps[1]);
                if (sts < pxcmStatus.PXCM_STATUS_NO_ERROR) break;

                PXCMScheduler.SyncPoint.SynchronizeEx(sps);
                sts = sps[0].Synchronize();
                if (sts < pxcmStatus.PXCM_STATUS_NO_ERROR) break;

                // Display Results //
                GetEmoData(emotionDet);
                Thread.Sleep(500);
            }
            PXCMImage.Dispose(images);
            PXCMScheduler.SyncPoint.Dispose(sps);

            capture.Dispose();
            emotionDet.Dispose();
            session.Dispose();
            Console.WriteLine("Stopped");
        }

        private void GetEmoData(PXCMEmotion ft)
        {
            uint numFaces = ft.QueryNumFaces();
            if (numFaces == 0) warningNoFaceDetected = true;
            else if (numFaces > 1) warningNumFaces = true;
            else
            {
                warningNumFaces = false;
                warningNoFaceDetected = false;
            }
            PXCMEmotion.EmotionData[] arrData = new PXCMEmotion.EmotionData[NUM_EMOTIONS];
            if (ft.QueryAllEmotionData(0, arrData) >= pxcmStatus.PXCM_STATUS_NO_ERROR)
            {
                //ProcessEmoData(arrData); // Original Function
                ProcessMyEmoData(AdaptData(arrData));
            }
        }

        public PXCMEmotion.EmotionData[] AdaptData(PXCMEmotion.EmotionData[] _arrData){
            PXCMEmotion.EmotionData[] new_arrData = new PXCMEmotion.EmotionData[3];
            new_arrData[0] = _arrData[0]; // anger
            new_arrData[1] = _arrData[4]; // joy
            new_arrData[2] = _arrData[5]; // sadness
            return new_arrData;
        }

        public void ProcessMyEmoData(PXCMEmotion.EmotionData[] data)
        {
            lock (this)
            {
                int epidx = -1; int maxscoreE = -3; float maxscoreI = 0;
                for (int i = 0; i < data.Length; i++)
                {
                    if (data[i].evidence < maxscoreE) continue;
                    if (data[i].intensity < maxscoreI) continue;
                    maxscoreE = data[i].evidence;
                    maxscoreI = data[i].intensity;
                    epidx = i;
                }
                if ((epidx != -1) && (maxscoreI > 0.4))
                {
                    form_module3.patientEmotion = myEmotionLabels[epidx];
                }
                else
                {
                    form_module3.patientEmotion = "pNeutral";
                }
            }
        }

        /* Original Function : */
        /*
        public void ProcessEmoData(PXCMEmotion.EmotionData[] data)
        {
            lock (this)
            {
                bool emotionPresent = false;
                int epidx = -1; int maxscoreE = -3; float maxscoreI = 0;
                for (int i = 0; i < NUM_PRIMARY_EMOTIONS; i++)
                {
                    if (data[i].evidence < maxscoreE) continue;
                    if (data[i].intensity < maxscoreI) continue;
                    maxscoreE = data[i].evidence;
                    maxscoreI = data[i].intensity;
                    epidx = i;
                }
                if ((epidx != -1) && (maxscoreI > 0.4))
                {
                    form_module3.patientEmotion = EmotionLabels[epidx];
                    Console.Write("Emotion : " + form_module3.patientEmotion + "\n");
                    emotionPresent = true;
                }

                int spidx = -1;
                if (emotionPresent)
                {
                    maxscoreE = -3; maxscoreI = 0;
                    for (int i = 0; i < (NUM_EMOTIONS - NUM_PRIMARY_EMOTIONS); i++)
                    {
                        if (data[NUM_PRIMARY_EMOTIONS + i].evidence < maxscoreE) continue;
                        if (data[NUM_PRIMARY_EMOTIONS + i].intensity < maxscoreI) continue;
                        maxscoreE = data[NUM_PRIMARY_EMOTIONS + i].evidence;
                        maxscoreI = data[NUM_PRIMARY_EMOTIONS + i].intensity;
                        spidx = i;
                    }
                    if ((spidx != -1))
                    {
                        // We don't use the Sentiment in out case so we don't need that//
                        //form_module3.patientSentiment = SentimentLabels[spidx];
                        //Console.Write("Sentiment : " + form_module3.patientSentiment + "\n");
                    }
                }
            }
        }*/

        internal void RequestStop()
        {
            _shouldStop = true;
        }
    }
}
