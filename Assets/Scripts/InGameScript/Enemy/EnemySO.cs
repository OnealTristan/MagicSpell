using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "ScriptableObjects/EnemySO")]
public class EnemySO : ScriptableObject {
    public string enemyName;

    public int damage;
    public int damageInterval;

    public int attackInterval;

    public int maxHealth;
}