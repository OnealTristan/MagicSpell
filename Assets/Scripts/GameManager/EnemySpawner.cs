using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private static int INCREMENTHEALTH = 2;

    [Header(" References ")]
    [SerializeField] private GameObject[] enemyGameObject;
	[SerializeField] private GameObject[] enemyBossGameObject;
    private Transform enemySpawnPos;
    private Enemy enemy;
    private HealthUI healthUI;
    private GuessLetter guessLetter;
    private Data data;

    [Header(" Elements ")]
    [SerializeField] private int starterHealth;
    private int currentEnemyIndex = 0;
	private bool bossSpawned = false;

    // Start is called before the first frame update
    void Awake()
    {
        data = GameObject.FindGameObjectWithTag("Data").GetComponent<Data>();
        enemySpawnPos = GameObject.Find("SpawnEnemyPosition").GetComponent<Transform>();
        healthUI = GameObject.Find("HPUI_Holder").GetComponent<HealthUI>();
        guessLetter = GameObject.Find("GuessTextContainer").GetComponent<GuessLetter>();
    }

	private void Start() {
		SpawnEnemy();
	}

	private void SpawnEnemy() {
		int chapterIndex = data.GetChapterIndex();
		int levelIndex = data.GetLevelIndex();

        // projectMode(true) == TA
        if (data.GetProjectMode() == true) {
			if (levelIndex == 9) {
				if (bossSpawned) {
					Debug.Log("Boss already spawned.");
					return;
				} 

				if (currentEnemyIndex < enemyGameObject.Length) {
					Debug.Log("Enemy " + currentEnemyIndex + " Spawn!");
					guessLetter.GetRandomLetterException();

					starterHealth = data.chapterSO[data.GetChapterIndex()].starterEnemyHealthChapter + (INCREMENTHEALTH * data.GetLevelIndex());

					GameObject enemyObj = Instantiate(enemyGameObject[currentEnemyIndex], enemySpawnPos);
					enemy = enemyObj.GetComponent<Enemy>();

					enemy.SetEnemyHealth(starterHealth);
					enemyObj.GetComponent<Enemy>().OnDeath += SpawnEnemy;

					currentEnemyIndex++;
				} else {
					Debug.Log("Spawning Boss" + chapterIndex);
					SpawnBoss(chapterIndex);
				}
			} else {
				int enemiesToSpawn = DetermineEnemiesToSpawn(chapterIndex, levelIndex);

				if (currentEnemyIndex < enemiesToSpawn) {
					Debug.Log("Enemy " + currentEnemyIndex + " Spawn!");
					if (enemiesToSpawn > 1) {
						guessLetter.GetRandomLetterException();
					}

					starterHealth = data.chapterSO[data.GetChapterIndex()].starterEnemyHealthChapter + (INCREMENTHEALTH * data.GetLevelIndex());

					GameObject enemyObj = Instantiate(enemyGameObject[currentEnemyIndex], enemySpawnPos);
					enemy = enemyObj.GetComponent<Enemy>();

					enemy.SetEnemyHealth(starterHealth);
					enemyObj.GetComponent<Enemy>().OnDeath += SpawnEnemy;

					currentEnemyIndex++;
				} else {
					healthUI.DisableEnemyFill();
					GameManager.instance.UpdateGameState(GameManager.GameState.Win);
				}
			}

			/*if (currentEnemyIndex == 0) {
				Debug.Log("Enemy " + currentEnemyIndex + " Spawn!");

				starterHealth = data.chapterSo[data.GetChapterIndex()].starterEnemyHealthChapter + (INCREMENTHEALTH * data.GetLevelIndex());

				GameObject enemyObj = Instantiate(enemyGameObject[0], enemySpawnPos);
				enemy = enemyObj.GetComponent<Enemy>();

				enemy.SetEnemyHealth(starterHealth);
				enemyObj.GetComponent<Enemy>().OnDeath += SpawnEnemy;

				currentEnemyIndex++;
			} else if (currentEnemyIndex < enemyGameObject.Length) {
				Debug.Log("Enemy " + currentEnemyIndex + " Spawn!");
				guessLetter.GetRandomLetterException();

				GameObject enemyObj = Instantiate(enemyGameObject[currentEnemyIndex], enemySpawnPos);
				enemy = enemyObj.GetComponent<Enemy>();

				enemy.SetEnemyHealth(starterHealth + (INCREMENTHEALTH * currentEnemyIndex));
				enemyObj.GetComponent<Enemy>().OnDeath += SpawnEnemy;

				currentEnemyIndex++;
			} else {
				healthUI.DisableEnemyFill();
				GameManager.instance.UpdateGameState(GameManager.GameState.Win);
			}*/
		}
		// projectMode(false) == KP
		else {
			if (currentEnemyIndex == 0) {
				Debug.Log("Enemy " + currentEnemyIndex + " Spawn!");

				GameObject enemyObj = Instantiate(enemyGameObject[0], enemySpawnPos);
				enemy = enemyObj.GetComponent<Enemy>();

				enemy.SetEnemyHealth(starterHealth);
				enemyObj.GetComponent<Enemy>().OnDeath += SpawnEnemy;

				currentEnemyIndex++;
			} else if (currentEnemyIndex < enemyGameObject.Length) {
				Debug.Log("Enemy " + currentEnemyIndex + " Spawn!");
				guessLetter.GetRandomLetterException();

				GameObject enemyObj = Instantiate(enemyGameObject[currentEnemyIndex], enemySpawnPos);
				enemy = enemyObj.GetComponent<Enemy>();

				enemy.SetEnemyHealth(starterHealth + (INCREMENTHEALTH * currentEnemyIndex));
				enemyObj.GetComponent<Enemy>().OnDeath += SpawnEnemy;

				currentEnemyIndex++;
			} else {
				healthUI.DisableEnemyFill();
				GameManager.instance.UpdateGameState(GameManager.GameState.Win);
			}
		}
	}

	private void SpawnBoss(int chapterIndex) {
		int bossHealth = data.chapterSO[data.GetChapterIndex()].starterEnemyHealthChapter + (INCREMENTHEALTH * data.GetLevelIndex()) + (INCREMENTHEALTH * currentEnemyIndex);

		GameObject bossObj = Instantiate(enemyBossGameObject[chapterIndex], enemySpawnPos);
		enemy = bossObj.GetComponent<Enemy>();

		enemy.SetEnemyHealth(bossHealth);
		bossObj.GetComponent<Enemy>().OnDeath += () => 
		{
			healthUI.DisableEnemyFill();
			GameManager.instance.UpdateGameState(GameManager.GameState.Win);
		};

		bossSpawned = true;
	}

	private int DetermineEnemiesToSpawn(int chapterIndex, int levelIndex) {
		if (chapterIndex == 0 && levelIndex == 0) {
			return 1;
		} else if (chapterIndex == 0 && levelIndex == 1) {
			return 2;
		} else {
			return 3;
		}
	}
}