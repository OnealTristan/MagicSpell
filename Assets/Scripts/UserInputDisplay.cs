using UnityEngine;
using UnityEngine.UI;

public class UserInputDisplay : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private Text textContainer;
    [SerializeField] private PlayerAnimation playerAnimation;

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
            newKeyboard.onEnterPressed += EnterPressedCallback;
        }
        else
        {
            Debug.LogError("NewKeyboard component not found in children. Make sure it is added to the GameObject.");
        }
    }

    private void BackspacePressedCallback()
    {
        if (textContainer.text.Length > 0)
        {
            textContainer.text = textContainer.text.Substring(0, textContainer.text.Length - 1);
			if (textContainer.text.Length < 1) {
				playerAnimation.PlayerIdle();
			}
		} else {
			playerAnimation.PlayerIdle();
		}
	}

    private void KeyPressedCallback(string key)
    {
        textContainer.text += key;
		playerAnimation.PlayerSpelling();
	}

    private void EnterPressedCallback() {

    }

    public void DeleteText() {
        textContainer.text = string.Empty;
    }

    public string DisplayText() {
        return textContainer.text.ToLower().Trim();
    }
}