using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UpgradeOptions : OverrideMonoBehaviour
{
    private string optionName = "";

    [SerializeField] private UpgradeOptionsSO upgradeOptionsSO;
    public UpgradeOptionsSO UpgradeOptionsSO => upgradeOptionsSO;

    public abstract void Upgrade();

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUpgradeOptionsSO();
        this.LoadUpgradeOptionInfo();
    }

    private void LoadUpgradeOptionsSO()
    {
        if (this.upgradeOptionsSO != null) return;
        string resourcePath = "UpgradeOptions/" + transform.name;
        this.upgradeOptionsSO = Resources.Load<UpgradeOptionsSO>(resourcePath);
        Debug.Log(transform.name + ": LoadUpgradeOptionsSO", gameObject);
    }

    private void LoadUpgradeOptionInfo()
    {
        if (this.upgradeOptionsSO == null) return;
        this.optionName = upgradeOptionsSO.optionName;
        Debug.Log(transform.name + ": LoadUpgradeOptionInfo", gameObject);
    }
}
