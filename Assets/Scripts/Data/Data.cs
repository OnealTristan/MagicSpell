using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    public static Data Instance;

    [Header(" Elements ")]
    public int coin;

    [Header(" References ")]
    public ChapterSO[] chapterSo;
    public AchievementSO[] achievementSO;

    //private SaveLoadManager saveLoadManager;

	private void Awake() {
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad(gameObject);
            LoadGame();
		} else {
			Destroy(gameObject);
		}
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

	public void UpdateLevelStatus(int chapterIndex, int levelIndex, bool isClear) {
        chapterSo[chapterIndex].chapterLevelClear[levelIndex - 1] = isClear;
    }

    public bool CheckLevelStatus(int chapterIndex, int levelIndex) {
        if (chapterSo[chapterIndex].chapterLevelClear[levelIndex - 1] == true) {
            return true;
        } else {
            return false;
        }
    }

    public int GetCoin() {
        return coin;
    }

    public int SetCoin(int coin) {
        return this.coin = coin;
    }
}