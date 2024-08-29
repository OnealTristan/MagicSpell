using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	public Action<int> OnDecreaseHPEnemy;
	public Action OnHittingEnemy;

	[Header(" References ")]
	private Enemy enemy;

	[Header(" Default Weapon ")]
	[SerializeField] private WeaponSO defaultWeapon;

	[Header(" Unicorn Wand ")]
    [SerializeField] private bool unicornWandIsActive;

	[Header(" Book ")]
	[SerializeField] private bool bookIsActive;
	private int bookDamage;

	[Header(" Attributes ")]
	[SerializeField] private int maxHealth;
	private int health;

    private int correctLetterCount;

	private WeaponSO equippedWeapon;

	private void Awake() {
		health = maxHealth;
	}

	private void Start() {
		if (equippedWeapon == null) {
			equippedWeapon = defaultWeapon;
		}
	}

	private void Update() {
		if (enemy == null && GameManager.instance.state == GameManager.GameState.OnGoing) {
			enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
		}
	}

	public void ActivatedWeapon() {
		if (OnDecreaseHPEnemy != null) {
			if (equippedWeapon != null) {
				enemy.SetEnemyHealth(enemy.GetEnemyHealth() - equippedWeapon.damage);
				OnDecreaseHPEnemy?.Invoke(enemy.GetEnemyHealth());
				OnHittingEnemy?.Invoke();
			} else {
				Debug.Log("Weapon Does not Equipped!");
			}
		}
	}

	public void EquipWeapon(WeaponSO weapon) {
		equippedWeapon = weapon;
	}

	private void Weapon5() {
		Debug.Log("Weapon 5 Activated!");
		//CorrectLetter();
		OnDecreaseHPEnemy?.Invoke(correctLetterCount);
    }

	private void Book() {
		Debug.Log("Weapon 5 Activated!");
		//CorrectLetter();
		bookDamage = correctLetterCount * 2;
		Debug.Log("Book Damage: " + bookDamage);
		OnDecreaseHPEnemy?.Invoke(bookDamage);
	}

	/*private void CorrectLetter() {
		correctLetterCount = 0;
		Debug.Log("CorrecLetter Method Active");
		for (int i = 0; i < text.text.Length; i++) {
			correctLetterCount++;
			Debug.Log("Correct Letter ke-" + correctLetterCount);
		}
		Debug.Log("Total correct count: " + correctLetterCount);
	}*/

	public int GetPlayerHealth() {
		return health;
	}

	public int SetPlayerHealth(int health) {
		return this.health = health;
	}
}