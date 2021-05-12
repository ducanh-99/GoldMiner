using UnityEngine;
using UnityEngine.UI;

public class LevelEntry : MonoBehaviour {
    public Button btn_start;
    public Level level;
    public Text level_index_text;
    public Text score_text;
    public Text time_text;
    public Text distance_text;
    public Text dynamite_text;

    // Start is called before the first frame update
    void Start() {
        Debug.Log("Start Level Entry ");
        btn_start.onClick.AddListener(PressBtnStart);
        level = LevelsManager.Instance.GetCurrentLevel();

        Debug.Log("Level Entry : " + level.ToString());
        level_index_text.text = "" + (level.index);
        score_text.text = "" + level.required_score;
        time_text.text = "" + level.time;
        distance_text.text = "" + level.distance + "m";
        dynamite_text.text = "" + InLevelManager.Instance.dynamite;
    }

    private void PressBtnStart() {
        InLevelManager.Instance.SetupLevel();
        SceneHandler.Instance.OpenScene(SceneHandler.LEVEL_STORE_SCENE);
    }
}