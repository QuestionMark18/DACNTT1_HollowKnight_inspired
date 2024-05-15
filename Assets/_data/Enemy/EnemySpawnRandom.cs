using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnRandom : OverrideMonoBehaviour
{
    [SerializeField] protected EnemyCtrl enemyCtrl;
    [SerializeField] protected float spawnDelay = 1f;
    [SerializeField] protected float spawnTimer = 0f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMinionsCtrl();
    }

    protected void LoadMinionsCtrl()
    {
        if (enemyCtrl != null) return;
        this.enemyCtrl = GetComponent<EnemyCtrl>();
        Debug.Log(transform.name + ": EnemyCtrl", gameObject);
    }

    private void FixedUpdate()
    {
        this.MinionSpawning();
        this.spawnDelay -= 0.00003f;
        float time = 0F;
        time += Time.fixedDeltaTime;
    }

    protected void MinionSpawning()
    {
        this.spawnTimer += Time.fixedDeltaTime;
        if (this.spawnTimer < this.spawnDelay) return;
        this.spawnTimer = 0f;

        Transform spawnPoint = this.enemyCtrl.SpawnPoints.GetRandomSpawnPoint();
        Vector3 spawnPositin = spawnPoint.position;
        Quaternion spawnRotation = transform.rotation;

        Transform prefab = this.enemyCtrl.EnemySpawner.RandomPrefab();
        Transform newMinion = this.enemyCtrl.EnemySpawner.Spawn(prefab, spawnPositin, spawnRotation);
        newMinion.gameObject.SetActive(true);
    }
}
