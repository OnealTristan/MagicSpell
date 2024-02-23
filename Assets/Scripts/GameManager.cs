using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[Header(" References ")]
	[SerializeField] private ConditionUI conditionUI;
	private EnemySpawner enemySpawner;
	private Enemy enemy;
	private Player player;

    public static GameManager instance;

    public GameState state;

    public enum GameState {
		OnGoing,
		Pause,
		Win,
		Lose
	}

	private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		enemySpawner = GetComponent<EnemySpawner>();
        instance = this;
	}

	private void Start() {
		Time.timeScale = 1f;
	}

    private void Update() {
        if (enemy == null && state == GameState.OnGoing) {
            enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
        }
    }

	public void UpdateGameState(GameState newState) {
		state = newState;

		switch (newState) {
			case GameState.OnGoing:
				Debug.Log("OnGoing!");
				break;
			case GameState.Pause:
				Debug.Log("Pause!");
				break;
			case GameState.Win:
				WinCondition();
				break;
			case GameState.Lose:
				LoseCondition();
				break;
			default:
				break;
		}
	}

	private void WinCondition() {
		conditionUI.ShowWinPanel();
		Time.timeScale = 0f;
	}

	private void LoseCondition() {
		conditionUI.ShowLosePanel();
		Time.timeScale = 0f;
	}
}