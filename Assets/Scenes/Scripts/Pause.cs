using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject PauseCanvas;
    public void PauseHandler() {
        PauseCanvas.SetActive(true);
    }

    public void ContinueHandler() {
        PauseCanvas.SetActive(false);
    }
}
