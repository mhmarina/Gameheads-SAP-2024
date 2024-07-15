using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    public Animator Controller; 
    public bool canMove = true; 

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
            
        }
        
            // left animation trigger
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) ) 
            {
                Controller.SetBool("Walk Left", true);
            }

            else 
            {
                Controller.SetBool("Walk Left", false);
            }

            // right animation trigger
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) ) 
            {
                Controller.SetBool("Walk Right", true);
            }

            else 
            {
                Controller.SetBool("Walk Right", false);
            }

            //forward animation trigger
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) ) 
            {
                Controller.SetBool("Walk Back", true);
            }

            else 
            {
                Controller.SetBool("Walk Back", false);
            }

            //back animation trigger
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) ) 
            {
                Controller.SetBool("Walk Front Trigger", true);
            }
            
            else {
                Controller.SetBool("Walk Front Trigger", false);
            }

            //breathe in animation trigger
            
            while (Input.GetKeyDown(KeyCode.Space))
            {
                    Controller.SetBool("Breathe In", true);
                    Debug.Log("breathe in");
            } 

                //else 
                //{
                //    Controller.SetBool("Breathe In", false);
                //    Debug.Log("Not breathing");
                //}

            //breathe out animation trigger
            if (Input.GetKeyDown(KeyCode.M))
                {
                Controller.SetBool("Breathe Out", true);

                }

            else 
            {
                Controller.SetBool("Breathe Out", false);
            }
            }
    }
