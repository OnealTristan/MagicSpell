using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingKeyboard : MonoBehaviour
{
    [Header(" References ")]
    [SerializeField] private Keyboard keyboard;
    [SerializeField] private Slider heightSlider;
    [SerializeField] private Slider bottomOffSlider;
    [SerializeField] private Slider keyToLineSlider;
    [SerializeField] private Slider spacingXSlider;

    // Update is called once per frame
    void FixedUpdate()
    {
        keyboard.heightPercent = heightSlider.value;
        keyboard.bottomOffset = bottomOffSlider.value;
        keyboard.keyToLineRatio = keyToLineSlider.value;
        keyboard.keyXSpacing = spacingXSlider.value;
    }
}
