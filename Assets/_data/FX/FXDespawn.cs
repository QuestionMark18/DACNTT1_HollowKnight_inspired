using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXDespawn : DespawnByTime
{
    protected override void ResetValues()
    {
        base.ResetValues();
        this.despawnDelay = 5f;
    }

    public override void DespawnObject()
    {
        FXSpawner.Instance.Respawn(transform.parent);
    }
}
