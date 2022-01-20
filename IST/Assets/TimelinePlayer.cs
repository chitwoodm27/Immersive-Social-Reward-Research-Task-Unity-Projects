using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TimelinePlayer : MonoBehaviour
{

    private PlayableDirector RightAvatar;

    private void Awake()
    {
        RightAvatar = GetComponent<PlayableDirector>();
       /* RightAvatar.played += RightAvatar_Played;
        RightAvatar.stopped += RightAvatar_Stopped;*/
    }
}
/*    private void StartTimeline()
{
    if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("Left arrow was pressed.");
            RightAvatar.Play();     
        }
    }
}

    */
