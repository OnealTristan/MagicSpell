using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionScript : MonoBehaviour
{
    [Header(" References ")]
    private Data data;

    [Header(" Elements ")]
    [SerializeField] private Loader.Scene restartScene;
    [SerializeField] private Loader.Scene nextLevelScene;

	private void Awake() {
		data = GameObject.FindGameObjectWithTag("Data").GetComponent<Data>();
	}

	public void NextLevel() {
		// project Mode TA
        if (data.GetProjectMode() == true) {
            if (data.GetLevelIndex() == 9) {
                data.SetChapterIndex(data.GetChapterIndex() + 1);
                data.SetLevelIndex(0);
            } else {
				data.SetLevelIndex(data.GetLevelIndex() + 1);
			}
			Loader.Load(Loader.Scene.GameLevel);
		// project Mode KP
		} else {
			Loader.Load(nextLevelScene);
		}
	}

    public void RestartLevel() {
		if (data.GetProjectMode() == true) {
			Loader.Load(Loader.Scene.GameLevel);
		} else {
			Loader.Load(restartScene);
		}
	}

    public void MenuLevel() {
        Loader.Load(Loader.Scene.LevelMenu);
		Time.timeScale = 1f;
	}
}