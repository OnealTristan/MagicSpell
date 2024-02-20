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
    [SerializeField] private Enemy enemy;
    [SerializeField] private Potion potion;

    private void Start() {
        player.OnDecreaseHPEnemy += OnDecreaseHPEnemy;
        enemy.OnDecreaseHPPlayer += OnDecreaseHPPlayer;

        potion.OnEncreaseHPPlayer += OnEncreaseHPPlayer;

		playerHealth.maxValue = player.GetPlayerHealth();
        playerHealth.value = playerHealth.maxValue;
		amountPlayer.text = playerHealth.value.ToString();

		enemyHealth.maxValue = enemy.GetEnemyHealth();
        enemyHealth.value = enemyHealth.maxValue;
        amountEnemy.text = enemyHealth.value.ToString();
	}

	private void Update() {
		if (playerHealth.value < 1) {
			playerFill.SetActive(false);
            GameManager.instance.UpdateGameState(GameManager.GameState.Lose);
		}

		if (enemyHealth.value < 1) {
			enemyFill.SetActive(false);
			GameManager.instance.UpdateGameState(GameManager.GameState.Win);
		}
	}

    private void OnDecreaseHPPlayer(int health) {
        playerHealth.value = health;
		amountPlayer.text = health.ToString();
		Debug.Log(health);
    }

    private void OnDecreaseHPEnemy(int health) {
        enemyHealth.value = health;
		amountEnemy.text = enemyHealth.value.ToString();
		Debug.Log(health);
	}

    private void OnEncreaseHPPlayer(int heal) {
        playerHealth.value += heal;
        Debug.Log("Heal: " + heal);
    }
}