using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookWire : MonoBehaviour {
    public GameObject hook;

    private RopeRenderer rope_renderer;

    private void Awake() {
        rope_renderer = GetComponent<RopeRenderer>();
    }

    // Update is called once per frame
    void Update() {
        RenderLine();
    }
    void RenderLine() {

         rope_renderer.RenderLine(hook.transform.position, true);
  
    }



}
