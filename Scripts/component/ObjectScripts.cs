using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ObjectManagerment;
using static ValueObject;

public class ObjectScripts : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isMoveFollow = false;
    public float maxY;
    public int score;
    public float weight;
    void Start()
    {
        ObjectManagerment objectMangagermentInstance = ObjectManagerment.GetInstance();
        ValueObject valueObject = objectMangagermentInstance.test(gameObject.tag);
        if (b != null)
        {
            score = valueObject.score;
            weight = valueObject.weight;
        }
        Debug.Log(score);
        Debug.Log(weight);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        moveFlowTarget();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Hook")
        {
            Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
            isMoveFollow = true;
            Debug.Log(gameObject.tag);

        }
    }

    void moveFlowTarget()
    {
        if (isMoveFollow)
        {

        }
    }

}
