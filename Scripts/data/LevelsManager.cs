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
	public static string FILE_PATH = Application.persistentDataPath + "/levels.dat";

	public List<Level> list;
	public int furthest_level_index;
	public int choosed_level_index;

	public static LevelsManager Instance{
		get {
			if (instance == null) {
				instance = new GameObject("LevelsManager").AddComponent<LevelsManager>();
				DontDestroyOnLoad(instance.gameObject);
			}
			return instance;
		}
	}

    private void Awake() {
	
		choosed_level_index = 1;
		LoadFromFile();
	
    }



	public void Setup() {
		if (PlayerPrefs.HasKey(SETUP_LEVEL_KEY)) return;

		list = new List<Level>();
		list.Add(new Level(1, 2000, 2000, 180));
		list.Add(new Level(2, 2250, 2000, 1000));
		list.Add(new Level(3, 2500, 2000, 100));
		list.Add(new Level(4, 3000, 2000, 1000));
		list.Add(new Level(5, 3250, 2000, 1000));
		list.Add(new Level(6, 3500, 2000, 1000));
		list.Add(new Level(7, 4000, 2000, 1000));
		list.Add(new Level(8, 4250, 2000, 1000));
		list.Add(new Level(9, 4500, 2000, 1000));
		list.Add(new Level(10,5000, 2000, 1000));
		furthest_level_index = 1 ;
		choosed_level_index = 1;

		PlayerPrefs.SetInt(SETUP_LEVEL_KEY, 1);
	}
	public void ChooseLevel(int index) {
		choosed_level_index = index;
    }

	public Level GetCurrentLevel() {

		return list[choosed_level_index-1];
    }

	public void Reset() {
		
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
		if (furthest_level_index<list.Count-1)
			furthest_level_index++;
		choosed_level_index = furthest_level_index;
    }

	public int GetLevelCount() {
		return list.Count;
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
	
		if (File.Exists(FILE_PATH)) {
		
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(FILE_PATH, FileMode.Open);
			LevelsData levels_data = (LevelsData)bf.Deserialize(file);

			list = levels_data.list;
			furthest_level_index = levels_data.furthest_level_index;
		//	Debug.Log("List " + list.Count);
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
