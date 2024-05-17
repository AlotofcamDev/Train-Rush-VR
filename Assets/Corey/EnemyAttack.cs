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

        GameObject inst = Instantiate(bomb, bombOrigin.position, Random.rotation);
        Rigidbody bombrb = inst.GetComponent<Rigidbody>();
        bombrb.AddForce(throwDir * throwForce, ForceMode.Impulse);
    }
}
