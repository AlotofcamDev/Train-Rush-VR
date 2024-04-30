using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainTimerDisplay : MonoBehaviour
{
    public Furnace furnace;

    public Slider trainPos;

    public GameObject speedArrowSlow;
    public GameObject speedArrowMed;
    public GameObject speedArrowFast;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // No coal: 1x Speed (1 second per second)
        // Full coal: 2x Speed (2 seconds per second)
        trainPos.value += ((furnace.currentHealth * 1.0f) + (furnace.maxHealth * 1.0f)) / furnace.maxHealth * Time.deltaTime;
        
        //Debug.Log(((furnace.currentHealth * 1.0f) + (furnace.maxHealth * 1.0f)) / furnace.maxHealth);

        if (furnace.currentHealth >= 80)
        {
            speedArrowSlow.SetActive(false);
            speedArrowMed.SetActive(false);
            speedArrowFast.SetActive(true);
        }
        else if (furnace.currentHealth >= 40 && furnace.currentHealth <= 60)
        {
            speedArrowSlow.SetActive(false);
            speedArrowMed.SetActive(true);
            speedArrowFast.SetActive(false);
        }
        else
        {
            speedArrowSlow.SetActive(true);
            speedArrowMed.SetActive(false);
            speedArrowFast.SetActive(false);
        }
    }
}
