using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
	public void StartButtonClick () {
        Debug.Log("Start Clicked");
        Loader.Load(Loader.Scene.LevelMenu);
    }
}
