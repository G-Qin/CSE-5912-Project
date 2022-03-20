using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public TextMeshProUGUI counterText;
    [SerializeField]
    int levelNum;

    [SerializeField]
    int maxLevelNum;

    [SerializeField]
    int levelWaitTime;

    private bool levelInProgress = false;
    
    void Start()
    {
        // Hide counter text at start
        counterText.text = "";
        // TO-DO: Game instructions?

        // Load the first level
        LoadLevel(levelNum);
        levelInProgress = true;       
    }

    private void LoadLevel(int levelNumber){
        Debug.Log("Loading level " + levelNumber);
        // Level hasn't started
        levelInProgress = false;

        // Wait 10 to 15 seconds for preparation
        StartCoroutine(LevelWait());

        // TO-DO: Read from level files
        string filename = "Level" + levelNum + ".txt"; // Could be other formats

        levelInProgress = true;
    }

    IEnumerator LevelWait(){
        for (int i = levelWaitTime; i > 0; i--){
            // Update canvas time counter
            counterText.text = i.ToString();
            yield return new WaitForSecondsRealtime(1);
        }
        // Show level
        counterText.text = "Level " + levelNum;
        yield return new WaitForSecondsRealtime(3);
        // Disable level texts
        counterText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (levelInProgress){
            // TO-DO: Check for level completion
        }
    }
}
