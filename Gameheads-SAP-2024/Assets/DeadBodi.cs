using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadBodi : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if(DialogueManager.instance.deadBodyTrigger == false)
            {
                DialogueManager.instance.setDeadTrigger();
            }
        }
    }
}
