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
    [SerializeField] private Potion potion;
    private Player player;
    private Enemy enemy;

    [Header(" Elements ")]
    int index;

    private void Start() {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

		player.OnDecreaseHPEnemy += OnDecreaseHPEnemy;
        potion.OnEncreaseHPPlayer += OnEncreaseHPPlayer;

        playerHealth.maxValue = player.GetPlayerHealth();
        playerHealth.value = playerHealth.maxValue;
        amountPlayer.text = playerHealth.value.ToString();
    }

	private void Update() {
        if (enemy == null && GameManager.instance.state == GameManager.GameState.OnGoing) {
            enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
            
            enemy.OnDecreaseHPPlayer += OnDecreaseHPPlayer;

            enemyHealth.maxValue = enemy.GetEnemyHealth();
            enemyHealth.value = enemyHealth.maxValue;
            amountEnemy.text = enemyHealth.value.ToString();
            Debug.Log("enemy ada");
        }

		if (playerHealth.value < 1) {
			playerFill.SetActive(false);
		}
	}

    private void OnDecreaseHPPlayer(int health) {
        playerHealth.value = health;
		amountPlayer.text = health.ToString();
    }

    private void OnDecreaseHPEnemy(int health) {
        enemyHealth.value = health;
		amountEnemy.text = enemyHealth.value.ToString();
	}

    private void OnEncreaseHPPlayer(int heal) {
        playerHealth.value += heal;
        Debug.Log("Heal: " + heal);
    }

    public void DisableEnemyFill() {
        enemyFill.SetActive(false);
    }
}