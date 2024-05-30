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
	private GameObject keyboard;
	private Enemy enemy;
    private Animator animator;
	[SerializeField] private Animator[] randomAnimator;

	private void Awake() {
		keyboard = GameObject.Find("Keyboard");
		animator = GetComponent<Animator>();
	}

	private void Update() {
		if (enemy == null && GameManager.instance.state == GameManager.GameState.OnGoing) {
			enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
			enemy.OnHittingPlayer += PlayerGetHitAnimation;
		}
	}

	public void RandomizeAnimator() {
		int randomAnim = UnityEngine.Random.Range(0, randomAnimator.Length);

		switch (randomAnim) {
			case 0:
				PlayerAttackMeteor();
				break;
		}
	}

	public void PlayerAttackMeteor() {

	}

    public void PlayerIdleAnimation() {
		/*animator.SetBool("IsIdle", true);
		animator.SetBool("IsAttack", false);
		animator.SetBool("IsSpelling", false);*/

		animator.Play(PLAYERIDLE);
	}

    public void PlayerSpellingAnimation() {
		/*animator.SetBool("IsSpelling", true);
		animator.SetBool("IsIdle", false);*/

		animator.Play(PLAYERSPELLING);
	}

    public void PlayerAttackAnimation() {
		/*animator.SetBool("IsAttack", true);
		animator.SetBool("IsIdle", false);
		animator.SetBool("IsSpelling", false);*/

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
}