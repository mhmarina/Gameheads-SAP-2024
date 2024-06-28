using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float shootingSpeed;

    void Update()
    {
        //TODO: make movement more random
        GetComponent<moveTowardPlayer>().moveTowardsPlayer(moveSpeed);
    }
    //TODO:
    public void orbitPlayer()
    {

    }
}
