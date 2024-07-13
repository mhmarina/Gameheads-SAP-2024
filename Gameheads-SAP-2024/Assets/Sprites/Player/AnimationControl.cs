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
        Controller = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space)) //change this to something else
        {
            canMove = true; 
        }
        

        if (canMove == true)
        { 
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) ) 
            {
                Controller.Play("Left Cycle");
            }

            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) ) 
            {
                Controller.Play("Right Cycle");
            }

            else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) ) 
            {
                Controller.Play("Player Back Cycle");
            }

            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) ) 
            {
                Controller.Play("Front Cycle");
            }

            else if (Input.GetKeyDown(KeyCode.Space))
            {
                Controller.Play("Breathe In");
            }

            else if (Input.GetKeyDown(KeyCode.M))
            {
                Controller.Play("Breathe Out");
            }
        }
    }
}
