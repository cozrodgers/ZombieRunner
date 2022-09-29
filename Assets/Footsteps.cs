using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public float stepRate = 0.5f;
    public float sprintStepRate;
    public float stepCoolDown;
    public AudioClip footStep;

    AudioSource footstepsAudioSource;

    void Start()
    {
        footstepsAudioSource = GetComponent<AudioSource>();
        sprintStepRate = stepRate / 2;

    }
    // Update is called once per frame
    void Update()
    {
        stepCoolDown -= Time.deltaTime;
        if ((Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f) && stepCoolDown < 0f)
        {
            footstepsAudioSource.pitch = 1f + Random.Range(-0.2f, 0.2f);
            footstepsAudioSource.PlayOneShot(footStep, 0.9f);
            if (Input.GetKey(KeyCode.LeftShift))
            {

                stepCoolDown = sprintStepRate;
            }
            else
            {

                stepCoolDown = stepRate;
            }
        }
    }

}
