using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
	private static string ENEMYIDLE = "EnemyIdle";
	private static string ENEMYATTACK1 = "EnemyAttack";
	private static string ENEMYATTACK2 = "EnemyAttack2";
	private static string ENEMYDEATH = "EnemyDeath";
	private static string ENEMYGETHIT = "EnemyGetHit";

	public Action OnEnemyAnimationStart;
	public Action OnEnemyAnimationEnd;

	[Header(" References ")]
    private Animator animator;
	private Enemy enemy;
	private Player player;
	private EventManager eventManager;

	private void Awake() {
		enemy = GetComponent<Enemy>();
		eventManager = GameObject.Find("EventManager").GetComponent<EventManager>();
	}

	private void OnEnable() {
		eventManager.onEnterPressedWrong += EnemyAttackAnimation;
		eventManager.onHittingEnemy += EnemyGetHitAnimation;
	}

	private void Start() {
		enemy.OnAttackCoroutine += EnemyAttackAnimation;
		enemy.OnDeathAnimation += EnemyDeathAnimation;
	}

	private void Update() {
		if (animator == null) {
			animator = GetComponent<Animator>();
		}

		/*if (player == null && GameManager.instance.state == GameManager.GameState.OnGoing) {
			player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
			player.OnHittingEnemy += EnemyGetHitAnimation;
		}*/
	}

	public void EnemyAttackAnimation() {
		if (enemy.GetIsBoss()) {
			if (enemy.GetCoroutineAttack()) {
				animator.Play(ENEMYATTACK2);
			} else {
				animator.Play(ENEMYATTACK1);
			}
		} else {
			animator.Play(ENEMYATTACK1);
		}
    }

    private void EnemyIdleAnimation() {
		animator.Play(ENEMYIDLE);
	}

	private void EnemyGetHitAnimation() {
		animator.Play(ENEMYGETHIT);
	}

	private void EnemyDeathAnimation() {
		animator.Play(ENEMYDEATH);

		//player.OnHittingEnemy -= EnemyGetHitAnimation;
		enemy.OnDeathAnimation -= EnemyDeathAnimation;
		enemy.OnAttackCoroutine -= EnemyAttackAnimation;
	}

	// Method dipanggil pada event animation enemy
	private void EnemyAnimationStart_DisableKeyboard() {
		OnEnemyAnimationStart?.Invoke();
	}
 
	// Method dipanggil pada event animation enemy
	private void EnemyAnimationEnd_EnableKeyboard() {
		OnEnemyAnimationEnd?.Invoke();
	}

	private void OnDisable() {
		eventManager.onEnterPressedWrong -= EnemyAttackAnimation;
		eventManager.onHittingEnemy -= EnemyGetHitAnimation;
	}
}