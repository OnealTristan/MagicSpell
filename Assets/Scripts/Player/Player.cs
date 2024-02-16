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
	[SerializeField] private EnemyDisplay enemy;

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
	[SerializeField] private int health;
    private int correctLetterCount;

	private void Start() {

	}

	public void ActivatedWeapon() {
		if (weapon1IsActive == true) {
			Weapon1();
		} else if (weapon2IsActive == true) {
			Weapon2();
		} else if (weapon3IsActive == true) {
			Weapon3();
		} else if (unicornWandIsActive == true) {
			Weapon5();
		} else if (bookIsActive == true) {
			Book();
		}
	}

    private void Weapon1() {
		Debug.Log("Weapon 1 Activated!");
		OnDecreaseHPEnemy?.Invoke(weapon1Damage);
    }

	private void Weapon2() {
		Debug.Log("Weapon 2 Activated!");
		OnDecreaseHPEnemy?.Invoke(weapon2Damage);
	}

	private void Weapon3() {
		Debug.Log("Weapon 3 Activated!");
		OnDecreaseHPEnemy?.Invoke(weapon3Damage);
	}

	private void Weapon5() {
		correctLetterCount = 0;
		Debug.Log("Weapon 5 Activated!");
		CorrectLetter();
		OnDecreaseHPEnemy?.Invoke(correctLetterCount);
    }

	private void Book() {
		correctLetterCount = 0;
		Debug.Log("Weapon 5 Activated!");
		CorrectLetter();
		bookDamage = correctLetterCount * 2;
		OnDecreaseHPEnemy?.Invoke(bookDamage);
	}

	private void CorrectLetter() {
		for (int i = 0; i < (text.text.Length); i++) {
			correctLetterCount++;
		}
	}

	public int GetPlayerHealth() {
		return health;
	}

	public int SetPlayerHealth(int health) {
		return this.health = health;
	}
}