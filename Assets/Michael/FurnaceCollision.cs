using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnaceCollision : MonoBehaviour
{
    public Furnace furnace;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coal")
        {
            furnace.HealDamage(20);
            Destroy(other.gameObject);
        }
    }
}
