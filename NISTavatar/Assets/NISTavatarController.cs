using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Threading.Tasks;
using EyeTrackingAPI;

public class NISTavatarController : MonoBehaviour

{
    //change these in the editor- not here!
    public List<Sprite> leftSide = new List<Sprite>(); //This is the list of all of your pictures you'll be using in the left side -- in trial order
    public List<Sprite> leftFeedback = new List<Sprite>();
    public List<Sprite> rightSide = new List<Sprite>(); //This is the list of all of your pictures you'll be using in the right side -- in trial order
    public List<Sprite> rightFeedback = new List<Sprite>();

    public Image leftFeedbackImage;
    public Image rightFeedbackImage;
    public Image leftImage; //Drag your left-image object here
    public Image rightImage; //Drag your right-image object here
    public GameObject leftImageGO; //Drag your left-image object here
    public GameObject rightImageGO; //Drag your right-image object here
    public GameObject leftFeedbackImageGO;
    public GameObject rightFeedbackImageGO;
    public GameObject nextRoundGO;
    public EyeTracker eyeTracker;

    private List<string> results = new List<string>(); //This is a list of all the choices your user made.

    private int trialNum = 0;
    private int cursor = 0; //This keeps track of what trial your user is on.  Remember arrays start counting at 0; and so do we now.

    // Start is called before the first frame update
    void Start()
    {
        leftImageGO.SetActive(true);
        rightImageGO.SetActive(true);
        leftFeedbackImageGO.SetActive(false);
        rightFeedbackImageGO.SetActive(false);
        nextRoundGO.SetActive(false);


        leftImage.sprite = leftSide[cursor]; //set the left side to the first face
        rightImage.sprite = rightSide[cursor]; //set the right side to the first face
        leftFeedbackImage.sprite = leftFeedback[cursor];
        rightFeedbackImage.sprite = rightFeedback[cursor];

        var gameObject = new GameObject("EyeTracker");
        gameObject.AddComponent<EyeTracker>();
        eyeTracker = gameObject.GetComponent<EyeTracker>();
        //ENABLE the eye tracker (ONLY if on a computer SMI is installed on, otherwise it will crash your script)
        eyeTracker.enabled = false; //set to false by default so it doesn't crash your script on your laptop.
  
        StartCoroutine(trialRun()); //Start running out trial
    }

    // Update is called once per frame
    void Update()
    {

    }

    //This is a coroutine; it will run parallel to our scene!  Doing this lets us do things like having pauses!
    IEnumerator trialRun()
    {

        string sysTime = System.DateTime.Now.ToString("hhmm"); //time variable (hours and minutes) and how it will show up in the file name
        string sysDate = System.DateTime.Now.ToString("ddMM_"); //day variable (day and month) and how it will show up in the file name
        eyeTracker.setFilePath("C:\\NISTavatar\\EyeTrackingdata\\" + sysDate + sysTime + "\\");
        eyeTracker.setFileName(sysDate + sysTime);
        bool running = true; //is the test running?
        while (running) //this loops until we say it is finished
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow)) //when they push down Left Arrow (Don't use GetKey!  Always GetKeyDown or GetKeyUp.)
            {
                trialNum++;
                //append the trial number if you're doing multiple trials, otherwise leave as 1.
                eyeTracker.setTrialNumber(trialNum);
                //start recording
                eyeTracker.startRecording();
                
                //Turn on the dot, turn off the pictures
                leftImageGO.SetActive(false);
                rightImageGO.SetActive(false);
                leftFeedbackImageGO.SetActive(false);
                rightFeedbackImageGO.SetActive(false);
                nextRoundGO.SetActive(false);
                yield return new WaitForSeconds(1);

                leftImageGO.SetActive(false);
                rightImageGO.SetActive(false);
                leftFeedbackImageGO.SetActive(true);
                rightFeedbackImageGO.SetActive(false);
                nextRoundGO.SetActive(false);
                yield return new WaitForSeconds(2);

                leftImageGO.SetActive(false);
                rightImageGO.SetActive(false);
                leftFeedbackImageGO.SetActive(false);
                rightFeedbackImageGO.SetActive(false);
                nextRoundGO.SetActive(false);
                yield return new WaitForSeconds(1.5f);

                leftImageGO.SetActive(false);
                rightImageGO.SetActive(false);
                leftFeedbackImageGO.SetActive(false);
                rightFeedbackImageGO.SetActive(false);
                nextRoundGO.SetActive(true);
                yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

                eyeTracker.stopRecording();


                cursor++; // same as cursor = cursor + 1;  It tells us to move to the next trial
                if (cursor >= leftSide.Count) //checks if we completed all of the trials!
                {
                    running = false; //we're done!
                    nextRoundGO.SetActive(false);
                    Debug.Log("Player chose left"); //Debugs are primarily for testing, they're a good way to know what happened actually happened.  Abuse these freely to help find bugs or keep track
                    results.Add("Left"); //they chose left; put it in our results.
                }
                else //there's more to go, set up our pictures for the new trial
                {
                    leftImageGO.SetActive(true);
                    rightImageGO.SetActive(true);
                    leftFeedbackImageGO.SetActive(false);
                    rightFeedbackImageGO.SetActive(false);
                    nextRoundGO.SetActive(false);


                    Debug.Log("Player chose left"); //Debugs are primarily for testing, they're a good way to know what happened actually happened.  Abuse these freely to help find bugs or keep track
                    results.Add("Left"); //they chose left; put it in our results.

                    leftImage.sprite = leftSide[cursor];
                    rightImage.sprite = rightSide[cursor];
                    leftFeedbackImage.sprite = leftFeedback[cursor];
                    rightFeedbackImage.sprite = rightFeedback[cursor];

                }
            } //end of the ifLeftKey



            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                trialNum++;
                //append the trial number if you're doing multiple trials, otherwise leave as 1.
                eyeTracker.setTrialNumber(trialNum);
                //start recording
                eyeTracker.startRecording();
     
                leftImageGO.SetActive(false);
                rightImageGO.SetActive(false);
                leftFeedbackImageGO.SetActive(false);
                rightFeedbackImageGO.SetActive(false);
                nextRoundGO.SetActive(false);
                yield return new WaitForSeconds(1);

                leftImageGO.SetActive(false);
                rightImageGO.SetActive(false);
                leftFeedbackImageGO.SetActive(false);
                rightFeedbackImageGO.SetActive(true);
                nextRoundGO.SetActive(false);
                yield return new WaitForSeconds(2);

                leftImageGO.SetActive(false);
                rightImageGO.SetActive(false);
                leftFeedbackImageGO.SetActive(false);
                rightFeedbackImageGO.SetActive(false);
                nextRoundGO.SetActive(false);
                yield return new WaitForSeconds(1.5f);

                leftImageGO.SetActive(false);
                rightImageGO.SetActive(false);
                leftFeedbackImageGO.SetActive(false);
                rightFeedbackImageGO.SetActive(false);
                nextRoundGO.SetActive(true);
                yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

                eyeTracker.stopRecording();

                cursor++; // same as cursor = cursor + 1;  It tells us to move to the next trial
                if (cursor >= rightSide.Count) //checks if we completed all of the trials!
                {
                    running = false; //we're done!
                    nextRoundGO.SetActive(false);
                    Debug.Log("Player chose right");
                    results.Add("Right");
                }
                else //there's more to go, set up our pictures for the new trial
                {
                    leftImageGO.SetActive(true);
                    rightImageGO.SetActive(true);
                    leftFeedbackImageGO.SetActive(false);
                    rightFeedbackImageGO.SetActive(false);
                    nextRoundGO.SetActive(false);


                    Debug.Log("Player chose right");
                    results.Add("Right");

                    leftImage.sprite = leftSide[cursor];
                    rightImage.sprite = rightSide[cursor];
                    leftFeedbackImage.sprite = leftFeedback[cursor];
                    rightFeedbackImage.sprite = rightFeedback[cursor];


                }
            } //end of the ifRightKey
            
            yield return null;
        }     //end of the while loop


        //The trial is finished; for testing sake, let's print out all the results.
        int trial = 1; //this is just readability.
        foreach (string sidePicked in results) //for every result we have...
        {
            Debug.Log("Trial" + trial + sidePicked); //print out what we chose.
            trial++;
        }


        string docPath = @"C:\NISTavatar\LRdata\"; //assign the location that we want the file saved
        if (!Directory.Exists(docPath))
        {
            Directory.CreateDirectory(docPath);
        }
        sysTime = System.DateTime.Now.ToString("hh.mm"); //time variable (hours and minutes) and how it will show up in the file name
        sysDate = System.DateTime.Now.ToString("dd.MM_"); //day variable (day and month) and how it will show up in the file name
        
        try                                                              //combine the document path with the file name and write in the results
        {
            File.WriteAllLines(Path.Combine(docPath, "NISTavatar_LR" + sysDate + sysTime + ".txt"), results);
        }

        catch (Exception e)
        {
            Debug.Log(e, this);
        }
    }
}
        
       
