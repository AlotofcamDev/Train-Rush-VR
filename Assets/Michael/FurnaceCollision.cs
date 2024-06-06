using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FurnaceCollision : MonoBehaviour
{
    public static event Action onDestroyCoal;

    public Furnace furnace;

    public RagdollScript ragdoll;
    public bool firstCoalTriggered = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coal")
        {
            if (IsHeld(other)) return;

            onDestroyCoal?.Invoke();
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
            //if (IsHeld(other)) return;

            Debug.Log("Ragdoll In Furnace");

            ragdoll.Kindling();
        }
    }

    private bool IsHeld(Collider other)
    {
        CustomGrabbable ovrGrab = other.GetComponentInChildren<CustomGrabbable>();
        //VRGrabbableExtended ovrGrabExt = other.GetComponentInChildren<OVRGrabbableExtended>();
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
