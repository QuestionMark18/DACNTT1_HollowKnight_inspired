using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlePosition : OverrideMonoBehaviour
{
    private static HandlePosition _instance;
    public static HandlePosition Instance => _instance;

    protected override void Awake()
    {
        base.Awake();
        HandlePosition._instance = this;
    }

    public Vector3 HandleZByY(Vector3 position)
    {
        return new Vector3(position.x, position.y, position.y);
    }
}
