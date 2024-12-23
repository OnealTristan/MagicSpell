using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OptionInGameScript : MonoBehaviour
{
    [SerializeField] private OptionInGameUI optionInGameUI;
    [SerializeField] private GameObject exitPanel;

    [Header(" Variable ")]
    private bool optionIsOpened;

	private void Start() {
		exitPanel.SetActive(false);
	}

	public void ClickOptionButton() {
        if (optionIsOpened == false) {
            optionInGameUI.InAnimation();
			optionIsOpened = true;
        } else {
            optionInGameUI.OutAnimation();
            optionIsOpened = false;
        }
    }

    public void ClickExitButton() {
        exitPanel.SetActive(true);
    }

    public void ClickNoButton() {
        exitPanel.SetActive(false);
    }

    public void ClickYesButton() {
        Debug.Log("Yes Cliced");
        Loader.Load(Loader.Scene.LevelMenu);
    }
}