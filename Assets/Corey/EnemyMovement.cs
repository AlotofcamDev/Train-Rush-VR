using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    private Vector3 startPos;

    private Vector3 movementDirection = Vector3.forward;

    [SerializeField]
    private float acceleration;
    [SerializeField]
    private float topSpeed;
    [SerializeField] private float targetSpeed;

    private bool isAttacking = false;

    private Rigidbody rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        bool closeEnoughToAttack = transform.position.z >= target.position.z - 0.5f;

        isAttacking = closeEnoughToAttack;
    }

    private void FixedUpdate()
    {
        targetSpeed = topSpeed * ((target.position.z - transform.position.z) / (target.position.z - startPos.z));

        Vector3 force = movementDirection * acceleration * Time.fixedDeltaTime;
        rigidBody.AddForce(force);

        float clampedSpeed = Mathf.Clamp(rigidBody.velocity.z, -20f*topSpeed, targetSpeed);
        rigidBody.velocity = movementDirection * clampedSpeed;
    }
}
