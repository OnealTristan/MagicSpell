using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {
    [Header(" Elements ")]
    [SerializeField] private Animator animator;

    public void PlayerIdle() {
        animator.SetBool("IsIdle", true);
		animator.SetBool("IsAttack", false);
		animator.SetBool("IsSpelling", false);
	}

    public void PlayerSpelling() {
		animator.SetBool("IsSpelling", true);
		animator.SetBool("IsIdle", false);
	}

    public void PlayerAttack() {
		animator.SetBool("IsAttack", true);
		animator.SetBool("IsIdle", false);
		animator.SetBool("IsSpelling", false);
	}
}
