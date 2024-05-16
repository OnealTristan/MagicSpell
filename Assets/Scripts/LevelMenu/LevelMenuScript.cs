 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelMenuScript : MonoBehaviour
{
	[Header(" References ")]
	[SerializeField] private Button[] levelButtons;

	[Space(10)]
	[SerializeField] private GameObject chapter1DescPanel;
	[SerializeField] private GameObject[] chapter1DescLevelPanel;
	private Data data;

	private void Awake() {
		data = GameObject.FindGameObjectWithTag("Data").GetComponent<Data>();
	}

	private void Start() {
		UpdateLevelButtonInteractable();
	}

	private void UpdateLevelButtonInteractable() {
		for (int i = 0; i < data.chapter1.chapterLevelClear.Length; i++) {
			if (i == 0 || data.chapter1.chapterLevelClear[i - 1] == true) {
				levelButtons[i].interactable = true;
			} else {
				levelButtons[i].interactable = false;
			}
		}
	}

	public void ClickLevelButton(int index) {
		chapter1DescPanel.SetActive(true);
		chapter1DescLevelPanel[index-1].SetActive(true);
	}

	public void ClickChapter1PanelButtonBackLevel(int index) {
		chapter1DescPanel.SetActive(false);
		chapter1DescLevelPanel[index - 1].SetActive(false);
	}

	public void ClickChapter1PanelButtonPlayLevel(int levelIndex) {
		Loader.Load((Loader.Scene)levelIndex);
	}

	public void ClickBackButton () {
        Loader.Load(Loader.Scene.MainMenu);
    }
}