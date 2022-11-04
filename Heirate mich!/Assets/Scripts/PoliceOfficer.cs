using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PoliceOfficer : MonoBehaviour
{
    private string _enemyName;
    private float _speed;
    private int _maxHealth;
    private int _damage;
    private int _health;
    private float _stopDistancing;
    private float _retreatDistance;
    private float timeBtwShots;
    private float startTimeBtwShots;
    private float shootDistance;
    private Transform _playerPos;
    public GameObject projectile;


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
    [SerializeField]
    public float StopDistance
    {
        get { return _stopDistancing; }
        set { _stopDistancing = value; }
    }
    [SerializeField]
    public float RetreatDistance
    {
        get { return _retreatDistance; }
        set { _retreatDistance = value; }
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
        EnemyName = "PoliceOfficer";
        Speed = 5;
        MaxHealth = 1;
        Damage = 10;
        StopDistance = 4;
        RetreatDistance = 3;
        Health = MaxHealth;

        startTimeBtwShots = 2;
        timeBtwShots = startTimeBtwShots;
        shootDistance = StopDistance + 1;

        PlayerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();



    }

    void FixedUpdate()
    {
        
        isDead();
        Move();

        if (timeBtwShots <= 0 && Vector2.Distance(transform.position, PlayerPos.position) <= shootDistance)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
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
        float distance = Vector2.Distance(transform.position, PlayerPos.position);
        if (distance > StopDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, PlayerPos.position, Speed * Time.deltaTime);
        }
        else if (distance <= RetreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, PlayerPos.position, -Speed * Time.deltaTime);
        }
        else
        {
            transform.position = this.transform.position;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            Health -= 1;
        }
    }
}