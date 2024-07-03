using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const string INTERACTABLE_TAG = "InteractableObject";

    [SerializeField] private float moveSpeed;
    [SerializeField] private float pulseRadius;
    [SerializeField] private float pulseForce;
    [SerializeField] private float pullForce;
    [SerializeField] private GameObject InputManager;
    [SerializeField] int MAX_PLAYER_HEALTH;
    private InputManager im;
    private int playerHealth;
    float horizontalInput;
    float verticalInput;
    

    public float getMoveSpeed() {
        return moveSpeed;
    }

    public void setMoveSpeed(float speed)
    {
        moveSpeed = speed;
    }

    public int getPlayerHealth()
    {
        return playerHealth;
    }

    private void Start()
    {
        /* We want this player to persist across levels. */
        DontDestroyOnLoad(this.gameObject);
        playerHealth = MAX_PLAYER_HEALTH;
        im = InputManager.GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //movement
        horizontalInput = im.button_horizontalInput;
        verticalInput = im.button_verticalInput;
        transform.Translate(new Vector2(horizontalInput, verticalInput) * moveSpeed * Time.deltaTime);

        //attacks
        //can only either inhale OR exhale
        if (im.button_exhale)
        {
            exhale();
        }

        else if (im.button_inhale)
        {
            inhale();
        }

        // Player death
        if(playerHealth <= 0)
        {
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
                Vector2 direction = collider.transform.position - transform.position;
                Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();
                InteractableObject io = collider.GetComponent<InteractableObject>();
                if (rb != null && io.canBePushed)
                {
                    rb.AddForce(direction.normalized * pulseForce, ForceMode2D.Impulse);
                }
            }
        }
    }

    private void inhale()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(INTERACTABLE_TAG);
        if(enemies.Length > 0)
        {
            foreach(GameObject gO in enemies)
            {
                InteractableObject iO = gO.GetComponent<InteractableObject>();
                if (iO.canBePulled)
                {
                    iO.setPullSpeed(pullForce);
                    iO.moveTowardsPlayer();
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<ManaMovement>())
        {
            playerHealth++;
            Mathf.Clamp(playerHealth, 0, MAX_PLAYER_HEALTH);
            Destroy(collision.gameObject);
            Debug.Log("Collision with Mana " + playerHealth);
        }
        if (collision.gameObject.GetComponent<EnemyMovement>())
        {
            playerHealth--;
            Mathf.Clamp(playerHealth, 0, MAX_PLAYER_HEALTH);
            Destroy(collision.gameObject);
            Debug.Log("Collision with Enemy " + playerHealth);
        }
    }

}
