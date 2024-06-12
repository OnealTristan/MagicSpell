 using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelMenuScript : MonoBehaviour
{
	[Header(" References ")]
	[SerializeField] private Button[] levelButtons;

	[Space(10)]
	[SerializeField] private GameObject ContainerChapter;

	[Space(10)]
	[SerializeField] private GameObject chapter1PanelPopUpContainer;
	[SerializeField] private GameObject[] chapter1LevelPanelPopUp;
	private Data data;

	[Header(" Elements ")]
	private int levelIndex;

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

	private void UpdateLevelPrizeText(int index) {
		TextMeshProUGUI[] textsPrize = gameObject.GetComponentsInChildren<TextMeshProUGUI>();

		foreach(TextMeshProUGUI textPrize in textsPrize) {
			if (textPrize.CompareTag("TextPrizeLevel")) {
				if (data.CheckLevelStatus(index) == true) {
					textPrize.text = "X " + data.chapter1.chapterLevelWinPrizeAfterComplete[index - 1].ToString();
				} else {
					textPrize.text = "X " + data.chapter1.chapterLevelWinPrize[index - 1].ToString();
				}
			}
		}
	}

	public void ClickLevelButton(int index) {
		chapter1PanelPopUpContainer.SetActive(true);
		chapter1LevelPanelPopUp[index-1].SetActive(true);
		UpdateLevelPrizeText(index);
		ContainerChapter.SetActive(false);
	}

	public void ClickChapter1PanelButtonBackLevel(int index) {
		chapter1PanelPopUpContainer.SetActive(false);
		chapter1LevelPanelPopUp[index - 1].SetActive(false);
		ContainerChapter.SetActive(true);
	}

	public void ClickChapter1PanelButtonPlayLevel(int levelIndex) {
		Loader.Load((Loader.Scene)levelIndex);
	}

	public void ClickBackButton () {
        Loader.Load(Loader.Scene.MainMenu);
    }
}