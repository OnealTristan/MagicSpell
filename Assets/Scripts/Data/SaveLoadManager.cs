using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public static class SaveLoadManager
{
	public static void SaveGame(Data data) {
		string saveFilePath = Application.persistentDataPath + "/data.json";

		SaveData saveData = new SaveData {
			coin = data.coin,
			chapter1ChapterLevelClear = data.chapter1.chapterLevelClear,
			achievements = new List<AchievementSaveData>()
		};

		foreach (var achievement in data.achievementSO) {
			AchievementSaveData achievementData = new AchievementSaveData {
				achievementCategoryName = achievement.achievementCategoryName,
				achievementCategoryWordsAchieved = achievement.achievementCategoryWordsAchieved,
				achievementCategoryClaimed = achievement.achievementCategoryClaimed,
				achievementCategoryDone = achievement.achievementCategoryDone,
			};
			saveData.achievements.Add(achievementData);
		}

		string json = JsonUtility.ToJson(saveData);
		File.WriteAllText(saveFilePath, json);
		Debug.Log("Data Saved!");
	}

	public static void LoadGame(Data data) {
		string saveFilePath = Application.persistentDataPath + "/data.json";

		if (File.Exists(saveFilePath)) {
			string json = File.ReadAllText(saveFilePath);
			SaveData saveData = JsonUtility.FromJson<SaveData>(json);

			data.coin = saveData.coin;
			data.chapter1.chapterLevelClear = saveData.chapter1ChapterLevelClear;

			foreach (var achievementData in saveData.achievements) {
				var achievement = data.achievementSO.FirstOrDefault(a => a.achievementCategoryName == achievementData.achievementCategoryName);
				if (achievement != null) {
					achievement.achievementCategoryWordsAchieved = achievementData.achievementCategoryWordsAchieved;
					achievement.achievementCategoryClaimed = achievementData.achievementCategoryClaimed;
					achievement.achievementCategoryDone = achievementData.achievementCategoryDone;
				}
			}

			Debug.Log("Data Loaded!");
		} else {
			Debug.LogError("File doesn't exist");
			return;
		}
	}
}
