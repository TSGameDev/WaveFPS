using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    public void Fire();
    public bool Reload();
    public void Inspect();
    public void SetAiming(bool _IsAiming);
    public void DestroyWeaponModel();
    public void ToggleWeaponActive(bool _IsActive);
    public IWeapon SpawnWeaponModel(Transform _Parent, Transform _WeaponAimTransfrom, Transform _WeaponAimOutTransform);
}
