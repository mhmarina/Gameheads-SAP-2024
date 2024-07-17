using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    public Animator Controller; 
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
            if (Input.GetKey(KeyCode.Space)) 
            {
                Controller.SetBool("Breathe In", true);
            }

            else
            {
                Controller.SetBool("Breathe In", false);
            }
        
            // left animation trigger
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) ) 
            {
                Controller.SetBool("Walk Left", true);
            }

            else 
            {
                Controller.SetBool("Walk Left", false);
            }

            // right animation trigger
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) ) 
            {
                Controller.SetBool("Walk Right", true);
            }

            else 
            {
                Controller.SetBool("Walk Right", false);
            }

            //forward animation trigger
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) ) 
            {
                Controller.SetBool("Walk Back", true);
            }

            else 
            {
                Controller.SetBool("Walk Back", false);
            }

            //back animation trigger
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) ) 
            {
                Controller.SetBool("Walk Front Trigger", true);
            }
            
            else {
                Controller.SetBool("Walk Front Trigger", false);
            }

            //breathe in animation trigger
            

            //breathe out animation trigger
            if (Input.GetKey(KeyCode.M))
                {
                Controller.SetBool("Breathe Out", true);

                }

            else 
            {
                Controller.SetBool("Breathe Out", false);
            }
            }
    }
