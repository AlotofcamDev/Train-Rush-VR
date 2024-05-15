using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentCheckPos : MonoBehaviour
{
    public Furnace furnace;
    public float baseSpeed;
    private float tempPos = 0;

    public int maxDist;

    private float speedMod;

    // Start is called before the first frame update
    void Start()
    {
        furnace = GameObject.FindObjectOfType<Furnace>();
    }

    // Update is called once per frame
    void Update()
    {
        speedMod = ((furnace.currentHealth * 1.0f) + (furnace.maxHealth * 1.0f)) / furnace.maxHealth * Time.deltaTime;

        if (this.transform.position.z < -maxDist)
        {
            //this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, maxDist);
            tempPos = this.transform.position.z + (maxDist * 2);
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, tempPos);
        }

        this.transform.position = new Vector3(0, 0, this.transform.position.z - (baseSpeed * speedMod));


    }
}
