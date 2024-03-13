using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[Header(" References ")]
	private ConditionUI conditionUI;
	private Data data;
	private Enemy enemy;
	private Player player;

	[Header(" Elements ")]
	[SerializeField] private int incrementHealthEnemy;

    public static GameManager instance;

	[Space(10)]
    public GameState state;

    public enum GameState {
		OnGoing,
		Pause,
		Win,
		Lose
	}

	private void Awake() {
		conditionUI = GameObject.Find("Canvas").GetComponent<ConditionUI>();
		data = GameObject.FindGameObjectWithTag("Data").GetComponent<Data>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        instance = this;
	}

	private void Start() {
		Time.timeScale = 1f;
	}

    private void Update() {
        if (enemy == null && state == GameState.OnGoing) {
            enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
			enemy.SetIncrementEnemyHealth(incrementHealthEnemy);
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
				data.level1IsClear = true;
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