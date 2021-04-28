using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup
{

    public string tag { get; set; }
    public string name { get; set; }
    public int price { get; set; }

    public bool is_bought { get; set; }
    public string description { get; set; }

    public string sprite { get; set; }

    public Powerup(string tag,string name,string description,int price,string sprite) {
        this.tag = tag;
        this.name = name;
        this.price = price;
        this.is_bought = false;
        this.description = description;
        this.sprite = sprite;
    }
}
public class PowerupManager : MonoBehaviour
{

    public int STONE_COLLECTION_FACTOR=1;
    public int POLISH_DIAMOND_FACTOR=1;
    public  int TIME_PLUS_ADDITION=15;
    public int MINER_STRENGTH_FACTOR=1;
    public int BARROW_SPEED_FACTOR=1;
    public int LUCKY_FLOWER_FACTOR=1;

    private static PowerupManager instance;
    public static int SALE_COUNT = 4;
    private static List<Powerup> sales = new List<Powerup>();


    private static Dictionary<string, Powerup> powers_dict = new Dictionary<string, Powerup>()
    {
        {
            "Dynamite",
            new Powerup("Dynamite","Thuốc nổ","Ném thuốc nổ để phá hủy vật thể đang kéo lên!",100,"dynamite")},
        {
            "StoneCollection",
            new Powerup("StoneCollection","Bộ sưu tập đá","Tăng giá trị của đá lên 3 lần",200,"stone_collection")
        },
        {
            "LuckyFlower",
            new Powerup("LuckyFlower","Hoa may mắn","Tăng xác xuất nhận được đồ giá trị trong túi bí mật",100,"lucky_flower")
        },
        {
            "Oil",
            new Powerup("Oil","Dầu bôi trơn","Tăng tốc độ di chuyển của xe goòng(nhanh về đích)",100,"oil")
        },
        {
            "PolishDiamond",
            new Powerup("PolishDiamond","Đánh bóng kim cương","Tăng giá trị kim cương lên 2 lần",200,"polish_diamond")
        },
        {
            "PowerDrink",
            new Powerup("PowerDrink","Volka","Khỏe như gấu, tăng tốc độ kéo vật",100,"power_drink")
        },
        {
            "TimePlus",
            new Powerup("TimePlus","Đồng hồ cát","Tăng thời gian thêm 20s",200,"time_plus")
        }
    };



    public static PowerupManager Instance {
        get {
            if (instance == null) {
                instance = new GameObject("PowerupManager").AddComponent<PowerupManager>();
                DontDestroyOnLoad(instance.gameObject);
            }
            return instance;
        }
    }

    public bool BuyItem(Powerup item,bool free) {
        if (item.price > PlayerManager.Instance.GetMoney()) return false;
        item.is_bought = true;
        PlayerManager.Instance.AddMoney(-item.price);
        Debug.Log("Buy Item "+ item.name);
        switch (item.tag) {
            case "StoneCollection":
                STONE_COLLECTION_FACTOR = 2;
                break;
            case "PolishDiamond":
                POLISH_DIAMOND_FACTOR = 2;
                break;
            case "TimePlus":
                InLevelManager.Instance.AddTime(TIME_PLUS_ADDITION);
                break;
            case "PowerDrink":
                MINER_STRENGTH_FACTOR = 8;
                break;
            case "Oil":
                BARROW_SPEED_FACTOR = 3;
                break;
            case "Dynamite":
                InLevelManager.Instance.AddDynamite(1);
                break;
            case "LuckyFlower":
                LUCKY_FLOWER_FACTOR = 3;
                break;

            default:
                break;
        }
        return true;
    }
    public int GetSaleCount() {
        return SALE_COUNT;
    }

    public void ResetPowerUp() {
        STONE_COLLECTION_FACTOR = 1;
        POLISH_DIAMOND_FACTOR = 1;
        TIME_PLUS_ADDITION = 15;
        MINER_STRENGTH_FACTOR = 1;
        BARROW_SPEED_FACTOR = 1;
        LUCKY_FLOWER_FACTOR = 1;

        foreach (KeyValuePair<string, Powerup> entry in powers_dict) {
            entry.Value.is_bought = false;
        }
    }

    public List<Powerup> GetSaleItems() {
        return sales;
    }
    public List<Powerup> ChoosePowerUpToSell() {

        ResetPowerUp();
        sales = new List<Powerup>();
        List<Powerup> powers_l = new List<Powerup>(powers_dict.Values);
        int last_i = 0;
        int temp;
        int powers_count = powers_dict.Count;
        for (int i = 0; i < SALE_COUNT; i++) {
            temp = Random.Range(last_i, powers_count - (SALE_COUNT - i)+1);
    
            sales.Add( powers_l[temp]);
            last_i = temp + 1;
          
        };
        return sales;
    }



    public Powerup GetPowerUp(string tag)
    {
     
        if (powers_dict.ContainsKey(tag))
        {
            return powers_dict[tag];
        }
        return null;
    }
}
