using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMenuScript : MonoBehaviour
{
    public void OnClickLevel1Button () {
        Loader.Load(Loader.Scene.Level1);
    }
}
