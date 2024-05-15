using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModelHandleWeapon : PlayerModelHandle
{
    [SerializeField] protected Transform weaponModel_0;
    [SerializeField] protected Transform weaponModel_1;
    [SerializeField] Quaternion rotation;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModelBody_0();
        this.LoadModelBody_1();
    }

    protected void LoadModelBody_0()
    {
        if (this.weaponModel_0 != null) return;
        this.weaponModel_0 = transform.parent.Find("Model_0");
    }

    protected void LoadModelBody_1()
    {
        if (this.weaponModel_1 != null) return;
        this.weaponModel_1 = transform.parent.Find("Model_1");
    }

    protected override void Handle()
    {
        this.rotation = transform.parent.rotation;
        if (this.rotation.z > 0.7f || this.rotation.z < -0.7f)
        {
            this.weaponModel_0.gameObject.SetActive(false);
            this.weaponModel_1.gameObject.SetActive(true);
        }
        else
        {
            this.weaponModel_0.gameObject.SetActive(true);
            this.weaponModel_1.gameObject.SetActive(false);
        }
    }
}
