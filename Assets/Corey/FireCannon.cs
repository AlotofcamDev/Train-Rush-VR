using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCannon : MonoBehaviour
{
    public float shotStrength;
    public float barrelOffset;

    public DiegeticRotatorModified rotatorMod;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rotatorMod.isGrabbedL && rotatorMod.isGrabbedR && (OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger) || OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger)))
        {
            Shoot();
        }

        // FOR DEBUGGING
        if (Input.GetKeyDown(KeyCode.E))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject bulletInst = Instantiate(bullet, transform.forward * barrelOffset + transform.position, Quaternion.identity);
        bulletInst.GetComponent<Rigidbody>().AddForce(transform.forward * shotStrength, ForceMode.Impulse);
    }
}
