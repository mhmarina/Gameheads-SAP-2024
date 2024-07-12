using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : InteractableObject
{
    [SerializeField] int radius;
    [SerializeField] float orbitSpeed;
    [SerializeField] int healing;
    [SerializeField] private float smoothTime = 0.0f;

    private GameObject player;
    private InputManager im;
    private Vector2 velocity = Vector2.zero;
    //angle in radians from 0 to 2pi
    private float angle;

    public Mana()
    {
        objectType = "mana";
        pushOrPull = pushPullType.CAN_PULL;
    }

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        im = GameObject.FindGameObjectWithTag("InputManager").GetComponent<InputManager>();
        angle = Random.Range(0, 2 * Mathf.PI);
    }

    void Update()
    {
        if (!im.button_inhale && player)
        {
            angle += orbitSpeed * Time.deltaTime;
            float h = player.transform.position.x - radius * Mathf.Cos(angle);
            float k = player.transform.position.y - radius * Mathf.Sin(angle);
            transform.position = Vector2.SmoothDamp(transform.position, new Vector2(h, k), ref velocity, smoothTime);
        }
        else if(player)
        {
            onInhale(player, 5);
        }
    }

    public override void onCollisionWithPlayer()
    {
        player.GetComponent<Health>().setHealth(player.GetComponent<Health>().getHealth()+healing);
        Destroy(gameObject);
    }
}
