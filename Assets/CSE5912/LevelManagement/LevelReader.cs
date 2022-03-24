using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelReader : MonoBehaviour
{
    public string[] ReadLevel(int levelNum){
        Debug.Log("Reading level" + levelNum);
        string filename = "Level" + levelNum + ".txt";

        string[] lines = File.ReadAllLines(@"Assets\CSE5912\LevelManagement\Levels\" + filename);

        return lines;
    }

    public int[] ReadSpawnerInfo(string info){
        string[] infoPiece = info.Split(",");
        int[] result = new int[infoPiece.Length];
        for (int i = 0; i < result.Length; i++){
            result[i] = Int32.Parse(infoPiece[i]);
        }
        return result;
    }
}
