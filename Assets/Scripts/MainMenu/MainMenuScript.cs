using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    public void OnClickStartButton () {
        Debug.Log("Start Clicked");
        Loader.Load(Loader.Scene.LevelMenu);
    }
}
