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
    }

    private void PressBackBtn() {
        Debug.Log("Go Back");
        SceneHandler.Instance.GoBack();
    }
}
