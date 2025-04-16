using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
	private static EventManager instance;

	[Header(" Event Keyboard Class ")]
	//UserInputDisplay-KeyPressedCallback
	public Action<string> onKeyPressed;

	//UserInputDisplay-BackspacePressedCallback
	public Action onBackspacePressed;

	/*
	Enemy-ResetInterval
	PlayerAnimation-Attack
	UserInputDisplay-EnterPressedCallback
	GuessLetter-SpawnBoxHuruf
	*/
	public Action onEnterPressedCorrect;

	/*
	PlayerAnimation-Idle
	EnemyAnimation-Attack
	UserInputDisplay-EnterPressedCallback
	*/
	public Action onEnterPressedWrong;

	[Header(" Event UserInputDisplay Class ")]
	/*
	PlayerAnimation-Spelling
	*/
	public Action onTextDisplay;

	/*
	PlayerAnimation-Idle
	*/
	public Action onTextEmpty;

	[Header(" Event Player Class ")]
	// HealthUI-DecreaseHPEnemy
	public Action<int> onDecreaseHPEnemy;

	/*
	Enemy-ResetInterval
	EnemyAnimation-Gethit
	*/
	public Action onHittingEnemy;

	[Header(" Event ShopScript Class ")]
	public Action onBuyWeapon;

	public Action onBuyPotion;

	private void Awake() {
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy(gameObject);
		}
	}

	public void OnKeyPressed(string key) {
		onKeyPressed?.Invoke(key);
	}

	public void OnBackspacePressed() {
		onBackspacePressed?.Invoke();
	}

	public void OnEnterPressedCorrect() {
        if (onEnterPressedCorrect != null)
            onEnterPressedCorrect?.Invoke();
	}

	public void OnEnterPressedWrong() {
		onEnterPressedWrong?.Invoke();
	}

	public void OnTextDisplay() {
		onTextDisplay?.Invoke();
	}

	public void OnTextEmpty() {
		onTextEmpty?.Invoke();
	}

	public void OnDecreaseHPEnemy(int health) {
		onDecreaseHPEnemy?.Invoke(health);
	}

	public void OnHittingEnemy() {
		onHittingEnemy?.Invoke();
	}

	public void OnBuyWeapon() {
		onBuyWeapon?.Invoke();
	}

	public void OnBuyPotion() {
		onBuyPotion?.Invoke();
	}
}