using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBomb : MonoBehaviour
{
    public float damage;
    public GameObject explosion;

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
            Instantiate(explosion, transform.position, Quaternion.identity);
            SimpleHapticVibrationManager.VibrateController(0.2f, 0.4f, OVRInput.Controller.LTouch);
            SimpleHapticVibrationManager.VibrateController(0.2f, 0.4f, OVRInput.Controller.RTouch);
            Destroy(gameObject);
        }
    }
}
