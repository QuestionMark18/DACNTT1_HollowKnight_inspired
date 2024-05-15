using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class MinionDamageReceiver : DamageReceiver
{
    [SerializeField] protected BoxCollider2D boxCollider;

    [SerializeField] protected MinionCtrl minionCtrl;
    public MinionCtrl MinionCtrl => minionCtrl;


    protected override void ResetValues()
    {
        base.ResetValues();
        this.maxHP = this.minionCtrl.MinionSO.maxHP;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMinionCtrl();
        this.LoadCollider();
    }

    protected virtual void LoadMinionCtrl()
    {
        if (this.minionCtrl != null) return;
        this.minionCtrl = transform.parent.GetComponent<MinionCtrl>();
        Debug.Log(transform.name + ": LoadMinionCtrl", gameObject);
    }

    protected virtual void LoadCollider()
    {
        if (this.boxCollider != null) return;
        this.boxCollider = GetComponent<BoxCollider2D>();
        this.boxCollider.isTrigger = true;
        this.boxCollider.size = new Vector2(0.5f, 0.8f);
        Debug.Log(transform.name + ": BoxCollider2D", gameObject);
    }

    protected override void OnDead()
    {
        this.OnDeadFX();
        this.Reborn();
        this.OnDeadDrop();

        this.minionCtrl.MinionDespawn.DespawnObject();
    }

    protected void OnDeadFX()
    {
        Transform fxOndead = FXSpawner.Instance.Spawn(GetFXName(), transform.parent.position, transform.parent.rotation);
        fxOndead.gameObject.SetActive(true);
    }

    protected void OnDeadDrop()
    {
        Vector3 position = transform.position;
        ItemDropSpawner.Instance.Drop(minionCtrl.MinionSO.dropItemList, position);
    }

    protected string GetFXName()
    {
        return transform.parent.name + "_Dead";
    }

    public override void Deduct(int deduct)
    {
        base.Deduct(deduct);
        this.MinionHit();
        Invoke(nameof(MinionHit), 0.1f);
    }

    protected void MinionHit()
    {
        Transform fxModel = this.minionCtrl.Model.Find("Minion_Hit");
        fxModel.gameObject.SetActive(!fxModel.gameObject.activeSelf);
    }
}
