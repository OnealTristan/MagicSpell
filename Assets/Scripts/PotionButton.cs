using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionButton : MonoBehaviour
{
    [Header(" Settings ")]
    [SerializeField] private GameObject keyboard;
    [SerializeField] private GameObject potionPanel;

    public void OnButtonClick () {
        if (keyboard.activeSelf == true) {
            potionPanel.SetActive(true);
            keyboard.SetActive(false);
        } else {
            potionPanel.SetActive(false);
            keyboard.SetActive(true);
        }
    }
}
