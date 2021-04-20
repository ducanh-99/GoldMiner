using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class LevelResult : MonoBehaviour {
    public Button btn_main_menu;
    public Button btn_main_action;

    public Level level;

    public GameObject stars_container;
    public GameObject this_canvas;
    public Text earning_text;
    public Text target_text;
    public Image result_image;
    public bool is_passed;

    public GameObject[] star_prefabs = new GameObject[3];

    void Awake() {
        btn_main_menu.onClick.AddListener(PressBtnMainMenu);
        btn_main_action.onClick.AddListener(PressBtnMainAction);

        level = InLevelManager.Instance.level;


        earning_text.text = "" + InLevelManager.Instance.score;
        target_text.text = "" + level.required_score;
        is_passed= InLevelManager.Instance.is_passed;
        result_image.sprite = 
            Resources.Load(
                is_passed?"win_text":"try_again_text",
                 typeof(Sprite)
            ) as Sprite;


        btn_main_action.image.sprite=
           Resources.Load(
                is_passed ? "button_win" : "button_replay",
                 typeof(Sprite)) as Sprite;

        Debug.Log("Star " + level.star);
        if (level.star > 0) {
            GameObject star = Instantiate(star_prefabs[level.star - 1]) as GameObject;
            star.transform.SetParent(this_canvas.transform, false);
            star.transform.SetParent(stars_container.transform);
            star.GetComponent<RectTransform>().localPosition =
             new Vector2( 0, 0);
        }
     
     
    }

    private void PressBtnMainAction() {
        if (InLevelManager.Instance.is_passed) {
            LevelsManager.Instance.NextLevel();
        }
          
        SceneHandler.Instance.OpenScene(SceneHandler.LEVEL_ENTRY_SCENE);
    }

    private void PressBtnMainMenu() {
        if (InLevelManager.Instance.is_passed) {
            LevelsManager.Instance.NextLevel();
        }
        InLevelManager.Instance.ReturnDataForPlayerManager();
        SceneHandler.Instance.OpenScene(SceneHandler.MAIN_MENU_SCENE);
    }
}