 using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public class LevelMenuScript : MonoBehaviour {
	[Header(" References ")]
	[SerializeField] private GameObject[] ChapterScrollView;
	[SerializeField] private GameObject ButtonRight;
	[SerializeField] private GameObject ButtonLeft;

	[SerializeField] private TextMeshProUGUI textHabitat;
	[SerializeField] private TextMeshProUGUI textChapter;

	[Space(10)]
	[SerializeField] private GameObject ContainerChapter;

	[Header(" Chapter 1 Panel PopUp ")]
	[SerializeField] private GameObject chapter1PanelPopUpContainer;
	[SerializeField] private GameObject[] chapter1LevelPanelPopUp;
	
	private Data data;

	[Header(" Elements ")]
	[SerializeField]private int chapterIndex;

	private void Awake() {
		data = GameObject.FindGameObjectWithTag("Data").GetComponent<Data>();
	}

	private void Start() {
		UpdateNavigationButtonInteraction();
		UpdateLevelButtonInteractable();
		UpdateChapterName();
	}

	private void UpdateNavigationButtonInteraction() {
		if (chapterIndex == 0) {
			ButtonLeft.SetActive(false);
		} else if (chapterIndex == ChapterScrollView.Length - 1) {
			ButtonRight.SetActive(false);
		} else if (chapterIndex < ChapterScrollView.Length - 1) {
			ButtonRight.SetActive(true);
			ButtonLeft.SetActive(true);
		}
	}

	private void UpdateChapterName () {
		if (data.chapterSO.Length > chapterIndex) {
			textHabitat.text = data.chapterSO[chapterIndex].chapterName;
			textChapter.text = "Chapter " + (chapterIndex+1).ToString();
		}
	}

	public void ClickChangeChapterButtonRight() {
		if (chapterIndex < ChapterScrollView.Length - 1) {
			chapterIndex++;
			UpdateNavigationButtonInteraction();
			UpdateLevelButtonInteractable();
			UpdateChapterName();
			ChapterScrollView[chapterIndex - 1].gameObject.SetActive(false);
			ChapterScrollView[chapterIndex].gameObject.SetActive(true);
		}
	}

	public void ClickChangeChapterButtonLeft() {
		if (chapterIndex > 0) {
			chapterIndex--;
			UpdateNavigationButtonInteraction();
			UpdateLevelButtonInteractable();
			UpdateChapterName();
			ChapterScrollView[chapterIndex + 1].gameObject.SetActive(false);
			ChapterScrollView[chapterIndex].gameObject.SetActive(true);
		}
	}

	private void UpdateLevelButtonInteractable() {
		Button[] currentChapterLevelButtons = ChapterScrollView[chapterIndex].GetComponentsInChildren<Button>();

		for (int i = 0; i < data.chapterSO[chapterIndex].chapterLevelClear.Length; i++) {
			currentChapterLevelButtons[i].interactable = false;
		}

		if (chapterIndex == 0) {
			for (int i = 0; i < data.chapterSO[chapterIndex].chapterLevelClear.Length; i++) {
				if (i == 0 || data.chapterSO[chapterIndex].chapterLevelClear[i - 1] == true) {
					currentChapterLevelButtons[i].interactable = true;
				}
			}
		} else if (chapterIndex > 0) {
			if (data.chapterSO[chapterIndex - 1].chapterComplete == true) {
				for (int i = 0; i < data.chapterSO[chapterIndex].chapterLevelClear.Length; i++) {
					if (i == 0 || data.chapterSO[chapterIndex].chapterLevelClear[i - 1] == true) {
						currentChapterLevelButtons[i].interactable = true;
					}
				}
			}
		}
	}

	private void UpdateLevelPanelText(int levelIndex) {
		TextMeshProUGUI[] texts = gameObject.GetComponentsInChildren<TextMeshProUGUI>();

		foreach (TextMeshProUGUI text in texts) {
			if (text.CompareTag("TextPrizeLevelPanel")) {
				if (data.CheckLevelStatus(chapterIndex, levelIndex) == true) {
					text.text = "X " + data.chapterSO[chapterIndex].chapterLevelWinPrizeAfterComplete[levelIndex - 1].ToString();
				} else {
					text.text = "X " + data.chapterSO[chapterIndex].chapterLevelWinPrize[levelIndex - 1].ToString();
				}
			}

			if (text.CompareTag("TextHabitatLevelPanel")) {
				text.text = data.chapterSO[chapterIndex].chapterName;
			}

			if (text.CompareTag("TextLevelLevelPanel")) {
				int calculatedLevelIndex = levelIndex;

				for (int i = 0; i < chapterIndex; i++) {
					calculatedLevelIndex += data.chapterSO[i].chapterLevelClear.Length;
				}
				text.text = "Level " + (chapterIndex + 1) + " - " + (calculatedLevelIndex);
			}
		}
	}

	public void ClickLevelButton(int levelIndex) {
		chapter1PanelPopUpContainer.SetActive(true);
		chapter1LevelPanelPopUp[levelIndex - 1].SetActive(true);
		UpdateLevelPanelText(levelIndex);
		ContainerChapter.SetActive(false);
	}

	public void ClickChapter1PanelButtonBackLevel(int index) {
		chapter1PanelPopUpContainer.SetActive(false);
		chapter1LevelPanelPopUp[index - 1].SetActive(false);
		ContainerChapter.SetActive(true);
	}

	public void ClickChapter1PanelButtonPlayLevel(int levelIndex) {
		if (data.GetProjectMode() == false) {
			int calculatedlevelIndex = levelIndex;

			for (int i = 0; i < chapterIndex; i++) {
				calculatedlevelIndex += data.chapterSO[i].chapterLevelClear.Length;
			}

			Loader.Load((Loader.Scene)calculatedlevelIndex);
		} else {
			Loader.Load(Loader.Scene.GameLevel);
			data.SetChapterIndex(chapterIndex);
			data.SetLevelIndex(levelIndex - 1);
		}
	}

	public void ClickBackButton () {
        Loader.Load(Loader.Scene.MainMenu);
    }
}