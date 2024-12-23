using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Dictionary : MonoBehaviour
{
    private string[] validWords;

    void Awake()
    {
        LoadData();
    }

	private void Start() {
        //CountWords();
        //Debug.Log("Random word yang didapat = " + GetRandomWord());
	}

	private void LoadData() {
        TextAsset textFile = Resources.Load("Dictionary") as TextAsset;
        validWords = textFile.text.ToLower().Split(new[] { '\n', '\r' }, System.StringSplitOptions.RemoveEmptyEntries);
	}

    public string[] GetValidWords() {
        return validWords;
    }

    public string GetRandomWord() {
        var word = validWords.Where(words => words.Length == 5).ToArray();

		/*Debug.Log("Jumlah kata dengan panjang 5 huruf: " + word.Length);
		foreach (string kata in word) {
			Debug.Log("Kata: " + kata);
		}*/

		if (word.Length > 0) {
            int randomIndex = Random.Range(0, word.Length);
            string randomWord = word[randomIndex];
            return randomWord;
        } else {
            return null;
        }
    }

    private void CountWords() {
        int count3Words = validWords.Count(s => s.Length == 3);
        int count4Words = validWords.Count(s => s.Length == 4);
        int count5Words = validWords.Count(s => s.Length == 5);

        Debug.Log("3 huruf = " + count3Words);
        Debug.Log("4 huruf = " + count4Words);
        Debug.Log("5 huruf = " + count5Words);
    }
}