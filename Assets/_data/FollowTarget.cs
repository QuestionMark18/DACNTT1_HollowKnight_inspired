using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : OverrideMonoBehaviour
{
    [SerializeField] protected GameObject target;
    [SerializeField] protected float speed = 1f;

    protected void FixedUpdate()
    {
        this.Follow();
    }

    protected void Follow()
    {
        if (target == null) return;
        transform.position = Vector3.Lerp(transform.position, this.target.transform.position, this.speed * Time.deltaTime);
    }
}
