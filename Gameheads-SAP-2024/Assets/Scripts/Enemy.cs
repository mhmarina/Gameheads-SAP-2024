using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : InteractableObject
{
    [SerializeField] private float moveSpeed;
    private GameObject player;

    public Enemy()
    {
        objectType = "enemy";
        pushOrPull = pushPullType.BOTH;
    }

    public override void onCollisionWithPlayer()
    {
        player.GetComponent<Health>().setHealth(player.GetComponent<Health>().getHealth()-5);
    }

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        //continuously move towards player
        if (player)
        {
            onInhale(player, moveSpeed);
        }
    }
}
