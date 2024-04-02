using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    public static Data Instance;

    [Header(" Elements ")]
    public int coin;
    [Space(10)]
    public bool[] chapter1LevelClear;

	private void Awake() {
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy(gameObject);
		}
	}

    public void UpdateLevelStatus(int levelIndex, bool isClear) {
        chapter1LevelClear[levelIndex - 1] = isClear;
    }

    public int GetCoin() {
        return coin;
    }

    public int SetCoin(int coin) {
        return this.coin = coin;
    }
}
