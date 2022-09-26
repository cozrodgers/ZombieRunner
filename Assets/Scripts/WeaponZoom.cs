using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] RigidbodyFirstPersonController firstPersonController;

    float defaultFieldOfView;
    [SerializeField] float zoomedOutFOV = 60f;
    [SerializeField]float zoomedInFOV = 20f;
    float ADSSpeed = 50f;
    bool isZoomed = false;
    [SerializeField] float zoomInSensitivity = 2f;
    [SerializeField] float zoomOutSensitivity = .5f;

    void Start()
    {
        defaultFieldOfView = cam.fieldOfView;
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            ToggleZoom();
            if (isZoomed)
            {
                cam.fieldOfView = zoomedInFOV;
                firstPersonController.mouseLook.XSensitivity = zoomInSensitivity;
                firstPersonController.mouseLook.YSensitivity = zoomInSensitivity;
            }

            else
            {
                cam.fieldOfView = zoomedOutFOV;
                firstPersonController.mouseLook.XSensitivity = zoomOutSensitivity;
                firstPersonController.mouseLook.YSensitivity = zoomOutSensitivity;
            }
        }
    }



    public void ToggleZoom()
    {
        isZoomed = !isZoomed;
    }
}
