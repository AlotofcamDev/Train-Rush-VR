using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{

    bool BiggerExplosion = false;
    bool FasterTrain = false;
    bool ChunkierCoal = false;

    public Button Buy1;
    public Button Buy2;
    public Button Buy3;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ability_BiggerExplosions()
    {

        Buy1.interactable = false;

        int explosionSize =+ 5;
    }

    public void ability_FasterTrain()
    {
        int trainSpeed = +3;
    }

    public void ability_ChunkierCoal()
    {
        int coalValue = +2;
    }
}
