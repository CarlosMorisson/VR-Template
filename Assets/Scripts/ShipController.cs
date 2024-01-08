using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;
public class ShipController : MonoBehaviour
{
    [SerializeField] private XRKnob anchor;
    [SerializeField] private XRKnob wheel;
    [SerializeField] private float forwardSpeed;
    [SerializeField] private float sideSpeed;
    void Update()
    {
        float forwardVelocity = forwardSpeed * anchor.value;
        float sideVelocity = sideSpeed * anchor.value * Mathf.Lerp(-1, 1, wheel.value);
        //
        Vector3 velocity = new Vector3(sideVelocity, 0, forwardVelocity);
        transform.position += velocity * Time.deltaTime;
    }
}
