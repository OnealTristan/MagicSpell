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
        TextAsset textFile = Resources.Load("words") as TextAsset;
        validWords = textFile.text.Split("\n");
    }

    public string[] GetValidWords() {
        return validWords;
    }
}
