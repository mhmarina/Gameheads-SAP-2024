using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveSparkTrigger : MonoBehaviour
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

     private void OnTriggerEnter2D(Collider2D other)
    {
        //Check to see if the tag on the collider is equal to Enemy
        if (other.gameObject.CompareTag("InteractableObject")) 
        {
            Debug.Log("Triggered by Enemy");
            Controller.SetBool("recievedMo'o", true); 
 
        }

        else 
        {
            Controller.SetBool("recievedMo'o", false); 
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
      if (other.gameObject.CompareTag("InteractableObject")) 
        {
            Debug.Log("Triggered by Enemy");
            Controller.SetBool("recievedMo'o", false); 
 
        }

    }
}
