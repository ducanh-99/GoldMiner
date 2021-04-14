using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueObject
{
    public int score { get; set; }
    public float weight { get; set; }
}
public class ObjectManagerment : MonoBehaviour
{
    private static ObjectManagerment instance;
    private static Dictionary<string, ValueObject> ObjectDictionary = new Dictionary<string, ValueObject>()
    {
        {"GoldBig",  new ValueObject{score=200, weight=10}},
        {"GoldMedium", new ValueObject{score=100, weight=5}}
    };


    private ObjectManagerment() { }
    public static ObjectManagerment Instance {
        get {
            if (instance == null) {
                instance = new GameObject("ObjectManagerment").AddComponent<ObjectManagerment>();
                DontDestroyOnLoad(instance.gameObject);
            }
            return instance;
        }
    }
    public ValueObject GetValueObject(string tag)
    {
        Debug.Log("Find Tag :"+ tag);
        if (ObjectDictionary.ContainsKey(tag))
        {
            return ObjectDictionary[tag];
        }
        return null;
    }
}
