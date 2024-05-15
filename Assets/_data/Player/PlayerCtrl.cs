using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : OverrideMonoBehaviour
{
    [SerializeField] protected PlayerMovementControl playerMovementControl;
    public PlayerMovementControl PlayerMovementControl => playerMovementControl;

    [SerializeField] protected PlayerInfo playerInfo;
    public PlayerInfo PlayerInfo => playerInfo;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerMovementControl();
        this.LoadPlayerInfo();
    }

    protected void LoadPlayerMovementControl()
    {
        if (this.playerMovementControl != null) return;
        this.playerMovementControl = GetComponent<PlayerMovementControl>();
        Debug.Log(transform.name + ": LoadPlayerMovementControl", gameObject);
    }

    protected void LoadPlayerInfo()
    {
        if (this.playerInfo != null) return;
        this.playerInfo = GetComponent<PlayerInfo>();
        Debug.Log(transform.name + ": LoadPlayerInfo", gameObject);
    }
}
