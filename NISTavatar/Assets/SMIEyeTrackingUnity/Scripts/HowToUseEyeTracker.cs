using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EyeTrackingAPI; //STEP 1 -import the API
public class HowToUseEyeTracker : MonoBehaviour
{
    EyeTracker eyeTracker; //STEP 2 - set up the script in your variables like this;

    // Start is called before the first frame update
    void Start()
    {
        //STEP 3 - Instatiate, copy these lines in! 
        var gameObject = new GameObject("EyeTracker");
        gameObject.AddComponent<EyeTracker>();
        eyeTracker = gameObject.GetComponent<EyeTracker>();
        //END OF COPY
        //STEP 4 - ENABLE the eye tracker (ONLY if on a computer SMI is installed on, otherwise it will crash your script)
        eyeTracker.enabled = false; //set to false by default so it doesn't crash your script on your laptop.

        StartCoroutine(PretendThisIsYourCode()); //ignore me!  This is for sample purposes!
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PretendThisIsYourCode()
    {
        //STEP 5 - set the directory you want to write to
        eyeTracker.setFilePath("C:\\IST_EyeData\\MyParticipant\\");
        //STEP 6 - name your file (after your participant is fine)
        eyeTracker.setFileName("MyParticipantName");
        //STEP 7 - append the trial number if you're doing multiple trials, otherwise leave as 1.
        eyeTracker.setTrialNumber(1);
        //STEP 8 - start recording
        eyeTracker.startRecording();
        /*
         * 
         *  YOUR TRIAL HAPPENS HERE
         * 
         */
        yield return new WaitForSeconds(1); //ignore this, for demonstration purposes
        eyeTracker.stopRecording();

        //IF YOU WANT TO DO ANOTHER TRIAL AND NOT OVERWRITE
        eyeTracker.setTrialNumber(2);
        eyeTracker.startRecording();
        yield return new WaitForSeconds(1); //ignore this, for demonstration purposes
        eyeTracker.stopRecording();
        yield return null;
    }
}
