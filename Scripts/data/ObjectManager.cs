using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueObject {
    public string tag { get; set; }
    public int score { get; set; }
    public float weight { get; set; }
}
public class ObjectManagerment : MonoBehaviour
{


    private static ObjectManagerment instance;
    private static float HOOK_SPEED = Hook.HOOK_SPEED;

    private static int MIN_DEFAULT_SCORE_OF_SECRECT_BAG = 20;
    private static int MAX_DEFAULT_SCORE_OF_SECRECT_BAG = 200;
    private static int MAX_ADD_SCORE_OF_SECRET_BAG = 600;
    private static float THRESHOLD_ADD_SCORE_OF_SECRET_BAG = 0.8f;
    private static float MIN_WEIGHT_OF_SECRECT_BAG = HOOK_SPEED * 0.1f;
    private static float MAX_WEIGHT_OF_SECRECT_BAG = HOOK_SPEED * 0.9f;



    private static Dictionary<string, ValueObject> dict = new Dictionary<string, ValueObject>()
    {
        {"GoldSmall",  new ValueObject{score =50, weight=HOOK_SPEED*0.2f}}, // GoldSmall's Weight Is Base Weight;
        {"GoldMedium",  new ValueObject{score=100, weight=HOOK_SPEED*0.4f}},
        {"GoldBig", new ValueObject{score=250, weight=HOOK_SPEED*0.6f}},
        {"GoldHuge",  new ValueObject{score=500, weight=HOOK_SPEED*0.6f}},

        {"StoneSmall",  new ValueObject{score=5, weight=HOOK_SPEED*0.5f}},
        {"StoneMedium", new ValueObject{score=10, weight=HOOK_SPEED*0.65f}},
        {"StoneBig",  new ValueObject{score=20, weight=HOOK_SPEED*0.8f}},

        {"SkeletonBody",  new ValueObject{score=10, weight=HOOK_SPEED*0.1f}},
        {"SkeletonSkull", new ValueObject{score=10, weight=HOOK_SPEED*0.1f}},
        {"SkeletonLimb",  new ValueObject{score=10, weight=HOOK_SPEED*0.1f}},

        {"GemGreen",  new ValueObject{score=200, weight=HOOK_SPEED*0.2f}},
        {"GemYellow", new ValueObject{score=200, weight=HOOK_SPEED*0.2f}},
        {"GemRed",  new ValueObject{score=200, weight=HOOK_SPEED*0.2f}},
        {"GemOrange",  new ValueObject{score=200, weight=HOOK_SPEED*0.2f}},
        {"GemViolet", new ValueObject{score=200, weight=HOOK_SPEED*0.2f}},


        {"Diamond",  new ValueObject{score=600, weight=HOOK_SPEED*0.2f}},
        {"StoneDiamond",  new ValueObject{score=610, weight=HOOK_SPEED*0.8f}},

        {"Mouse",  new ValueObject{score=10, weight=HOOK_SPEED*0.1f}},
        {"MouseDiamond",  new ValueObject{score=610, weight=HOOK_SPEED*0.1f}},
        {"MouseMiner", new ValueObject{score=50, weight=HOOK_SPEED*0.7f}},
        {"SecretBag",  new ValueObject{score=200, weight=HOOK_SPEED*0.5f}},
        {"TreasureChest",  new ValueObject{score=500, weight=HOOK_SPEED*0.8f}},

        {"OreSeam", new ValueObject{score=10, weight=HOOK_SPEED*0.1f}},

        {"AladdinLamp",  new ValueObject{score =0, weight=HOOK_SPEED*0.2f}},
    };


    private ObjectManagerment() { }
    public static ObjectManagerment Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("ObjectManagerment").AddComponent<ObjectManagerment>();
                instance.SetTags();
                DontDestroyOnLoad(instance.gameObject);
            }
            return instance;
        }
    }

   void SetTags() {
        foreach (KeyValuePair<string, ValueObject> ele1 in dict) {
            ele1.Value.tag = ele1.Key;
        }
   }

    public int RandomScoreForSecretBag() {
     //   Debug.Log("Lucky Factor :"+ PowerupManager.Instance.LUCKY_FLOWER_FACTOR);
        float p = Random.Range(0f, 1f) * PowerupManager.Instance.LUCKY_FLOWER_FACTOR;
        //Debug.Log("Probabiliy Of Add Score " + p);
        return Random.Range(MIN_DEFAULT_SCORE_OF_SECRECT_BAG, MAX_DEFAULT_SCORE_OF_SECRECT_BAG)
            + 
            (p >= THRESHOLD_ADD_SCORE_OF_SECRET_BAG ? 1 : 0)
            * MAX_ADD_SCORE_OF_SECRET_BAG;
            //Random.Range(0, MAX_ADD_SCORE_OF_SECRET_BAG);
    }
   public ValueObject GetValueObject(string tag){
       // Debug.Log("Find Tag :" + tag);

       
        if (dict.ContainsKey(tag))
        {
            if (tag == "SecretBag") {
                dict[tag].score = RandomScoreForSecretBag();
                dict[tag].weight = Random.Range(MIN_WEIGHT_OF_SECRECT_BAG, MAX_WEIGHT_OF_SECRECT_BAG);
            }
            return dict[tag];
        }
        return null;
    }
}
