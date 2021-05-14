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

    public AudioSource audioSource;
    public AudioClip audioBuy;
    public AudioClip audioChangeItem;

    public float remain_choose_time=0;
    public float remain_buy_time = 0;
    public static float DELAY_TIME = 0.3f;

    public Text[] item_text = new Text[4];

    public Text cur_item_des_text;
    public Image cur_item_image;
    public Text cur_item_price_text;
    public Text cur_item_buy_text;

    void Start() {
        btn_start.onClick.AddListener(PressBtnStart);
        item_count = PowerupManager.Instance.GetSaleCount();
        items = PowerupManager.Instance.ChoosePowerUpToSell();

        choose_index = 0;

        LoadItemList();
    }


    private void PressBtnStart() {
        SceneHandler.Instance.OpenScene(SceneHandler.LEVEL_PLAY_SCENE);
    }
    
    void LoadItemList() {
        for (int i = 0; i < items.Count; i++) {
            item_text[i].text = items[i].name;
        }
    }

    // Update is called once per frame
    void FixedUpdate() {
        wallet_text.text = "" + PlayerManager.Instance.GetMoney();
        ChooseItem();
        BuyItem();
    }

    void ChooseItem() {
      //  Debug.Log("Delay Time " + remain_choose_time + " , " + Time.deltaTime);
        remain_choose_time -= Time.deltaTime;

        if (remain_choose_time > 0) return;
        if (Input.GetKey(KeyCode.UpArrow)) {
            audioSource.PlayOneShot(audioChangeItem);

            choose_index = (choose_index + item_count - 1) % item_count;
            remain_choose_time = DELAY_TIME;
        }
        else if (Input.GetKey(KeyCode.DownArrow)) {
            audioSource.PlayOneShot(audioChangeItem);

            choose_index = (choose_index + 1) % item_count;
            remain_choose_time = DELAY_TIME;
        }

        for (int i = 0; i < items.Count; i++) {
            item_text[i].fontStyle = i == choose_index? FontStyle.BoldAndItalic:FontStyle.Normal;
        }

        Powerup choosed_item = items[choose_index];
        cur_item_des_text.text = "" + choosed_item.description;
        cur_item_price_text.text = "" + choosed_item.price;
        cur_item_buy_text.text = choosed_item.is_bought ? "Đã mua!" : "Nhấn ENTER để mua!";
        cur_item_image.sprite = Resources.Load(choosed_item.sprite, typeof(Sprite)) as Sprite;
    }

    void BuyItem() {
        remain_buy_time -= Time.deltaTime;

        if (remain_buy_time > 0) return;

        if ((Input.GetKey(KeyCode.KeypadEnter) || Input.GetKey("enter"))) {
            audioSource.PlayOneShot(audioBuy);

            Debug.Log("Press Enter");
            Powerup choosed_powerup = items[choose_index];
            remain_buy_time = DELAY_TIME;
            if (!choosed_powerup.is_bought ) {
                PowerupManager.Instance.BuyItem(choosed_powerup, false);
            }
        }
    }
}