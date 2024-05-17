using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{

    public bool BiggerExplosion = false;
    public bool FasterTrain = false;
    public bool ChunkierCoal = false;

    public int BuyValue1 = 400;
    public int BuyValue2 = 300;
    public int BuyValue3 = 500;

    public Button Buy1;
    public Button Buy2;
    public Button Buy3;

    public Furnace furnace;
    public GameManager gameManager;


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
        if(gameManager.credits >= 400)
        {
            Buy1.interactable = false;
            BiggerExplosion = true;
        }
        
    }

    public void ability_FasterTrain()
    {
        if(gameManager.credits >= 300)
        {
            Buy2.interactable = false;
            FasterTrain = true;
        }
            
    }

    public void ability_ChunkierCoal()
    {
        if (gameManager.credits >=500)
        {
            Buy3.interactable = false;
            ChunkierCoal = true;
        }
        
    }
}
