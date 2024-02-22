using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header(" References ")]
    [SerializeField] private Transform enemySpawnPos;
    [SerializeField] private GameObject enemy;

    // Start is called before the first frame update
    void Awake()
    {
        Instantiate(enemy, enemySpawnPos);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
