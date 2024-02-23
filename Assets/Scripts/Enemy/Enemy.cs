using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public Action<int> OnDecreaseHPPlayer;
    public Action OnDeath;

    [Header(" References ")]
    [SerializeField] private EnemySO enemySO;
    Player player;
    private EnemyAnimation enemyAnim;

    [Header(" Elements ")]
    private int health;

    private void Awake() {
        enemyAnim = GetComponent<EnemyAnimation>();
        health = enemySO.maxHealth;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

	private void Start() {

	}

	public void EnemyAttack() {
        player.SetPlayerHealth(player.GetPlayerHealth() - enemySO.damage);
        OnDecreaseHPPlayer?.Invoke(player.GetPlayerHealth());
    }

    public void EnemyDeath() {
        OnDeath?.Invoke();
        if (gameObject != null) {
            Destroy(gameObject);
        }
    }

    public int GetEnemyHealth() {
        return health;
    }

    public int SetEnemyHealth(int health) {
        return this.health = health;
    }
}
