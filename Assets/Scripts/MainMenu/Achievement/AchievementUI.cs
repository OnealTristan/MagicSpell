using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementUI : MonoBehaviour {
	[Header(" References ")]
	[SerializeField] private GameObject[] panels;
	[SerializeField] private Button nextButton;
	[SerializeField] private Button prevButton;

	[Header(" Elements ")]
	private int currentPanelIndex = 0;

	private void Start() {
		UpdatePanel();
		UpdateButtons();
	}

	public void NextPanel() {
		if (currentPanelIndex < panels.Length - 1) {
			currentPanelIndex++;
			UpdatePanel();
			UpdateButtons();
		}
	}

	public void PrevPanel() {
		if (currentPanelIndex > 0) {
			currentPanelIndex--;
			UpdatePanel();
			UpdateButtons();
		}
	}

	private void UpdatePanel() {
		for (int i = 0; i < panels.Length; i++) {
			panels[i].SetActive(i == currentPanelIndex);
		}
	}

	private void UpdateButtons() {
		nextButton.gameObject.SetActive(currentPanelIndex < panels.Length - 1);
		prevButton.gameObject.SetActive(currentPanelIndex > 0);
	}

	public void ShowInventoryPanel() {
		gameObject.SetActive(true);
	}

	public void HideInventoryPanel() {
		gameObject.SetActive(false);
	}
}