using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject settingMenuUI;
    [SerializeField] private BackgroundMusic bgm;
    

    public static bool gameIsPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickPauseButton() {
        Pause();
    }

    public void OnClickResumeButton() {
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		gameIsPaused = false;
        bgm.UnpauseBgm();
	}

    private void Pause() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        bgm.PauseBgm();
    }

    public void OnClickExitButton() {
        Loader.Load(Loader.Scene.MainMenu);
		Time.timeScale = 1f;
		gameIsPaused = false;
	}

    public void OnClickSettingButton() {
		pauseMenuUI.SetActive(false);
		settingMenuUI.SetActive(true);
	}
}