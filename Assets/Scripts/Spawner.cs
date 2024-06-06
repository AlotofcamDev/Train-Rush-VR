using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform coalSpawner;
    public GameObject coal;

    public int maxCoal = 50;
    public int coalCount = 0;

    public float coalSpawnRate;
    private float coalTimer;

    private Vector3 spawnPos;

    private void Start()
    {
        FurnaceCollision.onDestroyCoal += RemoveCoalFromCount;
    }

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
            if (coalCount >= maxCoal) return;

            AddCoalToCount();

            spawnPos = coalSpawner.position + new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f));
            Instantiate(coal, spawnPos, Quaternion.identity);
            coalTimer = 0;
        }

        /*
        Instantiate(coal, coalSpawner.position, Quaternion.identity);
        new WaitForSeconds(3f);
        */
    }

    private void AddCoalToCount()
    {
        coalCount++;
    }

    private void RemoveCoalFromCount()
    {
        coalCount--;
    }
}
