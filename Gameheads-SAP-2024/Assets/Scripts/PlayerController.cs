using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float pulseRadius;
    [SerializeField] private float pulseForce;
    [SerializeField] private float pullForce;
    [SerializeField] private LayerMask enemyLayer;
    float horizontalInput;
    float verticalInput;

    public float getMoveSpeed() {
        return moveSpeed;
    }

    public void setMoveSpeed(float speed)
    {
        moveSpeed = speed;
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
        if (Input.GetKey(KeyCode.M) && !Input.GetKey(KeyCode.Space))
        {
            Debug.Log("exhale");
            exhale();
        }

        if (Input.GetKey(KeyCode.Space) && !Input.GetKey(KeyCode.M))
        {
            Debug.Log("inhale");
            inhale();
        }
    }

    private void exhale()
    {
        //3 is the enemy layer...
        Collider2D[] enemiesWithinPulseRange = Physics2D.OverlapCircleAll(transform.position, pulseRadius, enemyLayer);
        //check for objects tagged enemy in collider
        foreach(Collider2D enemy in enemiesWithinPulseRange)
        {
            Vector2 direction = enemy.transform.position - transform.position;
            Rigidbody2D rb = enemy.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.AddForce(direction.normalized * pulseForce, ForceMode2D.Impulse);
            }
        }
    }

    private void inhale()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("pullableObject");
        Debug.Log(enemies.Length);
        if(enemies.Length > 0)
        {
            foreach(GameObject gO in enemies)
            {
                gO.GetComponent<EnemyMovement>().moveTowardsPlayer(pullForce);
            }
        }
    }

}
