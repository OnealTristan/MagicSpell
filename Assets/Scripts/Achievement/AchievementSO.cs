using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AchievementCategory", menuName = "ScriptableObjects/AchievementCategorySO")]
public class AchievementSO : ScriptableObject
{
	public string achievementCategoryName;
	public string[] achievementCategoryWords;
	public string[] achievementCategoryWordsAchieved;
	public bool achievementCategoryClaimed;
	public bool achievementCategoryDone;
}
