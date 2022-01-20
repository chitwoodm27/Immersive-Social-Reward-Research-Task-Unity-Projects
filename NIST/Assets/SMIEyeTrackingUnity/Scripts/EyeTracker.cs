using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Pvr_UnitySDKAPI;
using System.IO;
using SMI;


namespace EyeTrackingAPI
{
    public class EyeTracker : MonoBehaviour
    {
        public bool enabled = true;
        string filepath = "C:\\NIST\\EyeTrackingdata\\";
        string filename = "NIST_ET";
        int trialappend = 1;
        bool recording = false;
        StreamWriter VRRec, EyeRec;
        SMIEyeTrackingUnity smiInstance = null;

        void Start()
        {
            smiInstance = SMIEyeTrackingUnity.Instance;
        }

        Vector3 getrot()
        {
            return (UnityEngine.XR.InputTracking.GetLocalRotation(UnityEngine.XR.XRNode.CenterEye).eulerAngles);
        }

        Vector3 getpos()
        {
            return UnityEngine.XR.InputTracking.GetLocalPosition(UnityEngine.XR.XRNode.CenterEye);
        }

        IEnumerator record()
        {
            if (enabled)
            {
                if (!Directory.Exists(filepath))
                {
                    Directory.CreateDirectory(filepath);
                }
                VRRec = File.CreateText(filepath + filename + "_" + trialappend + "_vr.txt");
                EyeRec = File.CreateText(filepath + filename + "_" + trialappend + "_eye.txt");
                VRRec.WriteLine("Roll Pitch Yaw MS Time X Y Z");
                EyeRec.WriteLine("BinocPorX BinocPorY LeftPorX LeftPorY RightPorX RightPorY IPD LeftGazeBaseX LeftGazeBaseY LeftGazeBaseZ RightGazeBaseX RightGazeBaseY RightGazeBaseZ LPupilRadius RPupilRadius LGazeDirX LGazeDirY LGazeDirZ RGazeDirX RGazeDirY RGazeDirZ MS Time");
                while (recording)
                { 
                    float timestamp = Time.time;
                    double timestamptoa = System.DateTime.Now.ToOADate();
                    Vector3 VRRot = getrot();
                    Vector3 VRPos = getpos();
                    Vector3 GazeLeft = smiInstance.smi_GetLeftGazeBase();
                    Vector3 GazeRight = smiInstance.smi_GetRightGazeBase();


                    VRRec.WriteLine((VRRot.x + 180) % 360 + " " + (VRRot.y + 180) % 360 + " " + (VRRot.z + 180) % 360 + " " + timestamp + " " + timestamptoa + " " + VRPos.x + " " + VRPos.y + " " + VRPos.z);
                    EyeRec.WriteLine(smiInstance.smi_GetBinocularPor().x.ToString() + " " + smiInstance.smi_GetBinocularPor().y.ToString() + " "
                        + smiInstance.smi_GetLeftPor().x + " " + smiInstance.smi_GetLeftPor().y + " " + smiInstance.smi_GetRightPor().x + " " + smiInstance.smi_GetRightPor().y + " "
                        + smiInstance.smi_GetIPD().ToString() + " "
                        + GazeLeft.x.ToString() + " " + GazeLeft.y.ToString() + " " + GazeLeft.z.ToString() + " "
                        + GazeRight.x.ToString() + " " + GazeRight.y.ToString() + " " + GazeRight.z.ToString() + " "
                        + smiInstance.smi_GetLeftPupilRadius().ToString() + " " + smiInstance.smi_GetRightPupilRadius().ToString() + " "
                        + smiInstance.smi_GetLeftGazeDirection().x.ToString() + " " + smiInstance.smi_GetLeftGazeDirection().y.ToString() + " " + smiInstance.smi_GetLeftGazeDirection().z.ToString() + " "
                        + smiInstance.smi_GetRightGazeDirection().x.ToString() + " " + smiInstance.smi_GetRightGazeDirection().y.ToString() + " " + smiInstance.smi_GetRightGazeDirection().z.ToString() + " "
                        + timestamp + " " + timestamptoa);
                    yield return null;
                }
                VRRec.Close();
                EyeRec.Close();
            }
        }

        /// <summary>
        /// Begins recording the VR Head and Eye Tracking status
        /// </summary>
        public void startRecording()
        {
            recording = true;
            StartCoroutine(record());
        }

        /// <summary>
        /// Stops recording the VR Head and Eye Tracking status
        /// </summary>
        public void stopRecording()
        {
            recording = false;
        }

        /// <summary>
        /// Sets the file path, use a string of format "C:\\foldername\\"
        /// </summary>
        /// <param name="fp">The file path to use</param>
        public void setFilePath(string fp)
        {
            filepath = fp;
        }

        /// <summary>
        /// Sets the file name, use a string of format "participant_name"
        /// </summary>
        /// <param name="fn">The file name to use</param>
        public void setFileName(string fn)
        {
            filename = fn;
        }

        /// <summary>
        /// Sets the trial number to append, use a integer
        /// </summary>
        /// <param name="tn">The trial number</param>
        public void setTrialNumber(int tn)
        {
            trialappend = tn;
        }

    }
}