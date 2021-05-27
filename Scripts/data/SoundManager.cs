using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour {

    public enum Sound {
        Button_Click,
        Buy_Item,
        Timer,
        Drag,
        Cheer,
        Explode,
        Barrow_Move,
        End_Level,
        Button_Disable
    }

    private static SoundManager instance;
    public float music_volume = 1;
    public float sound_volume = 1;

    public AudioSource musicSource;
    public AudioSource soundSource;

    public Dictionary<int, string> dict = new Dictionary<int, string>() {
        {(int)Sound.Button_Click,"button_click" },
        {(int)Sound.Buy_Item,"buy_item" },
        {(int)Sound.Timer,"timer" },
        {(int)Sound.Drag,"drag" },
        {(int)Sound.Cheer,"cheer" },
        {(int)Sound.Explode,"explode" },
        {(int)Sound.Barrow_Move,"barrow_move" },
        {(int)Sound.End_Level,"end_level" },
        {(int)Sound.Button_Disable,"disable_level" },

    };

    private void Awake() {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("SoundManager");
        if (musicObj.Length > 1) {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public static SoundManager Instance() {
        GameObject soundManagerObj = GameObject.FindWithTag("SoundManager");

        if (soundManagerObj != null) {
            return soundManagerObj.GetComponent<SoundManager>();
        }
        return null;
    }

    private void Start() {

        music_volume = PlayerPrefs.GetFloat("music_volume", 1);
        musicSource.volume = music_volume;

        sound_volume = PlayerPrefs.GetFloat("sound_volume", 1);
        soundSource.volume = sound_volume;
    }

    private void Update() {
        musicSource.volume = music_volume;
        PlayerPrefs.SetFloat("music_volume", music_volume);

        soundSource.volume = sound_volume;
        PlayerPrefs.SetFloat("sound_volume", sound_volume);
    }

    public  void MusicVolumeUpdate(float volume) {
        music_volume = volume;
    }

    public void SoundVolumeUpdate(float volume) {
        sound_volume = volume;
    }
    public void PlayMusicBackground(bool is_loop=true) {
        musicSource.clip = (AudioClip)Resources.Load("Sounds/background" );

        musicSource.loop = is_loop;
        musicSource.Play();
    }

    public void PlaySound(int sound_id, bool is_loop=false,bool is_stop=false) {
        if (Instance() == null) return;
        if (!dict.ContainsKey((int)sound_id)) {
            return;
        }
        if (is_stop) {
            soundSource.Stop();
            return;
        }

        soundSource.clip = (AudioClip)Resources.Load("Sounds/" + dict[sound_id]);

        soundSource.loop = is_loop;
        soundSource.Play();
    }

}
