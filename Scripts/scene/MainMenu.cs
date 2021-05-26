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
    // public Button btn_setting;
    // public Button btn_instruction;
    public Button btn_exit;

    public AudioSource audioSource;
    public AudioClip audioClick;

    private void Awake() {
        btn_continue.onClick.AddListener(PressContinueBtn);
        btn_new_game.onClick.AddListener(PressNewGameBtn);
     //   btn_instruction.onClick.AddListener(PressInstructionBtn);
        btn_exit.onClick.AddListener(PressExitBtn);
    }




    private void PressContinueBtn() {
        SoundManager soundManager = SoundManager.Instance();
        if (soundManager != null) {
            soundManager.PlaySound((int)SoundManager.Sound.Button_Click);
        }
        SceneHandler.Instance.OpenScene(SceneHandler.LEVEL_LIST_SCENE);
    }

    private void PressNewGameBtn() {
        SoundManager soundManager = SoundManager.Instance();
        if (soundManager != null) {
            soundManager.PlaySound((int)SoundManager.Sound.Button_Click);
        }

        Debug.Log("Press NewGameBtn on MainMenu");
        LevelsManager.Instance.Reset();
        PlayerManager.Instance.Reset();
        SceneHandler.Instance.OpenScene(SceneHandler.LEVEL_LIST_SCENE);
    }

    private void PressExitBtn() {   
        SoundManager soundManager = SoundManager.Instance();
        if (soundManager != null) {
            soundManager.PlaySound((int)SoundManager.Sound.Button_Click);
        }
        Application.Quit();
    }

    private void OnDestroy() {
        
    }
}
