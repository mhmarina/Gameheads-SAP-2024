using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private GameObject playerObject;
    [SerializeField] private int moveSpeed;
    [SerializeField] private int shootingSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = (Vector2.MoveTowards(transform.position, playerObject.transform.position, moveSpeed*Time.deltaTime));
    }
}
