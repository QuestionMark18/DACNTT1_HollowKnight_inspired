using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXSpawner : Spawner
{
    private static FXSpawner instance;
    public static FXSpawner Instance { get => instance; }

    public static string minion_0_Dead = "Minion_0_Dead";
    public static string minion_1_Dead = "Minion_1_Dead";
    public static string minion_2_Dead = "Minion_2_Dead";

    protected override void Awake()
    {
        base.Awake();
        FXSpawner.instance = this;
    }
}
