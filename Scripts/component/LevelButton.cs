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
    public Image background_image;




    // Start is called before the first frame update
    void Start() {
   //     Debug.Log("Load Level Button" + level.index + " " + level.star);

        if (level.star == 0) index_text.text = "";
            else  index_text.text = ""+level.index;
        btn.onClick.AddListener(LoadLevel);
        background_image.sprite = Resources.Load("level_star_"+level.star, typeof(Sprite)) as Sprite;
    }

    public void LoadLevel() {
        Debug.Log(level.index);
        var furthest_level=LevelsManager.Instance.GetFurthestLevel();
        if (level.index <= furthest_level) {
            InLevelManager.Instance.GetDataFromPlayerManager();
            LevelsManager.Instance.ChooseLevel(level.index);
            SceneHandler.Instance.OpenScene(SceneHandler.LEVEL_ENTRY_SCENE);
        }


    }
}
