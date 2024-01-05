using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private Text text;
    [SerializeField] private Keyboard keyboard;
    private string[] validWords;

    // Start is called before the first frame update
    void Start()
    {
        keyboard.onEnterPressed += EnterPressedCallback;
        keyboard.onBackspacePressed += BackspacePressedCallback;
        keyboard.onKeyPressed += KeyPressedCallback;

        LoadData();
    }

    private void LoadData() {
        TextAsset textFile = Resources.Load("words") as TextAsset;
        validWords = textFile.text.Split("\n");
    }

    private void EnterPressedCallback() {
        bool stringFound = false;

		if (validWords != null) {
            foreach (string word in validWords) {
				if (word.Contains(text.text.ToLower().Trim())) {
					Debug.Log("Type: " + text.text.ToLower().Trim() + " Found!!");
					text.text = string.Empty;
                    stringFound = true;
					break;
				}
			}

            if (!stringFound) {
				Debug.Log("Type: " + text.text.ToLower().Trim() + " Not Found!!");
				text.text = string.Empty;
            }
        }
    }

    private void BackspacePressedCallback() {
        if (text.text.Length > 0)
        {
			text.text = text.text.Substring(0, text.text.Length - 1);
		}
    }

    private void KeyPressedCallback(string key) {
        text.text += key.ToUpper().Trim();
    }
}