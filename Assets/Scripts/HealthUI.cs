using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [Header("Refrences")]
    [SerializeField] private Slider playerHealth;
    [SerializeField] private Slider enemyHealth;
    [SerializeField] private Player player;
    [SerializeField] private Enemy enemy;

    [Header(" Settings ")]
    [Range(0, 100)]
    [SerializeField] private float maxPlayerHealth;
	[Range(0, 100)]
	[SerializeField] private float maxEnemyHealth;

    private void Start() {
        player.OnDecreaseHPEnemy += OnDecreaseHPEnemy;
        enemy.OnDecreaseHPPlayer += OnDecreaseHPPlayer;

		playerHealth.maxValue = maxPlayerHealth;
        enemyHealth.maxValue = maxEnemyHealth;
        playerHealth.value = maxPlayerHealth;
        enemyHealth.value = maxEnemyHealth;
    }

    private void OnDecreaseHPPlayer(float damage) {
        playerHealth.value -= damage;
        Debug.Log(damage);
    }

    private void OnDecreaseHPEnemy(float damage) {
        enemyHealth.value -= damage;
		Debug.Log(damage);
	}
}