using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryInGameScript : MonoBehaviour {
    public Action OnInventoryButtonClick;
    public Action OnBackButtonClick;

    [Header(" References ")]
    [SerializeField] private Player player;
    [Space(10)]
    [SerializeField] private WeaponSO oakWand;
    [SerializeField] private WeaponSO phoenixWand;
    [SerializeField] private WeaponSO thunderWand;

    public void ClickOakWandEquipButton() {
        player.EquipWeapon(oakWand);
		Debug.Log("Weapon " + oakWand.name + " Equipped!");
	}

	public void ClickPhoenixWandEquipButton() {
		player.EquipWeapon(phoenixWand);
		Debug.Log("Weapon " + phoenixWand.name + " Equipped!");
	}

	public void ClickThunderWandEquipButton() {
		player.EquipWeapon(thunderWand);
		Debug.Log("Weapon " + thunderWand.name + " Equipped!");
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
