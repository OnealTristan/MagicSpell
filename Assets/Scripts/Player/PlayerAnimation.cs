using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAnimation : MonoBehaviour 
{
	private static string PLAYERIDLE = "PlayerIdle";
	private static string PLAYERSPELLING = "PlayerSpelling";
	private static string PLAYERATTACK = "PlayerAttack";
	private static string PLAYERGETHIT = "PlayerGetHit";

	public Action OnPlayerAnimationStart;
	public Action OnPlayerAnimationEnd;

	[Header(" References ")]
	private Enemy enemy;
    private Animator animator;
	[SerializeField] private Animator[] randomAnimator;
	EventManager eventManager;

	private void Awake() {
		eventManager = GameObject.Find("EventManager").GetComponent<EventManager>();
	}

	private void OnEnable() {
		eventManager.onEnterPressedCorrect += PlayerAttackAnimation;
		eventManager.onEnterPressedWrong += PlayerIdleAnimation;

		eventManager.onTextDisplay += PlayerSpellingAnimation;
		eventManager.onTextEmpty += PlayerIdleAnimation;
	}

	private void Update() {
		if (animator == null)
        {
			animator = GetComponent<Animator>();
		}

		if (enemy == null && GameManager.instance.state == GameManager.GameState.OnGoing) {
			enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
			enemy.OnHittingPlayer += PlayerGetHitAnimation;
		}
	}

    public void PlayerIdleAnimation() {
		animator.Play(PLAYERIDLE);
	}

    public void PlayerSpellingAnimation() {
		animator.Play(PLAYERSPELLING);
	}

    public void PlayerAttackAnimation() {
		animator.Play(PLAYERATTACK);
	}

	private void PlayerGetHitAnimation() {
		animator.Play(PLAYERGETHIT);
	}

	private void PlayerAnimationStart_DisableKeyboard() {
		OnPlayerAnimationStart?.Invoke();
	}

	private void PlayerAnimationEnd_EnableKeyboard() {
		OnPlayerAnimationEnd?.Invoke();
	}

	private void OnDisable() {
		eventManager.onEnterPressedCorrect -= PlayerAttackAnimation;
		eventManager.onEnterPressedWrong -= PlayerIdleAnimation;

		eventManager.onTextDisplay -= PlayerSpellingAnimation;
		eventManager.onTextEmpty -= PlayerIdleAnimation;
	}
}