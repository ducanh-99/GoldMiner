using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeRenderer : MonoBehaviour
{
    private LineRenderer line_renderer;
    [SerializeField]
    private Transform start_positition;

    private float line_width = 0.05f;
    // Start is called before the first frame update
    void Awake() {
        line_renderer = GetComponent<LineRenderer>();
        line_renderer.startWidth = line_width;
        line_renderer.enabled = false;
    }

    public void RenderLine(Vector3 end_position,bool enable_renderer) {
        Debug.Log("Render Line ");
        if (enable_renderer) {
            if (!line_renderer.enabled) {
                line_renderer.enabled = true;
            };
            line_renderer.positionCount = 2;
        }
        else {
            line_renderer.positionCount = 0;
            if (line_renderer.enabled) {
                line_renderer.enabled = false;
            }
        };

        if (line_renderer.enabled) {
            Vector3 temp = start_positition.position;
            temp.z = -10f;
            start_positition.position = temp;

            temp = end_position;
            temp.z = 0f;
            end_position = temp;

            line_renderer.SetPosition(0, start_positition.position);
            line_renderer.SetPosition(1, end_position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
