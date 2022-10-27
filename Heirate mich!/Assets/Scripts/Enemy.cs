using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed;
    private Transform playerPos;
    private int _health;
    public int Health
    { 
        get { return _health; }
        set { _health = value; }
    }



    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        speed = 7f;
        Health = 2;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Movement
        transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);

        // Health calculations
        if (this.Health <= 0)
        {
            Destroy(gameObject);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            this.Health -= 1;

        }
    }

}
