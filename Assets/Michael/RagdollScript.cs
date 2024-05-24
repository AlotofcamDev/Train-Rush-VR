using UnityEngine;
using UnityEngine.SceneManagement;

public class RagdollScript : MonoBehaviour
{
    public bool isIntro;
    public bool isFading = false;

    public float fadeTime = 2;
    private float fadeTimer = 0;

    public OVRScreenFade screenFade;
    public ParticleSystem furnaceFire;

    // Start is called before the first frame update
    void Start()
    {
        if (isIntro)
        {
            Debug.Log("Hey! You there! You must be the new conductor! I'm the little guy on the shelf in front of you. Can you... pick me up real quick? While you're holding me, I'll show you around.");
        }
        else
        {
            Debug.Log("See? Totally fine. We're on our way! Chuck some coal in the furnace to keep us going!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isFading)
        {
            fadeTimer += Time.deltaTime;

            if (fadeTimer >= fadeTime)
            {
                if (isIntro)
                {
                    SceneManager.LoadScene("Game");
                }
                else
                {
                    SceneManager.LoadScene("MainMenu");
                }
            }
        }
    }

    // Intro dialogue
    public void Pickup()
    {
        if (isIntro)
        {
            Debug.Log("What's up boss? I'll be your helper doll for this trip. Don't worry, I'll only bug you if we're in danger... or if I get bored.");
            Debug.Log("We should get moving, we've got passengers to move across. I know this'll be weird, but toss me in that furnace and I'll get this train started");
        }
    }

    public void Kindling()
    {
        if (isIntro)
        {
            Debug.Log("Ahhh! HOTHOTHOTHOT!!!!");
            screenFade.FadeOut();
            isFading = true;
            furnaceFire.Play();
        }
    }

    // Game dialogue
    public void FirstCoal()
    {
        if (!isIntro)
        {
            Debug.Log("That's it boss! Nice and toasty!");
        }
    }

    public void FirstEnemy()
    {
        Debug.Log("Uhh... something's picking up on the train's sensors... I think we're being tailed by outlaws. Don't panic, we have those cannons outside for a reson. Check the port cannon and shoot them down!");
    }

    public void DestroyFirstEnemy()
    {
        Debug.Log("You got them boss! And we got their bounty reward for our troubles! But I doubt they tried to derail us alone. Keep a lookout, and if you deal with enough of them, you can upgrade the train with the money you get.");
    }

    // Game gameplay loop dialogue
    public void EnemyPort()
    {
        Debug.Log("Enemies port side!");
        Debug.Log("Port side, boss!");
    }

    public void EnemyStarboard()
    {
        Debug.Log("Enemies starboard side!");
        Debug.Log("Starboard side, boss!");
    }

    public void DamagePort()
    {
        Debug.Log("Taking damage port side!");
    }

    public void DamageStarboard()
    {
        Debug.Log("Taking damage starboard side!");
    }

    public void CoalLow()
    {
        Debug.Log("Our coal's running low, boss!");
        Debug.Log("We're slowing down, add some coal!");
    }

    public void HealthLow()
    {
        Debug.Log("We can't hold much longer!");
    }

    public void GetUpgrade()
    {
        Debug.Log("Good idea, boss!");
        Debug.Log("This should help!");
    }

    public void Toss()
    {
        Debug.Log("AAAAAHHHH");
        Debug.Log("AAHHHH");
        Debug.Log("AAAAAAAAAHHHH");
        Debug.Log("WEEEEEE");
        Debug.Log("YAYYYY");
    }

    public void EndGame()
    {
        Debug.Log("We made it to the station boss! Well done!");
        screenFade.FadeOut();
        isFading = true;
    }
}
