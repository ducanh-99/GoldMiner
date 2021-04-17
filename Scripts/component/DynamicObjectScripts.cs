using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicObjectScripts : ObjectScripts
{
    // Start is called before the first frame update
    private const float MAX_DISTANCE = 2;
    public float max_dictance;
    public float min_distance;
    public float move_speed;

    private bool is_rotate;
    void Start()
    {
        max_dictance = transform.position.x + MAX_DISTANCE;
        min_distance = transform.position.x - MAX_DISTANCE;
        is_rotate = true;
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
        if (is_rotate)
        {
            if (temp.x < max_dictance)
            {
                transform.position += transform.right * move_speed * Time.deltaTime;
            }
            else
            {
                is_rotate = false;
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
                is_rotate = true;
            }
        }
    }
}
