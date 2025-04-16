using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Chapter", menuName = "ScriptableObjects/ChapterSO")]
public class ChapterSO : ScriptableObject
{
	public Sprite backgroundChapter;
	public string chapterName;
	public int starterEnemyHealthChapter;

	public bool chapterComplete;
	public bool[] chapterLevelClear;
	public int[] chapterLevelLosePrize;
	public int[] chapterLevelWinPrize;
	public int[] chapterLevelWinPrizeAfterComplete;
}