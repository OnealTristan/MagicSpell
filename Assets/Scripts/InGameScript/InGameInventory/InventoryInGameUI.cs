using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryInGameUI : MonoBehaviour
{
    private InventoryInGameScript inventory;

    [Header(" References ")]
    [SerializeField] private GameObject inventoryPanel;

	private void Awake() {
		inventory = GetComponent<InventoryInGameScript>();
	}

	// Start is called before the first frame update
	void Start()
    {
        HideInventoryPanel();
        inventory.OnInventoryButtonClick += Inventory_OnInventoryButtonClick;
        inventory.OnBackButtonClick += Inventory_OnBackButtonClick;

	}

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Inventory_OnInventoryButtonClick() {
        ShowInventoryPanel();
    }
    
    private void Inventory_OnBackButtonClick() {
        HideInventoryPanel();
    }
    
	private void ShowInventoryPanel() {
        inventoryPanel.SetActive(true);
    }

    private void HideInventoryPanel() {
        inventoryPanel.SetActive(false);
    }
}
