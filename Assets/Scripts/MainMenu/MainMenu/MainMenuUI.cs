using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
	public void ShowMainMenuPanel() {
		gameObject.SetActive(true);
	}

	public void HideMainMenuPanel() {
		gameObject.SetActive(false);
	}
}
