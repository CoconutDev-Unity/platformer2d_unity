using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private GameObject PauseCanvas;
    [SerializeField] private GameObject GameOverCanvas;
    public void RestartHandler() {
        PauseCanvas.SetActive(false);
        GameOverCanvas.SetActive(false);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);

    }

    public void MainMenuHandler() {
        SceneManager.LoadScene(0);
    }
}
