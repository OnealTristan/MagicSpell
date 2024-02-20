using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public Action<int> OnDecreaseHPPlayer;

    [Header(" References ")]
    [SerializeField] Player player;
    [SerializeField] private EnemySO enemySO;
    private EnemyAnimation enemyAnim;

    [Header(" Elements ")]
    private int health;

    private void Awake() {
        enemyAnim = GetComponent<EnemyAnimation>();
        health = enemySO.maxHealth;
    }

	private void Start() {

	}

	public void EnemyAttack() {
        player.SetPlayerHealth(player.GetPlayerHealth() - enemySO.damage);
        OnDecreaseHPPlayer?.Invoke(player.GetPlayerHealth());
    }

    public int GetEnemyHealth() {
        return health;
    }

    public int SetEnemyHealth(int health) {
        return this.health = health;
    }
}
