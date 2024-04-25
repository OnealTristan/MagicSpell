using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationMainMenuScript : MonoBehaviour
{
	[Header(" References ")]
	[SerializeField] private GameObject mainMenuPanel;
	[SerializeField] private MainMenuUI mainMenuUI;
	[SerializeField] private ShopUI shopUI;
	[SerializeField] private InventoryUI inventoryUI;

	public void StartButtonClick() {
		if (mainMenuPanel.activeSelf == true) {
			Loader.Load(Loader.Scene.LevelMenu);
		} else {
			mainMenuUI.ShowMainMenuPanel();
			shopUI.HideShopPanel();
			inventoryUI.HideInventoryPanel();
		}
	}

	public void ShopButtonClick() {
		mainMenuUI.HideMainMenuPanel();
		shopUI.ShowShopPanel();
		inventoryUI.HideInventoryPanel();
	}

	public void InventoryButtonClick() {
		mainMenuUI.HideMainMenuPanel();
		shopUI.HideShopPanel();
		inventoryUI.ShowInventoryPanel();
	}
}
