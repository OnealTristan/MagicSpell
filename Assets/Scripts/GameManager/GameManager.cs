using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[Header(" References ")]
	[SerializeField] private GameObject tutorialPanel;
	[SerializeField] private GameObject gameLayoutPanel;
	[SerializeField] private GameObject background;
	private ConditionUI conditionUI;
	private Data data;
	private Enemy enemy;
	private Player player;

	[Header(" Elements ")]
	[SerializeField] private int levelIndex;
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
		// projectMode(true) == TA
		if (data.GetProjectMode() == true) {
			levelIndex = data.GetLevelIndex() + 1;
			chapterIndex = data.GetChapterIndex() + 1;
			ChangeBackgroundImage();

			if (levelIndex - 1 == 0 && chapterIndex - 1 == 0) {
				TutorialPanelShow();
			} else {
				GamePanelShow();
				Debug.Log(" Tutorial doesn't Exist in this level ");
			}
		}
		// projectMode(false) == KP
		else {
			if (tutorialPanel != null) {
				TutorialPanelShow();
			} else {
				GamePanelShow();
				Debug.Log(" Tutorial doesn't Exist in this level ");
			}
		}

		Time.timeScale = 1f;
	}

    private void Update() {
        if (enemy == null && state == GameState.OnGoing) {
            enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
			enemy.OnHittingPlayer += CheckHpPlayer;
		}

		if (player == null) {
			player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
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
		if (data.chapterSO[chapterIndex - 1].chapterLevelClear[levelIndex - 1] == true) {
			data.SetCoin(data.GetCoin() + data.chapterSO[chapterIndex - 1].chapterLevelWinPrizeAfterComplete[levelIndex - 1]);

			Debug.Log(data.chapterSO[chapterIndex - 1].chapterLevelWinPrizeAfterComplete[levelIndex - 1]);
		} else {
			data.SetCoin(data.GetCoin() + data.chapterSO[chapterIndex - 1].chapterLevelWinPrize[levelIndex - 1]);

			Debug.Log(data.chapterSO[chapterIndex - 1].chapterLevelWinPrize[levelIndex - 1]);
		}
		Time.timeScale = 0f;
		data.UpdateLevelStatus(chapterIndex - 1, levelIndex - 1, true);
	}

	private void LoseCondition() {
		conditionUI.ShowLosePanel();
		data.SetCoin(data.GetCoin() + data.chapterSO[chapterIndex - 1].chapterLevelLosePrize[levelIndex - 1]);
		Debug.Log(data.chapterSO[chapterIndex - 1].chapterLevelLosePrize[levelIndex - 1]);
		Time.timeScale = 0f;
	}

	private void CheckHpPlayer() {
		if (player.GetPlayerHealth() < 1) {
			UpdateGameState(GameState.Lose);
		}
	}

	private void TutorialPanelShow() {
		tutorialPanel.SetActive(true);
		gameLayoutPanel.SetActive(false);
	}
	
	public void GamePanelShow() {
		if (tutorialPanel != null) {
			tutorialPanel.SetActive(false);
		}
		gameLayoutPanel.SetActive(true);
	}

	private void ChangeBackgroundImage() {
		SpriteRenderer backgroundSprite = background.GetComponent<SpriteRenderer>();
		backgroundSprite.sprite = data.chapterSO[chapterIndex - 1].backgroundChapter;
	}
}