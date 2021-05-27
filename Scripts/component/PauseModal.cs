using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PauseModal : MonoBehaviour {
    public bool open;
    public Button btnClose;
    SoundManager soundManager;

    public const int OPTIONS_COUNT = 4;
    public enum OPTION {
        RESUME,
        RESTART,
        SETTING,
        QUIT
    }

    public string[] btn_labels = { "Resume", "Restart", "Setting", "Quit" };
    public Button[] btn_item = new Button[OPTIONS_COUNT];


    // Start is called before the first frame update
    void Start() {
        btnClose.onClick.AddListener(SwitchModal);
        soundManager = SoundManager.Instance();
        open = false;

        for (int i = 0; i < 4; i++) {
            int index = i;
            Debug.Log("Get Btt " + btn_labels[i]);
            btn_item[i].onClick.AddListener(() => ChooseItem(index));
            btn_item[i].GetComponentInChildren<Text>().text = btn_labels[i];
        }

    }

    public void SwitchModal() {
        if (soundManager != null) {
            soundManager.PlaySound((int)SoundManager.Sound.Button_Click);
        }
        open = !open;
        if (open) InLevelManager.Instance.Pause();
        else InLevelManager.Instance.UnPause();
    }

    // Update is called once per frame
    void Update() {
        if (open) {
            this.transform.localScale = new Vector3(1, 1, 1);
        }
        else {
            this.transform.localScale = new Vector3(0, 0, 0);
        }
    }


    void ChooseItem(int idx) {
        switch (idx) {
            case (int)OPTION.RESUME:
                Resume();
                break;
            case (int)OPTION.RESTART:
                Restart();
                break;
            case (int)OPTION.SETTING:
                Setting();
                break;
            case (int)OPTION.QUIT:
                Quit();
                break;
            default:
                break;
        };
    }


    public void Setting() {
        open = false;


        GameObject game_obj = GameObject.FindWithTag("SettingModal");
        if (game_obj == null) {
            Debug.Log("Setting Modal Object Null ");
            return;
        }

        game_obj.GetComponent<SettingModal>().SwitchModal();

    }

    public void Resume() {
        open = false;
        InLevelManager.Instance.UnPause();
    }

    public void Restart() {
        open = false;
        SceneHandler.Instance.OpenScene(SceneHandler.LEVEL_ENTRY_SCENE);
    }

    public void Quit() {
        Application.Quit();
    }
}
