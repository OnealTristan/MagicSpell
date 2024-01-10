using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuessLetter : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private Key letterPrefab;

    [Header(" Settings ")]
	[Range(0f, 1f)]
	[SerializeField] private float widthPercent;
	[Range(0f, 1f)]
	[SerializeField] private float heightPercent;
	[Range(0f, 1f)]
	[SerializeField] private float scale;
	[Range(0f, 10f)]
	[SerializeField] private float letterSpacing;

	private string letter;

    // Start is called before the first frame update
    void Start()
    {
        inputManager.OnShowLetterLine += OnShowLetterLine;
	}

    // Update is called once per frame
    void Update()
    {
		UpdateRectTransform();
		PlaceLetter();
	}

	private void UpdateRectTransform() {
		float width = widthPercent * Screen.width;
		float height = heightPercent * Screen.height;

		rectTransform.sizeDelta = new Vector2(width, height);

		Vector2 position;
		position.x = Screen.width / 2;
		position.y = Screen.height / 2;

		rectTransform.position = position;
	}

	private void CreateLetter() {
		for (int i = 0; i < letter.Length; i++) {
            char key = letter[i];
			Key keyInstance = Instantiate(letterPrefab, rectTransform);

			keyInstance.SetKey(key);
		}
	}

	private void PlaceLetter() {
		int lineCount = letter.Length;

		float lineHeight = rectTransform.rect.height / lineCount;

		float keyWidth = lineHeight * scale;
		float xSpacing = letterSpacing * lineHeight;

		int currentKeyIndex = 0;

		for (int i = 0; i < letter.Length; i++) {
			char key = letter[i];
			Key keyInstance = rectTransform.GetChild(currentKeyIndex).GetComponent<Key>();

			float halfKeyCount = (float)letter[i].ToString().Length / 2;
			float startX = rectTransform.position.x - (keyWidth + xSpacing) * halfKeyCount + (keyWidth + xSpacing) / 2;

			float keyX = startX + i * (keyWidth + xSpacing);

			float lineY = rectTransform.position.y + rectTransform.rect.height / 2 - lineHeight / 2;

			RectTransform keyRectTransform = keyInstance.GetComponent<RectTransform>();
			Vector2 keyPosition = new Vector2(keyX, lineY);
			keyRectTransform.position = keyPosition;

			keyRectTransform.sizeDelta = new Vector2(keyWidth, keyWidth);

			currentKeyIndex++;
		}
	}

	private void OnShowLetterLine(string huruf) {
        this.letter = huruf;
        Debug.Log(huruf);

		CreateLetter();
    }
}