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
    [SerializeField] private float breathMin;
    [SerializeField] private float timeBeforeExhale;
    private bool exhaleStarted = false;
    //tracks whether the player has reached max exhale already)
    private bool exhaleFinished = false;
    private InputManager im;
    private Health playerHealth;
    float horizontalInput;
    float verticalInput;
    [SerializeField] float maxTimeStopped;
    private float timeStopped;
    private bool canMove;
    [SerializeField] float damageInterval;
    private float damageTimer;

    //one button controls - meter var
    [SerializeField] public float breathMeter;
    [SerializeField] public float breathMax;

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
            if(horizontalInput != 0 || verticalInput != 0)
            {
                GameAudioManager.instance.PlaySFX("Player footsteps");
            }
            else 
            {
                if (GameAudioManager.instance.sfxSource.clip != null && GameAudioManager.instance.sfxSource.clip.name.Contains("footstep"))
                {
                    GameAudioManager.instance.sfxSource.clip = null;
                }
            }
        }
        //attacks
        //can only either inhale OR exhale
        //updated for breath meter - Rafa 7/11
        if (im.button_inhale && !exhaleStarted)
        {
                
            if(breathMeter < breathMax)
            {
                exhaleStarted = false;
                inhale();
                breathMeter += Mathf.Ceil(breathMax/3.0f) * Time.deltaTime;
                Debug.Log("Breath Meter: " + breathMeter);
            }
            else {
                if (!exhaleFinished) {
                    StartCoroutine(PauseBeforeExhale(timeBeforeExhale));
                }
            }
        }
        
        //can't exhale if breath meter is 0
        if (breathMeter > 0 ){
            
            if (!im.button_inhale || exhaleStarted) {
                if (!exhaleStarted) {
                    exhaleStarted = true;
                    if (breathMeter < breathMin) {
                        breathMeter = breathMin;
                    }
                }
                exhale();
                breathMeter -= (breathMax/1.5f) * Time.deltaTime;
                Debug.Log("exhaled");
            }
        }
        else {
            exhaleStarted = false;
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

        //enemy damage interval logic
        if(damageTimer < damageInterval)
        {
            damageTimer += 1 * Time.deltaTime;
        }
    }

    private void exhale()
    {
        GameAudioManager.instance.PlaySFXFromPlayer("Breathe out sound");
        Collider2D[] collidersWithinPulseRange = Physics2D.OverlapCircleAll(transform.position, pulseRadius);
        foreach(Collider2D collider in collidersWithinPulseRange)
        {
            if (collider.CompareTag(INTERACTABLE_TAG))
            {
                InteractableObject iO = collider.GetComponent<InteractableObject>();
                if (iO)
                {
                    float thisPulseForce = pulseForce;
                    // makes it so pulse force is proportional to breathMeter
                        iO.onExhale(gameObject, thisPulseForce * breathMeter);
                }
            }
        }
    }

    private void inhale()
    {
        // TODO: finding by tags is very expensive. remove this
        // Use arrays in manager instead.
        // check if they're within a certain range.
        Debug.Log("Inhaled");
        GameAudioManager.instance.PlaySFXFromPlayer("Breathe in sound");
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
                damageTimer = damageInterval;
                canMove = false;
                timeStopped = maxTimeStopped;
                Debug.Log(timeStopped);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<InteractableObject>())
        {
            collision.gameObject.GetComponent<InteractableObject>().onCollisionWithPlayer(gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<InteractableObject>())
        {
            if (collision.gameObject.GetComponent<InteractableObject>().getObjectType() == "enemy")
            {
                if (damageTimer >= damageInterval)
                {
                    collision.gameObject.GetComponent<InteractableObject>().onCollisionWithPlayer(gameObject);
                    damageTimer = 0f; // Reset the timer
                }
            }
        }

    }

    private IEnumerator PauseBeforeExhale(float seconds) {
        yield return new WaitForSeconds(seconds);
            exhaleStarted = true;
            exhaleFinished = false;
    }
}



