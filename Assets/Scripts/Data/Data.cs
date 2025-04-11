using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Data : MonoBehaviour
{
    public static Data instance;

    [Header(" Elements ")]
    [SerializeField] private int coin;
	private int maxHealthPlayer = 10;
	//projectMode(true) == PA else == KP
	[SerializeField] private bool projectMode;
	[SerializeField] private int chapterIndex;
	[SerializeField] private int levelIndex;
	private bool onGame;

	[Header(" References ")]
    public WeaponSO[] weaponSO;
	public PotionSO[] potionSO;
    public ChapterSO[] chapterSO;
    public AchievementSO[] achievementSO;

	private void Awake() {
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy(gameObject);
		}
	}

	private void Start() {
		LoadGame();
	}

	private void Update() {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			if (SceneManager.GetActiveScene().buildIndex == 1) {
				Application.Quit();
			} else {
				SceneManager.LoadScene(1);
			}
		}
	}

	private void OnApplicationPause(bool pause) {
		SaveGame();
	}

	private void OnApplicationQuit() {
        SaveGame();
	}

    private void SaveGame() {
        SaveLoadManager.SaveGame(this);
    }

    private void LoadGame() {
		SaveLoadManager.LoadGame(this);
	}

    public int GetCoin() {return coin;}

    public int SetCoin(int coin) {return this.coin = coin;}

	public int GetMaxHealthPlayer() {return maxHealthPlayer;}

	public int SetMaxHealthPlayer(int index) { return maxHealthPlayer = index; }

	public bool GetProjectMode() {return projectMode;}

	public int GetLevelIndex() {return levelIndex;}

	public int SetLevelIndex(int index) {return levelIndex = index;}

	public int GetChapterIndex() {return chapterIndex;}

	public int SetChapterIndex(int index) {return chapterIndex = index;}

	public void UpdateLevelStatus(int chapterIndex, int levelIndex, bool isClear) {
        chapterSO[chapterIndex].chapterLevelClear[levelIndex] = isClear;
        CheckChapterStatus(chapterIndex);
    }

    private void CheckChapterStatus (int chapterIndex) {
        if (chapterSO[chapterIndex].chapterLevelClear[9] == true) {
            chapterSO[chapterIndex].chapterComplete = true;
        }
    }

    public bool CheckLevelStatus(int chapterIndex, int levelIndex) {
        if (chapterSO[chapterIndex].chapterLevelClear[levelIndex - 1] == true) {
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