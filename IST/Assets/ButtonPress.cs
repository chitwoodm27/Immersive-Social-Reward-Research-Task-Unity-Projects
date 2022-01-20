using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonPress : MonoBehaviour
{

    public UnityEvent onLeftArrow;
    public UnityEvent onRightArrow;
    public UnityEvent onSpace;


    public void OnTriggerStay()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (onLeftArrow != null)
            {
                onLeftArrow.Invoke();
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (onRightArrow != null)
            {
                onRightArrow.Invoke();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (onSpace != null)
            {
                onSpace.Invoke();
            }
        }
    }
}
