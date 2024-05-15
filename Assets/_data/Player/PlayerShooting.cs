using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : OverrideMonoBehaviour
{
    [SerializeField] protected GameObject playerWeapon;
    [SerializeField] protected float firing;
    [SerializeField] protected float shootDelay = 0.2f;
    [SerializeField] protected float shootTimer = 0f;
    [SerializeField] protected const float recoil = 0.01f;

    private void Update()
    {
        this.GetFireBtn();
        this.Shooting();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerWeapon();
    }

    protected void LoadPlayerWeapon()
    {
        if (this.playerWeapon != null) return;
        this.playerWeapon = GameObject.Find("PlayerWeapon");
        Debug.Log(transform.name + ": LoadPlayerWeapon", gameObject);
    }

    protected void Shooting()
    {
        this.shootTimer += Time.deltaTime;
        if (!this.IsShooting()) return;
        if (this.shootTimer < this.shootDelay) return;
        this.shootTimer = 0f;

        Vector3 spawnPosition = playerWeapon.transform.position;
        Quaternion spawnRotation = playerWeapon.transform.rotation;
        spawnRotation.z += Random.Range(-recoil, recoil);
        Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.bullet_1, spawnPosition, spawnRotation);
        newBullet.gameObject.SetActive(true);

        BulletCtrl bulletCtrl = newBullet.GetComponent<BulletCtrl>();
        bulletCtrl.SetShooter(transform.parent);
    }

    private void GetFireBtn()
    {
        this.firing = InputManager.Instance.GetMouseDown();
    }

    private bool IsShooting()
    {
        return this.firing == 1f;
    }
}
