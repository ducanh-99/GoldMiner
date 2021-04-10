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




    // Start is called before the first frame update
    void Start() {
        //levelText.text = DataCenter.Instance.GetFurthestLevel()+"";
    }


}
