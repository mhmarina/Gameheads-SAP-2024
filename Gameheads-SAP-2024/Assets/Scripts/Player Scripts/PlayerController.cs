using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private string INTERACTABLE_TAG = "InteractableObject";
    [SerializeField] private float moveSpeed;
    [SerializeField] private float pulseRadius;
    [SerializeField] private float pulseForce;
    [SerializeField] private float pullForce;
    private InputManager im;
    private Health playerHealth;
    float horizontalInput;
    float verticalInput;
    [SerializeField] float maxTimeStopped;
    private float timeStopped;
    private bool canMove;

    //one button controls - meter var
    [SerializeField] private float breathMeter;
    [SerializeField] private float breathMax;

    private void Start()
    {
        playerHealth = GetComponent<Health>();
        /* We want this player to persist across levels. */
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        im = InputManager.instance;
        horizontalInput = im.button_horizontalInput;
        verticalInput = im.button_verticalInput;
        if (canMove)
        {
            transform.Translate(new Vector2(horizontalInput, verticalInput) * moveSpeed * Time.deltaTime);
        }
        //attacks
        //can only either inhale OR exhale
        //updated for breath meter - Rafa 7/11
        if (im.button_inhale)
        {
                
            if(breathMeter < breathMax)
            {
                inhale();
                breathMeter += 1;

            }
            Debug.Log("Inhaled");
        }

        else if (breathMeter > 0 && !im.button_inhale) {
            exhale();
            breathMeter -=1;
            Debug.Log("exhaled");
        }

        //player movement logic
        if(!canMove && timeStopped > 0)
        {
            timeStopped -= 1 * Time.deltaTime;
            Debug.Log("Stopped");
        }
        else if(timeStopped <= 0)
        {
            timeStopped = 0;
            canMove = true;
        }
        // Player death
        if (playerHealth.getHealth() <= 0)
        {
            //event system maybe boradcast death
            Destroy(gameObject);
        }
    }

    private void exhale()
    {
        Collider2D[] collidersWithinPulseRange = Physics2D.OverlapCircleAll(transform.position, pulseRadius);
        foreach(Collider2D collider in collidersWithinPulseRange)
        {
            if (collider.CompareTag(INTERACTABLE_TAG))
            {
                InteractableObject iO = collider.GetComponent<InteractableObject>();
                if (iO)
                {
                    // makes it so pulse force is proportional to breathMeter:  seemed to be causing issues, also not sure why we need it -Rafa
                    iO.onExhale(gameObject, pulseForce * (breathMeter / 100));
                }
            }
        }
    }

    private void inhale()
    {
        // TODO: finding by tags is very expensive. remove this
        // Use arrays in manager instead.
        // check if they're within a certain range.
        GameObject[] objectsList = GameObject.FindGameObjectsWithTag(INTERACTABLE_TAG);
        if(objectsList.Length > 0)
        {
            foreach(GameObject gO in objectsList)
            {
                InteractableObject iO = gO.GetComponent<InteractableObject>();
                if (iO)
                {
                    iO.onInhale(gameObject, pullForce);
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<InteractableObject>())
        {
            collision.gameObject.GetComponent<InteractableObject>().onCollisionWithPlayer(gameObject);
            if(collision.gameObject.GetComponent<InteractableObject>().getObjectType() == "enemy" && canMove)
            {
                canMove = false;
                timeStopped = maxTimeStopped;
                Debug.Log(timeStopped);
            }
        }
    }

}
