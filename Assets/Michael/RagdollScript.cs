using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class RagdollScript : MonoBehaviour
{
    public bool isIntro;
    public bool isFading = false;

    public float fadeTime = 2;
    private float fadeTimer = 0;

    public OVRScreenFade screenFade;
    public ParticleSystem furnaceFire;

    public Rigidbody rb;
    public float screamVelocity;
    public bool isGrabbed = false;

    public OVRGrabbableExtended grabbable;

    //public GameManager gameManager;
    public bool firstEnemyDestroyed = false;

    public float warningLineTime;
    public float coalWarningTime;
    public float damageWarningTime;

    private float warningLineTimer = 0;
    private float coalWarningTimer = 0;
    private float damageWarningTimer = 0;

    public AudioSource aSource;
    public List<AudioClip> voicelines = new List<AudioClip>();

    // Start is called before the first frame update
    void Start()
    {
        // aSource = GetComponent<AudioSource>();
        // grabbable = GetComponent<OVRGrabbableExtended>();

        if (isIntro)
        {
            Debug.Log("Hey! You there! You must be the new conductor! I'm the little guy on the shelf in front of you. Can you... pick me up real quick? While you're holding me, I'll show you around.");
            aSource.clip = voicelines[7];
            aSource.Play();
            //aSource.Stop();
            //aSource.PlayOneShot(voicelines[7]);
        }
        else
        {
            Debug.Log("See? Totally fine. We're on our way! Chuck some coal in the furnace to keep us going!");
            aSource.clip = voicelines[9];
            aSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(aSource.isPlaying);

        if (rb.velocity.magnitude >= screamVelocity && !isGrabbed)
        {
            Toss();
        }

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

        if (GameManager.Instance.credits == 10 && firstEnemyDestroyed == false)
        {
            DestroyFirstEnemy();
            firstEnemyDestroyed = true;
        }

        warningLineTimer += Time.deltaTime;
        coalWarningTimer += Time.deltaTime;
        damageWarningTimer += Time.deltaTime;
    }

    // Intro dialogue
    public void Pickup()
    {
        isGrabbed = true;

        if (isIntro)
        {
            Debug.Log("What's up boss? I'll be your helper doll for this trip. Don't worry, I'll only bug you if we're in danger... or if I get bored.");
            Debug.Log("We should get moving, we've got passengers to move across. I know this'll be weird, but toss me in that furnace and I'll get this train started");
            aSource.clip = voicelines[12];
            aSource.Play();
        }
        else
        {
            Debug.Log("Hey, boss!");
            Debug.Log("Hiya!");
            // Clip 10 or 11
            aSource.clip = voicelines[Random.Range(10, 12)];
            aSource.Play();
        }
    }

    public void Kindling()
    {
        if (isIntro)
        {
            Debug.Log("Ahhh! HOTHOTHOTHOT!!!!");
            aSource.clip = voicelines[8];
            aSource.Play();

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
            aSource.clip = voicelines[5];
            aSource.Play();
        }
    }

    public void FirstEnemy()
    {
        Debug.Log("Uhh... something's picking up on the train's sensors... I think we're being tailed by outlaws. Don't panic, we have those cannons outside for a reson. Check the port cannon and shoot them down!");
        aSource.clip = voicelines[4];
        aSource.Play();

        warningLineTimer = 0;
    }

    public void DestroyFirstEnemy()
    {
        Debug.Log("You got them boss! And we got their bounty reward for our troubles! But I doubt they tried to derail us alone. Keep a lookout, and if you deal with enough of them, you can upgrade the train with the money you get.");
        aSource.clip = voicelines[3];
        aSource.Play();

        warningLineTimer = 0;
    }

    // Game gameplay loop dialogue
    public void EnemyPort()
    {
        // Clip 14 or 15
        if (warningLineTimer > warningLineTime)
        {
            Debug.Log("Enemies port side!");
            Debug.Log("Port side, boss!");

            aSource.clip = voicelines[Random.Range(14, 16)];
            aSource.Play();

            warningLineTimer = 0;
        }
    }

    public void EnemyStarboard()
    {
        // Clip 23 or 24
        if (warningLineTimer > warningLineTime)
        {
            Debug.Log("Enemies starboard side!");
            Debug.Log("Starboard side, boss!");

            aSource.clip = voicelines[Random.Range(23, 25)];
            aSource.Play();

            warningLineTimer = 0;
        }
    }

    public void DamagePort()
    {
        if (warningLineTimer > warningLineTime && !isIntro && coalWarningTimer > coalWarningTime)
        {
            Debug.Log("Taking damage port side!");
            aSource.clip = voicelines[13];
            aSource.Play();

            warningLineTimer = 0;
            damageWarningTimer = 0;
        }
    }

    public void DamageStarboard()
    {
        if (warningLineTimer > warningLineTime && !isIntro && coalWarningTimer > coalWarningTime)
        {
            Debug.Log("Taking damage starboard side!");
            aSource.clip = voicelines[22];
            aSource.Play();

            warningLineTimer = 0;
            damageWarningTimer = 0;
        }
    }

    public void CoalLow()
    {
        // Clip 0 or 1
        if (warningLineTimer > warningLineTime && !isIntro && coalWarningTimer > coalWarningTime)
        {
            Debug.Log("Our coal's running low, boss!");
            Debug.Log("We're slowing down, add some coal!");

            aSource.clip = voicelines[Random.Range(0, 2)];
            aSource.Play();

            warningLineTimer = 0;
            coalWarningTimer = 0;
        }
    }

    public void HealthLow()
    {
        Debug.Log("We can't hold much longer!");
        aSource.clip = voicelines[2];
        aSource.Play();

        warningLineTimer = 0;
        damageWarningTimer = 0;
    }

    public void GetUpgrade()
    {
        Debug.Log("Good idea, boss!");
        Debug.Log("This should help!");
        // Clip 25 or 26
        aSource.clip = voicelines[Random.Range(25, 27)];
        aSource.Play();
    }

    public void Toss()
    {
        Debug.Log("AAAAAHHHH");
        Debug.Log("AAHHHH");
        Debug.Log("AAAAAAAAAHHHH");
        Debug.Log("WEEEEEE");
        Debug.Log("YEE HAW");
        // Clip 17, 18, 19, 20 or 21
        aSource.clip = voicelines[Random.Range(17, 22)];
        aSource.Play();
    }

    public void EndGame()
    {
        Debug.Log("We made it to the station boss! Well done!");
        aSource.clip = voicelines[6];
        aSource.Play();

        screenFade.FadeOut();
        isFading = true;

        warningLineTimer = 0;
        damageWarningTimer = 0;
        coalWarningTimer = 0;
    }

    public void ReleaseRagdoll()
    {
        isGrabbed = false;
    }

    public void StopDialogue()
    {
        aSource.Stop();
    }
}
