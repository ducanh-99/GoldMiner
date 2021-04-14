using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelButton : MonoBehaviour {
    public Level level;
    public Text index_text;
    //public Text scoreText;
    public Button btn;




    // Start is called before the first frame update
    void Start() {
        index_text.text = "Level "+level.index;
        btn.onClick.AddListener(LoadLevel);
    }

    public void LoadLevel() {
        Debug.Log(level.index);
        var furthest_level=LevelsManager.Instance.GetFurthestLevel();
        if (level.index <= furthest_level) {
            LevelsManager.Instance.ChooseLevel(level.index);
            SceneHandler.Instance.OpenScene(SceneHandler.LEVEL_ENTRY_SCENE);
        }


    }
}
