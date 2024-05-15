using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : OverrideMonoBehaviour
{
    private static PlayerInfo instance { get; set; }
    public PlayerInfo Instance => instance;

    [SerializeField] private float maxHP = 20f;
    public float MaxHP { get { return maxHP; } set { maxHP = value; } }

    [SerializeField] private int level = 1;
    public int Level { get { return level; } set { level = value; } }

    [SerializeField] private float currentExp = 0f;
    public float CurrentExp { get { return currentExp; } set { currentExp = value; } }

    [SerializeField] private float maxExp = 100f;
    public float MaxExp { get { return maxExp; } set { maxExp = value; } }

    protected override void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        this.CalculatePlayerLevel();
    }

    private void CalculatePlayerLevel()
    {
        if (this.currentExp < this.maxExp) return;
        this.level++;
        this.currentExp -= this.maxExp;
        this.maxExp *= 1.25f;
        this.LevelUp();
    }

    private void LevelUp()
    {
        // to do: code for level up
        //Time.timeScale = 0;
    }
}
