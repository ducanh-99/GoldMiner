using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ObjectManagerment;
using static ValueObject;

public class ObjectScripts : MonoBehaviour
{
    // Start is called before the first frame update
    public bool is_move_follow = false;

    public Transform target=null;

    void Start()
    {
        ObjectManagerment objectMangagermentInstance = ObjectManagerment.Instance;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetTarget(Transform target) {
        Debug.Log("Set Target ");
        is_move_follow = true;
        this.target = target;
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
            is_move_follow = true;

        }
    }

    void moveFlowTarget() {
        if (is_move_follow && target!=null) {
            transform.position = new Vector3(
                target.transform.position.x,
                target.transform.position.y - gameObject.GetComponent<Collider2D>().bounds.size.y / 2,
                transform.position.z
            );

        }
    }

}
