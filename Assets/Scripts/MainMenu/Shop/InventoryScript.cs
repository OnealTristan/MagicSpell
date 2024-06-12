using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour
{
	[Header(" References ")]
	[SerializeField] private ShopScript shopScript;
	[SerializeField] private Transform parentPosUI;
	[SerializeField] private GameObject contentPanelPrefab;
	[SerializeField] private Sprite equipImage;
	[SerializeField] private Sprite equipedImage;
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