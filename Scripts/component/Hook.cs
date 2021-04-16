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
    public Miner miner;
    private void Awake() {
    }
    // Start is called before the first frame update
    void Start() {
        initial_y = transform.position.y;
        initial_move_speed = move_speed;

        can_rotate = true;
        miner = GameObject.FindGameObjectWithTag("Miner").GetComponent<Miner>();

    }

    // Update is called once per frame
    void Update() {
        Rotate();
        GetInput();
        MoveRope();
        CheckMoveOutCameraView();
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
        if (Input.GetKeyDown(KeyCode.DownArrow)
            && miner.GetState() == (int)Miner.MINER_STATE.IDLE) { 
            if (can_rotate) {
                can_rotate = false;
                move_down = true;

                miner.UpdateState((int)Miner.MINER_STATE.DRAG);
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
               

                    miner.UpdateState((int)Miner.MINER_STATE.CHEER_UP);
                    Destroy(this.dragged_object);
                    this.dragged_object = null;
                }
                else {
                    miner.UpdateState((int)Miner.MINER_STATE.IDLE);
                }
            }
        }
    }

    bool CheckPositionOutBound() {
        return gameObject.GetComponent<Renderer>().isVisible;
    }

    void CheckMoveOutCameraView() {
        if (miner.GetState()==(int)Miner.MINER_STATE.DRAG) {
            if (!CheckPositionOutBound()) {
                move_down = false;
            }
        }
    }


    void OnTriggerEnter2D(Collider2D col) {
        if (!move_down) return;
        if (this.dragged_object != null) return;
        GameObject col_object = col.gameObject;

        ValueObject value_object = ObjectManagerment.Instance.GetValueObject(col_object.tag);

        if (value_object != null) {
            Debug.Log("Value Object :" + value_object.score);

            move_down = false;
          //  col_object.GetComponent<ObjectScripts>().SetTarget(transform);
            this.dragged_object = col_object;
           

        }
    }

}
