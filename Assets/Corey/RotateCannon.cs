using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCannon : MonoBehaviour
{
    public DiegeticRotator leftGrab;
    public DiegeticRotator rightGrab;

    public Transform left;
    public Transform right;

    public Transform objectToRotate;

    private void LateUpdate()
    {
        //if (leftGrab.isGrabbed && rightGrab.isGrabbed) // Maybe just lock each hand if the other isnt grabbed instead?
        //{
            objectToRotate.localRotation = AverageRot(left.rotation, right.rotation);
        //}
    }

    private Quaternion AverageRot(Quaternion a, Quaternion b)
    {
        return Quaternion.Slerp(a, b, 0.5f);
    }
}
