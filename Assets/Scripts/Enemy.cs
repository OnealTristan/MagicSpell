using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public Action<float> OnDecreaseHPPlayer;

    [Header(" Skitterfang ")]
    public bool skitterfangIsActive;
    [SerializeField] private float skitterfangDamage;
    
    [Header(" Shadowfang ")]
    public bool shadowfangIsActive;
    [SerializeField] private float shadowfangDamage;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Skitterfang() {
        if (skitterfangIsActive == true) {
            Debug.Log("Skitterfang Attack!");
            OnDecreaseHPPlayer?.Invoke(skitterfangDamage);
        }
    }

    public void Shadowfang() {
        if (shadowfangIsActive == true) {
            Debug.Log("Shadowfang Attack!");
            OnDecreaseHPPlayer?.Invoke(shadowfangDamage);
        }
    }
}
