using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


public class PlayerManager : MonoBehaviour {
	public static string SETUP_PLAYER_KEY = "setup_player";
	private static PlayerManager instance;
	public static string FILE_PATH = Application.persistentDataPath + "/player.dat";

	private  int money;
	private int dynamite;
	public static PlayerManager Instance {
		get {
			if (instance == null) {
				instance = new GameObject("PlayerManager").AddComponent<PlayerManager>();
				DontDestroyOnLoad(instance.gameObject);
			}
			return instance;
		}
	}

	private void Awake() {
		LoadFromFile();
	}



	public void Setup() {
		if (PlayerPrefs.HasKey(SETUP_PLAYER_KEY)) return;

		money = 1000;
		dynamite = 4;

		PlayerPrefs.SetInt(SETUP_PLAYER_KEY, 1);
	}

	public void AddMoney(int earning) {
		money += earning;
    }

	public int GetMoney() {
		return money;
    }

	public int GetDynamite() {
		return dynamite;
    }

	public void SetDynamite(int dynamite) {
		this.dynamite = dynamite;
    }


	public void Reset() {
	
		if (PlayerPrefs.HasKey(SETUP_PLAYER_KEY))
			PlayerPrefs.DeleteKey(SETUP_PLAYER_KEY);
		Setup();
	}




	private void SaveToFile() {
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = file = File.Open(FILE_PATH, FileMode.OpenOrCreate);
		PlayerModel player = new PlayerModel(money,dynamite);
		bf.Serialize(file, player);
		file.Close();
	}

	private void LoadFromFile() {
	
		if (File.Exists(FILE_PATH)) {
		
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(FILE_PATH, FileMode.Open);
			PlayerModel player = (PlayerModel)bf.Deserialize(file);

			money = player.money;
			dynamite = player.dynamite;
		
			file.Close();
		}
		else {
			Setup();
		};
	}

	private void OnDestroy() {
		SaveToFile();
	}
}
