using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameState state;

	private void Awake() {
		instance = this;
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

				break;
			case GameState.Pause:
				Debug.Log("Pause!");
				break;
			case GameState.Win:
				
				break;
			case GameState.Lose:

				break;
			default:
				break;
		}
	}
}