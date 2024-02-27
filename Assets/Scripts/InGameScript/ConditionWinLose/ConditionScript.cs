using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionScript : MonoBehaviour
{
    [SerializeField] private Loader.Scene restartScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartLevel() {
        Loader.Load(restartScene);
	}

    public void MenuLevel() {
        Loader.Load(Loader.Scene.LevelMenu);
    }
}
