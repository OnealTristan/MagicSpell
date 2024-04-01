using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionScript : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private Loader.Scene restartScene;
    [SerializeField] private Loader.Scene nextLevelScene;

    public void NextLevel() {
        Loader.Load(nextLevelScene);
    }

    public void RestartLevel() {
        Loader.Load(restartScene);
	}

    public void MenuLevel() {
        Loader.Load(Loader.Scene.LevelMenu);
    }
}
