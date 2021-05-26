using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InLevelManager : MonoBehaviour
{
	public Level level;


	public int time, distance, score, dynamite;
	public bool pause;
	public bool is_passed;

	private static InLevelManager instance;
	public GemsCollector gems_collector;
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
	public void EnterLevel() {
		StartCoroutine("CountDown");
		SoundManager soundManager = SoundManager.Instance();
		if (soundManager != null) {
			Debug.Log("Load Timer Sound");
			//soundManager.PlaySound((int)SoundManager.Sound.Timer,true);
		}
	}

	public void SetupLevel() {
		instance.level = LevelsManager.Instance.GetCurrentLevel();
		instance.time = instance.level.time;
		instance.distance = instance.level.distance;
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
			yield return new WaitForSeconds(1);
		}
		if (time <= 0) TimeOut();
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
