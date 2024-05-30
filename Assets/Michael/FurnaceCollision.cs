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
            if (IsHeld(other)) return;

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
            if (IsHeld(other)) return;

            ragdoll.Kindling();
        }
    }

    private bool IsHeld(Collider other)
    {
        CustomGrabbable ovrGrab = other.GetComponentInChildren<CustomGrabbable>();
        if (ovrGrab == null)
        {
            return true;
        }
        if (ovrGrab.isGrabbed)
        {
            return true;
        }
        return false;
    }
}
