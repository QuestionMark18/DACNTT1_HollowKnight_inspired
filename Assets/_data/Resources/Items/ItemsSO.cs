using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Items")]
public class ItemsSO : ScriptableObject
{
    public ItemID itemID;
    public string itemName;
}
