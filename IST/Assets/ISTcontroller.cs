using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using EyeTrackingAPI;

public class ISTcontroller: MonoBehaviour
{
    public GameObject[] trials; //fill this out in editor with drag and drop
    private List<string> results = new List<string>();
    private int curTrial = 0;
    public int spacePressed = 1;
    public List<PlayableDirector> playableDirectors;
    public GameObject[] Bios;
    public GameObject[] LeftAvatar;
    public GameObject[] RightAvatar;
    EyeTracker eyeTracker;


    void Start()
    {
        var gameObject = new GameObject("EyeTracker");
        gameObject.AddComponent<EyeTracker>();
        eyeTracker = gameObject.GetComponent<EyeTracker>();
        //ENABLE the eye tracker (ONLY if on a computer SMI is installed on, otherwise it will crash your script)
        eyeTracker.enabled = false; //set to false by default so it doesn't crash your script on your laptop.


        StartCoroutine(trialRun());

    }
    void Update()
    {
    }
    IEnumerator trialRun()
    {
        spacePressed = 0;
        Bios[curTrial].SetActive(true);
        LeftAvatar[curTrial].SetActive(false);
        RightAvatar[curTrial].SetActive(false);

        foreach (GameObject x in trials) x.SetActive(false); //turn off all Trials.
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space)); //space to start the trial
        while (curTrial <= trials.Length - 1) //run until we completed all trials
        {
            trials[curTrial].SetActive(true); //activate current trial
            LeftAvatar[curTrial].SetActive(false); //left avatar is OFF
            RightAvatar[curTrial].SetActive(false);//right avatar is OFF
            yield return new WaitForSeconds(0.1f); //need this so it doesn't crash
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space)); //space to start the trial 
            {

                if (spacePressed == 1) // space 1 stuff - gets ready to go to next trial and goes to the next trial
                {
                    {
                        LeftAvatar[curTrial].SetActive(false); //shuts off current avatars trials
                        RightAvatar[curTrial].SetActive(false); //shuts off current avatars trials
                        trials[curTrial].SetActive(false);  //deactivate current trial
                        curTrial++; //move to next trial then loop and activate it right away.
                        Bios[curTrial].SetActive(true); // turns bios on at beginning of trial
                    }
                spacePressed = 0; // this allows us to use space to be used for a different function (0 is used for bringing avatars into the room and 1 is used for switching trials)
                }
                else // this code is for bringing avatars into the room when space pressed = 0
                {
                    {
                        LeftAvatar[curTrial].SetActive(false); // turns avatars off while participants read bio
                        RightAvatar[curTrial].SetActive(false); // turns avatars off while participants read bio

                        StartCoroutine(myDelay()); //starts coroutine
                    }
                    IEnumerator myDelay() //timer for bios to disappear as avatars enter room - the reason for this is to allow the participant to associate the avatars face to their bio
                    {
                        string sysTime = System.DateTime.Now.ToString("hhmm"); //time variable (hours and minutes) and how it will show up in the file name
                        string sysDate = System.DateTime.Now.ToString("ddMM_"); //day variable (day and month) and how it will show up in the file name
                        eyeTracker.setFilePath("C:\\IST\\EyeTrackingdata\\" + sysDate + sysTime + "\\");
                        eyeTracker.setFileName(sysDate + sysTime);
                        eyeTracker.setTrialNumber(curTrial);
                        //start recording
                        eyeTracker.startRecording();

                        playableDirectors[curTrial].Play(); //plays the timeline that brings avatars into the room
                        yield return new WaitForSeconds(6f); //waits this many seconds                            
                        Bios[curTrial].SetActive(false); //turns bios off
                    }
                    spacePressed = 1; // this brings it back to the beginning to use space as 'next trial'
                    eyeTracker.stopRecording();
                }
            }
        }
            Debug.Log("End of trials");
        }
    }