using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dictionary : MonoBehaviour
{
    private string[] validWords;

    void Awake()
    {
        LoadData();
    }

    private void LoadData() {
        TextAsset textFile = Resources.Load("Dictionary") as TextAsset;
        validWords = textFile.text.ToLower().Split("\n");
    }

    public string[] GetValidWords() {
        return validWords;
    }
}