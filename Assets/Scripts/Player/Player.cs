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
	private Data data;
	private EventManager eventManager;

	[Header(" Default Weapon ")]
	[SerializeField] private WeaponSO defaultWeapon;

	[Header(" Attributes ")]
	[SerializeField] private int maxHealth;
	private int health;

	private void Awake() {
		data = GameObject.FindGameObjectWithTag("Data").GetComponent<Data>();
		eventManager = GameObject.Find("EventManager").GetComponent<EventManager>();
	}

	private void Start() {
		maxHealth = data.GetMaxHealthPlayer();
		health = maxHealth;
		Debug.Log("Health = " + health);
	}

	private void Update() {
		if (enemy == null && GameManager.instance.state == GameManager.GameState.OnGoing) {
			enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
		}
	}

	public void ActivatedWeapon() {
		if (defaultWeapon != null) {
			enemy.SetEnemyHealth(enemy.GetEnemyHealth() - defaultWeapon.weaponDamage);
			//OnDecreaseHPEnemy?.Invoke(enemy.GetEnemyHealth());
			//OnHittingEnemy?.Invoke();
			eventManager.OnDecreaseHPEnemy(enemy.GetEnemyHealth());
			eventManager.OnHittingEnemy();
		} else {
			Debug.Log("Weapon Does not Equipped!");
		}
	}

	/*private void Book() {
		Debug.Log("Weapon 5 Activated!");
		//CorrectLetter();
		bookDamage = correctLetterCount * 2;
		Debug.Log("Book Damage: " + bookDamage);
		OnDecreaseHPEnemy?.Invoke(bookDamage);
	}*/

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