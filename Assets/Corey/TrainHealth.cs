using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TrainHealth : MonoBehaviour
{
    public float startHealth;
    public float health;

    // (M)
    public Slider healthDisplay;
    public TextMeshProUGUI healthText;
    public RagdollScript ragdoll;
    public AudioSource aSource;

    public Image sliderImage;
    public Color normalColor;
    public Color hurtColor;

    public Color normalTextColor;
    public Color hurtTextColor;

    // Start is called before the first frame update
    void Start()
    {
        //onTrainDamage += takeDamage;
        health = startHealth;

        // (M)
        if (aSource != null)
        {
            aSource.volume = PlayerPrefs.GetFloat("masterVolume");
        }
    }

    // Update is called once per frame
    void Update()
    {
        sliderImage.color = Color.Lerp(sliderImage.color, normalColor, Time.deltaTime);
        healthText.color = Color.Lerp(healthText.color, normalTextColor, Time.deltaTime);
    }

    public void takeDamage(float damage)
    {
        health -= damage;

        if (health <= 0f)
        {
            ragdoll.GameOver();
            Debug.Log("Game end");
        }
        else if (health == 20f)
        {
            ragdoll.HealthLow();
        }

        healthDisplay.value = health;
        healthText.text = "Train Integrity: " + Mathf.Clamp(health, 0f, startHealth) + "%";

        sliderImage.color = hurtColor;
        healthText.color = hurtTextColor;
    }
}
