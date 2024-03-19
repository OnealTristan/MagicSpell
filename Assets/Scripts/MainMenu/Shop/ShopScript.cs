using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using System;

public class ShopScript : MonoBehaviour
{
    public Action OnBuyWeapon;

    [Header(" References ")]
    private Data data;
    [SerializeField] private Transform parentPosUI;
    [SerializeField] private GameObject contentPanelPrefab;
    [SerializeField] private WeaponSO[] weaponSO;

	private void Awake() {
		if (data == null) {
            data = GameObject.FindGameObjectWithTag("Data").GetComponent<Data>();
        }
	}

	// Start is called before the first frame update
	void Start()
    {
        for (int i = 0; i < weaponSO.Length; i++) {
            GameObject panelInstance = Instantiate(contentPanelPrefab, parentPosUI);

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

			// Set Button properties
			Button buttonBuy = panelInstance.GetComponentInChildren<Button>();
			TextMeshProUGUI textBuyButton = buttonBuy.GetComponentInChildren<TextMeshProUGUI>();
            if (weaponSO[i].buyed == true) {
				buttonBuy.interactable = false;
                textBuyButton.text = "Bought";
            } else {
				buttonBuy.interactable = true;
                textBuyButton.text = "Buy " + weaponSO[i].price.ToString();

                int index = i;
                buttonBuy.onClick.AddListener(() => BuyWeapon(index, buttonBuy, textBuyButton));
			}
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void BuyWeapon(int index, Button buttonBuy, TextMeshProUGUI textBuyButton) {
        if (data.coin >= weaponSO[index].price) {
            weaponSO[index].buyed = true;

			buttonBuy.interactable = false;
			textBuyButton.text = "Bought";

            data.SetCoin(data.coin - weaponSO[index].price);
            OnBuyWeapon?.Invoke();
		} else {
            return;
        }
    }
}