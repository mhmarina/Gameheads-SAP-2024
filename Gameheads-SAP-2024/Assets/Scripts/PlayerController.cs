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
    private int playerHealth;
    [SerializeField] int MAX_PLAYER_HEALTH;
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
        playerHealth = MAX_PLAYER_HEALTH;
    }

    // Update is called once per frame
    void Update()
    {
        //movement
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector2(horizontalInput, verticalInput) * moveSpeed * Time.deltaTime);

        //attacks
        //can only either inhale OR exhale
        if (Input.GetKey(KeyCode.M) && !Input.GetKeyDown(KeyCode.Space))
        {
            exhale();
        }

        if (Input.GetKey(KeyCode.Space) && !Input.GetKeyDown(KeyCode.M))
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
        //3 is the enemy layer...
        Collider2D[] enemiesWithinPulseRange = Physics2D.OverlapCircleAll(transform.position, pulseRadius);
        //check for objects tagged enemy in collider
        foreach(Collider2D enemy in enemiesWithinPulseRange)
        {
            if (enemy.CompareTag(INTERACTABLE_TAG))
            {
                Vector2 direction = enemy.transform.position - transform.position;
                Rigidbody2D rb = enemy.GetComponent<Rigidbody2D>();
                if (rb != null)
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
                gO.GetComponent<moveTowardPlayer>().moveTowardsPlayer(pullForce);
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
