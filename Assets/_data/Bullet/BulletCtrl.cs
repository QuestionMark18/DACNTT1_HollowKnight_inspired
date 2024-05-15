using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : OverrideMonoBehaviour
{
    [SerializeField] protected BulletDamageSender bulletDamageSender;
    public BulletDamageSender BulletDamageSender => bulletDamageSender;

    [SerializeField] protected Transform shooter;
    public Transform Shooter => shooter;

    [SerializeField] protected BulletDespawn bulletDespawn;
    public BulletDespawn BulletDespawn { get => bulletDespawn; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDamageSender();
        this.LoadBulletDespawn();
    }

    protected virtual void LoadDamageSender()
    {
        if (this.bulletDamageSender != null) return;
        this.bulletDamageSender = transform.GetComponentInChildren<BulletDamageSender>();
        Debug.Log(transform.name + ": LoadDamageSender", gameObject);
    }

    protected virtual void LoadBulletDespawn()
    {
        if (this.bulletDespawn != null) return;
        this.bulletDespawn = transform.GetComponentInChildren<BulletDespawn>();
        Debug.Log(transform.name + ": LoadDamageSender", gameObject);
    }

    public void SetShooter(Transform shooter)
    {
        this.shooter = shooter;
    }
}
