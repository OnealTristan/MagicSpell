using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
	[Header(" References ")]
	[SerializeField] private GameObject[] playerPrefab;
	private Transform playerSpawnPos;
	private Data data;

	private void Awake() {
		playerSpawnPos = GameObject.Find("SpawnPlayerPosition").GetComponent<Transform>();
		data = GameObject.FindGameObjectWithTag("Data").GetComponent<Data>();
		SpawnPlayer();
	}

	private void Start() {
		
	}

	private void SpawnPlayer() {
		for (int i = 0; i < data.weaponSO.Length; i++) {
			if (data.weaponSO[i].weaponEquip == true) {
				Instantiate(playerPrefab[i], playerSpawnPos);
			}
		}
	}
}