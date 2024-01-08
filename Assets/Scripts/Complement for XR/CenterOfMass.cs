using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterOfMass : MonoBehaviour
{
    public Vector3 centerofMass;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = centerofMass;
    }

    // Update is called once per frame
    void Update()
    {
        #if UNITY_EDITOR
        rb.centerOfMass = centerofMass;
        rb.WakeUp();
        #endif
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position + transform.rotation * centerofMass, 0.08f);
    }
}
