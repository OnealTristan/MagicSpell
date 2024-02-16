using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
//using static System.Net.Mime.MediaTypeNames;

public class NewKeyboard : MonoBehaviour
{
    // Event untuk memberitahu game bahwa sebuah karakter diketik
    public Action<string> onKeyPressed;

    // Event untuk memberitahu game bahwa tombol backspace ditekan
    public Action onBackspacePressed;

    // Event untuk memberitahu game bahwa tombol enter ditekan
    public Action onEnterPressed;

    [Header(" References ")]
    [SerializeField] private Player player;
    [SerializeField] private PlayerAnimation playerAnimation;
    [SerializeField] private EnemyDisplay enemyDisplay;
    [SerializeField] private GuessLetter guessLetter;
	// Instance UserInputDisplay
	public UserInputDisplay userInputDisplay;
	private Dictionary dictionary;

    private string[] letter;
    private string[] usedWords;

	void Awake() {
		userInputDisplay = GetComponent<UserInputDisplay>();
		dictionary = GetComponent<Dictionary>();
	}

	void Start()
    {
        letter = guessLetter.GetLetter();

        // Mendapatkan referensi UserInputDisplay
        if (userInputDisplay == null)
        {
            Debug.LogError("UserInputDisplay component not found in children. Make sure it is added to the GameObject.");
        }
    }

    /*void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Ended && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    Button button = hit.collider.GetComponent<Button>();

                    if (button != null)
                    {
                        switch (button.name)
                        {
                            case "BackspaceButton":
                                BackspaceFunction();
                                break;

                            case "EnterButton":
                                EnterFunction();
                                break;

                            default:
                                AlphabetFunction(button.GetComponentInChildren<Text>().text);
                                break;
                        }
                    }
                }
            }
        }
    }*/

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
            Debug.Log(txt);
            return;
        }

        bool stringFound = false;

        if (dictionary.GetValidWords() != null)
        {
            Debug.Log("wow");
            // Menguji jika kata yang sudah digunakan tidak dapat digunakan kembail
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

                            playerAnimation.PlayerAttack();

                            player.ActivatedWeapon();

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
                playerAnimation.PlayerIdle();

                enemyDisplay.EnemyAttack();

				userInputDisplay.DeleteText();
			}
        }
    }
}
