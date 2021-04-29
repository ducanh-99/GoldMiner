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

        is_move_follow = true;
        this.target = target;
    }

    void FixedUpdate()
    {
        moveFlowTarget();
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Hook" && col.gameObject.GetComponent<Hook>().move_down)
        {
            Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
            is_move_follow = true;
            SetTarget(col.gameObject.transform);

        }
        if (col.tag == "Explosion")
        {
            Debug.Log(col.gameObject + " : " + gameObject.name);
            Destroy(gameObject);
        }
        Debug.Log(col.gameObject + " : " + gameObject.name);
    }

    public void moveFlowTarget() {
        if (is_move_follow && target!=null) {
            transform.position = new Vector3(
                target.transform.position.x,
                target.transform.position.y - gameObject.GetComponent<Collider2D>().bounds.size.y / 2,
                transform.position.z
            );

        }
    }

}
