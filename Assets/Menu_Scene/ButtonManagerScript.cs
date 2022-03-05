using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonManagerScript : MonoBehaviour
{
    public GameObject LoadingPanel;
    AsyncOperation loadingOperation;
    public Slider progressBar;
    public TextMeshProUGUI percentLoaded;
   
   void Start()
   {
       Debug.Log("ABC");
   }
    public void StartGame()
    {
        LoadingPanel.SetActive(true);
        Debug.Log("Starting game");
        loadingOperation = SceneManager.LoadSceneAsync("Map_v7");

    }
    public void Update()
    {
        if(loadingOperation!=null)
        {
            float progressValue = Mathf.Clamp01(loadingOperation.progress / 0.9f);
            Debug.Log(progressValue);
            percentLoaded.text = Mathf.Round(progressValue * 100) + "%";
        }

    }
    public void ExitGame()
    {
        Debug.Log("Quitting game");
        Application.Quit();
    }
}
