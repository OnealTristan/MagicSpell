using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Animator animator;

	private void Awake() {
		animator = GetComponent<Animator>();
	}

	public void EnemyAttackAnimation() {
        animator.SetBool("isAttack", true);
        animator.SetBool("isIdle", false);
        Invoke("EnemyIdleAnimation", 0.5f);
    }

    public void EnemyIdleAnimation() {
		animator.SetBool("isIdle", true);
		animator.SetBool("isAttack", false);
	}
}