using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCannon : MonoBehaviour
{
    public float shotStrength;
    public float barrelOffset;
    public float cooldownTime = 0.25f; // Cooldown time in seconds

    public DiegeticRotator left;
    public DiegeticRotator right;
    public GameObject bullet;
    public Shop shop;

    public ParticleSystem particles;
    public float vibrationStrength = 0.5f;
    public float vibrationDuration = 0.2f;

    private bool canShoot = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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

        // Start the cooldown coroutine
        if (shop.FasterShooting == false)
        {
            StartCoroutine(Cooldown());
        }
        
    }

    private IEnumerator Cooldown()
    {
        // Set canShoot to false and wait for the cooldown time
        canShoot = false;
        yield return new WaitForSeconds(cooldownTime);
        // After the wait, set canShoot to true again
        canShoot = true;
    }
}
