using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
    [SerializeField] float resetTime = 0.1f;
    [SerializeField] Canvas damageTakenCanvas;

    void Start()
    {
        damageTakenCanvas.enabled = false;
    }

    public void ShowDamageSplatter()
    {
        StartCoroutine(ShowDamageTaken());
    }

    IEnumerator ShowDamageTaken()
    {
        damageTakenCanvas.enabled = true;
        yield return new WaitForSeconds(resetTime);
        damageTakenCanvas.enabled = false;
       
    }
}
