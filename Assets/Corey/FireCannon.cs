using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCannon : MonoBehaviour
{
    public float shotStrength;
    public float barrelOffset;

    public DiegeticRotator left;
    public DiegeticRotator right;
    public GameObject bullet;

    // (M)
    public AudioSource cannonSound;

    public ParticleSystem particles;
    public float vibrationStrength = 0.5f;
    public float vibrationDuration = 0.2f;

    private bool canShoot => fireTimer > fireRate;

    public float fireRate = 0.6f;
    private float fireTimer;

    // Start is called before the first frame update
    void Start()
    {
        cannonSound.volume = PlayerPrefs.GetFloat("masterVolume");
    }

    // Update is called once per frame
    void Update()
    {
        fireTimer += Time.deltaTime;

        // Check if both controllers are grabbed and either index trigger is pressed
        if (left.isGrabbed && right.isGrabbed && canShoot &&
            (OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger) || OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger)))
        {
            Shoot();
        }

        // For debugging with the keyboard
        if (Input.GetKeyDown(KeyCode.E) && canShoot)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        // Instantiate the bullet at the specified position and apply force to it
        GameObject bulletInst = Instantiate(bullet, transform.forward * barrelOffset + transform.position, Quaternion.identity);
        bulletInst.GetComponent<Rigidbody>().AddForce(transform.forward * shotStrength, ForceMode.Impulse);

        SimpleHapticVibrationManager.VibrateController(vibrationDuration, vibrationStrength, OVRInput.Controller.LTouch);
        SimpleHapticVibrationManager.VibrateController(vibrationDuration, vibrationStrength, OVRInput.Controller.RTouch);
        particles.Play();

        fireTimer = 0f;

        // (M)
        cannonSound.Play();
    }

    public void ActivateFasterShooting()
    {
        fireRate = 0.3f;
    }
}
