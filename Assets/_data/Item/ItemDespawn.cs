using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDespawn : Despawn
{
    public override void DespawnObject()
    {
        ItemDropSpawner.Instance.Respawn(transform.parent);
    }

    protected override bool CanDespawn()
    {
        return false;
    }
}
