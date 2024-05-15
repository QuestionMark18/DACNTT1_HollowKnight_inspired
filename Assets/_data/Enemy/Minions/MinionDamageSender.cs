using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionDamageSender : DamageSender
{

    [SerializeField] protected MinionCtrl minionCtrl;
    public MinionCtrl MinionCtrl { get => minionCtrl; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMinionCtrl();
    }

    protected virtual void LoadMinionCtrl()
    {
        if (this.minionCtrl != null) return;
        this.minionCtrl = transform.parent.GetComponent<MinionCtrl>();
        Debug.Log(transform.name + ": LoadBulletCtrl", gameObject);
    }

    protected override void ResetValues()
    {
        base.ResetValues();
        this.damage = this.minionCtrl.MinionSO.damage;
    }
}
