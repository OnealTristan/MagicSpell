using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class WeaponSO : ScriptableObject
{
    [Header(" References ")]
    public Sprite image;

    [Header(" Elements ")]
    public new string name;
    public int damage;
    public int price;
    [Space(10)]
    public bool buyed;
    public bool equip;
}