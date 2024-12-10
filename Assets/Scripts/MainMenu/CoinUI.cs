using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinUI : MonoBehaviour
{
    [Header(" References ")]
    [SerializeField] private ShopScript shopScript;
    private TextMeshProUGUI coinText;
    private Data data;

	private void Awake() {
		coinText = GameObject.Find("CoinContainer").GetComponentInChildren<TextMeshProUGUI>();
        data = GameObject.FindGameObjectWithTag("Data").GetComponent<Data>();
	}

	// Start is called before the first frame update
	void Start()
    {
        shopScript.onBuyWeapon += ShopScriptOnBuyWeapon;
        shopScript.onBuyPotion += ShopScriptOnBuyWeapon;
    }

	private void Update() {
		if (data.GetCoin() >= 0) {
			coinText.text = data.GetCoin().ToString();
		}
	}

	private void ShopScriptOnBuyWeapon() {
        coinText.text = data.GetCoin().ToString();
	}
}
