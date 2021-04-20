using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour {
    public bool pause ;
    public GameObject pauseUI;

    public const int OPTIONS_COUNT = 4;
    enum OPTIONS {
        RESUME,
        RESTART,
        SETTING,
        QUIT
    }

    public Text[] item_text = new Text[OPTIONS_COUNT];


    public int choose_index = 0;
    // Start is called before the first frame update
    void Start() {
        pauseUI.SetActive(false);
        pause = false;
        choose_index = 0;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Debug.Log("Switch Pause");
            pause = true;
            InLevelManager.Instance.Pause();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && pause) {
            choose_index = (choose_index + OPTIONS_COUNT  -1) % OPTIONS_COUNT;
        }

        else if (Input.GetKeyDown(KeyCode.DownArrow) && pause) {
            choose_index = (choose_index + OPTIONS_COUNT + 1) % OPTIONS_COUNT;
        }
        else if (Input.GetKeyDown(KeyCode.KeypadEnter) && pause){
            ChooseOption();
        }
        for (int i = 0; i < OPTIONS_COUNT; i++) {
            item_text[i].fontStyle = 
                i ==choose_index ? FontStyle.BoldAndItalic : FontStyle.Normal;
        }

        if (pause) {
            pauseUI.SetActive(true);
        }
        else {
            pauseUI.SetActive(false);
        }
    }

    void ChooseOption() {
        Debug.Log("ChooseOption");
        switch (choose_index) {
            case (int)OPTIONS.RESUME:
                Resume();
                break;
            case (int)OPTIONS.RESTART:
                Restart();
                break;
            case (int)OPTIONS.SETTING:
                Setting();
                break;
            case (int)OPTIONS.QUIT:
                Quit();
                break;
            default:
                break;
        };
    }


    public void Setting() {
        Debug.Log("Press Setting");
        pause = false;
        choose_index = 0;
        gameObject.GetComponent<SettingMenu>().OpenSetting();
   
    }

    public void Resume() {
        pause = false;
        InLevelManager.Instance.UnPause();
    }

    public void Restart() {
        SceneHandler.Instance.OpenScene(SceneHandler.LEVEL_ENTRY_SCENE);
    }

    public void Quit() {
        Application.Quit();
    }
}
