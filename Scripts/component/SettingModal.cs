using UnityEngine;
using UnityEngine.UI;



public class SettingModal : MonoBehaviour {

    public Slider musicSlider;
    public Slider soundSlider;
    public bool open;
    public Button btnClose;
    SoundManager soundManager;


    void Start() {
        if (btnClose == null) Debug.Log("Null Btn Close");
        btnClose.onClick.AddListener(SwitchModal);
        soundManager = SoundManager.Instance();
        if (soundManager != null) {
            musicSlider.value = PlayerPrefs.GetFloat("music_volume");
            soundSlider.value = PlayerPrefs.GetFloat("sound_volume");
            musicSlider.onValueChanged.AddListener(soundManager.MusicVolumeUpdate);
            soundSlider.onValueChanged.AddListener(soundManager.SoundVolumeUpdate);
        }
    }

    public void SwitchModal() {
        SoundManager soundManager = SoundManager.Instance();
        if (soundManager != null) {
            soundManager.PlaySound((int)SoundManager.Sound.Button_Click);
        }
        open = !open;
        if (open) InLevelManager.Instance.Pause();
        else InLevelManager.Instance.UnPause();
    }

    void Update() {
   
        if (open) {
            this.transform.localScale = new Vector3(1, 1, 1);
        }
        else {
            this.transform.localScale = new Vector3(0, 0, 0);
        }
    }

}
