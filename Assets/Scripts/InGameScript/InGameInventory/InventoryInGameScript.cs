using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryInGameScript : MonoBehaviour {
    public Action OnInventoryButtonClick;
    public Action OnBackButtonClick;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void ClickInventoryButton() {
		GameManager.instance.UpdateGameState(GameManager.GameState.Pause);
		OnInventoryButtonClick?.Invoke();
		Time.timeScale = 0f;
	}

    public void ClickBackButton() {
		GameManager.instance.UpdateGameState(GameManager.GameState.OnGoing);
		OnBackButtonClick?.Invoke();
		Time.timeScale = 1f;
	}
}
