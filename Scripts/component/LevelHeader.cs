using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class LevelHeader : MonoBehaviour {
    public Button btn_back;


    private void Awake() {
        btn_back.onClick.AddListener(PressBackBtn);
    }

    private void PressBackBtn() {
        SceneHandler.Instance.GoBack();
    }
}
