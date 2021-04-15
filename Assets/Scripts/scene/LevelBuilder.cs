using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    public GameObject[] level_container = new GameObject[10];
    // Start is called before the first frame update
    void Start()
    {
        int idx = LevelsManager.Instance.GetFurthestLevel();
        Instantiate(level_container[idx], new Vector3(0, 0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
