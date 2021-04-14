using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour {

    public float min_z = -70f, max_z = 70f;
    public float rotate_speed = 70f;
    private float rotate_angle;



    public float move_speed = 3f;
    public float initial_move_speed = 3f;

    public float min_y = -5.0f;
    private float initial_y;

    private bool move_down;
    private bool rotate_right;
    private bool can_rotate;

    private GameObject dragged_object = null;
    private void Awake() {
    }
    // Start is called before the first frame update
    void Start() {
        initial_y = transform.position.y;
        initial_move_speed = move_speed;

        can_rotate = true;

    }

    // Update is called once per frame
    void Update() {
        Rotate();
        GetInput();
        MoveRope();
    }

    void Rotate() {
        if (!can_rotate) return;
        if (rotate_right) {
            rotate_angle += rotate_speed * Time.deltaTime;
        }
        else {
            rotate_angle -= rotate_speed * Time.deltaTime;
        }

        transform.rotation = Quaternion.AngleAxis(rotate_angle, Vector3.forward);
        if (rotate_angle >= max_z) {
            rotate_right = false;
        }
        else if (rotate_angle <= min_z) {
            rotate_right = true;
        }
    }

    void GetInput() {
        if (Input.GetMouseButtonDown(0)) {
            if (can_rotate) {
                can_rotate = false;
                move_down = true;
            }
        }
    }

    void MoveRope() {
        if (can_rotate) {
            return;
        };
        if (!can_rotate) {
            Vector3 temp = transform.position;
            if (move_down) {
                temp -= transform.up * Time.deltaTime * move_speed;
            }
            else {
                temp += transform.up * Time.deltaTime * move_speed;
            }
            transform.position = temp;
            if (temp.y <= min_y) {
                move_down = false;
            }

            if (temp.y >= initial_y) {
                can_rotate = true;
                move_speed = initial_move_speed;
                if (this.dragged_object!=null) {
                 
                    ValueObject value= ObjectManagerment.Instance.GetValueObject(this.dragged_object.tag);
                    if (value != null)
                        InLevelManager.Instance.Earning(value);
                    Debug.Log("Destroy This Object "+ this.dragged_object.tag);
                    Destroy(this.dragged_object);
                }
            }
        }
    }


    void OnTriggerEnter2D(Collider2D col) {
        GameObject col_object = col.gameObject;

        ValueObject value_object = ObjectManagerment.Instance.GetValueObject(col_object.tag);
        if (value_object != null) {


            move_down = false;
            col_object.GetComponent<ObjectScripts>().SetTarget(transform);
            this.dragged_object = col_object;
           

        }
    }

}
