using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Furnace : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;
    public int furnaceHeal = 20;

    public float timerMax;
    public float timer;

    public HealthBar healthBar;
    public Shop shop;
    public RagdollScript ragdoll;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxFurnaceHealth(maxHealth);
        timer = timerMax;
    }

    // Update is called once per frame
    void Update()
    {  
        timer -= Time.deltaTime; 

        if (timer <= 0.0f)
        {
            TakeDamage(20);
            timer = timerMax;
        }

        if (ragdoll != null && currentHealth <= maxHealth / 5)
        {
            ragdoll.CoalLow();
        }
    }

    void TakeDamage(int damage)
    {
        if (currentHealth - damage >= 0)
        {
            currentHealth -= damage;
            healthBar.SetFurnaceHealth(currentHealth);
        }
    }

    public void HealDamage(int heal)
    {
        if(shop.ChunkierCoal == false)
        {
            currentHealth += heal;
            healthBar.SetFurnaceHealth(currentHealth);
        }
        else if (shop.ChunkierCoal == true)
        {
            currentHealth += heal + 10;
            healthBar.SetFurnaceHealth(currentHealth);
        }
        
        
    }

    public void OnCollision(Collider other)
    {

    }
}
