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
            other.GetComponent<RagdollScript>().StopDialogue();
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ragdoll")
        {
            other.gameObject.transform.position = ragdollSpawn.position;
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.gameObject.GetComponent<RagdollScript>().StopDialogue();
        }
    }
}
