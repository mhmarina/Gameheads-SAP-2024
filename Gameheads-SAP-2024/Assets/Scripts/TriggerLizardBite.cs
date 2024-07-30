using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLizardBite : MonoBehaviour
{
    private Animator Controller; 
    // Start is called before the first frame update
    void Start()
    {
      Controller = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
       
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //Check to see if the tag on the collider is equal to Enemy
        if (other.gameObject.CompareTag("Player")) 
        {
            Debug.Log("Triggered by Enemy");
            Controller.SetBool("IsBiting", true); 
 
        }

        else 
        {
            Controller.SetBool("IsBiting", false); 
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
      if (other.gameObject.CompareTag("Player")) 
        {
            Debug.Log("Triggered by Enemy");
            Controller.SetBool("IsBiting", false); 
 
        }

    }
}
