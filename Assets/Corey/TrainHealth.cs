using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TrainHealth : MonoBehaviour
{
    //public static event Action onTrainDamage;
    public float startHealth;
    private float health;

    // Start is called before the first frame update
    void Start()
    {
        //onTrainDamage += takeDamage;
        health = startHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void takeDamage(float damage)
    {

    }
}
