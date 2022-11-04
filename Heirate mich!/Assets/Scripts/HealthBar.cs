using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;
    /*
    private Transform player;
    private Vector3 tempPos;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        tempPos = transform.position;
        tempPos.x = player.position.x - 20;
        tempPos.y = player.position.y + 20;
        transform.position = tempPos;
    }
    */

    public void SetBaseHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
