using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject MessageUI;

    private bool _isActivated = false;

    public void Activate() {
        _isActivated = true;
        MessageUI.SetActive(false);
    }

    public void FinishLevel() {
        if (_isActivated) {
            SceneManager.LoadScene(2);
        }

        else if (!_isActivated) {
        MessageUI.SetActive(true);
        }
    }
    
    
}