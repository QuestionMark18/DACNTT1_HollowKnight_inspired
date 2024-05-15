using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MinionFollowPlayer : OverrideMonoBehaviour
{
    [SerializeField] public float speed = 1f;
    [SerializeField] public GameObject player;
    [SerializeField] protected MinionCtrl minionCtrl;

    protected override void ResetValues()
    {
        base.ResetValues();
        this.speed = this.minionCtrl.MinionSO.speed;
    }

    protected override void Start()
    {
        base.Start();
        transform.Rotate(180, 0, 0);
    }

    protected void FixedUpdate()
    {
        this.FollowPlayer();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayer();
        this.LoadMinionCtrl();
    }

    protected void LoadPlayer()
    {
        if (this.player != null) return;
        this.player = GameObject.Find("Player");
        Debug.Log(transform.name + ": Player", gameObject);
    }

    protected void LoadMinionCtrl()
    {
        if (this.minionCtrl != null) return;
        this.minionCtrl = transform.parent.GetComponent<MinionCtrl>();
        Debug.Log(transform.name + ": LoadMinionCtrl", gameObject);
    }

    protected void FollowPlayer()
    {
        this.ModelHandle();

        transform.parent.position = Vector3.MoveTowards(transform.parent.position, player.transform.position, speed * Time.deltaTime);
        transform.parent.position = HandlePosition.Instance.HandleZByY(transform.parent.position);
    }

    protected void ModelHandle()
    {
        if (this.player.transform.position.x < this.minionCtrl.Model.position.x) this.minionCtrl.Model.rotation = Quaternion.Euler(0f, 180f, 0f);
        else this.minionCtrl.Model.rotation = Quaternion.Euler(0f, 0f, 0f);
    }
}
