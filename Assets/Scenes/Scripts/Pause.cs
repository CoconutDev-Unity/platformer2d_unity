using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject PauseCanvas;
    public void PauseHandler() {
        PauseCanvas.SetActive(true);
        
        Time.timeScale = 0f;
    }

    public void ContinueHandler() {
        PauseCanvas.SetActive(false);

        Time.timeScale = 1f;
    }
}
