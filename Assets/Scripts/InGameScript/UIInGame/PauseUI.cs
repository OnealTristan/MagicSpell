using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUI : MonoBehaviour
{
	[SerializeField] private GameObject pausePanel;
    private PauseScript pauseScript;

	private void Awake() {
		pauseScript = GetComponent<PauseScript>();
	}

	// Start is called before the first frame update
	void Start()
    {
        HidePausePanel();
		pauseScript.OnPauseClick += PauseScript_OnPauseClick;
		pauseScript.OnResumeClick += PauseScript_OnResumeClick;
    }

	private void PauseScript_OnResumeClick(object sender, System.EventArgs e) {
		HidePausePanel();
	}

	private void PauseScript_OnPauseClick(object sender, System.EventArgs e) {
		ShowPausePanel();
	}

	private void HidePausePanel() {
        pausePanel.SetActive(false);
    }

    private void ShowPausePanel() {
		pausePanel.SetActive(true);
	}
}