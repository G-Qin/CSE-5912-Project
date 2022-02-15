using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManagerScript : MonoBehaviour
{
    public GameObject LoadingPanel;
   
    public void StartGame()
    {
        LoadingPanel.SetActive(true);
        Debug.Log("Starting game");
        SceneManager.LoadScene("Map_v7");

    }
    public void ExitGame()
    {
        Debug.Log("Quitting game");
        Application.Quit();
    }
}
