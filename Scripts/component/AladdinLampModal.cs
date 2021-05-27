using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class AladdinLampModal : MonoBehaviour {
    public bool open;
    public int item_count;
    public List<Powerup> items;

    public Button btn_close;
    public Image[] images = new Image[4];
    public Button[] container = new Button[4];
    SoundManager soundManager;
    public int choosed_item = -1;
    void Start() {
        open = false;
        btn_close.onClick.AddListener(SwitchModal);
    }

    public void SwitchModal() {
        PowerupManager.Instance.ChoosePowerUpToSell(false);
        choosed_item = -1;
        if (soundManager != null) {
            soundManager.PlaySound((int)SoundManager.Sound.Button_Click);
        }
        open = !open;
        if (open) {
            item_count = PowerupManager.Instance.GetSaleCount();
            items= PowerupManager.Instance.GetPowerUpToSell();
            InLevelManager.Instance.Pause();
            LoadItemList();
        }
        else InLevelManager.Instance.UnPause();
    }

    void LoadItemList() {
        for (int i = 0; i < items.Count; i++) {
            int index = i;
            images[i].sprite = Resources.Load(items[i].sprite, typeof(Sprite)) as Sprite;
            images[i].color = new Color(255, 255, 255, 0);
            container[i].onClick.AddListener(() => ChooseItem(index));
            container[i].GetComponent<Image>().color = Color.white;

        }

    }

    // Update is called once per frame
    void Update() {
        if (open) {
            this.transform.localScale = new Vector3(1, 1, 1);
        }
        else {
            this.transform.localScale = new Vector3(0, 0, 0);
        }

        if (choosed_item!=-1) {
            for (int i = 0; i < items.Count; i++) {
                images[i].color = new Color(255, 255, 255, 1);
            }
            Debug.Log("Show all items"+choosed_item);
            container[choosed_item].GetComponent<Image>().color = Color.yellow;
                //GetComponent<Image>().color = new Color(254, 246, 33, 1);
        }

    }
    public void ChooseItem(int idx) {
        if (choosed_item != -1) return;
        choosed_item = idx;
        PowerupManager.Instance.BuyItem(items[idx], true);
    }

}