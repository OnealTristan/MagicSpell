using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Achievement : MonoBehaviour
{
    [Header(" References ")]
    public AchievementSO[] achievements;

	public void AchievementCheck(string word) {
		word = word.ToLower();
		// iterasi semua achievement yang ada dalam array AchivementSO
		foreach (var achievement in achievements) {
			// Iterasi semua isi dari masing masing achievement
			for (int i = 0; i < achievement.achievementCategoryWords.Length; i++) {
				// Logika jika isi dari achievement sama dengan kata yang di kirim
				if (achievement.achievementCategoryWords[i].ToLower() == word) {
					// Logika jika kata yang di kirim tidak ada dalam kata yang sudah di achieved
					if (!achievement.achievementCategoryWordsAchieved.Contains(word)) {
						var achievedWordsList = new List<string>(achievement.achievementCategoryWordsAchieved);
						achievedWordsList.Add(word);
						achievement.achievementCategoryWordsAchieved = achievedWordsList.ToArray();

						Debug.Log("Achievement Unlocked on Category " + achievement.achievementCategoryName + ": " + word);
					} else {
						Debug.Log("Achievement Already Unlocked on Category " + achievement.achievementCategoryName + ": " + word);
					}
				}
			}
		}
	}
}