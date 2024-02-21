using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    private ScrollRect scrollRect;

	private void Start() {
		scrollRect = GetComponentInChildren<ScrollRect>();
		scrollRect.onValueChanged.AddListener(ListenerMethod);
	}

	public void OnClickStartButton () {
        Debug.Log("Start Clicked");
        Loader.Load(Loader.Scene.LevelMenu);
    }

	private void ListenerMethod(Vector2 value) {
		Debug.Log("ListenerMethod: " + value);
	}
}
