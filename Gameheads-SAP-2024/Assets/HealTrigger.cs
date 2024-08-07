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

    private void OnCollisionEnter2D(Collision2D collision) {

         if (collision.gameObject.GetComponent<InteractableObject>().getObjectType() == "mana"
         ) {
            healTrigger.SetBool("healing", true);
            Debug.Log("heal");

            if (Time.deltaTime > 2f){
               healTrigger.SetBool("healing", false); 
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