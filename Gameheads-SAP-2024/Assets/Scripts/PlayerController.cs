using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int moveSpeed;
    [SerializeField] private float pulseRadius;
    [SerializeField] private float pulseForce;
    [SerializeField] private LayerMask enemyLayer;
    float horizontalInput;
    float verticalInput;

    public int getMoveSpeed() {
        return moveSpeed;
    }

    public void setMoveSpeed(int speed)
    {
        moveSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector2(horizontalInput, verticalInput) * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.M))
        {
            Debug.Log("pulse");
            releasePulse();
        }
    }

    private void releasePulse()
    {
        //3 is the enemy layer...
        Collider2D[] enemiesWithinPulseRange = Physics2D.OverlapCircleAll(transform.position, pulseRadius, enemyLayer);
        Debug.Log(enemiesWithinPulseRange.Length);
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
}
