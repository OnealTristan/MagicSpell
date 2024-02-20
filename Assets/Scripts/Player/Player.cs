using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	public Action<int> OnDecreaseHPEnemy;

	[Header(" References ")]
	[SerializeField] private Text text;
	[SerializeField] private Enemy enemy;

    [Header("Weapon 1")]
    [SerializeField] private bool weapon1IsActive;
    [SerializeField] private int weapon1Damage;

	[Header("Weapon 2")]
	[SerializeField] private bool weapon2IsActive;
	[SerializeField] private int weapon2Damage;

	[Header("Weapon 3")]
	[SerializeField] private bool weapon3IsActive;
	[SerializeField] private int weapon3Damage;

	[Header(" Unicorn Wand ")]
    [SerializeField] private bool unicornWandIsActive;

	[Header(" Book ")]
	[SerializeField] private bool bookIsActive;
	private int bookDamage;

	[Header(" Attributes ")]
	[SerializeField] private int maxHealth;
	private int health;

    private int correctLetterCount;

	private void Awake() {
		health = maxHealth;
	}

	private void Start() {

	}

	public void ActivatedWeapon() {
		if (OnDecreaseHPEnemy != null) {
			if (weapon1IsActive == true) {
				Weapon1();
			} else if (weapon2IsActive == true) {
				Weapon2();
			} else if (weapon3IsActive == true) {
				Weapon3();
			} else if (unicornWandIsActive == true) {
				CorrectLetter();
				Weapon5();
			} else if (bookIsActive == true) {
				Book();
			}
		}
	}

    private void Weapon1() {
		Debug.Log("Weapon 1 Activated!");
		enemy.SetEnemyHealth(enemy.GetEnemyHealth() - weapon1Damage);
		OnDecreaseHPEnemy?.Invoke(enemy.GetEnemyHealth());
    }

	private void Weapon2() {
		Debug.Log("Weapon 2 Activated!");
		enemy.SetEnemyHealth(enemy.GetEnemyHealth() - weapon2Damage);
		OnDecreaseHPEnemy?.Invoke(enemy.GetEnemyHealth());
	}

	private void Weapon3() {
		Debug.Log("Weapon 3 Activated!");
		enemy.SetEnemyHealth(enemy.GetEnemyHealth() - weapon3Damage);
		OnDecreaseHPEnemy?.Invoke(enemy.GetEnemyHealth());
	}

	private void Weapon5() {
		Debug.Log("Weapon 5 Activated!");
		//CorrectLetter();
		OnDecreaseHPEnemy?.Invoke(correctLetterCount);
    }

	private void Book() {
		Debug.Log("Weapon 5 Activated!");
		CorrectLetter();
		bookDamage = correctLetterCount * 2;
		Debug.Log("Book Damage: " + bookDamage);
		OnDecreaseHPEnemy?.Invoke(bookDamage);
	}

	private void CorrectLetter() {
		correctLetterCount = 0;
		Debug.Log("CorrecLetter Method Active");
		for (int i = 0; i < text.text.Length; i++) {
			correctLetterCount++;
			Debug.Log("Correct Letter ke-" + correctLetterCount);
		}
		Debug.Log("Total correct count: " + correctLetterCount);
	}

	public int GetPlayerHealth() {
		return health;
	}

	public int SetPlayerHealth(int health) {
		return this.health = health;
	}
}