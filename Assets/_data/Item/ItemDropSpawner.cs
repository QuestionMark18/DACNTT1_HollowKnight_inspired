using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropSpawner : Spawner
{
    private static ItemDropSpawner _instance;
    public static ItemDropSpawner Instance => _instance;

    protected override void Awake()
    {
        base.Awake();
        ItemDropSpawner._instance = this;
    }

    public void Drop(List<DropItem> dropItems, Vector3 position)
    {
        ItemID itemID = dropItems[0].itemsSO.itemID;
        position.y -= 0.5f;
        Transform newItemDrop = ItemDropSpawner.Instance.Spawn(itemID.ToString(), position, transform.rotation);
        newItemDrop.gameObject.SetActive(true);
    }
}
