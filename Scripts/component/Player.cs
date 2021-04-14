using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour {

    public float speed = 10f, maxSpeed = 3;
    public Rigidbody2D r2;


    // Start is called before the first frame update
    void Start() {
        r2 = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {

    }
    private void FixedUpdate() {
        float h = Input.GetAxis("Horizontal");
        r2.AddForce((Vector2.right) * speed * h);

        if (r2.velocity.x > maxSpeed) {
            r2.velocity = new Vector2(maxSpeed, r2.velocity.y);
        }
        if (r2.velocity.x < -maxSpeed) {
            r2.velocity = new Vector2(-maxSpeed, r2.velocity.y);
        };
    }
}
