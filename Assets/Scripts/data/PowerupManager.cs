using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup
{
    public string name { get; set; }
    public int price { get; set; }

    public string description { get; set; }

    public Powerup(string name,string description,int price) {
        this.name = name;
        this.price = price;
        this.description = description;
    }
}
public class PowerupManager : MonoBehaviour
{
    private static PowerupManager instance;

    private static int[] selled_powerup_indexes = new int[4];
    private static Dictionary<string, Powerup> dict = new Dictionary<string, Powerup>()
    {
        { "Dynamite",new Powerup("Thuốc nổ","Ném thuốc nổ để phá hủy vật thể đang kéo lên!",100)},
        {"StoneCollection",new Powerup("Bộ sưu tập đá","Tăng giá trị của đá lên 3 lần",200)},
        {"LuckyFlower",new Powerup("Hoa may mắn","Tăng xác xuất nhận được đồ giá trị trong túi bí mật",100) },
        {"Oil",new Powerup("Dầu bôi trơn","Tăng tốc độ di chuyển của xe goòng(nhanh về đích)",100) },
        {"PolishDiamond",new Powerup("Đánh bóng kim cương","Tăng giá trị kim cương lên 2 lần",200) },
        {"PowerDrink",new Powerup("Volka","Khỏe như gấu, tăng tốc độ kéo vật",100) },
        {"TimePlus",new Powerup("Đồng hồ cát","Tăng thời gian thêm 20s",200) }
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

    public void ChoosePowerUpToSell() {

    }



    public Powerup GetPowerUp(string tag)
    {
        Debug.Log("Find Tag :" + tag);
        if (dict.ContainsKey(tag))
        {
            return dict[tag];
        }
        return null;
    }
}
