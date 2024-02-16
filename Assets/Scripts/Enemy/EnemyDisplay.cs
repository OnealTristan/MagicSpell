using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDisplay : MonoBehaviour {
    public Action<int> OnDecreaseHPPlayer;

    [Header(" References ")]
    [SerializeField] private EnemySO enemy;

    private EnemyAnimation enemyAnim;

    private void Awake() {
        enemyAnim = GetComponent<EnemyAnimation>();
    }

	private void Start() {

	}

	public void EnemyAttack() {
        enemyAnim.Attack();
        OnDecreaseHPPlayer?.Invoke(enemy.damage);
    }

    public int GetEnemyHealth() {
        return enemy.health;
    }

    public int SetEnemyHealth(int health) {
        return enemy.health = health;
    }
}
