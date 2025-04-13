using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public Action<int> OnDecreaseHPPlayer;
    public Action OnHittingPlayer;
    public Action OnAttackCoroutine;

    public Action OnDeathAnimation;
	public Action OnDeath;

	[Header(" References ")]
    [SerializeField] private EnemySO enemySO;
    private NewKeyboard keyboard;
    Player player;
    private EventManager eventManager;

    [Header(" Elements ")]
    public bool coroutineAttack;
    private int health;
    private Coroutine attackCoroutine;

    private bool isBoss;

    private void Awake() {
        health = enemySO.maxHealth;
        eventManager = GameObject.Find("EventManager").GetComponent<EventManager>();
	}

	private void OnEnable() {
		eventManager.onEnterPressedCorrect += ResetAttackInterval;
        eventManager.onHittingEnemy += ResetAttackInterval;
	}

	private void Start() {
        attackCoroutine = StartCoroutine(AttackRotuine());

        isBoss = enemySO.isBoss;
	}

	private void Update() {
		if (GetEnemyHealth() < 1) {
			EnemyDeath_EnemyAnimation();
            if (attackCoroutine != null) {
                StopCoroutine(attackCoroutine);
            }
        }

        if (player == null && GameManager.instance.state == GameManager.GameState.OnGoing) {
			player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
			player.OnHittingEnemy += ResetAttackInterval;
		}

        /*if (keyboard == null && GameManager.instance.state == GameManager.GameState.OnGoing) {
			keyboard = GameObject.FindGameObjectWithTag("Keyboard").GetComponent<NewKeyboard>();
			keyboard.OnEnterPressed += ResetAttackInterval;
		}*/
    }

    private IEnumerator AttackRotuine() {
        if (enemySO.attackInterval > 0) {
            while (true) {
                yield return new WaitForSeconds(enemySO.attackInterval);
                coroutineAttack = true;
                OnAttackCoroutine?.Invoke();
                //yield return new WaitForSeconds(PAUSEATTACK);
            }
        } else {
            yield break;
        }
    }

    public void ResetAttackInterval() {
        if (attackCoroutine != null) {
            StopCoroutine(attackCoroutine);
        }
        attackCoroutine = StartCoroutine(AttackRotuine());
    }

    public void EnemyAttack() {
        if (coroutineAttack == true) {
			player.SetPlayerHealth(player.GetPlayerHealth() - enemySO.damageInterval);
		} else {
            player.SetPlayerHealth(player.GetPlayerHealth() - enemySO.damage);
        }
		OnDecreaseHPPlayer?.Invoke(player.GetPlayerHealth());
		OnHittingPlayer?.Invoke();

        ResetAttackInterval();
        coroutineAttack = false;
	}

    public void EnemyDeath() {
        OnDeath?.Invoke();
		if (gameObject != null) {
			Destroy(gameObject);
			eventManager.onHittingEnemy -= ResetAttackInterval;
			eventManager.onEnterPressedCorrect -= ResetAttackInterval;
			//keyboard.OnEnterPressed -= ResetAttackInterval;
			//player.OnHittingEnemy -= ResetAttackInterval;
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

    public bool GetIsBoss() {
        return isBoss;
    }

    public bool GetCoroutineAttack() {
        return coroutineAttack;
    }
}