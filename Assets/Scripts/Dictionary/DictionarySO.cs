using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dictionary", menuName = "ScriptableObjects/DictionarySO")]
public class DictionarySO : ScriptableObject
{
    [Header("Elements")]
    public string category;
    public string[] word;
}
