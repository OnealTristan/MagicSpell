using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tutorial : MonoBehaviour, IPointerClickHandler
{
    private GameManager gameManager;
	private Enemy enemy;

	private void Awake() {
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}

	private void Update() {
		if (enemy == null) {
			enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
		}
	}

	public void OnPointerClick(PointerEventData eventData) {
		gameManager.GamePanelShow();
		enemy.ResetAttackInterval();
	}

	private void Enemy_ResetAttackInterval() {
		enemy.ResetAttackInterval();
	}
}