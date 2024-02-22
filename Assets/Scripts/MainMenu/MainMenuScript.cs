using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
	private void Start() {

	}

	public void OnClickStartButton () {
        Debug.Log("Start Clicked");
        Loader.Load(Loader.Scene.LevelMenu);
    }
}
