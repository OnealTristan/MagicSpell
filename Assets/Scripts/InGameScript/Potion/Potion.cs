using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public Action<int> OnEncreaseHPPlayer;

    [Header(" Elements ")]
    [SerializeField] private int lowPotionHeal;
    [SerializeField] private int medPotionHeal;
    [SerializeField] private int highPotionHeal;

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