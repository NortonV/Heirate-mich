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
    public float bulletForce = 20f;


    // Start is called before the first frame update
    void Start()
    {

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
        // Movement
        rbPlayer.MovePosition(rbPlayer.position + movement * movementSpeed * Time.fixedDeltaTime);

        // Rotation
        Vector2 lookDir = mousePos - rbPlayer.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rbPlayer.rotation = angle;
    }


    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
        rbBullet.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

}
