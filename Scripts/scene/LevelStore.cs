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
    public GameObject canvas;

    public Text item_des_text;
    public Text wallet_text;
    public int choose_index;

    public int item_count;
    public List<Powerup> items;
    public List<GameObject> items_go;

    public Rect container_dimensions;
    public Rect item_dimensions;

    public Vector2 spacing;
    public float remain_choose_time=0;
    public float remain_buy_time = 0;
    public static float DELAY_TIME = 0.3f;

    public Text[] item_text = new Text[4];
    void Start() {

        btn_start.onClick.AddListener(PressBtnStart);

        item_count = PowerupManager.Instance.GetSaleCount();
        items = PowerupManager.Instance.ChoosePowerUpToSell();

        choose_index = 0;

        LoadStore();
    }

    

    private void PressBtnStart() {
        SceneHandler.Instance.OpenScene(SceneHandler.LEVEL_PLAY_SCENE);
    }

    

    void LoadStore() {
        for (int i = 0; i < items.Count; i++) {
            item_text[i].text = items[i].name;
        }

    }

    // Update is called once per frame
    void FixedUpdate() {
        wallet_text.text = "You have " + PlayerManager.Instance.GetMoney();
        ChooseItem();
        BuyItem();
    }

    void ChooseItem() {

      //  Debug.Log("Delay Time " + remain_choose_time + " , " + Time.deltaTime);
        remain_choose_time -= Time.deltaTime;

        if (remain_choose_time > 0) return;
        if (Input.GetKey(KeyCode.LeftArrow)) {
            choose_index = (choose_index + item_count - 1) % item_count;
            remain_choose_time = DELAY_TIME;
        }
        else if (Input.GetKey(KeyCode.RightArrow)) {
            choose_index = (choose_index + 1) % item_count;
            remain_choose_time = DELAY_TIME;
        }


        Powerup choosed_item = items[choose_index];
        for (int i = 0; i < items_go.Count; i++) {
          
            items_go[i].GetComponent<StoreItem>().price_text.text =
                    items[i].is_bought ? "Bought" : items[i].price + "";
            items_go[i].GetComponent<StoreItem>().price_text.color = 
                    i == choose_index ? Color.yellow : Color.white;
        }

        item_des_text.text = choosed_item.name + " :" + choosed_item.description;
        item_des_text.color = Color.yellow;
    }

    void BuyItem() {
        remain_buy_time -= Time.deltaTime;

        if (remain_buy_time > 0) return;

        if ((Input.GetKey(KeyCode.KeypadEnter) || Input.GetKey("enter"))) {
            Debug.Log("Press Enter");
            Powerup choosed_powerup = items[choose_index];
            remain_buy_time = DELAY_TIME;
            if (!choosed_powerup.is_bought ) {
                PowerupManager.Instance.BuyItem(choosed_powerup);
            }
        }
    }
}