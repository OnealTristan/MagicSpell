using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public Action<float> OnDecreaseHPPlayer;

    [Header(" Skitterfang ")]
    [SerializeField] private SkitterfangAnimation skitterfangAnim;
    [SerializeField] private bool skitterfangIsActive;
    [SerializeField] private float skitterfangDamage;
    
    [Header(" Shadowfang ")]
    [SerializeField] private bool shadowfangIsActive;
    [SerializeField] private float shadowfangDamage;

	[Header(" Towerfang ")]
	[SerializeField] private bool towerfangIsActive;
	[SerializeField] private float towerfangDamage;

	[Header(" Voidbane ")]
	[SerializeField] private bool voidbaneIsActive;
	[SerializeField] private float voidbaneDamage;

	public void ActivatedEnemy() {
        if (skitterfangIsActive == true) {
            Skitterfang();
        } else if (shadowfangIsActive == true) {
            Shadowfang();
        } else if (towerfangIsActive == true) {
            Towerfang();
        } else if (voidbaneIsActive == true) {
            Voidbane();
        }
    }

    private void Skitterfang() {
        Debug.Log("Skitterfang Attack!");
        skitterfangAnim.Attack();
        OnDecreaseHPPlayer?.Invoke(skitterfangDamage);
    }

    private void Shadowfang() {
        Debug.Log("Shadowfang Attack!");
        OnDecreaseHPPlayer?.Invoke(shadowfangDamage);
    }

	private void Towerfang() {
        Debug.Log("Towerfang Attack!");
		OnDecreaseHPPlayer?.Invoke(towerfangDamage);
	}

	private void Voidbane() {
		Debug.Log("Towerfang Attack!");
		OnDecreaseHPPlayer?.Invoke(voidbaneDamage);
	}
}
