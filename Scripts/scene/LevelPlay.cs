using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class LevelPlay : MonoBehaviour {
    public Button btn_pass;

    // Start is called before the first frame update
    void Start() {
        btn_pass.onClick.AddListener(PressBtnPass);
    }

    private void PressBtnPass() {
        SceneHandler.Instance.OpenScene(SceneHandler.LEVEL_RESULT_SCENE);
    }
}