using UnityEngine;

public class Player : MonoBehaviour {
    public float speed, maxSpeed ;
    public Rigidbody2D rigidbody2d;
    public Miner miner;

    // Start is called before the first frame update
    void Start() {
        rigidbody2d = gameObject.GetComponent<Rigidbody2D>();
        miner = gameObject.GetComponentInChildren<Miner>();
      
        speed = 5f;
    }

    // Update is called once per frame
    void Update() {
        if (Mathf.Abs(rigidbody2d.velocity.x) >= 0.01) {
            if (miner.GetState() == (int)Miner.MINER_STATE.IDLE) {
             //   Debug.Log("Update Miner State From Player : MOVING");
                miner.UpdateState((int)Miner.MINER_STATE.MOVING);
            }
        }
        else {
            if (miner.GetState() == (int)Miner.MINER_STATE.MOVING) {
               // Debug.Log("Update Miner State From Player : IDLE");
                miner.UpdateState((int)Miner.MINER_STATE.IDLE);
            }
        }
    }

    private void FixedUpdate() {
        if (!miner.CanMove()) return;
        float h = Input.GetAxis("Horizontal");
        maxSpeed = 3f * PowerupManager.Instance.BARROW_SPEED_FACTOR;

        //  Debug.Log("Get Input And Can Move :");
        rigidbody2d.AddForce((Vector2.right) * speed * h * PowerupManager.Instance.BARROW_SPEED_FACTOR);

        //Debug.Log("Player Speed " + r2.velocity.x);
        if (rigidbody2d.velocity.x > maxSpeed) {
            rigidbody2d.velocity = new Vector2(maxSpeed, rigidbody2d.velocity.y);
        }
        if (rigidbody2d.velocity.x < -maxSpeed) {
            rigidbody2d.velocity = new Vector2(-maxSpeed, rigidbody2d.velocity.y);
        };
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.CompareTag("DestinationFlag")) {
            InLevelManager.Instance.ReachDestination();
        }
    }
}
