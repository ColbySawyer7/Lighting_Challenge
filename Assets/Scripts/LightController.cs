using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public float flickerSpeed = 0.1f;
    public float flickersPerSecond = 3.0f;
    public float intensity = 0.2f;

    private float time;
    private float start_intensity;
    private Light light;

    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
        start_intensity = light.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime * (1- Random.Range(-flickerSpeed, flickerSpeed)) * Mathf.PI;
        light.intensity = start_intensity + Mathf.Sin(time * flickersPerSecond) * intensity;
    }
}
