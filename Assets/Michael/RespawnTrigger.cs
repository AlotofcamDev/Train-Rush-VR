using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnTrigger : MonoBehaviour
{
    public Transform ragdollSpawn;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ragdoll")
        {
            other.transform.position = ragdollSpawn.position;
            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
