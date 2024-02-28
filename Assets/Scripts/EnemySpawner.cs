using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header(" References ")]
    [SerializeField] private Transform enemySpawnPos;
    [SerializeField] private HealthUI healthUI;
    [SerializeField] private GuessLetter guessLetter;
    [Space(10)]
    [SerializeField] private GameObject[] enemyGameObject;

    private int enemyHealth;
    private int currentEnemyIndex = 0;

    // Start is called before the first frame update
    void Awake()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy() {
        if (currentEnemyIndex == 0) {
            Debug.Log("Enemy " + currentEnemyIndex + " Spawn!");
            GameObject enemy = Instantiate(enemyGameObject[0], enemySpawnPos);
            enemy.GetComponent<Enemy>().OnDeath += SpawnEnemy;
            currentEnemyIndex++;
        } else if (currentEnemyIndex < enemyGameObject.Length) {
            Debug.Log("Enemy " + currentEnemyIndex + " Spawn!");
            guessLetter.GetRandomLetterException();
            GameObject enemy = Instantiate(enemyGameObject[currentEnemyIndex], enemySpawnPos);
            enemy.GetComponent<Enemy>().OnDeath += SpawnEnemy;
            currentEnemyIndex++;
        } else {
            healthUI.DisableEnemyFill();
            GameManager.instance.UpdateGameState(GameManager.GameState.Win);
        }
    }
}
