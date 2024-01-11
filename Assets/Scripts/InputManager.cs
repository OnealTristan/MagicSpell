using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    public Action<float> OnDecreaseHPPlayer;
    public Action<float> OnDecreaseHPEnemy;

    [Header(" Elements ")]
    [SerializeField] private Text text;
    [SerializeField] private Keyboard keyboard;
    [SerializeField] private Slider enemyHealthBar;
    [SerializeField] private Slider playerHealthBar;

    [Header(" Settings ")]
    [SerializeField] private string[] huruf;

	private string[] validWords;
	private float damage;
	private float correctLetterCount;

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
     
    // Method Actions jika enter ditekan/pencet
    private void EnterPressedCallback() {
        string txt = text.text.ToLower().Trim();
        bool stringFound = false;

		if (validWords != null) {
            foreach (string word in validWords) {
                // Equals() diperuntukan 1 kata penuh
                // Contains(i[0]) diperuntukan untuk setiap huruf dalam kata
				if (word.ToLower().Trim().Equals(txt)) {
                    // Menguji apakah kata tersebut mengandung 2 huruf yang harus di ketik?
                    if (txt.Contains(huruf[0]) && txt.Contains(huruf[1]))
                    {
                        // Jika benar maka damage akan diterima oleh musuh
                        correctLetterCount = 0;
                        Debug.Log("Type: " + txt + " Found!!");
                        CorrectLetter();
                        text.text = string.Empty;
                        damage = correctLetterCount;
                        OnDecreaseHPEnemy?.Invoke(damage);
                        stringFound = true;
                        break;
                    }
				}
			}

            //Jika salah maka damage akan diterima oleh player
            if (!stringFound) {
                correctLetterCount = 0;
				Debug.Log("Type: " + txt + " Not Found!!");
                CorrectLetter();
                damage = correctLetterCount;
                OnDecreaseHPPlayer?.Invoke(damage);
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

    private void CorrectLetter() {
       for (int i = 0; i < (text.text.Length); i++) {
          correctLetterCount++;
       }
    }

    public string[] GetHuruf() {
        return huruf;
    }
}