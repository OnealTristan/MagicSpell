using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UserInputDisplay : MonoBehaviour
{
    [Header(" References ")]
    [SerializeField] private Text textContainer;
    [SerializeField] private NewKeyboard keyboard;
    private PlayerAnimation playerAnimation;
	private EnemyAnimation enemyAnimation;
	private EventManager eventManager;

    [Header(" Elements ")]
    private bool wordEmpty;

	private void Awake() {
		eventManager = GameObject.Find("EventManager").GetComponent<EventManager>();
	}

	private void OnEnable() {
		eventManager.onKeyPressed += KeyPressedCallback;
		eventManager.onBackspacePressed += BackspacePressedCallback;
		eventManager.onEnterPressedCorrect += EnterPreseedCallback;
		eventManager.onEnterPressedWrong += EnterPreseedCallback;

		if (keyboard != null) {
			// Subscribe to events
			keyboard.onBackspacePressed += BackspacePressedCallback;
			keyboard.onKeyPressed += KeyPressedCallback;
			keyboard.OnEnterPressed += EnterPreseedCallback;
		} else {
			Debug.LogError("NewKeyboard component not found in children. Make sure it is added to the GameObject.");
		}
	}

	// Start is called before the first frame update
	void Start()
    {
		wordEmpty = true;
    }

	private void Update() {
		if (playerAnimation == null && GameManager.instance.state == GameManager.GameState.OnGoing) {
			playerAnimation = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAnimation>();
		}

		if (enemyAnimation == null && GameManager.instance.state == GameManager.GameState.OnGoing) {
			enemyAnimation = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyAnimation>();
			enemyAnimation.OnEnemyAnimationEnd += CheckWordEmpty;
		}
	}

	private void BackspacePressedCallback()
    {
        if (textContainer.text.Length > 0)
        {
            textContainer.text = textContainer.text.Substring(0, textContainer.text.Length - 1);
			if (textContainer.text.Length < 1) {
                wordEmpty = true;
				eventManager.OnTextEmpty();
				//playerAnimation.PlayerIdleAnimation();
			}
		} else {
            wordEmpty = true;
			eventManager.OnTextEmpty();
			//playerAnimation.PlayerIdleAnimation();
		}
	}

    private void KeyPressedCallback(string key)
    {
        if (wordEmpty == true) {
            wordEmpty = false;
            textContainer.text += key;
			eventManager.OnTextDisplay();
			//playerAnimation.PlayerSpellingAnimation();
        } else {
			textContainer.text += key;
		}
	}

    private void EnterPreseedCallback() {
        wordEmpty = true;
        textContainer.text = string.Empty;
    }

	private void CheckWordEmpty() {
		if (wordEmpty == false) {
			playerAnimation.PlayerSpellingAnimation();
		} else {
			return;
		}
	}

	public void DeleteText() {
		textContainer.text = string.Empty;
    }

    public string DisplayText() {
        return textContainer.text.ToLower().Trim();
    }

	private void OnDisable() {
		eventManager.onKeyPressed -= KeyPressedCallback;
		eventManager.onBackspacePressed -= BackspacePressedCallback;
		eventManager.onEnterPressedCorrect -= EnterPreseedCallback;
		eventManager.onEnterPressedWrong += EnterPreseedCallback;

		/*keyboard.onBackspacePressed -= BackspacePressedCallback;
		keyboard.onKeyPressed -= KeyPressedCallback;
		keyboard.OnEnterPressed -= EnterPreseedCallback;*/
	}
}