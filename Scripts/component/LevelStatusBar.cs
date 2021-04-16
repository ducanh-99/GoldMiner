using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelStatusBar : MonoBehaviour {
    public Level level;
    public Text dynamite_text;
    public Text score_text;
    public Text time_text;
    public Text distance_text;
    public Text header_text;



    private void Update() {
        time_text.text ="Time :" + InLevelManager.Instance.time;
        score_text.text = "Score :" + InLevelManager.Instance.score;
        distance_text.text = "Distance :" + InLevelManager.Instance.distance;
        header_text.text = "Level " + InLevelManager.Instance.level.index;
        dynamite_text.text = "Dynamite:  " + InLevelManager.Instance.dynamite;
    }


}
