using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;
    void Start()
    {
        gameOverCanvas.enabled = false;
    }

    public void HandleDeath()
    {
        ShowGameOverScreen();
    }

    private void ShowGameOverScreen()
    {
        gameOverCanvas.enabled = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
