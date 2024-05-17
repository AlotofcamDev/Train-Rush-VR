using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoalButton : MonoBehaviour
{

    public GameObject coalButton;
    public GameObject coalSpawner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        detectCoalButtonPress();
        
    }

    public void detectCoalButtonPress()
    {
        float currentValue = coalButton.GetComponent<DiegeticSlider>().CurrentValue;

        if (currentValue > 0)
        {
            coalSpawner.GetComponent<Spawner>().SpawnCoal();
        }
    }
}
