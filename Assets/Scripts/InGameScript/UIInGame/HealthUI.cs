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
    private Data data;
    private EventManager eventManager;

    [Header(" Elements ")]
    int index;

	private void Awake() {
		data = GameObject.FindGameObjectWithTag("Data").GetComponent<Data>();
		eventManager = GameObject.Find("EventManager").GetComponent<EventManager>();
	}

	private void OnEnable() {
        eventManager.onDecreaseHPEnemy += DecreaseHPEnemy;
	}

	private void Start() {
        potion.OnEncreaseHPPlayer += OnEncreaseHPPlayer;
    }

	private void Update() {
        if (enemy == null && GameManager.instance.state == GameManager.GameState.OnGoing) {
            enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
            
            enemy.OnDecreaseHPPlayer += DecreaseHPPlayer;

            enemyHealth.maxValue = enemy.GetEnemyHealth();
            enemyHealth.value = enemyHealth.maxValue;
            amountEnemy.text = enemyHealth.value.ToString();
            Debug.Log("enemy ada");
        }

        if (player == null && GameManager.instance.state == GameManager.GameState.OnGoing) {
			player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
			player.OnDecreaseHPEnemy += DecreaseHPEnemy;

			playerHealth.maxValue = data.GetMaxHealthPlayer();
			playerHealth.value = playerHealth.maxValue;
			amountPlayer.text = playerHealth.value.ToString();
		}

		if (playerHealth.value < 1) {
			playerFill.SetActive(false);
		}
	}

    private void DecreaseHPPlayer(int health) {
        playerHealth.value = health;
		amountPlayer.text = health.ToString();
    }

    private void DecreaseHPEnemy(int health) {
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