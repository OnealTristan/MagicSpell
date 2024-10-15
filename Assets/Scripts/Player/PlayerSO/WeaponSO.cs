using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Weapon", menuName = "ScriptableObjects/WeaponSO")]
public class WeaponSO : ScriptableObject
{
    [Header(" References ")]
    public Sprite image;

    [Header(" Elements ")]
    public string weaponName;
    public int weaponDamage;
    public int weaponPrice;
    [Space(10)]
    public bool weaponBuyed;
    public bool weaponEquip;
}