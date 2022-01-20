using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class BiosDisappear : MonoBehaviour
{

    public PlayableDirector playableDirector;


    void Start()
    {
        playableDirector = GetComponent<PlayableDirector>();

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playableDirector.Play();
        }
    }
}