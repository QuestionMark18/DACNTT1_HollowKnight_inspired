using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionCtrl : OverrideMonoBehaviour
{
    [SerializeField] protected MinionDespawn minionDespawn;
    public MinionDespawn MinionDespawn => minionDespawn;

    [SerializeField] protected MinionDamageSender minionDamageSender;
    public MinionDamageSender MinionDamageSender => minionDamageSender;

    [SerializeField] protected Transform model;
    public Transform Model => model;

    [SerializeField] protected MinionSO minionSO;
    public MinionSO MinionSO => minionSO;

    [SerializeField] protected Transform player;
    public Transform Player => player;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMinionDespawn();
        this.LoadMinionDamageSender();
        this.LoadMinionSO();
        this.LoadModel();
        this.LoadPlayer();
    }

    protected virtual void LoadMinionDespawn()
    {
        if (this.minionDespawn != null) return;
        this.minionDespawn = transform.GetComponentInChildren<MinionDespawn>();
        Debug.Log(transform.name + ": LoadMinionDamageReceiver", gameObject);
    }

    protected virtual void LoadMinionDamageSender()
    {
        if (this.minionDamageSender != null) return;
        this.minionDamageSender = transform.GetComponentInChildren<MinionDamageSender>();
        Debug.Log(transform.name + ": LoadMinionDamageSender", gameObject);
    }

    protected void LoadMinionSO()
    {
        if (this.minionSO != null) return;
        string resourcePath = "Enemy/Minions/" + transform.name;
        this.minionSO = Resources.Load<MinionSO>(resourcePath);
        Debug.Log(transform.name + ": LoadMinionSO", gameObject);
    }

    protected void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.Log(transform.name + ": LoadModel", gameObject);
    }

    public void LoadPlayer()
    {
        if (this.player != null) return;
        this.player = GameObject.Find("Player").transform;
        Debug.Log(transform.name + ": LoadPlayer", gameObject);
    }
}
