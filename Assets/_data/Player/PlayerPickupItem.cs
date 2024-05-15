using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]

public class PlayerPickupItem : OverrideMonoBehaviour
{
    [SerializeField] protected CircleCollider2D circleCollider;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
    }

    protected virtual void LoadCollider()
    {
        if (this.circleCollider != null) return;
        this.circleCollider = GetComponent<CircleCollider2D>();
        this.circleCollider.isTrigger = true;
        this.circleCollider.radius = 1f;
        Debug.Log(transform.name + ": BoxCollider2D", gameObject);
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        ItemPickupable itemPickupable = other.GetComponent<ItemPickupable>();
        if (itemPickupable == null) return;
        itemPickupable.PickUp();
        //Debug.Log("Looted: " + itemPickupable.transform.parent.name);
    }
}
