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
    private Data data;
    [SerializeField] private Transform parentContentPosWeaponUI;
	[SerializeField] private Transform parentContentPosPotionUI;
    [SerializeField] private GameObject PanelPrefab;
	[Space(10)]
	[SerializeField] private PotionSO[] potionSO;

	private void Awake() {
		if (data == null) {
            data = GameObject.FindGameObjectWithTag("Data").GetComponent<Data>();
        }
	}

	// Start is called before the first frame update
	void Start()
    {
		WeaponShop();
		PotionShop();
    }

	private void PotionShop() {
		for (int i = 0; i < potionSO.Length; i++) {
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
			if (weaponImage != null && potionSO[i].image != null) {
				weaponImage.sprite = potionSO[i].image;
			}

			// Set weapon name text
			TextMeshProUGUI text = panelInstance.GetComponentInChildren<TextMeshProUGUI>();
			text.text = potionSO[i].potionName;

			// Set price text
			Text priceText = panelInstance.GetComponentInChildren<Text>();
			priceText.text = potionSO[i].price.ToString();

			// Set Button properties
			Button buttonBuy = panelInstance.GetComponentInChildren<Button>();
			TextMeshProUGUI textBuyButton = buttonBuy.GetComponentInChildren<TextMeshProUGUI>();
			textBuyButton.text = "Buy";
			int index = i;
			buttonBuy.onClick.AddListener(() => BuyPotion(index));
		}
	}

	private void BuyPotion(int index) {
		if (data.GetCoin() >= potionSO[index].price) {
			potionSO[index].amount++;
			data.SetCoin(data.GetCoin() - potionSO[index].price);
			onBuyPotion?.Invoke();
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
            onBuyWeapon?.Invoke();
		} else {
			Debug.Log("Not Enough Coin");
            return;
        }
    }
}