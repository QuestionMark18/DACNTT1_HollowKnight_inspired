using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTargetCamera : FollowTarget
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
        if (this.target != null) return;
        this.target = GameObject.Find("CameraHolder");
        Debug.Log(transform.name + ": CameraHolder", gameObject);
    }
}
