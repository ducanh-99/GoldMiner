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

    public bool move_right;
    void Start()
    {
        max_dictance = transform.position.x + MAX_DISTANCE;
        min_distance = transform.position.x - MAX_DISTANCE;
        move_right = true;
        move_speed = 0.7f;

    }
    void Flip() {
        Vector3 scale;
        scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
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
               // Debug.Log("Moving To Right " + temp.x + "   " + max_dictance);
                transform.position += transform.right * move_speed * Time.deltaTime;
            }
            else
            {
                Debug.Log("Flip To Left");
                move_right = false;
                //  transform.Rotate (Vector3.up * -180);
                // transform.Rotate (Vector3.forward * 180);
                //Debug.Log("Move Right False");
                Flip();
            }
        }
        else
        {
            if (temp.x > min_distance)
            {
               // Debug.Log("Moving To Left " + temp.x + "   " + min_distance);
                transform.position -= transform.right * move_speed * Time.deltaTime;
            }
            else
            {
                Debug.Log("Flip To Right");
                move_right = true;
                Flip();
                // transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
            }
        }
    }

}
