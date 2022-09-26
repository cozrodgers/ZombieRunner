using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    Camera cam;
    RigidbodyFirstPersonController firstPersonController;

    float defaultFieldOfView;
    float zoomedOutFOV = 60f;
    float zoomedInFOV = 20f;
    float ADSSpeed = 50f;
    bool isZoomed = false;
    [SerializeField] float zoomInSensitivity = 2f;
    [SerializeField] float zoomOutSensitivity = .5f;
    void Start()
    {
        firstPersonController = GetComponent<RigidbodyFirstPersonController>();
        cam = Camera.main;
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
        Debug.Log("zoomed");
        isZoomed = !isZoomed;
    }
}
