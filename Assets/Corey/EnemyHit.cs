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
    public GameManager gameManager;

    public GameObject explosion;

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
            Instantiate(explosion, transform.position, Quaternion.identity);
            GameManager.Instance.credits += 10;
            //gameManager.credits += 10;
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            Vector3 knockbackDirection = other.GetComponent<Rigidbody>().velocity.normalized;
            TakeDamage(knockbackDirection);
            Destroy(other.gameObject);
        }
    }
    
    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Vector3 knockbackDirection = collision.gameObject.GetComponent<Rigidbody>().velocity.normalized;
            Destroy(collision.gameObject);
            TakeDamage(knockbackDirection);
        }
    }
    */
}
