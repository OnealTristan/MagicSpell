using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryInGameScript : MonoBehaviour {
    public Action OnInventoryButtonClick;
    public Action OnBackButtonClick;

    [Header(" References ")]
    [SerializeField] private WeaponSO oakWand;
    [SerializeField] private WeaponSO phoenixWand;
    [SerializeField] private WeaponSO thunderWand;

	private void Awake() {
		
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
