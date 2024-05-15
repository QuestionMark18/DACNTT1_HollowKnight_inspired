using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTargetPlayer : FollowTarget
{
    protected override void ResetValues()
    {
        base.ResetValues();
        this.speed = 5f;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayer();
    }

    protected void LoadPlayer()
    {
        if(this.target != null) return;
        this.target = GameObject.Find("Player");
        Debug.Log(transform.name + ": Player", gameObject);
    }
}
