using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneScript : MonoBehaviour
{
	public void SkipToMainMenu() {
		Loader.Load(Loader.Scene.MainMenu);
	}
}