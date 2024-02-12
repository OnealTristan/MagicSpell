using UnityEngine;
using UnityEngine.UI;

public class UserInputDisplay : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private Text text;

    // Start is called before the first frame update
    void Start()
    {
        // Get reference to NewKeyboard
        NewKeyboard newKeyboard = GetComponent<NewKeyboard>();
        if (newKeyboard != null)
        {
            // Subscribe to events
            newKeyboard.onBackspacePressed += BackspacePressedCallback;
            newKeyboard.onKeyPressed += KeyPressedCallback;
        }
        else
        {
            Debug.LogError("NewKeyboard component not found in children. Make sure it is added to the GameObject.");
        }
    }

    private void BackspacePressedCallback()
    {
        if (text.text.Length > 0)
        {
            text.text = text.text.Substring(0, text.text.Length - 1);
        }
    }

    private void KeyPressedCallback(string key)
    {
        text.text += key;
    }
}



