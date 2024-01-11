using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SetPokeIndexFinger : MonoBehaviour
{
    public Transform IndexFinger;
    private XRPokeInteractor xrPokeInteractor;
    void Start()
    {
        xrPokeInteractor = transform.parent.parent.GetComponentInChildren<XRPokeInteractor>();
        SetPokePoint();
    }
    public void SetPokePoint()
    {
        xrPokeInteractor.attachTransform = IndexFinger;
    }
}
