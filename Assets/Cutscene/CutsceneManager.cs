using UnityEngine.SceneManagement;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void LoadImages(){
        
    }

    public void LoadMainMenu(){
        Debug.Log("Loading the menu");
        SceneManager.LoadScene("Menu_Scene");
    }
}
