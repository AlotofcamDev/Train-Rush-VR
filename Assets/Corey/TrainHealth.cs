using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TrainHealth : MonoBehaviour
{
    //public static event Action onTrainDamage;
    public float startHealth;
    public float health;

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

    public void takeDamage(float damage)
    {
        health -= damage;

        if (health <= 0f)
        {
            Debug.Log("Game end");
        }
    }
}
