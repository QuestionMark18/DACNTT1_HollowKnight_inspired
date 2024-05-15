using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class BulletImpart : OverrideMonoBehaviour
{
    [SerializeField] protected BulletCtrl bulletCtrl;
    [SerializeField] protected BoxCollider2D boxCollider;
    [SerializeField] protected Rigidbody2D rb;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletCtrl();
        this.LoadCollider();
        this.LoadRigidbody();
    }

    protected virtual void LoadBulletCtrl()
    {
        if (this.bulletCtrl != null) return;
        this.bulletCtrl = transform.parent.GetComponent<BulletCtrl>();
        Debug.Log(transform.name + ": LoadBulletCtrl", gameObject);
    }

    protected virtual void LoadCollider()
    {
        if(this.boxCollider != null) return;
        this.boxCollider = GetComponent<BoxCollider2D>();
        this.boxCollider.isTrigger = true;
        this.boxCollider.size = new Vector2(0.2f, 0.1f);
        Debug.Log(transform.name + ": BoxCollider2D", gameObject);
    }

    protected virtual void LoadRigidbody()
    {
        if (this.rb != null) return;
        this.rb = GetComponent<Rigidbody2D>();
        this.rb.isKinematic = true;
        Debug.Log(transform.name + ": Rigidbody2D", gameObject);
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        Transform shooter = this.bulletCtrl.Shooter;
        if (other.transform.parent == shooter) return;
        this.bulletCtrl.BulletDamageSender.Send(other.transform);
    }
}
