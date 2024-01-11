using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    [SerializeField] 
    float depthBeforeSubmerged=1f;
    [SerializeField]
    float displacementAmount = 3f;
    [SerializeField]
    int floaterCount = 1;
    public float waterDrag = 0.99f;
    public float waterAngularDrag = 0.5f;
    [SerializeField]
    GameObject Ocean;
    [SerializeField]
    float OceanSpeed;
    void FixedUpdate()
    {
        //Vector3 direction = this.transform.position - Ocean.transform.position;
        //direction.Normalize();
        
        //
        rb.AddForceAtPosition(Physics.gravity / floaterCount, transform.position, ForceMode.Acceleration);
        float WaveHeight = WaveManager.instance.GetWaveHeight(transform.position.x);
        //Ocean.transform.position += new Vector3(direction.x, 0f, direction.z) * OceanSpeed * Time.deltaTime;
        if (transform.position.y < WaveHeight)
        {
            float displacementMultiplier = Mathf.Clamp01((WaveHeight - transform.position.y) / depthBeforeSubmerged) * displacementAmount;
            rb.AddForceAtPosition(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementMultiplier, 0f),transform.position,ForceMode.Acceleration );
            rb.AddForce(displacementMultiplier * -rb.velocity * waterDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
            rb.AddTorque(displacementMultiplier * -rb.angularVelocity * waterAngularDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }
    }
}
