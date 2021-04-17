using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Miner : MonoBehaviour {

    public enum MINER_STATE {
        IDLE, //0
        MOVING,//1
        DRAG,//2
        DRAG_HEAVY,//3
        CHEER_UP,//4
        THROW_DYNAMITE,//5
    };

    public Hook hook;

    public float speed = 10f, maxSpeed = 3;
    public Rigidbody2D r2;
    public int miner_state;

    public bool is_start_count_down;
    public float remain_time;
    public const float CHEER_UP_DURATION = 0.15f;
    public const float THROW_DYNAMITE_DURATION = 0.2f;

    public float again_throw_time;
    public const float AGAIN_THROW_DYNAMITE = 2.0f;

    public Animator anim;


    // Start is called before the first frame update
    void Start() {
        r2 = gameObject.GetComponent<Rigidbody2D>();
        miner_state = (int)MINER_STATE.IDLE;
        is_start_count_down = false;
        again_throw_time = 0;
        anim = gameObject.GetComponent<Animator>();

        hook = GameObject.FindGameObjectWithTag("Hook").GetComponent<Hook>();

    }


    public bool CanMove() {
        return miner_state == (int)MINER_STATE.MOVING 
            || miner_state == (int)MINER_STATE.IDLE;
    }
    public void UpdateState(int state) {
        anim.SetInteger("state", state);
        miner_state = state;
    }

    public int GetState() {
        return (int)miner_state;
    }
    // Update is called once per frame
    void Update() {
        
    }

    void CountDownThrowDynamite() {
        if (miner_state != (int)MINER_STATE.THROW_DYNAMITE) return;
        Debug.Log("is_start_count_down:" + is_start_count_down);
        Debug.Log("Remain Time :" + remain_time);
        if (!is_start_count_down) {
            is_start_count_down = true;
            remain_time = THROW_DYNAMITE_DURATION;
        }
        else {
            if (remain_time <= 0) {
                is_start_count_down = false;
                hook.GetDynamite();
                UpdateState((int)MINER_STATE.IDLE);
            }
        }
    }

    public void CountDownCheerUp() {
        if (miner_state != (int)MINER_STATE.CHEER_UP) return;
        if (!is_start_count_down) {
            is_start_count_down = true;
            remain_time = CHEER_UP_DURATION;
        }
        else {
            if (remain_time <= 0) {
                is_start_count_down = false;
    
                UpdateState((int)MINER_STATE.IDLE);
            }
        }
    }
    private void FixedUpdate() {

        remain_time -= Time.deltaTime;
        again_throw_time -= Time.deltaTime;

        if (Input.GetKey(KeyCode.UpArrow)) {
            if (miner_state==(int)MINER_STATE.DRAG && again_throw_time <= 0 ) {
                UpdateState((int)MINER_STATE.THROW_DYNAMITE);
            //    hook.GetDynamite();

            }
        }

        CountDownThrowDynamite();
        CountDownCheerUp();
  
    }

}
