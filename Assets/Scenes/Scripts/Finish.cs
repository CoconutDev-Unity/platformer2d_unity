using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private bool _isActivated = false;

    public void Activate() {
        _isActivated = true;
    }

    public void FinishLevel() {
        if (_isActivated) {
            SceneManager.LoadScene(2);
        }
    }
}