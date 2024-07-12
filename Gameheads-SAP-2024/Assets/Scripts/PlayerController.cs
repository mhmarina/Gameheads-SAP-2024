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

    //one button controls - meter var
    [SerializeField] private float breathMeter;
    [SerializeField] private float breathMax;

    private void Start()
    {
        playerHealth = GetComponent<Health>();
        /* We want this player to persist across levels. */
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
            im = InputManager.instance;
            horizontalInput = im.button_horizontalInput;
            verticalInput = im.button_verticalInput;
            transform.Translate(new Vector2(horizontalInput, verticalInput) * moveSpeed * Time.deltaTime);

            //attacks
            //can only either inhale OR exhale

            //updated for breath meter - Rafa 7/11
            if (im.button_inhale && breathMeter < breathMax)
            {
                inhale();
                breathMeter += 1;
                Debug.Log("Inhaled");
            }

            else if (im.button_inhale)
            {
                Debug.Log("Breath Maxed!");
            }
            else if (breathMeter > 0) {
                exhale();
                breathMeter -=1;
                Debug.Log("exhaled");
        }
        // Player death
        if (playerHealth.getHealth() <= 0)
        {
            //event system maybe boradcast death
            Destroy(gameObject);
        }
    }

    private void LogAllComponents(GameObject gameObject)
    {
        Component[] components = gameObject.GetComponents<Component>();
        foreach (Component component in components)
        {
            Debug.Log(gameObject.name + " has component: " + component.GetType().Name);
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
                    // makes it so pulse force is proportional to breathMeter
                    iO.onExhale(gameObject, pulseForce * (breathMeter / 100));
                }
            }
        }
    }

    private void inhale()
    {
        // TODO: tags are very expensive. remove this
        // Use arrays in manager instead.
        // check if they're within a certain range.
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(INTERACTABLE_TAG);
        if(enemies.Length > 0)
        {
            foreach(GameObject gO in enemies)
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
            Debug.Log("Collided!");
            collision.gameObject.GetComponent<InteractableObject>().onCollisionWithPlayer(gameObject);
        }
    }

}
