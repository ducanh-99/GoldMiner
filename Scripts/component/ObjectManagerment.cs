using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueObject
{
    public int score { get; set; }
    public float weight { get; set; }
}
public class ObjectManagerment
{
    private static ObjectManagerment instance;
    private static Dictionary<string, ValueObject> ObjectDictionary = new Dictionary<string, ValueObject>()
    {
        {"BigGold",  new ValueObject{score=200, weight=10}},
        {"MediumGold", new ValueObject{score=100, weight=5}}
    };


    private ObjectManagerment() { }
    public static ObjectManagerment GetInstance()
    {
        if (instance == null)
        {
            instance = new ObjectManagerment();
        }
        return instance;
    }
    public ValueObject test(string tag)
    {
        if (ObjectDictionary.ContainsKey(tag))
        {
            return ObjectDictionary[tag];
        }
        return null;
    }
}
