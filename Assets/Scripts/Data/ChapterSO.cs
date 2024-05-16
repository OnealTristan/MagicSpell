using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Chapter", menuName = "Chapter")]
public class ChapterSO : ScriptableObject
{
	public string chapterName;

	public bool[] chapterLevelClear;
}
