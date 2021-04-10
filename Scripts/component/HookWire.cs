using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookWire : MonoBehaviour {
    public float min_z = -55f, max_z = 55f;
    public float rotate_speed = 50f;
    private float rotate_angle;
    private bool rotate_right;
    private bool can_rotate;


    public float move_speed = 3f;
    public float initial_move_speed = 3f;

    public float min_y = -2.5f;
    private float initial_y;

    private bool move_down;

    private RopeRenderer rope_renderer;

    private void Awake() {
        rope_renderer = GetComponent<RopeRenderer>();
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
                rope_renderer.RenderLine(Vector3.zero, false);
                move_speed = initial_move_speed;
            }
            rope_renderer.RenderLine(temp, true);
        }
    }
}
