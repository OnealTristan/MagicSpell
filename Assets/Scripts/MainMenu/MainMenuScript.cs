using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
	[Header(" References ")]
	[SerializeField] private MainMenuUI mainMenuUI;
	[SerializeField] private ShopUI shopUI;
	[SerializeField] private InventoryUI inventoryUI;

	private void Start() {

	}

	public void StartButtonClick () {
        Debug.Log("Start Clicked");
        Loader.Load(Loader.Scene.LevelMenu);
    }

	public void MainMenuButtonClick () {
		mainMenuUI.ShowMainMenuPanel();
		shopUI.HideShopPanel();
		inventoryUI.HideInventoryPanel();
	}

	public void ShopButtonClick () {
		mainMenuUI.HideMainMenuPanel();
		shopUI.ShowShopPanel();
		inventoryUI.HideInventoryPanel();
	}

	public void InventoryButtonClick () {
		mainMenuUI.HideMainMenuPanel();
		shopUI.HideShopPanel();
		inventoryUI.ShowInventoryPanel();
	}
}
