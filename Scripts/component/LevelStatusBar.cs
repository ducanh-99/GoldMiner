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
    public Text distance_text;
    public Text level_index_text;



    private void Update() {
        InLevelManager mng = InLevelManager.Instance;
        level = mng.level;
        time_text.text ="" + mng.time;
        earning_text.text = "" + mng.score+" / "+ level.required_score;
        distance_text.text = "" + mng.distance;
        level_index_text.text = "" + level.index;
        dynamite_text.text = "" + InLevelManager.Instance.dynamite;
    }


}
