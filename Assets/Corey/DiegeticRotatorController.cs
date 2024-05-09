using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// DiegeticRotator is a component which will rotate between the given constraints
/// on the specified axis when a draggable is moved.
/// </summary>
public class DiegeticRotatorController : MonoBehaviour
{
    //[Header("Current slider value. Don't edit here.")]
    [HideInInspector]public float currentValue = 0;

    [Header("Slider Values")]

    [Tooltip("The initial value of the component.")]
    public float initialValue = 0;
    [Tooltip("The minimum value of the slider.")]
    public float minimumValue = 0;
    [Tooltip("The maximum value of the slider.")]
    public float maximumValue = 1;

    [Header("Rotator Components")]
    [Tooltip("The component which will be rotated.")]
    public Transform rotatablePart;
    [Tooltip("The axis on which the object will rotate.")]
    public RotationAxis rotationAxis;
    [Tooltip("The minimum angle of rotation for the object.")]
    public float minimumAngle = 0;
    [Tooltip("The maximum angle of rotation for the object.")]
    public float maximumAngle = 360;
    [Tooltip("The specified object will be outlined when the component can be grabbed. Can be null.")]
    public Outline inRangeOutlineHighlighter;

    
    //[Tooltip("Is the object currently being grabbed?")]
    [HideInInspector] public bool isGrabbed;
    [Header("Rotator Properties")]
    [Tooltip("Is the rotation of the object currently locked?")]
    public bool isLocked;
    [Tooltip("Should this object reset to its initial value when it is no longer grabbed?")]
    public bool resetWhenNotGrabbed;
    [Tooltip("How smoothly should the object rotate to its new location? 0 = no delay.")]
    [Range(0.0f, 1.0f)]
    public float smoothing = 0;
    public float maximumDistanceBeforeForcedDrop = 0.5f;

    [Space(20)]

    [Tooltip("Called whenever the value of the slider changes.")]
    public UnityEvent<float> onValueChanged;
    [Tooltip("Called when the slider changes into or out of the minimum value.")]
    public UnityEvent<bool> setToMinimumValue;
    [Tooltip("Called when the slider changes into or out of the maximum value.")]
    public UnityEvent<bool> setToMaximumValue;
    [Tooltip("Called when the user starts grabbing the object to rotate it.")]
    public UnityEvent onGrabStarted;
    [Tooltip("Called when the user sops grabbing the object to rotate it.")]
    public UnityEvent onGrabFinished;


    // Cache a reference to the grabbable.
    //public OVRGrabbableExtended grabbable;

    public DiegeticRotatorMod2 left;
    public DiegeticRotatorMod2 right;

    // Where is the object currently trying to rotate towards?
    public float desiredDegrees = 0;



    public enum RotationAxis
    {
      XAxis,
      YAxis,
      ZAxis
    };

    /// <summary>
    /// Update the rotator value when it is first created.
    /// </summary>
    protected virtual void Start()
    {

    }

    /// <summary>
    /// If the grabbable is being grabbed, calculate the new rotation of the component
    /// based on the position of the grabbable relative to the component.
    /// </summary>
    protected virtual void LateUpdate()
    {
        //Debug.Log($"left is grabbed: {left.isGrabbed}, right is grabbed: {right.isGrabbed}, is locked: {isLocked}.");

        if (left.isGrabbed  && right.isGrabbed && !isLocked)
        {
            //Debug.Log($"left: {left.desiredDegrees}, right: {right.desiredDegrees}.");
            desiredDegrees = (left.desiredDegrees + right.desiredDegrees) / 2f;

            //Debug.Log(desiredDegrees);

            
        }

        Quaternion targetRotation = Quaternion.Euler(
                rotationAxis == RotationAxis.XAxis ? desiredDegrees : 0,
                rotationAxis == RotationAxis.YAxis ? desiredDegrees : 0,
                rotationAxis == RotationAxis.ZAxis ? desiredDegrees : 0
            );

        // Handle final smoothing.
        if (smoothing > 0)
        {
            rotatablePart.localRotation = Quaternion.Lerp(rotatablePart.localRotation, targetRotation, Time.deltaTime * (1.1f - smoothing) * 10);
        }
        else
        {
            rotatablePart.localRotation = targetRotation;
        }
        
    }


}
