using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnTimer : MonoBehaviour
{
    public float despawnTime;
    private float despawnTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("masterVolume");
    }

    // Update is called once per frame
    void Update()
    {
        despawnTimer += Time.deltaTime;

        if (despawnTimer > despawnTime)
        {
            Destroy(gameObject);
        }
    }
}
