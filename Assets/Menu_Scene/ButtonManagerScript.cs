using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonManagerScript : MonoBehaviour
{
   
    public void StartGame()
    {
        Debug.Log("Starting game");
        SceneManager.LoadScene("Map_v7");
    }

    public void ExitGame()
    {
        Debug.Log("Quitting game");
        Application.Quit();
    }
}
