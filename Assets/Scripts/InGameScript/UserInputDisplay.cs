using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UserInputDisplay : MonoBehaviour
{
    [Header(" References ")]
    [SerializeField] private Text textContainer;
    [SerializeField] private NewKeyboard keyboard;
    private PlayerAnimation playerAnimation;

    [Header(" Elements ")]
    private bool wordEmpty;

	private void Awake() {
		playerAnimation = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAnimation>();
	}

	// Start is called before the first frame update
	void Start()
    {
        wordEmpty = true;

        // Get reference to NewKeyboard
        if (keyboard != null)
        {
            // Subscribe to events
            keyboard.onBackspacePressed += BackspacePressedCallback;
            keyboard.onKeyPressed += KeyPressedCallback;
            keyboard.OnEnterPressed += EnterPreseedCallback;
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
                wordEmpty = true;
				playerAnimation.PlayerIdleAnimation();
			}
		} else {
            wordEmpty = true;
			playerAnimation.PlayerIdleAnimation();
		}
	}

    private void KeyPressedCallback(string key)
    {
        if (wordEmpty == true) {
            wordEmpty = false;
            textContainer.text += key;
		    playerAnimation.PlayerSpellingAnimation();
        } else {
			textContainer.text += key;
		}
	}

    private void EnterPreseedCallback() {
        wordEmpty = true;
    }


	public void DeleteText() {
        textContainer.text = string.Empty;
    }

    public string DisplayText() {
        return textContainer.text.ToLower().Trim();
    }
}