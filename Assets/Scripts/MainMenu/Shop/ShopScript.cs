using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
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
    [SerializeField] private WeaponSO[] weaponSO;
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
		if (data.coin >= potionSO[index].price) {
			potionSO[index].amount++;
			data.SetCoin(data.coin - potionSO[index].price);
			onBuyPotion?.Invoke();
		} else {
			return;
		}
	}

    private void WeaponShop() {
		for (int i = 0; i < weaponSO.Length; i++) {
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
			if (weaponImage != null && weaponSO[i].image != null) {
				weaponImage.sprite = weaponSO[i].image;
			}

			// Set weapon name text
			TextMeshProUGUI text = panelInstance.GetComponentInChildren<TextMeshProUGUI>();
			text.text = weaponSO[i].name;

			// Set price text
			Text priceText = panelInstance.GetComponentInChildren<Text>();
			if (weaponSO[i].price == 0) {
				priceText.text = "FREE";
			} else {
				priceText.text = weaponSO[i].price.ToString();
			}

			// Set Button properties
			Button buttonBuy = panelInstance.GetComponentInChildren<Button>();
			TextMeshProUGUI textBuyButton = buttonBuy.GetComponentInChildren<TextMeshProUGUI>();
			if (weaponSO[i].buyed == true) {
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
        if (data.coin >= weaponSO[index].price) {
            weaponSO[index].buyed = true;

			buttonBuy.interactable = false;
			textBuyButton.text = "Bought";

            data.SetCoin(data.coin - weaponSO[index].price);
            onBuyWeapon?.Invoke();
		} else {
            return;
        }
    }
}