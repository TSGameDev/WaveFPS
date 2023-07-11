using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Data", menuName = "WeaponSystem/New Weapon Data")]
public class WeaponData : ScriptableObject
{
    [SerializeField] string _WeaponName;
    [SerializeField] int _MagAmount;
    [SerializeField] int _AmmoAmount;
    [SerializeField] float _WeaponRange;
    [SerializeField] float _TimeBetweenShots;
    [SerializeField] float _ShotDamage;

    [SerializeField] bool _IsWeaponAutomatic;

    [SerializeField] AnimatorOverrideController _WeaponAimOverride;

    public string GetWeaponName() => _WeaponName;
    public int GetMagAmount() => _MagAmount;
    public int GetAmmoAmount() => _AmmoAmount;
    public float GetWeaponRange() => _WeaponRange;
    public bool GetWeaponAutomatic() => _IsWeaponAutomatic;
    public float GetShotDelay() => _TimeBetweenShots;
    public float GetShotDamage() => _ShotDamage;
    public AnimatorOverrideController GetAnimOverride() => _WeaponAimOverride;
}
