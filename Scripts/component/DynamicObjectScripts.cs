using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicObjectScripts : ObjectScripts
{
    // Start is called before the first frame update
    private const float MAX_DISTANCE = 3;
    public float max_dictance;
    public float min_distance;
    public float move_speed;

    private bool move_right;
    void Start()
    {
        max_dictance = transform.position.x + MAX_DISTANCE;
        min_distance = transform.position.x - MAX_DISTANCE;
        move_right = true;
        move_speed = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      
        if (is_move_follow == false)
        {
            Move();
        }
        else
        {
            moveFlowTarget();
        }

    }


    void Move()
    {
        Vector3 temp = transform.position;
        //Debug.Log("Transform Position X" + transform.position.x);
        if (move_right)
        {
            if (temp.x < max_dictance)
            {
                transform.position += transform.right * move_speed * Time.deltaTime;
            }
            else
            {
                move_right = false;
                //Debug.Log("Move Right False");
                //  transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
            }
        }
        else
        {
            if (temp.x > min_distance)
            {
                transform.position += transform.right * -move_speed * Time.deltaTime;
            }
            else
            {
                move_right = true;
               // transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
            }
        }
    }
}
