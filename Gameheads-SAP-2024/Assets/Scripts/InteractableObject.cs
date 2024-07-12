using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{

    enum interActableObjectType
    {
        enemy,
        mana
    }

    private GameObject playerObject;
    private Health playerHealth;
    [SerializeField] public bool canBePulled;
    [SerializeField] public bool canBePushed;
    [SerializeField] private float pullSpeed;
    [SerializeField] private int damageOrHealing; //probably should change the name for this variable lol
    [SerializeField] private interActableObjectType myType;
    //bool to determine if it dies on contact
    [SerializeField] private bool playerDestroys;

    public void setPullSpeed(float sp)
    {
        this.pullSpeed = sp;
    }

    void Start()
    {
        playerObject = GameObject.FindWithTag("Player");
        playerHealth = playerObject.GetComponent<Health>();
    }

    private void Update()
    {
        if (!playerObject)
        {
            playerObject = GameObject.FindWithTag("Player");
            //place holder code. This allows the game not to crash if player dies.
            //include behavior that object should do when player dies here.
            if (!playerObject)
            {
                Debug.Log("Krilling myself now");
                Destroy(gameObject);
            }
        }
    }

    public void moveTowardsPlayer()
    {
        transform.position = (Vector2.MoveTowards(transform.position, playerObject.transform.position, pullSpeed * Time.deltaTime));
    }

    public void Interact()
    {
        switch (myType)
        {
            //enemy
            case interActableObjectType.enemy:
                if (playerHealth.getHealth() - damageOrHealing > 0)
                {
                    playerHealth.setHealth(playerHealth.getHealth() - damageOrHealing);
                }
                else
                {
                    playerHealth.setHealth(0);
                }
                break;
            //mana
            case interActableObjectType.mana:
                if(playerHealth.getHealth() + damageOrHealing < playerHealth.MAX_HEALTH)
                {
                    playerHealth.setHealth(playerHealth.getHealth() + damageOrHealing);
                }
                else
                {
                    playerHealth.setHealth(playerHealth.MAX_HEALTH);
                }
                break;
        }
        if (playerDestroys){
            Destroy(gameObject);
        }
    }

}
