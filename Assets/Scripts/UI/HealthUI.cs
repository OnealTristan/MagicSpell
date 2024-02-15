using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [Header("Refrences")]
    [SerializeField] private Slider playerHealth;
    [SerializeField] private GameObject playerFill;
    [SerializeField] private TextMeshProUGUI amountPlayer;

    [Space(10)]
    [SerializeField] private Slider enemyHealth;
	[SerializeField] private GameObject enemyFill;
    [SerializeField] private TextMeshProUGUI amountEnemy;

	[Space(10)]
    [SerializeField] private Player player;
    [SerializeField] private EnemyDisplay enemy;
    [SerializeField] private Potion potion;

    private void Start() {
        player.OnDecreaseHPEnemy += OnDecreaseHPEnemy;
        enemy.OnDecreaseHPPlayer += OnDecreaseHPPlayer;

        potion.OnEncreaseHPPlayer += OnEncreaseHPPlayer;

		playerHealth.maxValue = player.GetPlayerHealth();
        playerHealth.value = player.GetPlayerHealth();

        enemyHealth.maxValue = enemy.GetEnemyHealth();
        enemyHealth.value = enemy.GetEnemyHealth();
    }

	private void Update() {
		amountPlayer.text = player.GetPlayerHealth().ToString();
		amountEnemy.text = enemy.GetEnemyHealth().ToString();

		if (playerHealth.value < 1) {
			playerFill.SetActive(false);
		}

		if (enemyHealth.value < 1) {
			enemyFill.SetActive(false);
		}
	}

	private void OnDecreaseHPPlayer(int damage) {
        playerHealth.value -= damage;
        player.SetPlayerHealth(((int)playerHealth.value));
        Debug.Log(damage);
    }

    private void OnDecreaseHPEnemy(int damage) {
        enemyHealth.value -= damage;
        enemy.SetEnemyHealth(((int)enemyHealth.value));
		Debug.Log(damage);
	}

    private void OnEncreaseHPPlayer(int heal) {
        playerHealth.value += heal;
        Debug.Log("Heal: " + heal);
    }
}