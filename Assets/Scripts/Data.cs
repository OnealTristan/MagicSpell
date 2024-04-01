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
    public bool level1IsClear;
	public bool level2IsClear;
	public bool level3IsClear;
	public bool level4IsClear;

	private void Awake() {
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy(gameObject);
		}
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		
	}

    public int GetCoin() {
        return coin;
    }

    public int SetCoin(int coin) {
        return this.coin = coin;
    }
}
