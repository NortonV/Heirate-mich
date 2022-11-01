using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PoliceCar : MonoBehaviour
{
    private string _enemyName;
    private float _speed;
    private Transform _playerPos;
    private int _maxHealth;
    private int _damage;
    private int _health;

    [SerializeField]
    public string EnemyName
    {
        get { return _enemyName; }
        set { _enemyName = value; }
    }
    [SerializeField]
    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    public Transform PlayerPos
    {
        get { return _playerPos; }
        set { _playerPos = value; }
    }
    [SerializeField]
    public int MaxHealth
    {
        get { return _maxHealth; }
        set { _maxHealth = value; }
    }
    [SerializeField]
    public int Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }
    [SerializeField]
    public int Health
    {
        get { return _health; }
        set { _health = value; }
    }


    void Start()
    {
        EnemyName = "PoliceCar";
        Speed = 7;
        MaxHealth = 2;
        Damage = 2;
        Health = MaxHealth;
        print("PoliceCar");

        PlayerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }


    void FixedUpdate()
    {
        isDead();
        Move();
    }


    void isDead()
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }


    void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, PlayerPos.position, Speed * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            Health -= 1;
            print("Headshot");

        }
        
    }

}