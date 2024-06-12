using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;

public class AchievementPanelUI : MonoBehaviour
{
    [Header(" Left Content References ")]
    [SerializeField] private AchievementSO achievementSoLeft;
    [SerializeField] private TextMeshProUGUI textCategoryLeft;
    [SerializeField] private Transform parentContentLeft;
    [SerializeField] private GameObject achievementContentPrefabLeft;
    [SerializeField] private TextMeshProUGUI textWordCountLeft;

	[Header(" Right Content References ")]
	[SerializeField] private AchievementSO achievementSoRight;
	[SerializeField] private TextMeshProUGUI textCategoryRight;
	[SerializeField] private Transform parentContentRight;
	[SerializeField] private GameObject achievementContentPrefabRight;
	[SerializeField] private TextMeshProUGUI textWordCountRight;

	// Start is called before the first frame update
	void Start()
    {
        LeftPanelContent();
        RightPanelContent();
    }

    private void LeftPanelContent () {
        textCategoryLeft.text = achievementSoLeft.achievementCategoryName;

        textWordCountLeft.text = achievementSoLeft.achievementCategoryWordsAchieved.Length + " / " + achievementSoLeft.achievementCategoryWords.Length;

        for (int i = 0; i < achievementSoLeft.achievementCategoryWords.Length; i++) {
            GameObject panelInstance = Instantiate(achievementContentPrefabLeft, parentContentLeft);

            TextMeshProUGUI textContent = panelInstance.GetComponentInChildren<TextMeshProUGUI>();

            string word = achievementSoLeft.achievementCategoryWords[i];
            if (Array.Exists(achievementSoLeft.achievementCategoryWordsAchieved, element => element == word)) {
                textContent.text = word;
            } else {
                textContent.text = "???";
            }
        }
    }

    private void RightPanelContent () {
		textCategoryRight.text = achievementSoRight.achievementCategoryName;

		textWordCountRight.text = achievementSoRight.achievementCategoryWordsAchieved.Length + " / " + achievementSoRight.achievementCategoryWords.Length;

		for (int i = 0; i < achievementSoRight.achievementCategoryWords.Length; i++) {
			GameObject panelInstance = Instantiate(achievementContentPrefabRight, parentContentRight);

			TextMeshProUGUI textContent = panelInstance.GetComponentInChildren<TextMeshProUGUI>();

			string word = achievementSoRight.achievementCategoryWords[i];
			if (Array.Exists(achievementSoRight.achievementCategoryWordsAchieved, element => element == word)) {
				textContent.text = word;
			} else {
				textContent.text = "???";
			}
		}
	}
}