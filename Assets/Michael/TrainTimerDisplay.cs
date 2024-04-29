using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainTimerDisplay : MonoBehaviour
{
    public Furnace furnace;
    public Slider trainPos;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        trainPos.value += Time.deltaTime; // To use furnace health later

    }
}
