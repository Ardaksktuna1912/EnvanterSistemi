using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Object", menuName = "Scriptableobejct/ObjectItem")]
public class ScıObject : ScriptableObject
{
    public string ItemName;
    public string ItemDesc;
    public bool StackItem;
    public Sprite itemIcon;
    public GameObject itemprefab;

}
