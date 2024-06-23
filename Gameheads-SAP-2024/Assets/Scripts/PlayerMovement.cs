using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int moveSpeed;
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
    }
}
