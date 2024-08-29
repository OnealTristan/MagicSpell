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
    private Player player;
    private PlayerAnimation playerAnimation;

    [Header(" Enemy References ")]
    private Enemy enemy;
    private EnemyAnimation enemyAnimation;

    [Header(" Other References ")]
    [SerializeField] private Button[] keyButton;
    private Achievement achievement;
	private UserInputDisplay userInputDisplay;
    private GuessLetter guessLetter;
	// Instance UserInputDisplay

	private Dictionary dictionary;

    private string[] letter;
    private string[] usedWords;

	void Awake() {
		dictionary = GetComponent<Dictionary>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        playerAnimation = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAnimation>();

        achievement = GameObject.FindGameObjectWithTag("Data").GetComponent<Achievement>();
        guessLetter = GameObject.Find("GuessTextContainer").GetComponent<GuessLetter>();
		userInputDisplay = GameObject.Find("TextContainer").GetComponent<UserInputDisplay>();
	}

	void Start()
    {
        playerAnimation.OnPlayerAnimationStart += DisableKeyboard;
        playerAnimation.OnPlayerAnimationEnd += EnableKeyboard;

        letter = guessLetter.GetLetter();
    }

    void Update()
    {
        if (enemy == null && enemyAnimation == null && GameManager.instance.state == GameManager.GameState.OnGoing) {
            enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
            enemyAnimation = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyAnimation>();

			enemyAnimation.OnEnemyAnimationStart += DisableKeyboard;
            enemyAnimation.OnEnemyAnimationEnd += EnableKeyboard;
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
     
        if (string.IsNullOrEmpty(txt))
        {
            return;
        }

        bool stringFound = false;

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

                            achievement.AchievementCheck(txt);

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
                            userInputDisplay.DeleteText();
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

                enemy.coroutineAttack = false;
                enemyAnimation.EnemyAttackAnimation();

				userInputDisplay.DeleteText();
			}
        }
    }

    public void SetButtonInteractable(int buttonIndex, bool interactable) {
        if (buttonIndex >= 0 && buttonIndex < keyButton.Length) {
            keyButton[buttonIndex].interactable = interactable;
        }
    }

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
}