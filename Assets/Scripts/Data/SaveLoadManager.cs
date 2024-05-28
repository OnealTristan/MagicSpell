using UnityEngine;
using System.IO;

public static class SaveLoadManager
{
	public static void SaveGame(Data data) {
		string saveFilePath = Application.persistentDataPath + "/data.json";

		SaveData saveData = new SaveData {
			coin = data.coin,
			chapter1ChapterLevelClear = data.chapter1.chapterLevelClear
		};

		string json = JsonUtility.ToJson(saveData);
		File.WriteAllText(saveFilePath, json);
		Debug.Log("Data Saved!. Coin : " + data.coin + " Level : " + data.chapter1.chapterLevelClear);
	}

	public static void LoadGame(Data data) {
		string saveFilePath = Application.persistentDataPath + "/data.json";

		if (File.Exists(saveFilePath)) {
			string json = File.ReadAllText(saveFilePath);
			SaveData saveData = JsonUtility.FromJson<SaveData>(json);

			data.coin = saveData.coin;
			data.chapter1.chapterLevelClear = saveData.chapter1ChapterLevelClear;

			Debug.Log("Data Loaded!. Coin : " + data.coin + " Level : " + data.chapter1.chapterLevelClear);
		} else {
			Debug.LogError("File doesn't exist");
			return;
		}
	}
}
