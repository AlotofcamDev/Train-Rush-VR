using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public Transform coalSpawner;
    public GameObject coal;
   


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnCoal();
            
        }
    }


    public void SpawnCoal()
    {
        Instantiate(coal, coalSpawner.position, Quaternion.identity);
        new WaitForSeconds(3f);
    }
}
