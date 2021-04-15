using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour {
    public Player player;
    // Start is called before the first frame update
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    private void FixedUpdate() {
        Vector2 offset = gameObject.GetComponent<MeshRenderer>().material.mainTextureOffset;
        offset.x = player.transform.position.x;
        gameObject.GetComponent<MeshRenderer>().material.mainTextureOffset = offset * Time.deltaTime / 0.4f;
    }
}
