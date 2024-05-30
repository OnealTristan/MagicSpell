using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementUI : MonoBehaviour
{
	public void ShowInventoryPanel() {
		gameObject.SetActive(true);
	}

	public void HideInventoryPanel() {
		gameObject.SetActive(false);
	}
}
