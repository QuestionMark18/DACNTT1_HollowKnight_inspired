using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : OverrideMonoBehaviour
{
    [SerializeField] protected EnemySpawner enemySpawner;
    public EnemySpawner EnemySpawner { get => enemySpawner; }

    [SerializeField] protected EnemySpawnPoint spawnPoints;
    public EnemySpawnPoint SpawnPoints { get => spawnPoints; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemySpawner();
        this.LoadSpawnPoints();
    }

    protected void LoadEnemySpawner()
    {
        if (enemySpawner != null) return;
        this.enemySpawner = GetComponent<EnemySpawner>();
        Debug.Log(transform.name + ": EnemySpawner", gameObject);
    }

    protected void LoadSpawnPoints()
    {
        if (this.spawnPoints != null) return;
        this.spawnPoints = Transform.FindObjectOfType<EnemySpawnPoint>();
        Debug.Log(transform.name + ": EnemySpawnPoint", gameObject);
    }
}
