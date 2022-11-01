using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BulletEnemy : MonoBehaviour
{
    private float speed;

    private Transform player;
    private Vector2 target;
    private void Awake()
    {
        Destroy(gameObject, 5);
    }
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
        speed = 30f;


    }

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
}