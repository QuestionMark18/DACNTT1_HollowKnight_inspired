using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnPoints : OverrideMonoBehaviour
{
    [SerializeField] protected List<Transform> spawnPoints;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnPoint();
    }

    protected void LoadSpawnPoint()
    {
        if (this.spawnPoints.Count > 0) return;
        foreach (Transform spawnPoint in transform)
        {
            this.spawnPoints.Add(spawnPoint);
        }
        Debug.Log(transform.name + ": SpawnPoint", gameObject);
    }

    public Transform GetRandomSpawnPoint()
    {
        int randomSpawnPoint = Random.Range(0, this.spawnPoints.Count);
        return this.spawnPoints[randomSpawnPoint];
    }
}
