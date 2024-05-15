using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Minions", menuName = "ScriptableObjects/Minion")]
public class MinionSO : ScriptableObject
{
    public string minionName = "Minion";
    public int maxHP = 1;
    public int damage = 1;
    public float speed = 1;
    public List<DropItem> dropItemList;
}
