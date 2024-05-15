using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner
{
    private static BulletSpawner instance;
    public static BulletSpawner Instance { get => instance; }

    public static string bullet_1 = "Bullet_0";
    public static string bullet_2 = "Bullet_1";
    public static string bullet_3 = "Bullet_2";

    protected override void Start()
    {
        base.Start();
        BulletSpawner.instance = this;
    }
}
