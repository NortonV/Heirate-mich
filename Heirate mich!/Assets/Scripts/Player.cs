using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    // Movement
    public float movementSpeed = 4f;
    public Rigidbody2D rbPlayer;
    private Vector2 movement;

    // Rotation
    public Camera cam;
    private Vector2 mousePos;

    // Shooting
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 60f;

    // Health
    private int baseHealth;
    private int _health;
    public int Health
    {
        get { return _health; }
        set { _health = value; }
    }
    private bool secondLife = true;

    private void Start()
    {
        baseHealth = 5;
        Health = baseHealth;
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;

        //Rotation
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        // Shooting
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void FixedUpdate()
    {

        // Health
        if (Health <= 0)
        {
            print("Dead");
            // Display death sceen
            if (secondLife)
            {
                // Back to game
                Health = baseHealth;
                // secondLife = false
            }
            else
            {
                // Go to main menu || Play again
            }
        }

        // Movement
        rbPlayer.MovePosition(rbPlayer.position + movement * movementSpeed * Time.fixedDeltaTime);

        // Rotation
        Vector2 lookDir = mousePos - rbPlayer.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rbPlayer.rotation = angle;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            this.reduceHealth(3);
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
        rbBullet.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

    void reduceHealth(int damage)
    {
        Health -= damage;
    }

}