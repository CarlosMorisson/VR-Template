using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance;

    public float aplitude = 1f;
    public float length = 2f;
    public float speed = 1f;
    public float offset = 0f;

    void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);

    }

    // Update is called once per frame
    void Update()
    {
        offset += Time.deltaTime * speed;
    }
    public float GetWaveHeight(float x)
    {
        return aplitude * Mathf.Sin(x / length + offset);
    }
}
