using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // public List<GameObject> levels;
    // public List<GameObject> insLevel;
    // public static GameManager Manager;
    // private GameObject start;
    // public int activeLevel=0; 
    // private int levelCounter=0;
    // private void Start()
    // {
    //     activeLevel = PlayerPrefs.GetInt("level");
    //     Manager = this;
    //     if (activeLevel == 0)
    //     {
    //         start= Instantiate(levels[0]);
    //         insLevel.Add(start);
    //     }
    //     else
    //     {
    //         start= Instantiate(levels[activeLevel]);
    //         insLevel.Add(start);
    //     }
    // }
    // public void LevelCompleted()
    // {
    //     
    //     Camera.main.transform.parent = null;
    //     Destroy(insLevel[levelCounter]);
    //     GameObject ins=Instantiate(levels[activeLevel+1]);
    //     Time.timeScale = 1f;
    //     insLevel.Add(ins);
    //     activeLevel++;
    //     levelCounter++;
    //     PlayerPrefs.SetInt("level",activeLevel);
    // }
    //
    // public void LevelRetry()
    // {
    //     Destroy(insLevel[levelCounter]);
    //     insLevel.RemoveAt(0);
    //     GameObject ins=Instantiate(levels[activeLevel]);
    //     Time.timeScale = 1f;
    //     insLevel.Add(ins);
    // }
}
