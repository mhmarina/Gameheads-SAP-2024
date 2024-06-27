using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private GameObject playerObject;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float shootingSpeed;

    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: make movement more random
        moveTowardsPlayer(moveSpeed);
    }

    public void moveTowardsPlayer(float mS)
    {
        transform.position = (Vector2.MoveTowards(transform.position, playerObject.transform.position, mS * Time.deltaTime));

    }
    //TODO:
    public void orbitPlayer()
    {

    }
}
