using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
	public Action OnPauseClick;
	public Action OnResumeClick;

	public void ClickPauseButton() {
		OnPauseClick?.Invoke();
	}

    public void ClickNoButton() {
		OnResumeClick?.Invoke();
	}

    public void ClickYesButton() {
        Loader.Load(Loader.Scene.MainMenu);
	}

    /*public void OnClickSettingButton() {
		pauseMenuUI.SetActive(false);
		settingMenuUI.SetActive(true);
	}*/
}