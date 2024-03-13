using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    [Header(" Elements ")]
    public int coin;
    [Space(10)]
    public bool level1IsClear;
	public bool level2IsClear;

	private void Awake() {
		DontDestroyOnLoad(this);
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
