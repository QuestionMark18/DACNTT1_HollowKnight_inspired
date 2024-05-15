using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]

public abstract class DamageReceiver : OverrideMonoBehaviour
{
    [SerializeField] protected float HP = 1;
    [SerializeField] protected float maxHP = 1;
    [SerializeField] protected bool isDead = false;

    protected override void Start()
    {
        base.Start();
        this.Reborn();
    }

    protected virtual void Reborn()
    {
        this.HP = this.maxHP;
        this.isDead = false;
    }

    public void Add(int add)
    {
        if (this.IsDead()) return;
        this.HP += add;
        if (this.HP > maxHP) this.HP = maxHP;
    }

    public virtual void Deduct(int deduct)
    {
        if (this.IsDead()) return;
        this.HP -= deduct;
        if (this.HP < 0) this.HP = 0;
        CheckIsDead();
    }

    protected virtual bool IsDead()
    {
        return this.HP <= 0;
    }

    protected void CheckIsDead()
    {
        if (!this.IsDead()) return;
        this.isDead = true;
        this.OnDead();
    }

    protected abstract void OnDead();
}
