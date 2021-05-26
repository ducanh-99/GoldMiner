using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class LevelPlay : MonoBehaviour {
    public Button btn_pause;
    private void Start() {
        LoadLevel();
        btn_pause.onClick.AddListener(PauseGame);
    }

    public void PauseGame() {

        SoundManager soundManager = SoundManager.Instance();
        if (soundManager != null) {
            soundManager.PlaySound((int)SoundManager.Sound.Button_Click);
        }
        GameObject game_obj = GameObject.FindWithTag("PauseModal");
        if (game_obj == null) {
            return;
        }
        game_obj.GetComponent<PauseModal>().SwitchModal();
    }


    public  void LoadLevel() {
         int level_index = LevelsManager.Instance.GetCurrentLevel().index;
         var level_prefab = Resources.Load("Levels/Level"+level_index) as GameObject;
         var level_content = Instantiate(level_prefab, new Vector3(0,0,0), transform.rotation);


        GameObject gems = GameObject.FindGameObjectWithTag("GemsCollector");
        if (gems!=null) {
            Debug.Log("Detect Gems Collector");
            InLevelManager.Instance.SetGemsCollector(gems.GetComponent<GemsCollector>());
        }
     

        InLevelManager.Instance.EnterLevel();
    }
}