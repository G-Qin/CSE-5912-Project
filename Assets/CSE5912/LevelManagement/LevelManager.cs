using System;
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

    [SerializeField]
    List<GameObject> spawners = new List<GameObject>();

    [SerializeField]
    GameObject LevelPlaneWaypoint;

    [SerializeField]
    GameObject LevelPlaneWaypointText;

    [SerializeField]
    GameObject LevelPlane;

    [SerializeField]
    int TriggerLevelNum;

    private bool levelInProgress = false;
    private List<string> levelInfo = new List<string>();
    private int numOfEnemy = 0;
    private int levelInfoCounter = 1;
    private bool planeIsTriggered = false;
    
    void Start()
    {
        // Hide counter text at start
        counterText.text = "";
        // TO-DO: Game instructions?

        // Load the first level
        LoadLevel(levelNum);      
    }

    private void LoadLevel(int levelNumber){
        // Level hasn't started
        levelInProgress = false;

        // Wait 10 to 15 seconds for preparation
        StartCoroutine(LevelWait());

        // Read from level files
        levelInfo = new List<string>(this.GetComponent<LevelReader>().ReadLevel(levelNumber));
        numOfEnemy = Int32.Parse(levelInfo[0]);
        levelInfoCounter = 1;
    }

    IEnumerator LevelWait(){
        for (int i = levelWaitTime; i > 0; i--){
            // Update canvas time counter
            counterText.text = i.ToString();
            yield return new WaitForSecondsRealtime(1);
        }
        // Show level
        counterText.text = "Level " + levelNum;
        yield return new WaitForSecondsRealtime(2);
        // Disable level texts
        counterText.text = "";
        levelInProgress = true;
    }

    public void EnemyDeath(){
        numOfEnemy--;
    }

    public void TriggerPlane(){
        planeIsTriggered = true;
    }

    void Update()
    {
        if (levelInProgress){
            // TO-DO: Check for spawner update
            while (levelInfoCounter < levelInfo.Count){ // Check end of file
                int[] info = this.GetComponent<LevelReader>().ReadSpawnerInfo(levelInfo[levelInfoCounter]);
                if (info[4] >= numOfEnemy){
                    int enemyType = info[0];
                    int enemyCount = info[1];
                    int spIndex = info[2];
                    float interval = (float) info[3];
                    spawners[spIndex].GetComponent<SpawnerManager>().monsterType = enemyType;
                    spawners[spIndex].GetComponent<SpawnerManager>().monsterCount = enemyCount;
                    spawners[spIndex].GetComponent<SpawnerManager>().spawnInterval = interval;
                    spawners[spIndex].GetComponent<SpawnerManager>().SetupSpawner();
                    levelInfoCounter++;  
                } else {
                    break;
                }
            }

            // TO-DO: Check for level completion
            if (numOfEnemy <= 0){
                if (levelNum == maxLevelNum){
                    // TO-DO: Full game complete
                    levelInProgress = false;
                } else if (levelNum == TriggerLevelNum && !planeIsTriggered){
                    LevelPlane.SetActive(false);
                    LevelPlaneWaypoint.SetActive(true);
                    LevelPlaneWaypointText.SetActive(true);
                } else if (levelNum == TriggerLevelNum && planeIsTriggered){
                    LevelPlane.SetActive(true);
                    LevelPlane.transform.Rotate(0f, 0f, 180f, Space.Self);
                    LevelPlaneWaypoint.SetActive(false);
                    LevelPlaneWaypointText.SetActive(false);
                    levelNum++;
                    LoadLevel(levelNum);
                } else if (levelNum != TriggerLevelNum || planeIsTriggered){
                    levelNum++;
                    LoadLevel(levelNum);
                }
            }
        }
    }
}
