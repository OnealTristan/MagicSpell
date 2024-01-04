using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AndroidKeyboard : MonoBehaviour
{
    TouchScreenKeyboard keyboard;
    public Text txt;
    string pseudo;

	private void Awake() {
		TouchScreenKeyboard.Android.consumesOutsideTouches = true;
	}
	public void Start() {
        TouchScreenKeyboard.hideInput = true;
		keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
	}
	// Start is called before the first frame update
	public void OpenKeyboard()
    {
    //    keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
    }

    // Update is called once per frame
    void Update() {
        if (TouchScreenKeyboard.visible == false && keyboard != null) {
            if (keyboard.done) {
            pseudo = keyboard.text;
            txt.text = "Anjay " + pseudo;
            keyboard = null;
            }
        }
    }
}
