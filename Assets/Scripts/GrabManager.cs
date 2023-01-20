using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabManager : MonoBehaviour
{
    private Vector3 thisTransform;
    private Vector3 thisScale;
    private Quaternion thisRotation;

    private void Start()
    {
        thisTransform = transform.position;
        thisScale = transform.localScale;
        thisRotation = transform.rotation;
    }

    public void EndGrab()
    {
        transform.position = thisTransform;
        transform.localScale = thisScale;
        transform.rotation = thisRotation;
    }
}
