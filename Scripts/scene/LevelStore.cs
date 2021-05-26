using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class LevelStore : MonoBehaviour {
    public Button btn_start;
    
    public GameObject item_detail;

    public Text wallet_text;
    public int choose_index;

    public int item_count;
    public List<Powerup> items;




    public Button[] btn_item = new Button[4];


    public GameObject storeItemObj;


    void Start() {
        btn_start.onClick.AddListener(PressBtnStart);
        item_count = PowerupManager.Instance.GetSaleCount();
        items = PowerupManager.Instance.ChoosePowerUpToSell();

        choose_index = 0;
        for (int i = 0; i < 4; i++) {
            int index = i;
            btn_item[i].onClick.AddListener(() => ChooseItem(index));
        }

        LoadItemList();
    }


    private void PressBtnStart() {
        SoundManager soundManager = SoundManager.Instance();
        if (soundManager != null) {
            soundManager.PlaySound((int)SoundManager.Sound.Button_Click);
        }
        SceneHandler.Instance.OpenScene(SceneHandler.LEVEL_PLAY_SCENE);
    }
    
    void LoadItemList() {
        for (int i = 0; i < items.Count; i++) {
            btn_item[i].GetComponentInChildren<Text>().text = items[i].name;
        }
    }

    // Update is called once per frame
    void FixedUpdate() {
        wallet_text.text = "" + PlayerManager.Instance.GetMoney();
        for (int i = 0; i < items.Count; i++) {
            btn_item[i].GetComponentInChildren<Text>().fontStyle = i == choose_index ?
                FontStyle.Bold
                :
                FontStyle.Normal;
        }

        storeItemObj.GetComponent<StoreItem>().UpdateSelectedItem(items[choose_index]);
    }

    void ChooseItem(int item_idx) {
        SoundManager soundManager = SoundManager.Instance();
        if (soundManager != null) {
            soundManager.PlaySound((int)SoundManager.Sound.Button_Click);
        }
        choose_index = item_idx;
    }
}