using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public void StartHandler() {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    public void ExitHandler() {
        Application.Quit();
    }
}
