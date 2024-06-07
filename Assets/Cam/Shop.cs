using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{

    public bool BiggerExplosion = false;
    public bool FasterTrain = false;
    public bool ChunkierCoal = false;
    public bool FasterShooting = false;

    public int BuyValue1;
    public int BuyValue2;
    public int BuyValue3;
    public int BuyValue4;

    public Button Buy1;
    public Button Buy2;
    public Button Buy3;
    public Button Buy4;

    public Furnace furnace;
    public GameManager gameManager;

    // (M)
    public RagdollScript ragdoll;

    public TextMeshProUGUI moneyText;
    public GameObject cannon1;
    public GameObject cannon2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = $"${gameManager.credits}";

        // For debugging
        //if (Input.GetKeyDown(KeyCode.R)) ability_FasterShooting();
    }

    public void ability_BiggerExplosions()
    {
        if(gameManager.credits >= BuyValue1)
        {
            Buy1.interactable = false;
            BiggerExplosion = true;
            gameManager.credits -= BuyValue1;

            ragdoll.GetUpgrade();
        }
        
    }

    public void ability_ChunkierCoal()
    {
        if (gameManager.credits >= BuyValue2)
        {
            Buy2.interactable = false;
            ChunkierCoal = true;
            gameManager.credits -= BuyValue2;

            ragdoll.GetUpgrade();
        }

    }

    public void ability_FasterTrain()
    {
        if(gameManager.credits >= BuyValue3)
        {
            Buy3.interactable = false;
            FasterTrain = true;
            gameManager.credits -= BuyValue3;

            ragdoll.GetUpgrade();
        }
            
    }

    public void ability_FasterShooting()
    {
        if (gameManager.credits >= BuyValue4)
        {
            Buy4.interactable = false;
            FasterShooting = true;
            gameManager.credits -= BuyValue4;

            cannon1.GetComponentInChildren<FireCannon>().ActivateFasterShooting();
            cannon2.GetComponentInChildren<FireCannon>().ActivateFasterShooting();

            ragdoll.GetUpgrade();
        }
    }

}
