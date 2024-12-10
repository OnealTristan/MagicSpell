using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUI : MonoBehaviour
{
	[Header (" References ")]
    private PauseScript pauseScript;
	[SerializeField] private GameObject panelMenu;

	private void Awake() {
		pauseScript = GetComponent<PauseScript>();

		if (pauseScript != null) {
			Debug.Log("PauseScript Exist");
		} else {
			Debug.Log("PauseScript not Exist");
		}
	}

	// Start is called before the first frame update
	void Start()
    {
		if (pauseScript != null) {
			Debug.Log("PauseScript Exist");
		} else {
			Debug.Log("PauseScript not Exist");
		}
		pauseScript.OnPauseClick += PauseScript_OnPauseClick;
		pauseScript.OnResumeClick += PauseScript_OnResumeClick;
    }

	private void PauseScript_OnResumeClick() {
		panelMenu.SetActive(false);
	}

	private void PauseScript_OnPauseClick() {
		panelMenu.SetActive(true);
	}
}