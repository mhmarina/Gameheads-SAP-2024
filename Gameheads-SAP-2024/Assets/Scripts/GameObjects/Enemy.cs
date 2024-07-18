using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : InteractableObject
{
    [SerializeField] float moveSpeed;
    [SerializeField] int damage;
    [SerializeField] float attackRadius;
    private GameObject player;

    public Enemy()
    {
        objectType = "enemy";
        pushOrPull = pushPullType.BOTH;
    }

    public override void onCollisionWithPlayer(GameObject player)
    {
        player.GetComponent<Health>().setHealth(player.GetComponent<Health>().getHealth()-damage);
    }

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        //continuously move towards player
        if (Vector3.Distance(player.transform.position, this.transform.position) < attackRadius)
        {
            onInhale(player, moveSpeed);
        }
    }
}
