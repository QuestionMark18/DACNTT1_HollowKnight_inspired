using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByTime : Despawn
{
    [SerializeField] protected float despawnDelay = 1f;
    [SerializeField] protected float despawnTimer = 0f;

    protected override void OnEnable()
    {
        base.OnEnable();
        this.ResetTimer();
    }

    protected void ResetTimer()
    {
        this.despawnTimer = 0f;
    }

    protected override bool CanDespawn()
    {
        this.despawnTimer += Time.deltaTime;
        if (this.despawnTimer > this.despawnDelay) return true;
        return false;
    }
}
