using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using System;
using System.Text.RegularExpressions;

public class GuessLetter : MonoBehaviour
{
	[Header(" References ")]
	[SerializeField] private GameObject boxHurufParent;
	[SerializeField] private GameObject boxHurufPrefab;
	private List<GameObject> spawnedBoxes = new List<GameObject>();

	[Space(10)]
	[SerializeField] private GameObject boxHuruf1;
	[SerializeField] private GameObject boxHuruf2;

	[Space(10)]
	[SerializeField] private TextMeshProUGUI textHuruf1;
	[SerializeField] private TextMeshProUGUI textHuruf2;
	private Dictionary dictionary;
	private Data data;
	private EventManager eventManager;

    [Header(" Settings KP ")]
	[SerializeField] private bool checkRandomLetter;
	[SerializeField] private string[] letter;
	[SerializeField] private string[] randomLetter;

	[Header(" Variables ")]
	private string vowels = "aiueo";
	private string consonants = "bcdfghjklmnpqrstvwxyz";
	string word;

	private void Awake() {
		dictionary = GameObject.Find("Canvas").GetComponent<Dictionary>();
		data = GameObject.FindGameObjectWithTag("Data").GetComponent<Data>();
		eventManager = GameObject.Find("EventManager").GetComponent<EventManager>();
	}

	private void OnEnable() {
		eventManager.onEnterPressedCorrect += SpawnBoxHuruf;
	}

	// Start is called before the first frame update
	void Start()
    {
		// projectMode(false) == KP
		if (data.GetProjectMode() == false) {
			boxHuruf1.SetActive(true);
			boxHuruf2.SetActive(true);
			boxHurufParent.SetActive(false);

			if (checkRandomLetter == true) {
				GetRandomLetterException();
			} else {
				textHuruf1.text = letter[0].ToUpper();
				textHuruf2.text = letter[1].ToUpper();
			}
		// projectMode(true) == TA
		} else {
			boxHuruf1.SetActive(false);
			boxHuruf2.SetActive(false);
			boxHurufParent.SetActive(true);

			SpawnBoxHuruf();

			/*if (data.GetChapterIndex() == 0 && data.GetLevelIndex() == 0) {
				textHuruf1.text = letter[0].ToUpper();
				textHuruf2.text = letter[1].ToUpper();
			} else {
				GetRandomLetterException();
			}*/
		}
	}

	private void Update() {
		//GetCorrectRandomLetter();
	}

	public string[] GetLetter() {
        return letter;
    }

	private string GetRandomLetter() {
		int randomIndex = UnityEngine.Random.Range(0, randomLetter.Length);
		return randomLetter[randomIndex];
	}

	/*private int GetCorrectRandomLetter() {
		int ada = 0;

		foreach (string words in dictionary.GetValidWords()) {
			if (words.Contains(letter[0]) && words.Contains(letter[1])) {
				ada++;
			}
		}

		resultCorrectLetter = ada;
		Debug.Log("correct letter = " + resultCorrectLetter);
		return resultCorrectLetter;
	}*/

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
	
	public void SpawnBoxHuruf() {
		foreach (var box in spawnedBoxes) {
			Destroy(box);
		}

		word = dictionary.GetRandomWord();

		/*System.Random random = new System.Random();
		int randomMethod = random.Next(3); // Menghasilkan angka acak 0, 1, atau 2

		List<int> indexToRemove;
		switch (randomMethod) {
			case 0:
				indexToRemove = FirstRemove(word); // Hapus huruf di awal
				Debug.Log("Metode: Hapus Huruf di Awal");
				break;
			case 1:
				indexToRemove = VowelRemove(word); // Hapus dua vokal
				Debug.Log("Metode: Hapus Vokal");
				break;
			case 2:
				indexToRemove = LastRemove(word); // Hapus dua huruf terakhir
				Debug.Log("Metode: Hapus Huruf Terakhir");
				break;
			case 3:
				indexToRemove = ConsonantRemove(word); // Hapus dua konsonan
				Debug.Log("Metode: Hapus Dua Konsonan");
				break;
			default:
				indexToRemove = new List<int>();
				Debug.LogWarning("Metode default dipilih, tidak ada huruf yang dihapus.");
				break;
		}*/

		var indexToRemove = ConsonantRemove(word);

		Debug.Log("Huruf random = " + word);

		char[] wordArray = word.ToCharArray();
		foreach (var index in indexToRemove) {
			wordArray[index] = '_';
		}
		word = new string(wordArray);

		for (int i = 0; i < word.Length; i++) {
			GameObject boxHuruf = Instantiate(boxHurufPrefab, boxHurufParent.transform);

			TextMeshProUGUI text = boxHuruf.GetComponentInChildren<TextMeshProUGUI>();
			text.text = word[i] == '_' ? "_" : word[i].ToString().ToUpper();

			spawnedBoxes.Add(boxHuruf);
		}
	}

	private List<int> VowelRemove(string word) {
		var vowelIndex = word.Select((letter, index) => new { letter, index })
							.Where(x => vowels.Contains(char.ToLower(x.letter)))
							.Select(x => x.index)
							.ToList();

		System.Random random = new System.Random();
		var indexToRemove = vowelIndex.OrderBy(x => random.Next())
									.Take(Math.Min(2, vowelIndex.Count))
									.ToList();

		return indexToRemove;
	}

	private List<int> ConsonantRemove(string word) {
		var consonantIndices = word.Select((letter, index) => new { letter, index })
							   .Where(x => consonants.Contains(char.ToLower(x.letter)))
							   .Select(x => x.index)
							   .ToList();

		// Pilih 2 indeks secara acak
		System.Random random = new System.Random();
		var indicesToRemove = consonantIndices.OrderBy(x => random.Next())
											  .Take(Math.Min(2, consonantIndices.Count))
											  .ToList();

		return indicesToRemove;
	}

	private List<int> FirstRemove(string word) {
		var indexToRemove = new List<int>();

		// Hilangkan dua huruf pertama jika panjang kata >= 4
		if (word.Length >= 4) {
			indexToRemove.Add(0);
			indexToRemove.Add(1);
		}
		// Hilangkan satu huruf pertama jika panjang kata < 4
		else if (word.Length > 1) {
			indexToRemove.Add(0);
		}

		return indexToRemove;
	}

	private List<int> LastRemove(string word) {
		List<int> index = new List<int>();

		if (word.Length <= 3) {
			// Jika kata hanya 3 huruf, hapus huruf terakhir saja
			index.Add(word.Length - 1);
		} else {
			// Jika kata lebih dari 3 huruf, hapus 2 huruf terakhir
			index.Add(word.Length - 1);
			index.Add(word.Length - 2);
		}

		return index;
	}

	public bool CheckContainWord(string playerInput) {
		if (playerInput.Length != word.Length) {
			Debug.Log("Kata tidak match panjang");
			return false;
		}

		for (int i = 0; i < word.Length; i++) {
			if (word[i] != '_' && word[i] != playerInput[i]) {
				Debug.Log($"Kata tidak cocok pada posisi {i}: {word[i]} != {playerInput[i]}");
				return false;
			}
		}

		bool isWordValid = dictionary.GetValidWords().Contains(playerInput.ToLower().Trim());
		if (!isWordValid) {
			Debug.Log("Kata tidak ditemukan di dictionary");
		}
		return isWordValid;
	}

	private void OnDisable() {
		eventManager.onEnterPressedCorrect -= SpawnBoxHuruf;
	}
}