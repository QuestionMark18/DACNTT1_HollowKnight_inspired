using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByDistance : Despawn
{
    [SerializeField] protected float limitDistance = 50f;
    [SerializeField] protected float distance = 0f;
    [SerializeField] protected Camera mainCamera;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCamera();
    }

    protected void LoadCamera()
    {
        if (mainCamera != null) return;
        this.mainCamera = GameObject.FindAnyObjectByType<Camera>();
        Debug.Log(transform.name + ": Camera", gameObject);
    }

    protected override bool CanDespawn()
    {
        this.distance = Vector3.Distance(transform.position, this.mainCamera.transform.position);
        if (distance > limitDistance) return true;
        return false;
    }
}
