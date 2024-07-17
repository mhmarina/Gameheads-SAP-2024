using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Rendering;

public class LizardAnimator : MonoBehaviour
{

     public Animator Controller; 

    // Start is called before the first frame update
    void Start()
    {
       Controller = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        //Check to see if the tag on the collider is equal to Enemy
        if (other.tag == "Player")
        {
            Debug.Log("Triggered by Enemy");
            Controller.SetBool("IsBiting", true); 
        }

        else 
        {
            Controller.SetBool("IsBiting", false); 
        }
    }
}
