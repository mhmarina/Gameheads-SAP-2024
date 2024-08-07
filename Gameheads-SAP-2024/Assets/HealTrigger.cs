using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HealTrigger : MonoBehaviour
{

    public Animator healTrigger; 
    public string layerName; 
    // Start is called before the first frame update
    void Start()
    {
        healTrigger = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (InputManager.instance.button_inhale) {
            healTrigger.SetBool("healing", true);
        }

        else{
            healTrigger.SetBool("healing", false);
        }
    }


   // private void OnCollisionEnter2D(Collision2D collision){


   //         healTrigger.SetBool("healing", true);
        
   // }
}
