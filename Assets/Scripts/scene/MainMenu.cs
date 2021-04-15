using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class MainMenu : MonoBehaviour
{
    public Button btn_continue;
    public Button btn_new_game;
    public Button btn_setting;
    public Button btn_instruction;
    public Button btn_exit;

    private void Awake() {
        btn_continue.onClick.AddListener(PressContinueBtn);
        btn_new_game.onClick.AddListener(PressNewGameBtn);
        btn_setting.onClick.AddListener(PressSettingBtn);
        btn_instruction.onClick.AddListener(PressInstructionBtn);
        btn_exit.onClick.AddListener(PressExitBtn);
    }

    private void PressContinueBtn() {
        Debug.Log("Press ContinueBtn on MainMenu");
        SceneHandler.Instance.OpenScene(SceneHandler.LEVEL_LIST_SCENE);
    }

    private void PressNewGameBtn() {
        Debug.Log("Press NewGameBtn on MainMenu");
        LevelsManager.Instance.Reset();
        SceneHandler.Instance.OpenScene(SceneHandler.LEVEL_LIST_SCENE);
    }

    private void PressSettingBtn() {
        Debug.Log("Press SettingBtn on MainMenu");
        SceneHandler.Instance.OpenScene(SceneHandler.SETTING_SCENE);
    }

    private void PressInstructionBtn() {
        Debug.Log("Press Instruction on MainMenu");
        SceneHandler.Instance.OpenScene(SceneHandler.INSTRUCTION);
    }

    private void PressExitBtn() {
        Debug.Log("Press QuitBtn on MainMenu");
        Application.Quit();
    }
}
