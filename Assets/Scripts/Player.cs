using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	public Action<float> OnDecreaseHPEnemy;

	[Header(" Settings ")]
	[SerializeField] private Text text;

    [Header(" Activated Weapon ")]
    public bool weapon1IsActive;
    [SerializeField] private bool weapon5IsActive;

    [Header(" Attributes ")]
    private float damage;
    private float correctLetterCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Weapon1(float dmg) {
        if (weapon1IsActive == true) {
            Debug.Log("Weapon 1 Activated!");
            damage = dmg;
            OnDecreaseHPEnemy?.Invoke(damage);
        }
    }

    public void Weapon5() {
        if (weapon5IsActive == true) {
			correctLetterCount = 0;
			Debug.Log("Weapon 5 Activated!");
            CorrectLetter();
            damage = correctLetterCount;
            OnDecreaseHPEnemy?.Invoke(damage);
		}
    }

	private void CorrectLetter() {
		for (int i = 0; i < (text.text.Length); i++) {
			correctLetterCount++;
		}
	}
}
