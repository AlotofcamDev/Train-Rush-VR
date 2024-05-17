using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBomb : MonoBehaviour
{
    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MainTrain")
        {
            // do sfx and other fx
            other.GetComponent<TrainHealth>().takeDamage(damage);
            Destroy(gameObject);
        }
    }
}
