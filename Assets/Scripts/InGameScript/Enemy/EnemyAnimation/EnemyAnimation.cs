using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
	public Action OnEnemyAnimationStart;
	public Action OnEnemyAnimationEnd;

    private Animator animator;

	private void Awake() {
		animator = GetComponent<Animator>();
	}

	public void EnemyAttackAnimation() {
        animator.SetBool("isAttack", true);
        animator.SetBool("isIdle", false);

        Invoke("EnemyIdleAnimation", 0.5f);
    }

	// Method dipanggil pada event animation enemy
	private void EnemyAnimationStart() {
		OnEnemyAnimationStart?.Invoke();
	}

    public void EnemyIdleAnimation() {
		animator.SetBool("isIdle", true);
		animator.SetBool("isAttack", false);
	}
 
	// Method dipanggil pada event animation enemy
	private void EnemyAnimationEnd() {
		OnEnemyAnimationEnd?.Invoke();
	}
}