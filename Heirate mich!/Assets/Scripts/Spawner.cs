using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject enemy;
    public Transform[] spawnPoints;
    private float spawnCooldown;
    public float spawnStartTime;


    // Start is called before the first frame update
    void Start()
    {
        spawnCooldown = spawnStartTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnCooldown <= 0)
        {
            int randPos = Random.Range(0, spawnPoints.Length);
            Instantiate(enemy, spawnPoints[randPos].position, Quaternion.identity);
            spawnCooldown = spawnStartTime;
        }
        else
        {
            spawnCooldown -= Time.deltaTime;
        }
    }
}
