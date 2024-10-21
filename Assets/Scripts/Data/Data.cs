using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Data : MonoBehaviour
{
    public static Data Instance;

    [Header(" Elements ")]
    public int coin;

    [Header(" References ")]
    public WeaponSO[] weaponSO;
    public ChapterSO[] chapterSo;
    public AchievementSO[] achievementSO;

	private void Awake() {
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad(gameObject);
            //LoadGame();
		} else {
			Destroy(gameObject);
		}
	}

	private void OnApplicationQuit() {
        //SaveGame();
	}

    private void SaveGame() {
        SaveLoadManager.SaveGame(this);
    }

    private void LoadGame() {
		SaveLoadManager.LoadGame(this);
	}

    public int GetCoin() {
        return coin;
    }

    public int SetCoin(int coin) {
        return this.coin = coin;
    }

	public void UpdateLevelStatus(int chapterIndex, int levelIndex, bool isClear) {
        chapterSo[chapterIndex].chapterLevelClear[levelIndex] = isClear;
        CheckChapterStatus(chapterIndex);
    }

    private void CheckChapterStatus (int chapterIndex) {
        if (chapterSo[chapterIndex].chapterLevelClear[9] == true) {
            chapterSo[chapterIndex].chapterComplete = true;
        }
    }

    public bool CheckLevelStatus(int chapterIndex, int levelIndex) {
        if (chapterSo[chapterIndex].chapterLevelClear[levelIndex - 1] == true) {
            return true;
        } else {
            return false;
        }
    }

	public void AchievementCheck(string word) {
		word = word.ToLower();
		// iterasi semua achievement yang ada dalam array AchivementSO
		foreach (var achievement in achievementSO) {
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

						CheckIfCategoryCompleted();
					} else {
						Debug.Log("Achievement Already Unlocked on Category " + achievement.achievementCategoryName + ": " + word);
					}
				}
			}
		}
	}

	private void CheckIfCategoryCompleted() {
		foreach (var achievement in achievementSO) {
			bool allWordsAchieved = achievement.achievementCategoryWords.All(word => achievement.achievementCategoryWordsAchieved.Contains(word.ToLower()));

			if (allWordsAchieved) {
				achievement.achievementCategoryDone = true;
				Debug.Log("Achievement Category Completed: " + achievement.achievementCategoryName);
			}
		}
	}
}