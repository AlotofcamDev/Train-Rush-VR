using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform target;
    private Vector3 startPos;

    private Vector3 movementDirection = Vector3.forward;

    [SerializeField]
    private float acceleration;
    [SerializeField]
    private float topSpeed;
    [SerializeField] private float targetSpeed;

    public bool closeEnoughToAttack = false;

    private Rigidbody rigidBody;

    // (M)
    public bool isLeftSide;
    public bool closeEnoughForWarning = false;
    private RagdollScript ragdoll;

    // Link to furnace
    private Furnace furnace;
    private float speedMult;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("EnemyTarget").transform;

        // (M)
        ragdoll = GameObject.Find("RagdollMesh").GetComponent<RagdollScript>();

        rigidBody = GetComponent<Rigidbody>();
        startPos = transform.position;
        furnace = GameObject.FindGameObjectWithTag("Furnace").GetComponent<Furnace>();
        topSpeed *= Random.Range(0.7f, 1.1f);
    }

    // Update is called once per frame
    void Update()
    {
        // 0.5 at health = max, 0.75 at health = max/2, 1 at health = 0
        speedMult = 1.5f - ((furnace.currentHealth + furnace.maxHealth) / (2f * furnace.maxHealth));

        closeEnoughToAttack = transform.position.z >= target.position.z - 4f;

        // (M)
        if (transform.position.z >= target.position.z - 15f && !closeEnoughForWarning)
        {
            if (isLeftSide)
            {
                ragdoll.EnemyStarboard();
            }
            else
            {
                ragdoll.EnemyPort();
            }

            closeEnoughForWarning = true;
        }

        // Movement physics
        targetSpeed = topSpeed * ((target.position.z - transform.position.z) / (target.position.z - startPos.z)) * speedMult;

        Vector3 force = movementDirection * acceleration * Time.deltaTime;
        rigidBody.AddForce(force);

        float clampedSpeed = Mathf.Clamp(rigidBody.velocity.z, -20f * topSpeed, targetSpeed);
        rigidBody.velocity = movementDirection * clampedSpeed;

        //Debug.Log(rigidBody.velocity);
    }

    /*
    private void FixedUpdate()
    {
        targetSpeed = topSpeed * ((target.position.z - transform.position.z) / (target.position.z - startPos.z)) * speedMult;

        Vector3 force = movementDirection * acceleration * Time.fixedDeltaTime;
        rigidBody.AddForce(force);

        float clampedSpeed = Mathf.Clamp(rigidBody.velocity.z, -20f*topSpeed, targetSpeed);
        rigidBody.velocity = movementDirection * clampedSpeed;

        Debug.Log(rigidBody.velocity);
    }
    */
}
