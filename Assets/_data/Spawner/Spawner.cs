using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : OverrideMonoBehaviour
{
    [SerializeField] protected Transform pool;
    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected List<Transform> poolObjects;

    protected override void LoadComponents()
    {
        this.LoadPrefabs();
        this.LoadHolderObject();
    }

    protected virtual void LoadHolderObject()
    {
        if (this.pool != null) return;
        this.pool = transform.Find("Holder");
        Debug.Log(transform.name + ": LoadHolderObject", gameObject);
    }

    private void LoadPrefabs()
    {
        if (this.prefabs.Count > 0) return;

        Transform prefabs = transform.Find("Prefabs");
        foreach(Transform prefab in prefabs)
        {
            this.prefabs.Add(prefab);
        }
        HidePrefabs();

        Debug.Log(transform.name + ": LoadPrefabs", gameObject);
    }

    protected void HidePrefabs()
    {
        foreach(Transform prefabs in this.prefabs)
        {
            prefabs.gameObject.SetActive(false);
        }
    }

    public virtual Transform Spawn(string prefabName ,Vector3 spawnPosition, Quaternion spawnRotation)
    {
        Transform prefab = GetPrefabByName(prefabName);
        if (prefab == null)
        {
            Debug.LogWarning("Prefabs not found: " + prefabName);
            return null;
        }
        return this.Spawn(prefab, spawnPosition, spawnRotation);
    }

    public virtual Transform Spawn(Transform prefab, Vector3 spawnPosition, Quaternion spawnRotation)
    {
        Transform newPrefab = GetObjectFromPool(prefab);
        newPrefab.SetPositionAndRotation(spawnPosition, spawnRotation);
        newPrefab.parent = this.pool;
        return newPrefab;
    }

    protected Transform GetPrefabByName(string prefabName)
    {
        foreach(Transform prefab in this.prefabs)
        {
            if(prefab.name == prefabName) return prefab;
        }
        Debug.Log("Prefab not found: " + prefabName);
        return null;
    }

    protected Transform GetObjectFromPool(Transform prefab)
    {
        foreach (Transform poolObject in this.poolObjects)
        {
            if (poolObject.name == prefab.name)
            {
                poolObjects.Remove(poolObject);
                return poolObject;
            }
        }

        Transform newPrefab = Instantiate(prefab);
        newPrefab.name = prefab.name;
        return newPrefab;
    }

    public virtual void Respawn(Transform obj)
    {
        this.poolObjects.Add(obj);
        obj.gameObject.SetActive(false);
    }

    public virtual Transform RandomPrefab()
    {
        int randomPrefab = Random.Range(0, this.prefabs.Count);
        return this.prefabs[randomPrefab];
    }
}
