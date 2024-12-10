using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionInGameUI : MonoBehaviour
{
	private static string INANIMATION = "InAnimation";
	private static string OUTANIMATION = "OutAnimation";

	private Animator animator;

	private void Awake() {
		animator = GetComponent<Animator>();
	}

	public void InAnimation() {
		animator.Play(INANIMATION);
	}

	public void OutAnimation() {
		animator.Play(OUTANIMATION);
	}
}