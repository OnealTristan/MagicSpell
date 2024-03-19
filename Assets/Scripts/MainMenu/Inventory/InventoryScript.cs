using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour
{
    [Header(" References ")]
	[SerializeField] private Transform parentPosUI;
	[SerializeField] private GameObject contentPanelPrefab;
	[SerializeField] private WeaponSO[] weaponSO;

	// Start is called before the first frame update
	void Start()
    {
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
					textBuyButton.text = "Equipped";
				} else {
					buttonBuy.interactable = true;
					textBuyButton.text = "Equip";
				}
			}
		}
    }
}
