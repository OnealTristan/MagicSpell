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


    private string[] validWords;
    private float damage;
    private float correctLetterCount;

    [Header(" Settings ")]
    [SerializeField] private string[] huruf;

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
                    if (txt.Contains(huruf[0]) && txt.Contains(huruf[1]))
                    {
                        correctLetterCount = 0;
                        CorrectLetter();

                        Debug.Log("Type: " + txt + " Found!!");
                        text.text = string.Empty;
                        damage = countDamage(correctLetterCount);
                        OnDecreaseHPEnemy?.Invoke(damage);
                        stringFound = true;
                        break;
                    }
				}
			}

            if (!stringFound) {
				Debug.Log("Type: " + txt + " Not Found!!");
                correctLetterCount = 0;
                CorrectLetter();
                damage = countDamage(correctLetterCount);
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

    public float countDamage(float correctLetterCount) {
        damage = 1 * correctLetterCount; // Contoh: damage minimum adalah 5
        return damage;
    }

    private void CorrectLetter() {
       for (int i = 0; i < (text.text.Length); i++) {
          correctLetterCount++;
       }
    }
}