using UnityEngine;
using UnityEngine.UI;

public class SettingItem {
    public bool on;
    public string name;
    public SettingItem(string name, bool on) {
        this.name = name;
        this.on = on;
    }
}

public class SettingMenu : MonoBehaviour {
    public bool open ;
    public GameObject UI;

    public Button btn_setting;
    public const int OPTIONS_COUNT = 4;

    public AudioSource audioSource;
    public AudioClip audioSelected;
    public AudioClip audioChangeSetting;
    enum OPTIONS {
        SOUND,
        AUDIO,
        SAVE_GAME,
        QUIT
    }

    public SettingItem[] items = new SettingItem[OPTIONS_COUNT];
    public Text[] item_text = new Text[OPTIONS_COUNT];
    public int choose_index = 0;

    // Start is called before the first frame update
    void Start() {
        UI.SetActive(false);
        open = false;
        choose_index = 0;

        if (btn_setting!=null)
            btn_setting.onClick.AddListener(OpenSetting);

        items[0] = new SettingItem("Sound", true);
        items[1] = new SettingItem("Audio", true);
        items[2] = new SettingItem("Reset", true);
        items[3] = new SettingItem("Save", true);
    }

    public void OpenSetting() {
        Debug.Log("Go Hwew");
        open = true;
        InLevelManager.Instance.Pause();
    }
    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.UpArrow) && open) {
            audioSource.PlayOneShot(audioChangeSetting);
            choose_index = (choose_index + OPTIONS_COUNT  -1) % OPTIONS_COUNT;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && open) {
            audioSource.PlayOneShot(audioChangeSetting);
            choose_index = (choose_index + OPTIONS_COUNT + 1) % OPTIONS_COUNT;
        }
        else if (Input.GetKeyDown(KeyCode.KeypadEnter) && open) {
            audioSource.PlayOneShot(audioSelected);
            ChooseOption();
        }
        for (int i = 0; i < OPTIONS_COUNT; i++) {
            item_text[i].fontStyle = i == choose_index
                ? FontStyle.Bold
                : FontStyle.Normal;

            item_text[i].text = items[i].name  + (
                i == OPTIONS_COUNT - 1
                    ? ""
                    : items[i].on  ? " :   ON" : " :   OFF");
        }

        if (open) {
            UI.SetActive(true);
        }
        else {
            UI.SetActive(false);
        }
    }

    void ChooseOption() {
        if (!open) return;

        Debug.Log("ChooseOption"+ choose_index+" , open = "+open);
        if (choose_index < OPTIONS_COUNT-1) {
            items[choose_index].on = !items[choose_index].on;
        }
        else {
            SaveSetting();
        }
    }

    public void SaveSetting() {
        open = false;
        choose_index = 0;

        InLevelManager.Instance.UnPause();
    }
}
