using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUI : MonoBehaviour
{
    private PauseScript pauseScript;
    [SerializeField] private GameObject pausePanel;

	private void Awake() {
		pauseScript = GetComponent<PauseScript>();
	}

	// Start is called before the first frame update
	void Start()
    {
        HidePanel();
		pauseScript.OnPauseClick += PauseScript_OnPauseClick;
		pauseScript.OnResumeClick += PauseScript_OnResumeClick;
    }

	private void PauseScript_OnResumeClick(object sender, System.EventArgs e) {
		HidePanel();
	}

	private void PauseScript_OnPauseClick(object sender, System.EventArgs e) {
		ShowPanel();
	}

	public void HidePanel() {
        pausePanel.SetActive(false);
    }

    public void ShowPanel() {
		pausePanel.SetActive(true);
	}
}