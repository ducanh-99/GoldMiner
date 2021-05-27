using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class ButtonsBar : MonoBehaviour {
    public Button btn_back;
    public Button btn_setting;
    private void Awake() {
        btn_back.onClick.AddListener(PressBackBtn);
        btn_setting.onClick.AddListener(PressSettingBtn);
    }

    private void PressBackBtn() {
        SoundManager soundManager = SoundManager.Instance();
        if (soundManager != null) {
            soundManager.PlaySound((int)SoundManager.Sound.Button_Click);
        }
        SceneHandler.Instance.GoBack();
    }

    private void PressSettingBtn() {
        SoundManager soundManager = SoundManager.Instance();
        if (soundManager != null) {
            soundManager.PlaySound((int)SoundManager.Sound.Button_Click);
        }
        Debug.Log("Open Setting");

        GameObject game_obj = GameObject.FindWithTag("SettingModal");
        if (game_obj == null) {
            Debug.Log("Setting Modal Object Null ");
            return;
        }

        game_obj.GetComponent<SettingModal>().SwitchModal();
    }
}
