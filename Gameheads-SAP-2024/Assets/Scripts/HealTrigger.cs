using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class HealTrigger : MonoBehaviour
{

    public Animator healTrigger;  
    // Start is called before the first frame update
    void Start()
    {
        healTrigger = GetComponent<Animator>(); 
    }

    // Update is called once per frame

    private void OnCollisionEnter2D(Collision2D collision) {

        if (collision.gameObject.GetComponent<InteractableObject>())
        {
            Debug.Log(collision.gameObject.GetComponent<InteractableObject>().getObjectType());
            if (collision.gameObject.GetComponent<InteractableObject>().getObjectType() == "mana" && InputManager.instance.button_inhale)
            {
                healTrigger.Play("Heal");
                Debug.Log("heal");
            }
        }
    }
}


//   private void OnCollisionEnter2D(Collision2D collision){

   // if (collision.LayerMask.LayerToName == "Mana"){
    //     healTrigger.SetBool("healing", true);
        
   // }
//}
   
//}