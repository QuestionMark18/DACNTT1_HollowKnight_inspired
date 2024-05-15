using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovementControl : OverrideMonoBehaviour
{
    [SerializeField] Rigidbody2D player;
    [SerializeField] protected float runSpeed = 1.5f;
    [SerializeField] public float horizontal;
    [SerializeField] public float vertical;
    [SerializeField] protected float limitX = 19.5f;
    [SerializeField] protected float limitY = 19.5f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerRigidbody();
    }

    protected void LoadPlayerRigidbody()
    {
        if (this.player != null) return;
        this.player = GetComponent<Rigidbody2D>();
        Debug.Log(transform.name + ": LoadPlayerRigidbody", gameObject);
    }

    void Update()
    {
        this.horizontal = InputManager.Instance.GetHorizontal();
        this.vertical = InputManager.Instance.GetVertical();
    }

    private void FixedUpdate()
    {
        this.Move();
    }

    protected void Move()
    {
        this.movementLimit();
        if (this.horizontal != 0 & this.vertical != 0)
        {
            this.horizontal *= 0.707f;
            this.vertical *= 0.707f;
        }
        this.player.velocity = new Vector2(this.horizontal * this.runSpeed, this.vertical * this.runSpeed);
        transform.position = HandlePosition.Instance.HandleZByY(transform.position);
    }

    protected void movementLimit()
    {
        Vector3 playerPos = transform.position;
        if ((playerPos.x > this.limitX && this.horizontal > 0) || (playerPos.x < -this.limitX && this.horizontal < 0)) this.horizontal = 0f;
        if ((playerPos.y > this.limitY && this.vertical > 0) || (playerPos.y < -this.limitY && this.vertical < 0)) this.vertical = 0f;
    }
}
    