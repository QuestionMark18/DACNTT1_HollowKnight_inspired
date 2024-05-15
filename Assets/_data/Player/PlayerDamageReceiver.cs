using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class PlayerDamageReceiver : DamageReceiver
{
    [SerializeField] protected BoxCollider2D boxCollider;
    [SerializeField] protected PlayerCtrl playerCtrl;

    protected override void ResetValues()
    {
        base.ResetValues();
        this.maxHP = this.playerCtrl.PlayerInfo.MaxHP;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerCtrl();
        this.LoadCollider();
    }

    protected virtual void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = transform.parent.GetComponent<PlayerCtrl>();
        Debug.Log(transform.name + ": LoadPlayerCtrl", gameObject);
    }

    protected virtual void LoadCollider()
    {
        if (this.boxCollider != null) return;
        this.boxCollider = GetComponent<BoxCollider2D>();
        this.boxCollider.isTrigger = true;
        this.boxCollider.size = new Vector2(0.5f, 1f);
        Debug.Log(transform.name + ": BoxCollider2D", gameObject);
    }

    protected override void OnDead()
    {
        this.FXOnDead();
        this.GetPlayer().SetActive(false);
        this.GetEnemySpawner().SetActive(false);
    }

    protected void FXOnDead()
    {
        Transform fxOndead = FXSpawner.Instance.Spawn(GetFXName(), transform.parent.position, transform.parent.rotation);
        fxOndead.gameObject.SetActive(true);
    }

    protected string GetFXName()
    {
        return transform.parent.name + "_Dead";
    }

    protected GameObject GetPlayer()
    {
        return GameObject.Find("Player");
    }

    protected GameObject GetEnemySpawner()
    {
        return GameObject.Find("EnemySpawner");
    }
}
