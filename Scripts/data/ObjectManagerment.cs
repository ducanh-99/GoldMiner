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
        {"GoldSmall",  new ValueObject{score=50, weight=1}}, // GoldSmall's Weight Is Base Weight;
        {"GoldMedium",  new ValueObject{score=100, weight=2}},
        {"GoldBig", new ValueObject{score=250, weight=5}},
        {"GoldHuge",  new ValueObject{score=500, weight=10}},

        {"StoneSmall",  new ValueObject{score=5, weight=1}},
        {"StoneMedium", new ValueObject{score=10, weight=5}},
        {"StoneBig",  new ValueObject{score=20, weight=10}},

        {"SkeletonBody",  new ValueObject{score=10, weight=1}},
        {"SkeletonSkull", new ValueObject{score=10, weight=1}},
        {"SkeletonLimb",  new ValueObject{score=10, weight=1}},

        {"GemGreen",  new ValueObject{score=200, weight=1}},
        {"GemYellow", new ValueObject{score=200, weight=1}},
        {"GemRed",  new ValueObject{score=200, weight=1}},
        {"GemOrange",  new ValueObject{score=200, weight=1}},
        {"GemViolet", new ValueObject{score=200, weight=1}},


        {"Diamond",  new ValueObject{score=600, weight=1}},
        {"StoneDiamond",  new ValueObject{score=610, weight=5}},

        {"Mouse",  new ValueObject{score=10, weight=1}},
        {"MouseDiamond",  new ValueObject{score=610, weight=1}},
        {"MouseMiner", new ValueObject{score=50, weight=5}},
        {"SecretBag",  new ValueObject{score=200, weight=3}},
        {"TreasureChest",  new ValueObject{score=500, weight=5}},
  
        {"OreSeam", new ValueObject{score=10, weight=1}},
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
