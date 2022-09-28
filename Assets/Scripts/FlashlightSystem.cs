using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightSystem : MonoBehaviour
{
    [SerializeField] float lightDecay = .1f;
    [SerializeField] float angleDecay = 1f;
    [SerializeField] float minimumAngle = 40f;

    Light mylight;

    void Start()
    {
        mylight = GetComponent<Light>();
    }
    public float GetBatteryLife() {
        return mylight.intensity;
    }

    public void IncreaseBattery(float chargeAmount)
    {
        mylight.intensity += chargeAmount;
    }

    // Update is called once per frame
    void Update()
    {
        if (mylight.spotAngle > minimumAngle)
        {
            DecreaseLightAngle();
        }
        DecreaseLightIntensity();

    }
    void DecreaseLightIntensity()
    {
        mylight.intensity -= lightDecay * Time.deltaTime;

    }
    void DecreaseLightAngle()
    {
        mylight.spotAngle -= angleDecay * Time.deltaTime;
    }
}
