using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionDespawn : Despawn
{
    public override void DespawnObject()
    {
        EnemySpawner.Instance.Respawn(transform.parent);
    }

    protected override bool CanDespawn()
    {
        return false;
    }
}
