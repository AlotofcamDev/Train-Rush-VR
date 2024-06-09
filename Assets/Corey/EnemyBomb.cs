using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBomb : MonoBehaviour
{
    public float damage;
    public GameObject explosion;

    // (M)
    public bool isLeftSide;

    public MeshRenderer meshRenderer;
    public Collider col;
    public DespawnTimer despawnScript;
    public ParticleSystem particle1;
    public ParticleSystem particle2;

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
            GameObject.Find("Train").GetComponent<TrainHealth>().takeDamage(damage, isLeftSide);

            Instantiate(explosion, transform.position, Quaternion.identity);
            SimpleHapticVibrationManager.VibrateController(0.2f, 0.3f, OVRInput.Controller.LTouch);
            SimpleHapticVibrationManager.VibrateController(0.2f, 0.3f, OVRInput.Controller.RTouch);
            // enable timer scirpt
            meshRenderer.enabled = false;
            col.enabled = false;
            despawnScript.enabled = true;
            particle1.Stop();
            particle2.Stop();
            enabled = false;
            //Destroy(gameObject);
        }
    }
}
