using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private static int INCREMENTHEALTH = 2;

    [Header(" References ")]
    [SerializeField] private GameObject[] enemyGameObject;
    private Transform enemySpawnPos;
    private Enemy enemy;
    private HealthUI healthUI;
    private GuessLetter guessLetter;

    private int currentEnemyIndex = 0;

    // Start is called before the first frame update
    void Awake()
    {
        enemySpawnPos = GameObject.Find("SpawnEnemyPosition").GetComponent<Transform>();
        healthUI = GameObject.Find("HPUI_Holder").GetComponent<HealthUI>();
        guessLetter = GameObject.Find("GuessTextContainer").GetComponent<GuessLetter>();
    }

	private void Start() {
		SpawnEnemy();
	}

	private void SpawnEnemy() {
        if (currentEnemyIndex == 0) {
            Debug.Log("Enemy " + currentEnemyIndex + " Spawn!");

            GameObject enemyObj = Instantiate(enemyGameObject[0], enemySpawnPos);

			enemyObj.GetComponent<Enemy>().OnDeath += SpawnEnemy;
            
            currentEnemyIndex++;
        } else if (currentEnemyIndex < enemyGameObject.Length) {
            Debug.Log("Enemy " + currentEnemyIndex + " Spawn!");
            guessLetter.GetRandomLetterException();

            GameObject enemyObj = Instantiate(enemyGameObject[currentEnemyIndex], enemySpawnPos);
			enemy = enemyObj.GetComponent<Enemy>();

            enemy.SetEnemyHealth(enemy.GetEnemyHealth() + (INCREMENTHEALTH * currentEnemyIndex));
			enemyObj.GetComponent<Enemy>().OnDeath += SpawnEnemy;

            currentEnemyIndex++;
        } else {
            healthUI.DisableEnemyFill();
            GameManager.instance.UpdateGameState(GameManager.GameState.Win);
        }
    }
}
