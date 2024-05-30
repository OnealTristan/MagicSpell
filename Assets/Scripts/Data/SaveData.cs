using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
	public int coin;
	public bool[] chapter1ChapterLevelClear;
	public List<AchievementSaveData> achievements;
}