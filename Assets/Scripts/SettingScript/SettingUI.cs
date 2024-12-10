using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingUI : MonoBehaviour
{
    [Header(" References ")]
    [SerializeField] private GameObject settingPanel;
    [SerializeField] private GameObject optionPanel;
    [SerializeField] private GameObject creditPanel;

    public void ClickSettingButton() {
        settingPanel.SetActive(true);
    }

    public void ClickSettingBackButton() {
        settingPanel.SetActive(false);
    }

    public void ClickCreditButton() {
        optionPanel.SetActive(false);
        creditPanel.SetActive(true);
    }

    public void ClickCreditBackButton() {
        optionPanel.SetActive(true);
        creditPanel.SetActive(false);
    }
}
