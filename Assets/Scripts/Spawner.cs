using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public Transform coalSpawner;
    public GameObject coal;

    public float coalSpawnRate;
    private float coalTimer;

    private Vector3 spawnPos;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnCoal();
            
        }

        if (coalTimer < coalSpawnRate)
        {
            coalTimer += Time.deltaTime;
        }
    }


    public void SpawnCoal()
    {
        if (coalTimer >= coalSpawnRate)
        {
            spawnPos = coalSpawner.position + new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f));
            Instantiate(coal, spawnPos, Quaternion.identity);
            coalTimer = 0;
        }

        /*
        Instantiate(coal, coalSpawner.position, Quaternion.identity);
        new WaitForSeconds(3f);
        */
    }
}
