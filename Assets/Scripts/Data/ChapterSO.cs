using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Chapter", menuName = "ScriptableObjects/ChapterSO")]
public class ChapterSO : ScriptableObject
{
	public string chapterName;

	public bool[] chapterLevelClear;
}
