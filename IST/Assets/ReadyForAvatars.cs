using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class ReadyForAvatars : MonoBehaviour
{

    public PlayableDirector playableDirector;
    public GameObject Bios;


    void Start()
    {
        playableDirector = GetComponent<PlayableDirector>();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            playableDirector.Play();
            StartCoroutine(myDelay());
        }
        
        IEnumerator myDelay()

        {
                yield return new WaitForSeconds(4.5f);
                Bios.SetActive(false);
            }

        }
    }

   

