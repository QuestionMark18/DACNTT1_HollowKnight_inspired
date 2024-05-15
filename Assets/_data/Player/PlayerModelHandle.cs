using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class PlayerModelHandle : OverrideMonoBehaviour
{
    protected void Update()
    {
        this.Handle();
    }

    protected abstract void Handle();
}
