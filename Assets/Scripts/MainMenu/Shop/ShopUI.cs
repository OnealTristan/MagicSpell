using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
	private static string INVENTORYTEXT = "Inventory";
	private static string SHOPTEXT = "Shop";

	[Header(" References ")]
	[SerializeField] private GameObject shopPanel;
	[SerializeField] private GameObject inventoryPanel;
	[SerializeField] private Button shopButton;
	private TextMeshProUGUI textButton;

	[Header(" Elements ")]
	private bool shopUI;

	private void Awake() {
		textButton = shopButton.GetComponentInChildren<TextMeshProUGUI>();
	}

	private void Start() {
		ClickButtonShop();
	}

	public void ClickButtonShop() {
		if (shopUI == true) {
			shopPanel.SetActive(false);
			inventoryPanel.SetActive(true);
			textButton.text = SHOPTEXT;
			shopUI = false;
		} else {
			shopPanel.SetActive(true);
			inventoryPanel.SetActive(false);
			textButton.text = INVENTORYTEXT;
			shopUI = true;
		}
	}

	public void ShowShopPanel () {
		gameObject.SetActive(true);
	}

	public void HideShopPanel() {
		gameObject.SetActive(false);
	}
}