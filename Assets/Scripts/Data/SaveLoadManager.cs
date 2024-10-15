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
			weapons = new List<WeaponSaveData>(),
			chapters = new List<ChapterSaveData>(),
			achievements = new List<AchievementSaveData>()
		};

		foreach (var weapons in data.weaponSO) {
			WeaponSaveData weaponSaveData = new() {
				weaponName = weapons.weaponName,
				weaponBuyed = weapons.weaponBuyed,
				weaponEquip = weapons.weaponEquip
			};
			saveData.weapons.Add(weaponSaveData);
		}

		foreach (var chapters in data.chapterSo) {
			ChapterSaveData chapterSaveData = new() { 
				chapterName = chapters.chapterName,
				chapterComplete = chapters.chapterComplete,
				chapterLevelClear = chapters.chapterLevelClear
			};
			saveData.chapters.Add(chapterSaveData);
		}

		foreach (var achievement in data.achievementSO) {
			AchievementSaveData achievementData = new() {
				achievementCategoryName = achievement.achievementCategoryName,
				achievementCategoryWordsAchieved = achievement.achievementCategoryWordsAchieved,
				achievementCategoryClaimed = achievement.achievementCategoryClaimed,
				achievementCategoryDone = achievement.achievementCategoryDone
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
			
			foreach (var weaponData in saveData.weapons) {
				var weapon = data.weaponSO.FirstOrDefault(a => a.weaponName == weaponData.weaponName);
				if (weapon != null) {
					weapon.weaponBuyed = weaponData.weaponBuyed;
					weapon.weaponEquip = weaponData.weaponEquip;
				}
			}

			foreach (var chapterData in saveData.chapters) {
				var chapter = data.chapterSo.FirstOrDefault(a => a.chapterName == chapterData.chapterName);
				if (chapter != null) {
					chapter.chapterComplete = chapterData.chapterComplete;
					chapter.chapterLevelClear = chapterData.chapterLevelClear;
				}
			}

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