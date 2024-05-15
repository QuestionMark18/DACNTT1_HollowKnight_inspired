using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeOptions", menuName = "ScriptableObjects/UpgradeOptions")]
public class UpgradeOptionsSO : ScriptableObject
{
    public UpgradeOptionID optionID;
    public string optionName;
}
