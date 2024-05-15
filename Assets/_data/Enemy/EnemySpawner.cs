using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    private static EnemySpawner instance;
    public static EnemySpawner Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        EnemySpawner.instance = this;
    }

    public override Transform RandomPrefab()
    {
        int rand = Random.Range(0, 100);
        if (rand < 30) return this.prefabs[0];
        else if (rand < 55) return this.prefabs[1];
        else if (rand < 75) return this.prefabs[2];
        else if (rand < 90) return this.prefabs[3];
        else return this.prefabs[4];
    }
}