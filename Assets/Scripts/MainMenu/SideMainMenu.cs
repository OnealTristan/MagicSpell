using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SideMainMenu : MonoBehaviour {
    [Header(" References ")]
    [SerializeField] private GameObject scrollbar;

    float scrollPos = 0.5f;
    float[] pos;
    private void Start() {
        pos = new float[transform.childCount];
    }

    private void Update() {
        float distance = 1f / (pos.Length - 1f);
        
        for (int i = 0; i < pos.Length; i++) {
            pos[i] = distance * i;
        }

        if (Input.GetMouseButton(0)) {
            scrollPos = scrollbar.GetComponent<Scrollbar>().value;
        } else {
            for (int i = 0; i < pos.Length; i++) {
                if (scrollPos < pos[i] + (distance / 2) && scrollPos > pos[i] - (distance / 2)) {
                    scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[i], 0.1f);
                }
            }
        }
    }
}
