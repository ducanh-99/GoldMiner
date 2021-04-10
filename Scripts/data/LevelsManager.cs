using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


public class LevelsManager : MonoBehaviour
{
	public static string SETUP_LEVEL_KEY = "setup_level";
	private static LevelsManager instance;
	public static string FILE_PATH;

	public List<Level> list;
	public int furthest_level_index;
	public int choosed_level_index;

	public static LevelsManager Instance {
		get { return instance ?? (instance = new GameObject("LevelsManager").AddComponent<LevelsManager>()); }
	}

    private void Awake() {
		FILE_PATH = Application.persistentDataPath + "/levels.dat";
		choosed_level_index = 0;
		LoadFromFile();
		Debug.Log("Levels List" + list.Count);
    }



	public void Setup() {
		if (PlayerPrefs.HasKey(SETUP_LEVEL_KEY)) return;

		list = new List<Level>();
		list.Add(new Level(0, 100,200,10));
		list.Add(new Level(1, 100, 200, 20));
		list.Add(new Level(2, 100, 200, 30));
		list.Add(new Level(3, 100, 200, 40));
		list.Add(new Level(4, 100, 200, 50));
		furthest_level_index = 0 ;

		PlayerPrefs.SetInt(SETUP_LEVEL_KEY, 1);
	}
	public void ChooseLevel(int index) {
		choosed_level_index = index;
    }

	public Level GetCurrentLevel() {
		return list[choosed_level_index];
    }

	public void Reset() {
		Debug.Log("Levels : reset");
		if (PlayerPrefs.HasKey(SETUP_LEVEL_KEY))
			PlayerPrefs.DeleteKey(SETUP_LEVEL_KEY);
		Setup();
    }



	public List<Level> GetAllLevels() {
		return list;		
	}

	public int GetFurthestLevel() {
		return furthest_level_index;
    }

	public void NextLevel() {
		furthest_level_index++;
		choosed_level_index = furthest_level_index;
    }

	private void SaveToFile() {
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = file = File.Open(FILE_PATH, FileMode.OpenOrCreate);
		LevelsData levels_data = new LevelsData();
		levels_data.list = list;
		levels_data.furthest_level_index = furthest_level_index;
		bf.Serialize(file, levels_data);
		file.Close();
	}

	private void LoadFromFile() {
		Debug.Log("LoadFromFile");
		if (File.Exists(FILE_PATH)) {
			Debug.Log("File exist");
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(FILE_PATH, FileMode.Open);
			LevelsData levels_data = (LevelsData)bf.Deserialize(file);

			list = levels_data.list;
			furthest_level_index = levels_data.furthest_level_index;
		//	Debug.Log("List " + list.Count);
			file.Close();
		}
		else {
			Debug.Log("File Not Exist");
			Setup();
			Debug.LogError("Levels : error");
		};
	}

	private void OnDestroy() {
		SaveToFile();
    }
}
