using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using System.IO;
using System.Text;

public class TimelineControllerRight : MonoBehaviour
{

    public PlayableDirector playableDirector;
    string sysTime = System.DateTime.Now.ToString("hh.mm"); //time variable (hours and minutes) and how it will show up in the file name
    string sysDate = System.DateTime.Now.ToString("ddMM_"); //day variable (day and month) and how it will show up in the file name

    private List<string> results = new List<string>(); //This is a list of all the choices your user made.

    void Start()
    {
        playableDirector = GetComponent<PlayableDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            playableDirector.Play();
            Debug.Log(gameObject.tag + ": Right");

            sysTime = System.DateTime.Now.ToString("hh.mm"); //time variable (hours and minutes) and how it will show up in the file name
            sysDate = System.DateTime.Now.ToString("dd.MM_"); //day variable (day and month) and how it will show up in the file name



            FileStream fs = new FileStream("C:/IST/LRdata/IST_LR" + sysDate + sysTime + ".txt", FileMode.Append, FileAccess.Write, FileShare.Write);
            fs.Close();
            StreamWriter sw = new StreamWriter("C:/IST/LRdata/IST_LR" + sysDate + sysTime + ".txt", true, Encoding.ASCII);
            sw.Write(gameObject.tag + ": Right\n");
            sw.Close();

        }
    }
}


