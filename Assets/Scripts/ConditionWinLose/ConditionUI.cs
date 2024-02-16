using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionUI : MonoBehaviour
{
    [Header(" References ")]
    [SerializeField] private GameObject winConditionPanel;
    [SerializeField] private GameObject loseConditionPanel;

    public void ShowWinPanel() {
        winConditionPanel.SetActive(true);
    }

	public void HideWinPanel() {
        winConditionPanel.SetActive(false);
	}

	public void ShowLosePanel() {
        loseConditionPanel.SetActive(true);
	}

	public void HideLosePanel() {
        loseConditionPanel.SetActive(false);
	}
}
