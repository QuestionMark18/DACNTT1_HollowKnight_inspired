using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]

public class ItemPickupable : OverrideMonoBehaviour
{
    [SerializeField] protected ItemCtrl itemCtrl;
    [SerializeField] protected CircleCollider2D circleCollider;
    [SerializeField] private GameObject player;
    [SerializeField] private PlayerCtrl playerCtrl;

    [SerializeField] private float pickupSpeed = 10f;
    [SerializeField] private bool isPickup = false;

    protected override void ResetValues()
    {
        base.ResetValues();
        isPickup = false;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
        this.LoadItemCtrl();
        this.LoadPlayer();
        this.LoadPlayerCtrl();
    }

    protected void LoadCollider()
    {
        if (this.circleCollider != null) return;
        this.circleCollider = GetComponent<CircleCollider2D>();
        this.circleCollider.isTrigger = true;
        this.circleCollider.radius = 0.1f;
        Debug.Log(transform.name + ": LoadCollider", gameObject);
    }

    protected void LoadItemCtrl()
    {
        if(this.itemCtrl != null) return;
        this.itemCtrl = transform.parent.GetComponent<ItemCtrl>();
        Debug.Log(transform.name + ": LoadItemCtrl", gameObject);
    }

    protected void LoadPlayer()
    {
        if (this.player != null) return;
        this.player = GameObject.Find("Player");
        Debug.Log(transform.name + ": LoadPlayer", gameObject);
    }

    protected void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = player.GetComponent<PlayerCtrl>();
        Debug.Log(transform.name + ": LoadPlayerCtrl", gameObject);
    }

    private void Update()
    {
        this.PickingUp();
    }

    public void PickUp()
    {
        this.isPickup = true;
    }

    private void PickingUp()
    {
        if (this.isPickup) transform.parent.position = Vector3.MoveTowards(transform.parent.position, player.transform.position, pickupSpeed * Time.deltaTime);
    }

    public void Picked()
    {
        switch (this.transform.parent.name)
        {
            case "GreenXP":
                Debug.Log("Picked GreenXP");
                this.playerCtrl.PlayerInfo.CurrentExp += 3f;
                break;
            case "BlueXP":
                Debug.Log("Picked BlueXP");
                this.playerCtrl.PlayerInfo.CurrentExp += 5f;
                break;
            case "GoldXP":
                Debug.Log("Picked GoldXP");
                this.playerCtrl.PlayerInfo.CurrentExp += 10f;
                break;
            default:
                Debug.Log("Nothing picked");
                break;
        }

        this.ResetValues();
        this.itemCtrl.ItemDespawn.DespawnObject();
        //Debug.Log("Picked: " + this.transform.name);
    }
}
