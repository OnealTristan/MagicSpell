using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GuessLetter : MonoBehaviour
{
    [Header(" Elements ")]
	[SerializeField] private TextMeshProUGUI textHuruf1;
	[SerializeField] private TextMeshProUGUI textHuruf2;
	private Dictionary dictionary;
	private Data data;

    [Header(" Settings ")]
	[SerializeField] private bool checkRandomLetter;
	[SerializeField] private string[] letter;
	[SerializeField] private string[] randomLetter;

	//private string alphabet = "abcdefghijklmnopqrstuvwxyz";
	int resultCorrectLetter;

	private void Awake() {
		dictionary = GetComponent<Dictionary>();
		data = GameObject.FindGameObjectWithTag("Data").GetComponent<Data>();
	}

	// Start is called before the first frame update
	void Start()
    {
		// projectMode(false) == KP
		if (data.GetProjectMode() == false) {
			if (checkRandomLetter == true) {
				GetRandomLetterException();
			} else {
				textHuruf1.text = letter[0].ToUpper();
				textHuruf2.text = letter[1].ToUpper();
			}
		// projectMode(true) == TA
		} else {
			if (data.GetChapterIndex() == 0 && data.GetLevelIndex() == 0) {
				textHuruf1.text = letter[0].ToUpper();
				textHuruf2.text = letter[1].ToUpper();
			} else {
				GetRandomLetterException();
			}
		}

		Debug.Log(letter[0]);
		Debug.Log(letter[1]);
	}

	private void Update() {
		//GetCorrectRandomLetter();
	}

	public string[] GetLetter() {
        return letter;
    }

	private string GetRandomLetter() {
		int randomIndex = Random.Range(0, randomLetter.Length);
		return randomLetter[randomIndex];
	}

	private int GetCorrectRandomLetter() {

		int ada = 0;

		foreach (string words in dictionary.GetValidWords()) {
			if (words.Contains(letter[0]) && words.Contains(letter[1])) {
				ada++;
			}
		}

		resultCorrectLetter = ada;
		Debug.Log("correct letter = " + resultCorrectLetter);
		return resultCorrectLetter;
	}

	/*private void RandomLetter() {
		letter[0] = GetRandomLetter().ToString();
		letter[1] = GetRandomLetter().ToString();

		if (letter[0] == letter[1]) {
			RandomLetter();
		}
	}*/

	public void GetRandomLetterException() {		
		string[] parts = GetRandomLetter().Split(",");
		letter[0] = parts[0];
		letter[1] = parts[1];
        textHuruf1.text = letter[0].ToUpper();
        textHuruf2.text = letter[1].ToUpper();
    }
}