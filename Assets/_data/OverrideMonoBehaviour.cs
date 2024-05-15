using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverrideMonoBehaviour : MonoBehaviour
{
    private void Reset()
    {
        this.LoadComponents();
        this.ResetValues();
    }

    protected virtual void OnEnable()
    {
        // for override 
    }

    protected virtual void Awake()
    {
        // for override 
    }

    protected virtual void Start()
    {
        // for override 
    }

    protected virtual void LoadComponents()
    {
        // for override
    }

    protected virtual void ResetValues()
    {
        // for override
    }
}
