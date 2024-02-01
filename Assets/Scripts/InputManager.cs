using System;
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
    [SerializeField] private Player player;
    [SerializeField] private Enemy enemy;
    [SerializeField] private PlayerAnimation playerAnimation;

    [Header(" Settings ")]
    [SerializeField] private string[] letter;
    [SerializeField] private bool randomLetter;
    [SerializeField] private string[] exceptions;

    private string alphabet = "abcdefghijklmnopqrstuvwxyz";
	private string[] validWords;
    private string[] usedWords;
    int resultCorrectLetter;

    // Start is called before the first frame update
    void Start()
    {
        if (randomLetter == true) {
			GetException();
		}
        Debug.Log(letter[0]);
        Debug.Log(letter[1]);

        

        keyboard.onEnterPressed += EnterPressedCallback;
        keyboard.onBackspacePressed += BackspacePressedCallback;
        keyboard.onKeyPressed += KeyPressedCallback;

        LoadData();
    }

	private void Update() {
        GetCorrectRandomLetter();
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
            // Menguji jika kata yang sudah digunakan tidak dapat digunakan kembail
            if (usedWords == null || Array.IndexOf(usedWords, txt) == -1) {
                foreach (string word in validWords) {
                    // Equals() diperuntukan 1 kata penuh
                    // Contains(i[0]) diperuntukan untuk setiap huruf dalam kata
                    if (word.ToLower().Trim().Equals(txt)) {
                        // Menguji apakah kata tersebut mengandung 2 huruf yang harus di ketik?
                        if (txt.Contains(letter[0]) && txt.Contains(letter[1])) {
                            // Jika benar maka damage akan diterima oleh musuh
                            Debug.Log("Type: " + txt + " Found!!");

							playerAnimation.PlayerAttack();

							player.ActivatedWeapon();

							if (usedWords == null) {
                                usedWords = new string[0];
                            }

                            Array.Resize(ref usedWords, usedWords.Length + 1);
                            usedWords[usedWords.Length - 1] = txt;

                            stringFound = true;
                            text.text = string.Empty;
                            break;
                        }
                    }
			    }
            }

            //Jika salah maka damage akan diterima oleh player
            if (!stringFound) {
				Debug.Log("Type: " + txt + " Not Found!!");
				playerAnimation.PlayerIdle();

				enemy.ActivatedEnemy();

                text.text = string.Empty;
            }
		}
	}
    private void BackspacePressedCallback() {
        if (text.text.Length > 0)
        {
			text.text = text.text.Substring(0, text.text.Length - 1);
			if (text.text.Length < 1) {
                playerAnimation.PlayerIdle();
			}
		} else {
			playerAnimation.PlayerIdle();
		}
    }

    private void KeyPressedCallback(string key) {
        text.text += key.ToUpper().Trim();
        playerAnimation.PlayerSpelling();
	}

    public string[] GetLetter() {
        return letter;
    }

    private char GetRandomLetter() {
        int randomIndex = UnityEngine.Random.Range(0, alphabet.Length);
        return alphabet[randomIndex];
    }

    private int GetCorrectRandomLetter() {
        
        int ada = 0;

        foreach (string words in validWords) {
            if (words.Contains(letter[0]) && words.Contains(letter[1])) {
                ada++;
            }
        }

        resultCorrectLetter = ada;
        Debug.Log("correct letter = " +resultCorrectLetter);
        return resultCorrectLetter;
    }

    private void RandomLetter () {
        letter[0] = GetRandomLetter().ToString();
        letter[1] = GetRandomLetter().ToString();

        if (letter[0] == letter[1]) {
            RandomLetter();
        }
    }

    private void GetException() {
        RandomLetter();
        foreach (string exception in exceptions) {
            string[] parts = exception.Split(",");
            if (letter[0].Contains(parts[0]) && letter[1].Contains(parts[1]) || letter[0].Contains(parts[1]) && letter[1].Contains(parts[0])) {
                RandomLetter();
            }
        }
    }
}