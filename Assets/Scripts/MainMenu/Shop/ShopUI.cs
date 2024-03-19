using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
	public void ShowShopPanel () {
		gameObject.SetActive(true);
	}

	public void HideShopPanel() {
		gameObject.SetActive(false);
	}
}
