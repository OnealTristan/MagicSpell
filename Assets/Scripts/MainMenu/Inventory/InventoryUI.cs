using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ShowInventoryPanel () {
        gameObject.SetActive(true);
    }

	public void HideInventoryPanel() {
        gameObject.SetActive(false);
	}
}
