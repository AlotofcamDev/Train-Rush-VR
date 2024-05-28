using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TrainTimerDisplay : MonoBehaviour
{
    public Furnace furnace;
    public Shop shop;
    public RagdollScript ragdoll;

    public Slider trainPos;

    public TextMeshProUGUI displayText;
    private float timerMod;
    private float trainDist;

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

        if (shop.FasterTrain == true)
        {
            timerMod = ((furnace.currentHealth * 1.0f) + (furnace.maxHealth * 1.0f)) * 1.5f / furnace.maxHealth * Time.deltaTime;
        }
        else
        {
            timerMod = ((furnace.currentHealth * 1.0f) + (furnace.maxHealth * 1.0f)) / furnace.maxHealth * Time.deltaTime;
        }
            

        trainPos.value += timerMod;

        //Debug.Log(((furnace.currentHealth * 1.0f) + (furnace.maxHealth * 1.0f)) / furnace.maxHealth);

        trainDist = Mathf.Floor(trainPos.maxValue - trainPos.value);

        displayText.text = Mathf.Round(trainDist / 10) / 10 + "km to station.";

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

        if (trainDist <= 0f)
        {
            ragdoll.EndGame();
        }
    }
}
