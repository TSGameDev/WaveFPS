using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Weapon;

public interface IWeapon
{
    public void Fire();
    public bool Reload();
    public void Inspect();
    public void SetAiming(bool _IsAiming);
    public void DestroyWeaponModel();
    public void HolsterWeapon();
    public void SetHolsterTrigger(AnimTrigger _AnimTriggerFunction);
    public void ActiveWeapon(bool _IsActive);
    public IWeapon SpawnWeaponModel(Transform _Parent, Transform _WeaponAimTransfrom, Transform _WeaponAimOutTransform);
}
