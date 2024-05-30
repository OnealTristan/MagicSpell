using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour
{
	private static string EQUIPPED = "Equipped";
	private static string EQUIP = "Equip";

	[Header(" References ")]
	[SerializeField] private ShopScript shopScript;
	[SerializeField] private Transform parentPosUI;
	[SerializeField] private GameObject contentPanelPrefab;
	[SerializeField] private WeaponSO[] weaponSO;
	private WeaponSO equippedWeapon;

	private void Awake() {
		shopScript.OnBuyWeapon += UpdateInventory;
	}

	// Start is called before the first frame update
	void Start()
    {
		UpdateInventory();
    }

	private void UpdateInventory() {
		foreach (Transform child in parentPosUI) {
			Destroy(child.gameObject);
		}

		foreach (WeaponSO weapon in weaponSO) {
			if (weapon.buyed == true) {
				GameObject panelInstance = Instantiate(contentPanelPrefab, parentPosUI);

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
				if (weaponImage != null && weapon.image != null) {
					weaponImage.sprite = weapon.image;
				}

				// Set weapon name text
				TextMeshProUGUI text = panelInstance.GetComponentInChildren<TextMeshProUGUI>();
				text.text = weapon.name;

				// Set Button properties
				Button buttonBuy = panelInstance.GetComponentInChildren<Button>();
				TextMeshProUGUI textBuyButton = buttonBuy.GetComponentInChildren<TextMeshProUGUI>();
				if (weapon.equip == true) {
					buttonBuy.interactable = false;
					textBuyButton.text = EQUIPPED;

					equippedWeapon = weapon;
				} else {
					buttonBuy.interactable = true;
					textBuyButton.text = EQUIP;

					buttonBuy.onClick.AddListener(() => EquipWeapon(weapon, textBuyButton));
				}
			}
		}
	}

	private void EquipWeapon(WeaponSO weapon, TextMeshProUGUI textBuyButton) {
		if (equippedWeapon != null) {
			equippedWeapon.equip = false;
		}
		weapon.equip = true;
		equippedWeapon = weapon;

		textBuyButton.text = EQUIPPED;

		UpdatePreviousEquipButton();

		UpdateInventory();
	}

	private void UpdatePreviousEquipButton() {
		foreach (WeaponSO weapon in weaponSO) {
			if (weapon != equippedWeapon && weapon.equip == true) {
				weapon.equip = false;
			}
		}
	}
}