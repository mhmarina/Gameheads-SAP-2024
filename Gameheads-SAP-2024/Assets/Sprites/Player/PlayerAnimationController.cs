using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Timers;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public Animator Controller; 
    public float elapsedTime = 0f; 
    //public Animator BreatheHold; 
    // Start is called before the first frame update
    void Start()
    {
        //controller call
        Controller = GetComponent<Animator>();
        //BreatheHold = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //breathe in trigger          
        if (InputManager.instance.button_inhale) 
            {
                Controller.SetBool("Breathe In", true);
                
                
                //Controller.SetBool("Breathe Out", false);
            }

            else
            {
                Controller.SetBool("Breathe In", false);
                //Controller.SetBool("Breathe Out", true);

            }
        
            // left animation trigger
            if (InputManager.instance.button_horizontalInput < 0) 
            {
                Controller.SetBool("Walk Left", true);
            }

            else 
            {
                Controller.SetBool("Walk Left", false);
            }

            // right animation trigger
            if (InputManager.instance.button_horizontalInput > 0) 
            {
                Controller.SetBool("Walk Right", true);
            }

            else 
            {
                Controller.SetBool("Walk Right", false);
            }

            //forward animation trigger
            if (InputManager.instance.button_verticalInput > 0) 
            {
                Controller.SetBool("Walk Back", true);
            }

            else 
            {
                Controller.SetBool("Walk Back", false);
            }

            //back animation trigger
            if (InputManager.instance.button_verticalInput < 0) 
            {
                Controller.SetBool("Walk Front Trigger", true);
            }
            
            else {
                Controller.SetBool("Walk Front Trigger", false);
            }
            

            //breathe out animation trigger
            if (InputManager.instance.button_exhale)
                {
                Controller.SetBool("Breathe Out", true);

                }

            else 
            {
                Controller.SetBool("Breathe Out", false);
            }
            }
    }
