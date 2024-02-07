using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class AndroidKeyboard : MonoBehaviour, IPointerClickHandler
{
    private TextMeshProUGUI text;

    // Start is called before the first frame update
    void Awake()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        TouchScreenKeyboard.hideInput = true;
    }

    private void OnClick() {
        TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
        TouchScreenKeyboard.hideInput = true;
    }

    private void HideInputField() {
        TouchScreenKeyboard.hideInput = true;
    }

    public void OnPointerClick(PointerEventData eventData) {
        OnClick();
    }
}
