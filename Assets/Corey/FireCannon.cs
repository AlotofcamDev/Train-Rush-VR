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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(left.isGrabbed + ", " + right.isGrabbed);
        if (left.isGrabbed && right.isGrabbed && (OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger) || OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger)))
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
