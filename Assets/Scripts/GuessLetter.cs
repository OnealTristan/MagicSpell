using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GuessLetter : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private NewKeyboard newKeyboard;
	[SerializeField] private TextMeshProUGUI textHuruf1;
	[SerializeField] private TextMeshProUGUI textHuruf2;

	private string[] letter;

    // Start is called before the first frame update
    void Start()
    {
        letter = newKeyboard.GetLetter();
        textHuruf1.text = letter[0].ToUpper();
        textHuruf2.text = letter[1].ToUpper();
	}

    // Update is called once per frame
    void Update()
    {

	}
}