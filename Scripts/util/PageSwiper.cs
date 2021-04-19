using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class PageSwiper : MonoBehaviour, IDragHandler, IEndDragHandler {
    private Vector3 panelLocation;
    public float percentThreshold = 0.2f;
    public float easing = 0.5f;
    public int totalPages = 1;
    private int currentPage =1;

   // public Button btn_left;
   // public Button btn_right;

    // Start is called before the first frame update
    private void Awake() {
        panelLocation = transform.position;
      //  btn_left.onClick.AddListener(() => SwitchPanel(true));
      //  btn_right.onClick.AddListener(() => SwitchPanel(false));
    }

    public void SwitchPanel(bool left) {

        Debug.Log("Switch Panel To Left :" + left+"  "+currentPage);
        if (left && currentPage <= 1) return;
        if (!left && currentPage >= totalPages) return;
        currentPage  += (left ? -1 : 1);
        panelLocation += new Vector3(Screen.width*(left?1:-1), 0, 0);
        StartCoroutine(SmoothMove(transform.position, panelLocation, easing));

        Debug.Log("After Switch:" + left + "  " + currentPage);
    }

    void MoveRightPanel() {

    }
    public void OnDrag(PointerEventData data) {
        float difference = data.pressPosition.x - data.position.x;
        transform.position = panelLocation - new Vector3(difference, 0, 0);
    }
    public void OnEndDrag(PointerEventData data) {
        float percentage = (data.pressPosition.x - data.position.x) / Screen.width;
        if (Mathf.Abs(percentage) >= percentThreshold) {
          //  Vector3 newLocation = panelLocation;
            if (percentage > 0 && currentPage < totalPages) {
                SwitchPanel(false);
               // currentPage++;
               // newLocation += new Vector3(-Screen.width, 0, 0);
            }
            else if (percentage < 0 && currentPage > 1) {
                //currentPage--;
                SwitchPanel(true);
               // newLocation += new Vector3(Screen.width, 0, 0);
            }
            // StartCoroutine(SmoothMove(transform.position, newLocation, easing));
            // panelLocation = newLocation;
            else {
                StartCoroutine(SmoothMove(transform.position, panelLocation, easing));
            }
        }
        else {
            StartCoroutine(SmoothMove(transform.position, panelLocation, easing));
        }
    }
    IEnumerator SmoothMove(Vector3 startpos, Vector3 endpos, float seconds) {
        float t = 0f;
        while (t <= 1.0) {
            t += Time.deltaTime / seconds;
            transform.position = Vector3.Lerp(startpos, endpos, Mathf.SmoothStep(0f, 1f, t));
            yield return null;
        }
    }
}