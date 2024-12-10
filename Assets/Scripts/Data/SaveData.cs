using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
	public int coin;
	public int maxHealthPlayer;
	public List<WeaponSaveData> weapons;
	public List<ChapterSaveData> chapters;
	public List<AchievementSaveData> achievements;
}