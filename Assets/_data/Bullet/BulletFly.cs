using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : OverrideMonoBehaviour
{
    [SerializeField] private float speed = 20f;
    [SerializeField] private Vector3 direction = Vector3.right;

    private void Update()
    {
        Fly();
    }

    private void Fly()
    {
        transform.parent.Translate(this.direction * this.speed * Time.deltaTime);
        transform.parent.position = HandlePosition.Instance.HandleZByY(transform.parent.position);
    }
}
