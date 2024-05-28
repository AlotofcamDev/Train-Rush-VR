using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnaceCollision : MonoBehaviour
{
    public Furnace furnace;

    public RagdollScript ragdoll;
    public bool firstCoalTriggered = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coal")
        {
            furnace.HealDamage(20);
            Destroy(other.gameObject);

            if (!firstCoalTriggered)
            {
                ragdoll.FirstCoal();
                firstCoalTriggered = true;
            }
        }
        else if (other.tag == "Ragdoll")
        {
            ragdoll.Kindling();
        }
    }
}
