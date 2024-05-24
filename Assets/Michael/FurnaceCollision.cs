using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnaceCollision : MonoBehaviour
{
    public Furnace furnace;

    public RagdollScript ragdoll;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coal")
        {
            furnace.HealDamage(20);
            Destroy(other.gameObject);
        }
        else if (other.tag == "Ragdoll")
        {
            ragdoll.Kindling();
        }
    }
}
