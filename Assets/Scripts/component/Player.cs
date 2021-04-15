using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour {

    public float speed = 10f, maxSpeed = 3;
    public Rigidbody2D r2;
    public Miner miner;

    // Start is called before the first frame update
    void Start() {
        r2 = gameObject.GetComponent<Rigidbody2D>();
        miner = gameObject.GetComponentInChildren<Miner>();
    }

    // Update is called once per frame
    void Update() {
        if (Mathf.Abs(r2.velocity.x) >= 0.01 && miner.CanMove()) {
            miner.UpdateState((int)Miner.MINER_STATE.MOVING);
        }
        else {
            if (miner.GetState() == (int)Miner.MINER_STATE.MOVING) {
                miner.UpdateState((int)Miner.MINER_STATE.IDLE);
            }
        }
    }

    private void FixedUpdate() {
        if (!miner.CanMove()) return;
        float h = Input.GetAxis("Horizontal");

        r2.AddForce((Vector2.right) * speed * h);

        if (r2.velocity.x > maxSpeed) {
            r2.velocity = new Vector2(maxSpeed, r2.velocity.y);
        }
        if (r2.velocity.x < -maxSpeed) {
            r2.velocity = new Vector2(-maxSpeed, r2.velocity.y);
        };

      
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.CompareTag("DestinationFlag")){
            InLevelManager.Instance.ReachDestination();
        }

    }
}
