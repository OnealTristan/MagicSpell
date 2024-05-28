using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PanelOpeningCutSceneScript : MonoBehaviour, IPointerClickHandler
{
    private CutSceneScript cutSceneScript;

	private void Awake() {
		cutSceneScript = GetComponent<CutSceneScript>();
	}

	public void OnPointerClick(PointerEventData eventData) {
        cutSceneScript.SkipToMainMenu();
    }
}
