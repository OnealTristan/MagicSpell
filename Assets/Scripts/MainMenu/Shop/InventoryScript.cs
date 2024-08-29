using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour
{
	[Header(" References Classes ")]
	[SerializeField] private ShopScript shopScript;

	[Header(" References Weapon ")]
	[SerializeField] private Transform parentContentWeaponPosUI;
	[SerializeField] private GameObject contentPanelWeaponPrefab;
	[SerializeField] private Sprite equipImage;
	[SerializeField] private Sprite equipedImage;
	[SerializeField] private WeaponSO[] weaponSO;
	private WeaponSO equippedWeapon;

	[Header(" References Potion ")]
	[SerializeField] private Transform parentContentPotionPosUI;
	[SerializeField] private GameObject contentPanelPotionPrefab;
	[SerializeField] private PotionSO[] potionSO;

	// Start is called before the first frame update
	void Start()
    {
		shopScript.onBuyWeapon += UpdateWeaponInventory;
		shopScript.onBuyPotion += UpdatePotionInventory;
		UpdateWeaponInventory();
		UpdatePotionInventory();
    }

	private void UpdatePotionInventory() {
		foreach (Transform child in parentContentPotionPosUI) {
			Destroy(child.gameObject);
		}

		foreach (PotionSO potion in potionSO) {
			if (potion.amount > 0) {
				GameObject panelInstance = Instantiate(contentPanelPotionPrefab, parentContentPotionPosUI);

				Image[] images = panelInstance.GetComponentsInChildren<Image>();

				foreach (Image image in images) {
					if (image.CompareTag("WeaponImage")) {
						image.sprite = potion.image;
					}
				}

				// Set weapon name text
				TextMeshProUGUI text = panelInstance.GetComponentInChildren<TextMeshProUGUI>();
				text.text = potion.potionName;

				// Set Button properties
				Button buttonEquip = panelInstance.GetComponentInChildren<Button>();
				buttonEquip.onClick.AddListener(() => EquipPotion(potion));
			}
		}
	}

	private void EquipPotion(PotionSO potion) {

	}

	private void UpdateWeaponInventory() {
		foreach (Transform child in parentContentWeaponPosUI) {
			Destroy(child.gameObject);
		}

		foreach (WeaponSO weapon in weaponSO) {
			if (weapon.buyed == true) {
				GameObject panelInstance = Instantiate(contentPanelWeaponPrefab, parentContentWeaponPosUI);

				Image[] images = panelInstance.GetComponentsInChildren<Image>();

				foreach (Image image in images) {
					if (image.CompareTag("WeaponImage")) {
						image.sprite = weapon.image;
					}
				}

				// Set weapon name text
				TextMeshProUGUI text = panelInstance.GetComponentInChildren<TextMeshProUGUI>();
				text.text = weapon.name;

				// Set Button properties
				Button buttonEquip = panelInstance.GetComponentInChildren<Button>();
				Image imageButton = buttonEquip.GetComponent<Image>();
				if (weapon.equip == true) {
					buttonEquip.interactable = false;
					imageButton.sprite = equipedImage;

					equippedWeapon = weapon;
				} else {
					buttonEquip.interactable = true;
					imageButton.sprite = equipImage;

					buttonEquip.onClick.AddListener(() => EquipWeapon(weapon, imageButton));
				}
			}
		}
	}

	private void EquipWeapon(WeaponSO weapon, Image imageButton) {
		if (equippedWeapon != null) {
			equippedWeapon.equip = false;
		}
		weapon.equip = true;
		equippedWeapon = weapon;

		imageButton.sprite = equipImage;

		UpdateWeaponInventory();
	}
}