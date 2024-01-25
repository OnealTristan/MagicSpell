using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public Action<float> OnEncreaseHPPlayer;

    [Header(" Elements ")]
    [SerializeField] private float lowPotionHeal;
    [SerializeField] private float medPotionHeal;
    [SerializeField] private float highPotionHeal;

    public void OnClickPotionLow () {
        OnEncreaseHPPlayer?.Invoke(lowPotionHeal);
    }

    public void OnClickPotionMed () {
		OnEncreaseHPPlayer?.Invoke(medPotionHeal);
	}

    public void OnClickPotionHigh () {
		OnEncreaseHPPlayer?.Invoke(highPotionHeal);
	}
}
