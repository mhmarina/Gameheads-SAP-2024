using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    public Animator Controller; 
    public bool canMove = false; 

    // Start is called before the first frame update
    void Start()
    {
        //controller call
        Controller = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //gotta find another way to make the animations temporary
        if (Input.GetKeyDown(KeyCode.Space)) //change this to something else
        {
            canMove = true; 
        }
        

        if (canMove == true)
        { 
            // left animation trigger
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) ) 
            {
                Controller.Play("Left Cycle");
            }

            // right animation trigger
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) ) 
            {
                Controller.Play("Right Cycle");
            }

            //forward animation trigger
            else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) ) 
            {
                Controller.Play("Player Back Cycle");
            }

            //back animation trigger
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) ) 
            {
                Controller.Play("Front Cycle");
            }

            //breathe in animation trigger
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                Controller.Play("Breathe In");
            }

            //breathe out animation trigger
            else if (Input.GetKeyDown(KeyCode.M))
            {
                Controller.Play("Breathe Out");
            }
        }
    }
}
