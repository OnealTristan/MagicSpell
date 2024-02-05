using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobileKeyboard : MonoBehaviour
{
	public InputField inputField;

	public void OnButtonClick(string value) {
		inputField.text += value;
	}

	public void OnBackspaceButtonClick() {
		if (inputField.text.Length > 0) {
			inputField.text = inputField.text.Substring(0, inputField.text.Length - 1);
		}
	}

	public void OnClearButtonClick() {
		inputField.text = "";
	}
}
