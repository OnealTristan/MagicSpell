using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelMenuScript : MonoBehaviour
{
	[Header(" References ")]
	[SerializeField] private Button[] levelButtons;
	private Data data;

	private void Awake() {
		data = GameObject.FindGameObjectWithTag("Data").GetComponent<Data>();
	}

	private void Start() {
		UpdateLevelButtonInteractable();
	}

	private void UpdateLevelButtonInteractable() {
		for (int i = 0; i < data.chapter1LevelClear.Length; i++) {
			if (i == 0 || data.chapter1LevelClear[i - 1] == true) {
				levelButtons[i].interactable = true;
			} else {
				levelButtons[i].interactable = false;
			}
		}
	}
	
	public void ClickLevelButton(int levelIndex) {
		Loader.Load((Loader.Scene)levelIndex);
	}

	public void ClickBackButton () {
        Loader.Load(Loader.Scene.MainMenu);
    }
}