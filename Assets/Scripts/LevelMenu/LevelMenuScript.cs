using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelMenuScript : MonoBehaviour
{
	[Header(" References ")]
	private Data data;
    private Button level2Button;
	private Button level3Button;

	private void Awake() {
		level2Button = GameObject.Find("Level2").GetComponent<Button>();
		level3Button = GameObject.Find("Level3").GetComponent<Button>();
		data = GameObject.FindGameObjectWithTag("Data").GetComponent<Data>();
	}

	private void Update() {
		if (data.level1IsClear == false) {
			level2Button.interactable = false;
		} else {
			level2Button.interactable = true;
		}

		if (data.level2IsClear == false) {
			level3Button.interactable = false;
		} else {
			level3Button.interactable = true;
		}
	}

	public void ClickLevel1Button () {
        Loader.Load(Loader.Scene.Level1);
    }

	public void ClickLevel2Button() {
		Loader.Load(Loader.Scene.Level2);
	}

	public void ClickLevel3Button() {
		Loader.Load(Loader.Scene.Level3);
	}

	public void ClickBackButton () {
        Loader.Load(Loader.Scene.MainMenu);
    }
}