using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class LevelStore : MonoBehaviour {
    public Button btn_start;

    // Start is called before the first frame update
    void Start() {
        btn_start.onClick.AddListener(PressBtnStart);
    }

    private void PressBtnStart() {
        SceneHandler.Instance.OpenScene(SceneHandler.LEVEL_PLAY_SCENE);
    }
}