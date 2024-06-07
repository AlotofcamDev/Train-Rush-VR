using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    EnemyMovement enemyMove;
    TrainHealth trainHealth;

    public float cooldown;
    private float cooldownTimer;

    public float throwHeight;
    public float throwForce;

    public GameObject bomb;
    public Transform bombOrigin;

    // Start is called before the first frame update
    void Start()
    {
        enemyMove = GetComponent<EnemyMovement>();
        trainHealth = GameObject.FindGameObjectWithTag("MainTrain").GetComponent<TrainHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer += Time.deltaTime;

        if (enemyMove.closeEnoughToAttack && cooldownTimer >= cooldown)
        {
            Attack();
            cooldownTimer = 0f;
        }
    }

    private void Attack()
    {
        Vector3 horDir = (enemyMove.target.position - bombOrigin.position).normalized;
        Vector3 throwDir = (horDir + Vector3.up*throwHeight).normalized;

        GameObject inst = Instantiate(bomb, bombOrigin.position, Quaternion.identity);
        Rigidbody bombrb = inst.GetComponent<Rigidbody>();
        bombrb.AddForce(throwDir * throwForce, ForceMode.Impulse);
        bombrb.maxAngularVelocity = 20f;
        if (horDir.x > 0)
        {
            bombrb.angularVelocity = new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), Random.Range(-18f, -6f));
        } else
        {
            bombrb.angularVelocity = new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), Random.Range(6f, 18f));
        }
    }
}
