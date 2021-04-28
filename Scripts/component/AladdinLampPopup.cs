using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class AladdinLampPopup : MonoBehaviour {
    public int choose_index;
    public bool open;
    public int item_count;
    public List<Powerup> items;

    public AudioSource audioSource;
    public AudioClip audioBuy;
    public AudioClip audioChangeItem;

    public Image[] images = new Image[4];
    public Image[] container = new Image[4];

    public GameObject UI;

    public float remain_choose_time = 0;
    public static float DELAY_TIME = 200f;
    public bool is_choosed_item = false;
    void Start() {
        UI.SetActive(false);
        open = false;

    }

    public void Close() {
        open = false;
        choose_index = 0;
        Debug.Log("On Close");
        InLevelManager.Instance.UnPause();
    }

    void LoadItemList() {
        for (int i = 0; i < items.Count; i++) {
            images[i].sprite = Resources.Load(items[i].sprite, typeof(Sprite)) as Sprite;
            images[i].color= new Color(255, 255, 255, 0);
        }

    }

    // Update is called once per frame
    void Update() {
  
        if (InLevelManager.Instance.open_lamp_yet) {
            InLevelManager.Instance.open_lamp_yet = false;
            InLevelManager.Instance.Pause();
            open = true;
            is_choosed_item = false ;
            item_count = PowerupManager.Instance.GetSaleCount();
            items = PowerupManager.Instance.ChoosePowerUpToSell();
            choose_index = 0;
            LoadItemList();
            Debug.Log("Open Modal " + open);
        };

        if (!open) return;
        remain_choose_time -=1;
        if (remain_choose_time > 0) return;
        remain_choose_time = 0;
        if (Input.GetKey(KeyCode.UpArrow) && open && !is_choosed_item) {
            Debug.Log("Press Up Arrow on Lamp");
            choose_index = (choose_index + item_count - 1) % item_count;
            remain_choose_time = DELAY_TIME;
        }
        else if (Input.GetKey(KeyCode.DownArrow) && open && !is_choosed_item) {
            choose_index = (choose_index + 1) % item_count;
            remain_choose_time = DELAY_TIME;
        }
        else if ((Input.GetKey(KeyCode.KeypadEnter) || Input.GetKey("enter")) && open) {
            Debug.Log("FUCK FUCK FUCK");
            remain_choose_time = DELAY_TIME;
            if (is_choosed_item) Close();
            else {
                is_choosed_item = true;
                ChooseItem();
            }
            
        };

        this.scaleContainers();

        if (open) {
            UI.SetActive(true);
        }
        else {
            UI.SetActive(false);
        }

    }

    public void scaleContainers() {
        for (int i = 0; i < items.Count; i++) {
            container[i].transform.localScale =
                i == choose_index ?
                    new Vector3(1.4f, 1.4f, 1.0f)
                    :
                    new Vector3(1.0f, 1.0f, 1.0f);
        }
    }

    public void ChooseItem() {
        for (int i = 0; i < items.Count; i++) {
            images[i].color = new Color(255, 255, 255, 1);
            images[i].transform.localScale=
                i == choose_index ?
                    new Vector3(1.2f, 1.2f, 1.0f)
                    :
                    new Vector3(1.0f, 1.0f, 1.0f);
        };

        PowerupManager.Instance.BuyItem(items[choose_index], true);
    }

}