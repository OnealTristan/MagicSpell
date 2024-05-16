using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
	public Action OnPauseClick;
	public Action OnResumeClick;

    [Header(" References ")]
    private BackgroundMusic bgm;

	private void Awake() {
		bgm = GameObject.FindGameObjectWithTag("Bgm").GetComponent<BackgroundMusic>();
		if (bgm != null) {
			Debug.Log("BGM Exist");
		} else {
			Debug.Log("BGM not Exist");
		}
	}

	public void ClickPauseButton() {
		GameManager.instance.UpdateGameState(GameManager.GameState.Pause);
		OnPauseClick?.Invoke();
		Time.timeScale = 0f;
		bgm.PauseBgm();
	}

    public void ClickResumeButton() {
		GameManager.instance.UpdateGameState(GameManager.GameState.OnGoing);
		OnResumeClick?.Invoke();
		Time.timeScale = 1f;
        bgm.UnpauseBgm();
	}

    public void ClickExitButton() {
        Loader.Load(Loader.Scene.MainMenu);
		Time.timeScale = 1f;
	}

    /*public void OnClickSettingButton() {
		pauseMenuUI.SetActive(false);
		settingMenuUI.SetActive(true);
	}*/
}