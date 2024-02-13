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

    [Header(" Settings ")]
    [Range(0, 100)]
    [SerializeField] private float maxPlayerHealth;
	[Range(0, 100)]
	[SerializeField] private float maxEnemyHealth;

    private void Start() {
        player.OnDecreaseHPEnemy += OnDecreaseHPEnemy;
        enemy.OnDecreaseHPPlayer += OnDecreaseHPPlayer;

        potion.OnEncreaseHPPlayer += OnEncreaseHPPlayer;

		playerHealth.maxValue = maxPlayerHealth;
        enemyHealth.maxValue = maxEnemyHealth;
        playerHealth.value = maxPlayerHealth;
        enemyHealth.value = maxEnemyHealth;
    }

	private void Update() {
		amountPlayer.text = playerHealth.value.ToString();
		amountEnemy.text = enemyHealth.value.ToString();

		if (playerHealth.value < 1) {
			playerFill.SetActive(false);
		}

		if (enemyHealth.value < 1) {
			enemyFill.SetActive(false);
		}
	}

	private void OnDecreaseHPPlayer(float damage) {
        playerHealth.value -= damage;
        Debug.Log(damage);
    }

    private void OnDecreaseHPEnemy(float damage) {
        enemyHealth.value -= damage;
		Debug.Log(damage);
	}

    private void OnEncreaseHPPlayer(float heal) {
        playerHealth.value += heal;
        Debug.Log("Heal: " + heal);
    }
}