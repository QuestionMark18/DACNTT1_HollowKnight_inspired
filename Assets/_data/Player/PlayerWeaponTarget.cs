using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerWeaponTarget : OverrideMonoBehaviour
{
    protected Vector3 playerWeaponTarget;

    private void Update()
    {
        this.GetTargetPosition();
        this.LookAtTarget();
    }

    protected virtual void GetTargetPosition()
    {
        this.playerWeaponTarget = InputManager.Instance.GetMousePosition(); ;
        this.playerWeaponTarget.z = 0;
    }

    private void LookAtTarget()
    {
        Vector3 diff = this.playerWeaponTarget - transform.parent.position;
        diff.Normalize();
        float rotate_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(0f, 0f, rotate_z);
    }
}
