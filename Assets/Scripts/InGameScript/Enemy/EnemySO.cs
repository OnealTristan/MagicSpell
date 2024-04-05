using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class EnemySO : ScriptableObject {
    public string enemyName;

    public int damage;
    public int damageTimer;

    public int maxHealth;
}