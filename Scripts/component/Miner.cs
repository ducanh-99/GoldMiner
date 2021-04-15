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

    public float speed = 10f, maxSpeed = 3;
    public Rigidbody2D r2;
    public int miner_state;

    public bool is_cheering;
    public float cheer_up_time=0.1f;

    public Animator anim;


    // Start is called before the first frame update
    void Start() {
        r2 = gameObject.GetComponent<Rigidbody2D>();
        miner_state = (int)MINER_STATE.IDLE;
        anim = gameObject.GetComponent<Animator>();
    }


    public bool CanMove() {
        return miner_state == (int)MINER_STATE.MOVING 
            || miner_state == (int)MINER_STATE.IDLE;
    }
    public void UpdateState(int state) {
        Debug.Log("Miner Update State :"+ state);
        miner_state = state;
    }

    public int GetState() {
        return (int)miner_state;
    }
    // Update is called once per frame
    void Update() {
        anim.SetInteger("state", miner_state);
    }
    private void FixedUpdate() {
    
        if (miner_state ==(int) Miner.MINER_STATE.CHEER_UP) {
            is_cheering = true;
            StartCoroutine("CountDownCheerUp");
        };
    }

    public IEnumerator CountDownCheerUp() {
        while (is_cheering) {
            is_cheering = false;
            yield return new WaitForSeconds(cheer_up_time);
        }
        if (!is_cheering) {
            UpdateState((int)Miner.MINER_STATE.IDLE);
            is_cheering = true;
        }
    }
}
