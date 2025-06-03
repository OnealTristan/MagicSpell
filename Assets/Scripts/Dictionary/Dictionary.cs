using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Dictionary : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private DictionarySO[] dictionarySO;
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

    public bool IsWordInDictionarySO(string wordToCheck)
    {
        if (dictionarySO == null || dictionarySO.Length == 0)
            return false;

        string lowerWord = wordToCheck.ToLower().Trim();

        foreach (var dictSO in dictionarySO) {
            if (dictSO != null && dictSO.word != null) {
                if (dictSO.word.Any(w => w.ToLower().Trim() == lowerWord)) {
                    return true;
                }
            }
        }

        return false;
    }

    public DictionarySO GetRandomDictionarySO()
    {
        if (dictionarySO == null || dictionarySO.Length == 0)
            return null;

        int randomDictIndex = Random.Range(0, dictionarySO.Length);
        DictionarySO selectedDict = dictionarySO[randomDictIndex];
        return selectedDict;
    }

    public string GetRandomWord() {
        /*var word = validWords.Where(words => words.Length == 5).ToArray();

		if (word.Length > 0) {
            int randomIndex = Random.Range(0, word.Length);
            string randomWord = word[randomIndex];
            return randomWord;
        } else {
            return null;
        }*/
        DictionarySO selectedDictionary = GetRandomDictionarySO();
        text.text = selectedDictionary.category;

        string[] words = selectedDictionary.word;

        if (words == null || words.Length == 0)
            return null;

        int randomWordIndex = Random.Range(0, words.Length);
        return words[randomWordIndex];
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