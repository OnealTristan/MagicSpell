using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDisplay : MonoBehaviour
{
    public Action<float> OnDecreaseHPPlayer;

    [Header(" Elements ")]
    [SerializeField] private EnemySO enemy;

    private EnemyAnimation enemyAnim;

    private void Awake() {
        enemyAnim = GetComponent<EnemyAnimation>();
    }

    public void OnEnemyAttack() {
        enemyAnim.Attack();
        OnDecreaseHPPlayer?.Invoke(enemy.damage);
    }
}
