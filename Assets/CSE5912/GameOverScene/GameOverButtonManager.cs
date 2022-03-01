using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButtonManager : MonoBehaviour
{
    void Start() {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void LoadMainMenu(){
        SceneManager.LoadScene("Menu_Scene");
    }

    public void QuitGame(){
        Debug.Log("Quitting");
        Application.Quit();
    }
}
