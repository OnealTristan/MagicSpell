using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class Enemy : MonoBehaviour {
    public Action<int> OnDecreaseHPPlayer;
    public Action OnHittingPlayer;
    public Action OnDeathAnimation;
	public Action OnDeath;

	[Header(" References ")]
    [SerializeField] private EnemySO enemySO;
    Player player;

    [Header(" Elements ")]
    private int health;

    private void Awake() {
        health = enemySO.maxHealth;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}

	private void Update() {
		if (GetEnemyHealth() < 1) {
			EnemyDeath_EnemyAnimation();
		}
	}

	public void EnemyAttack() {
        player.SetPlayerHealth(player.GetPlayerHealth() - enemySO.damage);
        OnDecreaseHPPlayer?.Invoke(player.GetPlayerHealth());
        OnHittingPlayer?.Invoke();
    }

    public void EnemyDeath() {
        OnDeath?.Invoke();
		if (gameObject != null) {
			Destroy(gameObject);
		}
	}

    private void EnemyDeath_EnemyAnimation() {
        OnDeathAnimation?.Invoke();
    }

    public int GetEnemyHealth() {
        return health;
    }

    public int SetEnemyHealth(int health) {
        return this.health = health;
    }
}