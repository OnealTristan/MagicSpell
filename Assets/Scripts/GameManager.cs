using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[Header(" References ")]
	[SerializeField] private ConditionUI conditionUI;

    public static GameManager instance;

    public GameState state;

	private void Awake() {
		instance = this;
	}

	private void Start() {
		Time.timeScale = 1f;
	}

	public enum GameState {
		OnGoing,
		Pause,
		Win,
		Lose
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