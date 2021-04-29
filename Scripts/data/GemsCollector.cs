using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class GemType {
	public int id;
	public string sprite;
	public GemType(int id,string sprite) {
		this.id = id;
		this.sprite = sprite;
    }
}
public class GemsCollector : MonoBehaviour {

	public const int GEMS_TYPE = 5;
	public bool complete_collect;

	public int collect_status ;
	public static Dictionary<string, GemType> dict = new Dictionary<string, GemType>()
	{
		{"GemGreen",new GemType(0,"gem_green") },
		{"GemOrange", new GemType(1,"gem_orange")},
		{"GemRed", new GemType(2,"gem_red") },
		{"GemViolet", new GemType(3,"gem_violet") },
		{"GemYellow",  new GemType(4,"gem_yellow") }
	};
	public GemsCollector() {
		collect_status = 0;
    }

	public Image[] gems_go = new Image[GEMS_TYPE];

	public void CheckCompleteCollect(int type) {
		if (collect_status == -1) return;

		collect_status |= 1 << type;
		Debug.Log("Collect Status :"+ collect_status);
		Debug.Log("Complete Status :" + ((1 << GEMS_TYPE) - 1));
		if (collect_status == (1 << GEMS_TYPE) - 1) {
			InLevelManager.Instance.Earning(new ValueObject { tag = "bonus_gems_collector", score = 3000 });
				 = -1;
        }
    }

	public void CollectGem(string tag) {
        // Debug.Log("Find Tag :" + tag);

        if (dict.ContainsKey(tag)) {
			GemType gem_type = dict[tag];
			Debug.Log("Map GemType To    " + gem_type.id + gem_type.sprite);

			//Fix cứng hình ảnh đá quý trong giao diện prefab gems_collector để dễ căn chỉnh tỷ lệ: 
			// Thu thập loại nào => set opacity = 1 cho hình ảnh tương ứng.
			//  gems_go[gem_type.id].sprite=
			//	 Resources.Load(gem_type.sprite, typeof(Sprite)) as Sprite;
			Image gems = gems_go[gem_type.id];
			gems.color= new Color(255, 255,255,1);
			CheckCompleteCollect(gem_type.id);
		};
    }



}
