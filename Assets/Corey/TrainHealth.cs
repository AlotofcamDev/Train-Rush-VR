using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class TrainHealth : MonoBehaviour
{
    //public static event Action onTrainDamage;
    public float startHealth;
    public float health;

    // (M)
    public Slider healthDisplay;
    public TextMeshProUGUI healthText;
    public RagdollScript ragdoll;

    // Start is called before the first frame update
    void Start()
    {
        //onTrainDamage += takeDamage;
        health = startHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //aSource.
    }

    public void takeDamage(float damage)
    {
        health -= damage;

        if (health <= 0f)
        {
            Debug.Log("Game end");
        }
        else if (health <= 20f)
        {
            ragdoll.HealthLow();
        }

        healthDisplay.value = health;
        healthText.text = "Train Integrity: " + health + "%";
    }
}
