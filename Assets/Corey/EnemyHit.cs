using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    [SerializeField]
    private int health;

    [SerializeField]
    private float knockbackForce;

    private Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void TakeDamage(Vector3 knockbackDirection)
    {
        Vector3 knockback = knockbackDirection * knockbackForce;
        rigidBody.AddForce(knockback, ForceMode.Impulse);

        health--;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);

        if (other.tag == "Bullet")
        {
            Vector3 knockbackDirection = other.GetComponent<Rigidbody>().velocity.normalized;
            TakeDamage(knockbackDirection);
            Destroy(other.gameObject);
        }
    }
}
