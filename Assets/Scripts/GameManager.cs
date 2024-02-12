using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
   public static GameManager instance;

    public Text Jancok;
    private void Awake()
    {
        instance = this;
    }

    public void SetText(string keyboard)
    {
        Jancok.text += keyboard;
    }
}
