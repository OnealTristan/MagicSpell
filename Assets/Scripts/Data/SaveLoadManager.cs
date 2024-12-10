using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public static class SaveLoadManager
{
	public static void SaveGame(Data data) {
		string saveFilePath = Application.persistentDataPath + "/data.json";

		SaveData saveData = new SaveData {
			coin = data.GetCoin(),
			maxHealthPlayer = data.GetMaxHealthPlayer(),
			weapons = new List<WeaponSaveData>(),
			chapters = new List<ChapterSaveData>(),
			achievements = new List<AchievementSaveData>()
		};

		foreach (var weapons in data.weaponSO) {
			if (weapons.weaponBuyed == true) {
				WeaponSaveData weaponSaveData = new() {
					weaponName = weapons.weaponName,
					weaponBuyed = weapons.weaponBuyed,
					weaponEquip = weapons.weaponEquip
				};
				saveData.weapons.Add(weaponSaveData);
			}
		}

		foreach (var chapters in data.chapterSO) {
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

		Debug.Log($"Saving Max Health Player: {saveData.maxHealthPlayer}");

		string json = JsonUtility.ToJson(saveData);
		File.WriteAllText(saveFilePath, json);
		Debug.Log("Data Saved!");
	}

	public static void LoadGame(Data data) {
		string saveFilePath = Application.persistentDataPath + "/data.json";

		if (File.Exists(saveFilePath)) {
			string json = File.ReadAllText(saveFilePath);
			SaveData saveData = JsonUtility.FromJson<SaveData>(json);

			data.SetCoin(saveData.coin);

			if (saveData.maxHealthPlayer <= 0) {
				saveData.maxHealthPlayer = 10;
				Debug.LogWarning("Invalid Max Health Player in JSON. Setting to default value.");
			}
			data.SetMaxHealthPlayer(saveData.maxHealthPlayer);
			
			foreach (var weaponData in saveData.weapons) {
				var weapon = data.weaponSO.FirstOrDefault(a => a.weaponName == weaponData.weaponName);
				if (weapon != null && weaponData.weaponBuyed == true) {
					weapon.weaponBuyed = weaponData.weaponBuyed;
					weapon.weaponEquip = weaponData.weaponEquip;
				}
			}

			foreach (var chapterData in saveData.chapters) {
				var chapter = data.chapterSO.FirstOrDefault(a => a.chapterName == chapterData.chapterName);
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

			Debug.Log($"Loaded Max Health Player: {saveData.maxHealthPlayer}");

			Debug.Log("Data Loaded!");
		} else {
			Debug.LogError("File doesn't exist");
			return;
		}
	}
}