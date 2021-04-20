using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelStatusBar : MonoBehaviour {
    public Level level;
    public Text dynamite_text;
    public Text earning_text;
    public Text time_text;
    public Text target_text;
    public Text level_index_text;



    private void Update() {
        level = InLevelManager.Instance.level;
        time_text.text ="" + InLevelManager.Instance.time;
        earning_text.text = "" + InLevelManager.Instance.score;
        target_text.text = "" + level.required_score;
        level_index_text.text = "" + level.index;
        dynamite_text.text = "" + InLevelManager.Instance.dynamite;
    }


}
