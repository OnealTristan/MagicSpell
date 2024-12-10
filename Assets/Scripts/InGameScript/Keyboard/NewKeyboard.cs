using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using Unity.VisualScripting;
//using static System.Net.Mime.MediaTypeNames;

public class NewKeyboard : MonoBehaviour
{
    // Event untuk memberitahu game bahwa sebuah karakter diketik
    public Action<string> onKeyPressed;

    // Event untuk memberitahu game bahwa tombol backspace ditekan
    public Action onBackspacePressed;

    // Event untuk memberitahu game bahwa tombol enter ditekan
    public Action OnEnterPressed;

    [Header(" Player References ")]
    private PlayerAnimation playerAnimation;

    [Header(" Enemy References ")]
    private Enemy enemy;
    private EnemyAnimation enemyAnimation;

    [Header(" Other References ")]
    [SerializeField] private Button[] keyButton;
    private Data data;
	private UserInputDisplay userInputDisplay;
    private GuessLetter guessLetter;
	// Instance UserInputDisplay

	private Dictionary dictionary;

    private string[] letter;
    private string[] usedWords;

	void Awake() {
		dictionary = GetComponent<Dictionary>();

		data = GameObject.FindGameObjectWithTag("Data").GetComponent<Data>();
	}

    void Update()
    {
        if (enemy == null && GameManager.instance.state == GameManager.GameState.OnGoing) {
            enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
        }

        if (enemyAnimation == null && GameManager.instance.state == GameManager.GameState.OnGoing) {
			enemyAnimation = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyAnimation>();

			enemyAnimation.OnEnemyAnimationStart += DisableKeyboard;
			enemyAnimation.OnEnemyAnimationEnd += EnableKeyboard;
		}

        if (playerAnimation == null && GameManager.instance.state == GameManager.GameState.OnGoing) {
			playerAnimation = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAnimation>();

			playerAnimation.OnPlayerAnimationStart += DisableKeyboard;
			playerAnimation.OnPlayerAnimationEnd += EnableKeyboard;
		}

        if (guessLetter == null) {
			guessLetter = GameObject.Find("GuessTextContainer").GetComponent<GuessLetter>();
			letter = guessLetter.GetLetter();
		}

        if (userInputDisplay == null) {
			userInputDisplay = GameObject.Find("TextContainer").GetComponent<UserInputDisplay>();
		}
    }

    public void AlphabetFunction(string alphabet)
    {
        // Memicu event onKeyPressed dan memberikan karakter yang diketik
        onKeyPressed?.Invoke(alphabet);
    }

    public void BackspaceFunction()
    {
        // Memicu event onBackspacePressed
        onBackspacePressed?.Invoke();
    }

    public void EnterFunction()
    {
        string txt = userInputDisplay.DisplayText();

        bool stringFound = false;

        if (string.IsNullOrEmpty(txt))
        {
            return;
        }


        if (dictionary.GetValidWords() != null)
        {
            Debug.Log("wow");
            // Menguji jika kata yang sudah digunakan tidak dapat digunakan kembali
            if (usedWords == null || Array.IndexOf(usedWords, txt) == -1)
            {
                foreach (string word in dictionary.GetValidWords())
                {
                    // Equals() diperuntukan 1 kata penuh
                    // Contains(i[0]) diperuntukan untuk setiap huruf dalam kata
                    if (word.ToLower().Trim().Equals(txt))
                    {
                        // Menguji apakah kata tersebut mengandung 2 huruf yang harus di ketik?
                        if (txt.Contains(letter[0]) && txt.Contains(letter[1]))
                        {
                            // Jika benar maka damage akan diterima oleh musuh
                            Debug.Log("Type: " + txt + " Found!!");

                            data.AchievementCheck(txt);

                            playerAnimation.PlayerAttackAnimation();

                            // Reset interval enemy attack
                            OnEnterPressed?.Invoke();

                            //player.ActivatedWeapon();

                            if (usedWords == null)
                            {
                                usedWords = new string[0];
                            }

                            Array.Resize(ref usedWords, usedWords.Length + 1);
                            usedWords[usedWords.Length - 1] = txt;

                            stringFound = true;
                            break;
                        }
                    }
				}
            }

			//Jika salah maka damage akan diterima oleh player
			if (!stringFound)
            {
                Debug.Log("Type: " + txt + " Not Found!!");
                playerAnimation.PlayerIdleAnimation();

                enemyAnimation.EnemyAttackAnimation();

				userInputDisplay.DeleteText();
			}
		}
	}

    /*public void SetButtonInteractable(int buttonIndex, bool interactable) {
        if (buttonIndex >= 0 && buttonIndex < keyButton.Length) {
            keyButton[buttonIndex].interactable = interactable;
        }
    }*/

    private void DisableKeyboard() {
        Button[] buttons = GetComponentsInChildren<Button>();

		foreach (Button button in buttons) {
			button.interactable = false;
		}
	}

    private void EnableKeyboard() {
		Button[] buttons = GetComponentsInChildren<Button>();

		foreach (Button button in buttons) {
			button.interactable = true;
		}
	}

	private void OnDisable() {
		playerAnimation.OnPlayerAnimationStart -= DisableKeyboard;
		playerAnimation.OnPlayerAnimationEnd -= EnableKeyboard;

		enemyAnimation.OnEnemyAnimationStart -= DisableKeyboard;
		enemyAnimation.OnEnemyAnimationEnd -= EnableKeyboard;
	}
}