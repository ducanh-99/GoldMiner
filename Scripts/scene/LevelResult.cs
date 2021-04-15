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
    public Text main_action_text;
    public Text header_text;
    public Text earning_score_text;
    public Text used_time_text;
    public Text passed_text;


    void Awake() {
        btn_main_menu.onClick.AddListener(PressBtnMainMenu);
        btn_main_action.onClick.AddListener(PressBtnMainAction);
        level = LevelsManager.Instance.GetCurrentLevel();

        main_action_text.text = InLevelManager.Instance.is_passed ? "Next Level" : "Play Again";
        header_text.text = "Level " + (level.index + 1);

        earning_score_text.text = "Earning :" + InLevelManager.Instance.score + "  /  " + level.required_score;
        used_time_text.text = "Time :" + (level.time- InLevelManager.Instance.time) + "  /  " + level.time;
        passed_text.text = "Is_Passed  :" + (InLevelManager.Instance.is_passed?"Yes":"No");
    }

    private void PressBtnMainAction() {
        if (InLevelManager.Instance.is_passed)
            LevelsManager.Instance.NextLevel();
        SceneHandler.Instance.OpenScene(SceneHandler.LEVEL_ENTRY_SCENE);
    }

    private void PressBtnMainMenu() {
        SceneHandler.Instance.OpenScene(SceneHandler.MAIN_MENU_SCENE);
    }
}