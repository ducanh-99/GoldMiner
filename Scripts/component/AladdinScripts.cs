using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AladdinScripts : MonoBehaviour
{
   // public GameObject aladinLamp;
   public int item_count;
   public bool pause;
   public GameObject aladdinLamp;
   public GameObject option1;
   public GameObject option2;
   public GameObject option3;

  public Button button1;   
  public Button button2;   
  public Button button3;   
  public Button imgButton1;   
  public Button imgButton2;   
  public Button imgButton3;   
  public Button[] itemButton = new Button[3];
   public List<Powerup> items;
   void Start(){
   aladdinLamp.SetActive(false);
   pause= false;
   item_count = LampManager.Instance.GetSaleCount();
   items = LampManager.Instance.ChoosePowerUpToSell();
   LoadItemList();
   button1.onClick.AddListener(ChooseOption1);
   button2.onClick.AddListener(ChooseOption2);
   button3.onClick.AddListener(ChooseOption3);
   }
//    void Update(){

//    }
   void LoadItemList() {
        // for (int i = 0; i < items.Count; i++) {
        //     // itemButton[i].text = items[i].sprite;
        //    itemButton[i].sprite = Resources.Load( items[i].sprite, typeof(Sprite)) as Sprite;
        // }

    }
   void Update(){
      if(Input.GetKeyDown(KeyCode.LeftShift)){
          InLevelManager.Instance.Pause();
          pause = true;
      }
      
      
      if (pause) {
            aladdinLamp.SetActive(true);
        }
        else {
            aladdinLamp.SetActive(false);
        }
      // if(option1.Button.onClick.AddListener(ChooseItem));
   }
   void FixedUpdate() {
        // ChooseItem();
        BuyItem();
    }
    
    void ChooseOption1(){
      Debug.Log("Button1");
      InLevelManager.Instance.AddTime(20);;
       pause = false;
       InLevelManager.Instance.UnPause();
    }
    void ChooseOption2(){
      Debug.Log("Button2");
      InLevelManager.Instance.AddTime(20);;
       pause = false;
       InLevelManager.Instance.UnPause();
    }
    void ChooseOption3(){
      Debug.Log("Button3");
      InLevelManager.Instance.AddTime(20);;
       pause = false;
       InLevelManager.Instance.UnPause();
    }
    void ChooseItem() {

       Debug.Log("Option123");
       pause = false;
       InLevelManager.Instance.UnPause();
      //  return true;
      //  Debug.Log("Delay Time " + remain_choose_time + " , " + Time.deltaTime);
      //   remain_choose_time -= Time.deltaTime;

      //   if (remain_choose_time > 0) return;
      //   if (Input.GetKey(KeyCode.UpArrow)) {
      //       audioSource.PlayOneShot(audioChangeItem);
      //       choose_index = (choose_index + item_count - 1) % item_count;
      //       remain_choose_time = DELAY_TIME;
      //   }
      //   else if (Input.GetKey(KeyCode.DownArrow)) {
      //       audioSource.PlayOneShot(audioChangeItem);
      //       choose_index = (choose_index + 1) % item_count;
      //       remain_choose_time = DELAY_TIME;
      //   }

      //   for (int i = 0; i < items.Count; i++) {
      //       item_text[i].fontStyle = i == choose_index? FontStyle.BoldAndItalic:FontStyle.Normal;
      //   }

      //   Powerup choosed_item = items[choose_index];
      //   cur_item_des_text.text = "" + choosed_item.description;
      //   cur_item_price_text.text = "" + choosed_item.price;
      //   cur_item_buy_text.text = choosed_item.is_bought ?
      //           "Đã mua!"
      //           :
      //           "Nhấn ENTER để mua!";
      //   cur_item_image.sprite = 
      //       Resources.Load( choosed_item.sprite, typeof(Sprite)) as Sprite;
    }

    void BuyItem() {
      //   remain_buy_time -= Time.deltaTime;

      //   if (remain_buy_time > 0) return;

      //   if ((Input.GetKey(KeyCode.KeypadEnter) || Input.GetKey("enter"))) {
      //       audioSource.PlayOneShot(audioBuy);

      //       Debug.Log("Press Enter");
      //       Powerup choosed_powerup = items[choose_index];
      //       remain_buy_time = DELAY_TIME;
      //       if (!choosed_powerup.is_bought ) {
      //           PowerupManager.Instance.BuyItem(choosed_powerup);
      //       }
      //   }
    }
}
