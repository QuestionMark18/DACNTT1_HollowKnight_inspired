using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModelHandleBody : PlayerModelHandle
{
    [SerializeField] protected float playerHorizontal;
    [SerializeField] protected PlayerCtrl playerCtrl;
    [SerializeField] protected Transform modelBody;
    public PlayerCtrl PlayerCtrl => playerCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerCtrl();
        this.LoadModelBody();
    }

    protected void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = GameObject.Find("Player").transform.GetComponent<PlayerCtrl>();
        Debug.Log(transform.name + ": LoadPlayerCtrl", gameObject);
    }

    protected void LoadModelBody()
    {
        if (this.modelBody != null) return;
        this.modelBody = transform.parent.Find("Model");
    }

    protected override void Handle()
    {
        this.playerHorizontal = this.playerCtrl.PlayerMovementControl.horizontal;
        if (this.playerHorizontal > 0) modelBody.rotation = Quaternion.Euler(modelBody.rotation.x, 0f, modelBody.rotation.z);
        if (this.playerHorizontal < 0) modelBody.rotation = Quaternion.Euler(modelBody.rotation.x, 180f, modelBody.rotation.z);
    }
}