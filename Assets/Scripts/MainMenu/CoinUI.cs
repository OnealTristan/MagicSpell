using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinUI : MonoBehaviour
{
    [Header(" References ")]
    private ShopScript shopScript;
    private TextMeshProUGUI coinText;
    private Data data;

	private void Awake() {
		coinText = GameObject.Find("CoinContainer").GetComponentInChildren<TextMeshProUGUI>();
        data = GameObject.FindGameObjectWithTag("Data").GetComponent<Data>();
        shopScript = GameObject.Find("ShopPanel").GetComponent<ShopScript>();
	}

	// Start is called before the first frame update
	void Start()
    {
        coinText.text = data.GetCoin().ToString();

        shopScript.OnBuyWeapon += ShopScriptOnBuyWeapon;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ShopScriptOnBuyWeapon() {
        coinText.text = data.GetCoin().ToString();
	}
}
