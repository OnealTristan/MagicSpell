using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Potion", menuName = "ScriptableObjects/PotionSO")]
public class PotionSO : ScriptableObject
{
    [Header(" References ")]
    public Sprite image;

    [Header(" Elements ")]
    public int id;
    public string potionName;
    public int price;
    public int amount;
    public int slot;
}
