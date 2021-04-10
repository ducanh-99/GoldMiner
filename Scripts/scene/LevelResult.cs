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
    public bool is_passed;
    public int earning_score;
    // Start is called before the first frame update
    void Start() {
        btn_main_menu.onClick.AddListener(PressBtnMainMenu);
        btn_main_action.onClick.AddListener(PressBtnMainAction);
        level = LevelsManager.Instance.GetCurrentLevel();
        System.Random r = new System.Random();

        
        is_passed = (r.Next(0,5)%2==0?true:false);
        earning_score = level.required_score + r.Next(0, 100) * (is_passed ? 1 : -1);
        Debug.Log("Is passed " + is_passed + earning_score);

        main_action_text.text = is_passed ? "Next Level" : "Play Again";
        header_text.text = "Level " + (level.index + 1);
        earning_score_text.text = "Earning :" + earning_score + "  /  " + level.required_score;
        used_time_text.text = "Time :" + r.Next(0, level.time) + "  /  " + level.time;
        passed_text.text = "Is_Passed  :" + (is_passed?"Yes":"No");
    }

    private void PressBtnMainAction() {
        if (is_passed) LevelsManager.Instance.NextLevel();
        SceneHandler.Instance.OpenScene(SceneHandler.LEVEL_ENTRY_SCENE);
    }

    private void PressBtnMainMenu() {
        SceneHandler.Instance.OpenScene(SceneHandler.MAIN_MENU_SCENE);
    }
}