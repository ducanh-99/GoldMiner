using System.Collections;
using System.Collections.Generic;
using UB.Simple2dWeatherEffects.Standard;
using UnityEngine;
using UnityEngine.UI;

public class InLevelManager : MonoBehaviour
{
	public Level level;


	public int time, distance,score, dynamite;
	public bool pause;
	public bool is_passed;
	public bool commit_pass;

	private static InLevelManager instance;
	public GemsCollector gems_collector;

	public float des_pos = -1;
	D2FogsPE fog = null;
	public int FOG_CHANGE_CYCLE = 10;
	public static InLevelManager Instance{
		get
		{
			if (instance == null) {
				instance = new GameObject("InLevelManager").AddComponent<InLevelManager>();
				DontDestroyOnLoad(instance.gameObject);
				instance.SetupLevel();
			}

			return instance;
		}
	}

	public void CommitPassLevel() {
		commit_pass = true;
    }

	public void SetDestinationPos(float f) {
		Debug.Log("Des Pos " + f);
		this.des_pos = f;
    }

	public void SetPlayerPos(float f) {
		if (this.des_pos == -1) distance = 2000;
		this.distance =((int) (this.des_pos-f))*20;
    }
	public void EnterLevel() {
		StartCoroutine("CountDown");
		SoundManager soundManager = SoundManager.Instance();
		if (soundManager != null) {
			Debug.Log("Load Timer Sound");
		}
	}

	public void SetupLevel() {
		is_passed = false;
		commit_pass = false;
		instance.level = LevelsManager.Instance.GetCurrentLevel();
		instance.time = instance.level.time;
		instance.score = 0;
	}

	public void Pause() {
		if (!pause) {
			Time.timeScale = 0;
			pause = true;
		}
    }

	public void SetGemsCollector(GemsCollector gems) {
		if (gems != null) Debug.Log("Gems Collector Script Not nUll");	
		this.gems_collector = gems;
    }



	public void UnPause() {
		if (pause) {
			Time.timeScale = 1;
			pause = false;
		}
    }
	public void GetDataFromPlayerManager() {
		dynamite = PlayerManager.Instance.GetDynamite();
    }
    public void ReturnDataForPlayerManager() {
		PlayerManager.Instance.SetDynamite(dynamite);
    }

	public void AddDynamite(int number) {
		this.dynamite += number;
    }
	public void Earning(ValueObject value) {
	//	Debug.Log("Value Tag :" + value.tag);
		int value_score = value.score;
		if (value.tag.Contains("Diamond")) {
			value_score *= PowerupManager.Instance.POLISH_DIAMOND_FACTOR;
        }
		else if (value.tag.Contains("Stone")) {
			value_score *= PowerupManager.Instance.STONE_COLLECTION_FACTOR;
		} 
		else if(value.tag.Contains("AladdinLamp")){
			GameObject game_obj = GameObject.FindWithTag("AladdinLampModal");
			if (game_obj == null) {
				Debug.Log("Setting Modal Object Null ");
				return;
			}

			game_obj.GetComponent<AladdinLampModal>().SwitchModal();
		}
		else if (value.tag.Contains("Gem")) {
			Debug.Log("Collect A Gem " + value.tag);
			if (this.gems_collector != null) {
				this.gems_collector.CollectGem(value.tag);
            }
        }
		score += value_score;
    }
		


	public IEnumerator CountDown() {
		while (time>0) {
			time--;
			if (time % FOG_CHANGE_CYCLE == 0) ChangeFog();
			yield return new WaitForSeconds(1);
		}
		if (time <= 0) TimeOut();
	}

	public void SetupFog(D2FogsPE fog) {
		this.fog = fog;
    }

	public void ChangeFog() {
		if (fog == null) return;
		System.Random random = new System.Random();
		fog.Density = (float)random.Next(20,150) / 100;
		fog.Size = (float)random.Next(100, 250) / 100;
		fog.HorizontalSpeed = (float)random.Next(40, 200) / 100;
		Debug.Log(fog.Density + " " + fog.Size + "  " + fog.HorizontalSpeed);
	}

	public void CheckPass() {
		if (level.required_score <= score) {
			is_passed = true;
			level.star = Random.Range(1, 3);
			PlayerManager.Instance.AddMoney(score);
		}
		else {
			FailLevel();

		}
	}

	public void AddTime(int time) {
		this.time += time;
    }
	public void ReachDestination() {
		CheckPass();
		SoundManager soundManager = SoundManager.Instance();
		if (soundManager != null) {
			soundManager.PlaySound((int)SoundManager.Sound.Barrow_Move, true, true);
			soundManager.PlaySound((int)SoundManager.Sound.End_Level, false, false);
		}

		SceneHandler.Instance.OpenScene(SceneHandler.LEVEL_RESULT_SCENE);
	}

	public int GetScore() {
		return score;
    }

	public void FailLevel() {
		level.star = 0;
		is_passed = false;
    }
	public void TimeOut() {
		FailLevel();
		SoundManager soundManager = SoundManager.Instance();
		if (soundManager != null) {
			soundManager.PlaySound((int)SoundManager.Sound.Barrow_Move, true, true);
			soundManager.PlaySound((int)SoundManager.Sound.End_Level, false, false);
		}
		SceneHandler.Instance.OpenScene(SceneHandler.LEVEL_RESULT_SCENE);
	}



}
