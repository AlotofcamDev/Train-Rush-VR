using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coal : MonoBehaviour
{
    // Tag to identify the furnace object
    public string furnaceTag = "Furnace";

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider that entered is the furnace object
        if (other.CompareTag(furnaceTag))
        {
            // Check if the collided object is a coal
            Coal coal = GetComponent<Coal>();
            if (coal != null)
            {
                // Destroy the coal object
                Destroy(gameObject);
            }
        }
    }
}
