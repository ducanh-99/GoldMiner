using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class LevelEntry : MonoBehaviour {
    public Button btn_start;
    public Level level;
    public Text header_text;
    public Text score_text;
    public Text time_text;
    public Text distance_text;

    // Start is called before the first frame update
    void Start() {
        btn_start.onClick.AddListener(PressBtnStart);
        level = LevelsManager.Instance.GetCurrentLevel();
        Debug.Log("Level Entry : " + level.ToString());
        header_text.text = "Level " + (level.index+1);
        score_text.text = "Required Score :" + level.required_score;
        time_text.text = "Time :" + level.time;
        distance_text.text = "Distance :" + level.distance;
  
    }

    private void PressBtnStart() {
        SceneHandler.Instance.OpenScene(SceneHandler.LEVEL_STORE_SCENE);
    }
}