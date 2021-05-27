using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StoreItem : MonoBehaviour
{
    public Text name_text;
    public Text des_text;
    public Button buy_btn;
    public Image image;
    public Text price_text;

    public Powerup item;
    // Start is called before the first frame update
    void Start()
    {
        buy_btn.onClick.AddListener(BuyItem);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateSelectedItem(Powerup item) {
        this.item = item;
        name_text.text = item.name;
        des_text.text = item.description;
        price_text.text = "" + item.price;
        image.sprite= Resources.Load(item.sprite, typeof(Sprite)) as Sprite;
        buy_btn.GetComponentInChildren<Text>().text = item.is_bought ?
            "Đã mua"
            :
            item.price > PlayerManager.Instance.GetMoney()?
            "Không đủ tiền"
            :
            "Mua";
    }

    public void BuyItem() {
        SoundManager soundManager = SoundManager.Instance();
        if (soundManager != null) {
            soundManager.PlaySound(
                 item.is_bought || item.price > PlayerManager.Instance.GetMoney() ? 
                    (int)SoundManager.Sound.Button_Disable
                    :
                    (int)SoundManager.Sound.Button_Click);
        }
        if (item.is_bought) return;
        PowerupManager.Instance.BuyItem(item, false);
        
    }
}
