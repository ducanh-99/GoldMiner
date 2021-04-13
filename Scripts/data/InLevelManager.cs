using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InLevelManager : MonoBehaviour
{
	public Level level;

	
	public  int time, distance, score;
	public bool is_passed;

	private static InLevelManager instance;

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
	}

	public void SetupLevel() {
		instance.level = LevelsManager.Instance.GetCurrentLevel();
		instance.time = instance.level.time;
		instance.distance = instance.level.distance;
		instance.score = 0;
	}

	public void Earning(ValueObject value) {
		score += value.score;
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
		}
		else {
			is_passed = false;

		}
	}


	public int GetScore() {
		return score;
    }
	public void TimeOut() {
		CheckPass();
		Debug.Log("Score :" + score);
		Debug.Log("Time :" + time);
		Debug.Log("Pass :" + is_passed);

		SceneHandler.Instance.OpenScene(SceneHandler.LEVEL_RESULT_SCENE);
    }



}
