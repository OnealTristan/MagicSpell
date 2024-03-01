using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelMenuScript : MonoBehaviour
{
	[Header(" References ")]
	private Data data;
    private GameObject level2Button;

	private void Awake() {
		level2Button = GameObject.Find("Level2");
		data = GameObject.Find("DataManager").GetComponent<Data>();
	}

	private void Update() {
		if (data.level1IsClear == false) {
			level2Button.GetComponent<Button>().interactable = false;
		} else {
			level2Button.GetComponent<Button>().interactable = true;
		}
	}

	public void ClickLevel1Button () {
        Loader.Load(Loader.Scene.Level1);
    }

    public void ClickBackButton () {
        Loader.Load(Loader.Scene.MainMenu);
    }
}