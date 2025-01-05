using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ShopScript : MonoBehaviour
{
    public Action onBuyWeapon;
	public Action onBuyPotion;

    [Header(" References ")]
    [SerializeField] private Transform parentContentPosWeaponUI;
	[SerializeField] private Transform parentContentPosPotionUI;
    [SerializeField] private GameObject PanelPrefab;
    private Data data;
	private EventManager eventManager;

	private void Awake() {
		data = GameObject.FindGameObjectWithTag("Data").GetComponent<Data>();
		eventManager = GameObject.Find("EventManager").GetComponent<EventManager>();
	}

	// Start is called before the first frame update
	void Start()
    {
		WeaponShop();
		PotionShop();
    }

	// Function penampilan UI list data potion
	private void PotionShop() {
		for (int i = 0; i < data.potionSO.Length; i++) {
			GameObject panelInstance = Instantiate(PanelPrefab, parentContentPosPotionUI);

			// Mengambil references dari beberapa Image components
			Image[] images = panelInstance.GetComponentsInChildren<Image>();

			// Image untuk display gambar senjata
			Image weaponImage = null;

			// Iterasi mencari Image yang sesuai
			foreach (Image image in images) {
				// Cek Image mana yang diperuntukan sebagai display dari gambar weapon
				if (image.CompareTag("WeaponImage")) {
					weaponImage = image;
				}
			}

			// Set Weapon Image
			if (weaponImage != null && data.potionSO[i].image != null) {
				weaponImage.sprite = data.potionSO[i].image;
			}

			// Set weapon name text
			TextMeshProUGUI text = panelInstance.GetComponentInChildren<TextMeshProUGUI>();
			text.text = data.potionSO[i].potionName;

			// Set price text
			Text priceText = panelInstance.GetComponentInChildren<Text>();
			priceText.text = data.potionSO[i].price.ToString();

			// Set Button properties
			Button buttonBuy = panelInstance.GetComponentInChildren<Button>();
			TextMeshProUGUI textBuyButton = buttonBuy.GetComponentInChildren<TextMeshProUGUI>();
			textBuyButton.text = "Buy";
			buttonBuy.onClick.AddListener(() => BuyPotion(i - 1));
		}
	}

	private void BuyPotion(int index) {
		if (data.GetCoin() >= data.potionSO[index].price) {
			CheckBuyPotion(index);
			data.potionSO[index].amount++;
			data.SetCoin(data.GetCoin() - data.potionSO[index].price);
			//onBuyPotion?.Invoke();
			eventManager.OnBuyPotion();
		} else {
			// UI Coin tidak cukup
			return;
		}
	}

	private void CheckBuyPotion(int index) {
		if (data.potionSO[index].id == 0) {
			data.SetMaxHealthPlayer(data.GetMaxHealthPlayer() + 2);
		} else {
			return;
		}
	}

    private void WeaponShop() {
		for (int i = 0; i < data.weaponSO.Length; i++) {
			GameObject panelInstance = Instantiate(PanelPrefab, parentContentPosWeaponUI);

			// Mengambil references dari beberapa Image components
			Image[] images = panelInstance.GetComponentsInChildren<Image>();

			// Image untuk display gambar senjata
			Image weaponImage = null;

			// Iterasi mencari Image yang sesuai
			foreach (Image image in images) {
				// Cek Image mana yang diperuntukan sebagai display dari gambar weapon
				if (image.CompareTag("WeaponImage")) {
					weaponImage = image;
				}
			}

			// Set Weapon Image
			if (weaponImage != null && data.weaponSO[i].image != null) {
				weaponImage.sprite = data.weaponSO[i].image;
			}

			// Set weapon name text
			TextMeshProUGUI text = panelInstance.GetComponentInChildren<TextMeshProUGUI>();
			text.text = data.weaponSO[i].weaponName;

			// Set price text
			Text priceText = panelInstance.GetComponentInChildren<Text>();
			if (data.weaponSO[i].weaponPrice == 0) {
				priceText.text = "FREE";
			} else {
				priceText.text = data.weaponSO[i].weaponPrice.ToString();
			}

			// Set Button properties
			Button buttonBuy = panelInstance.GetComponentInChildren<Button>();
			TextMeshProUGUI textBuyButton = buttonBuy.GetComponentInChildren<TextMeshProUGUI>();
			if (data.weaponSO[i].weaponBuyed == true) {
				buttonBuy.interactable = false;
				textBuyButton.text = "Bought";
			} else {
				buttonBuy.interactable = true;
				textBuyButton.text = "Buy";

				int index = i;
				buttonBuy.onClick.AddListener(() => BuyWeapon(index, buttonBuy, textBuyButton));
			}
		}
	}

    private void BuyWeapon(int index, Button buttonBuy, TextMeshProUGUI textBuyButton) {
        if (data.GetCoin() >= data.weaponSO[index].weaponPrice) {
            data.weaponSO[index].weaponBuyed = true;

			buttonBuy.interactable = false;
			textBuyButton.text = "Bought";

            data.SetCoin(data.GetCoin() - data.weaponSO[index].weaponPrice);
			//onBuyWeapon?.Invoke();
			eventManager.OnBuyWeapon();
		} else {
			Debug.Log("Not Enough Coin");
            return;
        }
    }
}