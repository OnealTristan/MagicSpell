using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour
{
	[Header(" References Classes ")]
	[SerializeField] private ShopScript shopScript;
	private Data data;
	private EventManager eventManager;

	[Header(" References Weapon ")]
	[SerializeField] private Transform parentContentWeaponPosUI;
	[SerializeField] private GameObject contentPanelWeaponPrefab;
	[SerializeField] private Sprite equipImage;
	[SerializeField] private Sprite equipedImage;
	private WeaponSO equippedWeapon;

	[Header(" References Potion ")]
	[SerializeField] private Transform parentContentPotionPosUI;
	[SerializeField] private GameObject contentPanelPotionPrefab;

	private void Awake() {
		data = GameObject.FindGameObjectWithTag("Data").GetComponent<Data>();
		eventManager = GameObject.Find("EventManager").GetComponent<EventManager>();
	}

	private void OnEnable() {
		/*shopScript.onBuyWeapon += UpdateWeaponInventory;
		shopScript.onBuyPotion += UpdatePotionInventory;*/

		eventManager.onBuyWeapon += UpdateWeaponInventory;
		eventManager.onBuyPotion += UpdatePotionInventory;
	}

	// Start is called before the first frame update
	void Start()
    {
		UpdateWeaponInventory();
		UpdatePotionInventory();
    }

	private void UpdatePotionInventory() {
		foreach (Transform child in parentContentPotionPosUI) {
			Destroy(child.gameObject);
		}

		foreach (PotionSO potion in data.potionSO) {
			if (potion.amount > 0 || potion.id == 0) {
				GameObject panelInstance = Instantiate(contentPanelPotionPrefab, parentContentPotionPosUI);

				Image[] images = panelInstance.GetComponentsInChildren<Image>();

				foreach (Image image in images) {
					if (image.CompareTag("WeaponImage")) {
						image.sprite = potion.image;
					}
				}

				// Set weapon name text
				TextMeshProUGUI text = panelInstance.GetComponentInChildren<TextMeshProUGUI>();
				// Set Button properties
				Button buttonEquip = panelInstance.GetComponentInChildren<Button>();
				if (potion.id == 0) {
					text.text = "Max Health = " + data.GetMaxHealthPlayer();
					buttonEquip.interactable = false;
				} else {
					text.text = potion.potionName;
					buttonEquip.onClick.AddListener(() => EquipPotion(potion));
				}
			}
		}
	}

	private void EquipPotion(PotionSO potion) {

	}

	private void UpdateWeaponInventory() {
		foreach (Transform child in parentContentWeaponPosUI) {
			Destroy(child.gameObject);
		}

		foreach (WeaponSO weapon in data.weaponSO) {
			if (weapon.weaponBuyed == true) {
				GameObject panelInstance = Instantiate(contentPanelWeaponPrefab, parentContentWeaponPosUI);

				Image[] images = panelInstance.GetComponentsInChildren<Image>();

				foreach (Image image in images) {
					if (image.CompareTag("WeaponImage")) {
						image.sprite = weapon.image;
					}
				}

				// Set weapon name text
				TextMeshProUGUI text = panelInstance.GetComponentInChildren<TextMeshProUGUI>();
				text.text = weapon.weaponName;

				// Set Button properties
				Button buttonEquip = panelInstance.GetComponentInChildren<Button>();
				Image imageButton = buttonEquip.GetComponent<Image>();
				if (weapon.weaponEquip == true) {
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
			equippedWeapon.weaponEquip = false;
		}
		weapon.weaponEquip = true;
		equippedWeapon = weapon;

		imageButton.sprite = equipImage;

		UpdateWeaponInventory();
	}

	private void OnDisable() {
		/*shopScript.onBuyWeapon -= UpdateWeaponInventory;
		shopScript.onBuyPotion -= UpdatePotionInventory;*/

		eventManager.onBuyWeapon -= UpdateWeaponInventory;
		eventManager.onBuyPotion -= UpdatePotionInventory;
	}
}