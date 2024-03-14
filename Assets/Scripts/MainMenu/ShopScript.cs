using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopScript : MonoBehaviour
{
    [Header(" References ")]
    [SerializeField] private Transform parentPosUI;
    [SerializeField] private GameObject contentPanel;
    [SerializeField] private WeaponSO[] weaponSO;

	// Start is called before the first frame update
	void Start()
    {
        for (int i = 0; i < weaponSO.Length; i++) {
            GameObject panelInstance = Instantiate(contentPanel, parentPosUI);

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
            Button button = panelInstance.GetComponentInChildren<Button>();
            TextMeshProUGUI textBuyButton = button.GetComponentInChildren<TextMeshProUGUI>();
            if (weaponSO[i].buyed == true) {
                button.interactable = false;
                textBuyButton.text = "Bought";
            } else {
                button.interactable = true;
				textBuyButton.text = "Buy";
			}
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
