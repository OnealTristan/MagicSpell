using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAnimation : MonoBehaviour {
    [Header(" References ")]
	private GameObject keyboard;
    private Animator animator;
	[SerializeField] private Animator[] randomAnimator;

	private void Awake() {
		keyboard = GameObject.Find("Keyboard");
		animator = GetComponent<Animator>();
	}

	public void RandomizeAnimator() {
		int randomAnim = Random.Range(0, randomAnimator.Length);

		switch (randomAnim) {
			case 0:
				PlayerAttackMeteor();
				break;
		}
	}

	public void PlayerAttackMeteor() {
		// 
	}

    public void PlayerIdleAnimation() {
        animator.SetBool("IsIdle", true);
		animator.SetBool("IsAttack", false);
		animator.SetBool("IsSpelling", false);
	}

    public void PlayerSpellingAnimation() {
		animator.SetBool("IsSpelling", true);
		animator.SetBool("IsIdle", false);
	}

    public void PlayerAttackAnimation() {
		animator.SetBool("IsAttack", true);
		animator.SetBool("IsIdle", false);
		animator.SetBool("IsSpelling", false);
	}
}