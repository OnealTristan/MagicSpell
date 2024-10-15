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
	[SerializeField] private int LevelIndex;
	[SerializeField] private int chapterIndex;

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
        
        instance = this;
	}

	private void Start() {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

		Time.timeScale = 1f;
	}

    private void Update() {
        if (enemy == null && state == GameState.OnGoing) {
            enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
			enemy.OnHittingPlayer += CheckHpPlayer;
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
		if (data.chapterSo[chapterIndex - 1].chapterLevelClear[LevelIndex - 1] == true) {
			data.SetCoin(data.coin + data.chapterSo[chapterIndex - 1].chapterLevelWinPrizeAfterComplete[LevelIndex - 1]);
			Debug.Log(data.chapterSo[chapterIndex - 1].chapterLevelWinPrizeAfterComplete[LevelIndex - 1]);
		} else {
			data.SetCoin(data.coin + data.chapterSo[chapterIndex - 1].chapterLevelWinPrize[LevelIndex - 1]);
			Debug.Log(data.chapterSo[chapterIndex - 1].chapterLevelWinPrize[LevelIndex - 1]);
		}
		Time.timeScale = 0f;
		data.UpdateLevelStatus(chapterIndex - 1, LevelIndex - 1, true);
	}

	private void LoseCondition() {
		conditionUI.ShowLosePanel();
		data.SetCoin(data.coin + data.chapterSo[chapterIndex - 1].chapterLevelLosePrize[LevelIndex - 1]);
		Debug.Log(data.chapterSo[chapterIndex - 1].chapterLevelLosePrize[LevelIndex - 1]);
		Time.timeScale = 0f;
	}

	private void CheckHpPlayer() {
		if (player.GetPlayerHealth() < 1) {
			UpdateGameState(GameState.Lose);
		}
	}
}