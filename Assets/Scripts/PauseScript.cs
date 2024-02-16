using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
	public event EventHandler OnPauseClick;
	public event EventHandler OnResumeClick;

    [Header(" References ")]
    [SerializeField] private BackgroundMusic bgm;
    

    public static bool gameIsPaused = false;

    public void ClickPauseButton() {
		GameManager.instance.UpdateGameState(GameManager.GameState.Pause);
		OnPauseClick?.Invoke(this, EventArgs.Empty);
		Time.timeScale = 0f;
		gameIsPaused = true;
		bgm.PauseBgm();
	}

    public void ClickResumeButton() {
		GameManager.instance.UpdateGameState(GameManager.GameState.OnGoing);
		OnResumeClick?.Invoke(this, EventArgs.Empty);
		Time.timeScale = 1f;
		gameIsPaused = false;
        bgm.UnpauseBgm();
	}

    public void ClickExitButton() {
        Loader.Load(Loader.Scene.MainMenu);
		Time.timeScale = 1f;
		gameIsPaused = false;
	}

    /*public void OnClickSettingButton() {
		pauseMenuUI.SetActive(false);
		settingMenuUI.SetActive(true);
	}*/
}