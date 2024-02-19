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
        playerHealth.value = playerHealth.maxValue;

		enemyHealth.maxValue = enemy.GetEnemyHealth();
        enemyHealth.value = enemyHealth.maxValue;
	}

	private void Update() {
		amountPlayer.text = playerHealth.value.ToString();
		amountEnemy.text = enemyHealth.value.ToString();

		if (playerHealth.value < 1) {
			playerFill.SetActive(false);
            GameManager.instance.UpdateGameState(GameManager.GameState.Lose);
		}

		if (enemyHealth.value < 1) {
			enemyFill.SetActive(false);
			GameManager.instance.UpdateGameState(GameManager.GameState.Win);
		}
	}

    private void OnDecreaseHPPlayer(int damage) {
        playerHealth.value -= damage;
        Debug.Log(damage);
    }

    private void OnDecreaseHPEnemy(int damage) {
        enemyHealth.value -= damage;
		Debug.Log(damage);
	}

    private void OnEncreaseHPPlayer(int heal) {
        playerHealth.value += heal;
        Debug.Log("Heal: " + heal);
    }
}