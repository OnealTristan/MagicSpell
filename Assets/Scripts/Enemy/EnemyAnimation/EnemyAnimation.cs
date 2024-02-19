using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Animator animator;

	private void Awake() {
		animator = GetComponent<Animator>();
	}

	public void Attack() {
        animator.SetBool("isAttack", true);
        animator.SetBool("isIdle", false);
        Invoke("Idle", 0.5f);
    }

    public void Idle() {
		animator.SetBool("isIdle", true);
		animator.SetBool("isAttack", false);
	}
}
