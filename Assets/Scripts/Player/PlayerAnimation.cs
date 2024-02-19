using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAnimation : MonoBehaviour {
    [Header(" References ")]
    [SerializeField] private Animator animator;
	[SerializeField] private GameObject keyboard;
	[SerializeField] private Animator[] randomAnimator;

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

	private void DisableKeyboard() {
		Button[] buttons = keyboard.GetComponentsInChildren<Button>();

        foreach (Button button in buttons)
        {
			button.interactable = false;
        }
    }

	private void EnableKeyboard() {
		Button[] buttons = keyboard.GetComponentsInChildren<Button>();

		foreach (Button button in buttons) {
			button.interactable = true;
		}
	}
}
