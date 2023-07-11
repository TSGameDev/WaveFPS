using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour, IWeapon
{
    [Header("Generic Data")]
    [SerializeField] WeaponData weaponData;
    [SerializeField] Transform weaponFirePoint;
    [SerializeField] AudioClip weaponFireSound;
    [SerializeField] ParticleSystem weaponHitEffect;

    [Header("Aiming Data")]
    [SerializeField] private Transform weaponHolderTransform;
    [SerializeField] private Transform aimInTransform;
    [SerializeField] private Transform weaponReturnTransform;
    [SerializeField] private Transform sightTransform;
    [SerializeField] private float sightOffset;
    [SerializeField] private float aimingInTime;

    private Vector3 weaponAimInPos;
    private Vector3 weaponAimInPosVelocity;

    //Required Components
    private AudioSource _AudioSource;
    private AnimatorOverrideController _Animator;

    //Shooting Data
    private int _MaxMagAmmo;
    private int _CurrentMagAmmo;
    private int _MaxStockpileAmmo;
    private int _CurrentStockpileAmmo;
    private float _TimeBetweenShots;
    private bool _CanShoot;

    private float PARTICLE_SPAWN_NORMAL_OFFSET = 0.025f;

    private void Awake()
    {
        _AudioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _Animator = weaponData.GetAnimOverride();
        _MaxMagAmmo = weaponData.GetMagAmount();
        _MaxStockpileAmmo = weaponData.GetAmmoAmount();
        _CurrentMagAmmo = _MaxMagAmmo;
        _CurrentStockpileAmmo = _MaxStockpileAmmo;

        _TimeBetweenShots = 0;
        _CanShoot = true;
    }

    private void Update()
    {
        ShotCountDownTimer();
    }

    private void ShotCountDownTimer()
    {
        if (_TimeBetweenShots > 0f)
        {
            _TimeBetweenShots -= 1f * Time.deltaTime;
            _CanShoot = false;
        }
        else if (_TimeBetweenShots <= 0)
        {
            _CanShoot = true;
            _TimeBetweenShots = 0f;
        }
    }

    public void Fire()
    {
        if (_CanShoot && _CurrentMagAmmo > 0)
        {
            _CanShoot = false;
            _TimeBetweenShots = weaponData.GetShotDelay();
            _AudioSource.PlayOneShot(weaponFireSound);
            _CurrentMagAmmo--;

            if (Physics.Raycast(weaponFirePoint.position, weaponFirePoint.forward, out RaycastHit hit, weaponData.GetWeaponRange()))
            {
                Debug.DrawLine(weaponFirePoint.position, hit.point, Color.red, 60);
                ParticleSystem p = Instantiate(weaponHitEffect, hit.point + (hit.normal * PARTICLE_SPAWN_NORMAL_OFFSET), Quaternion.identity);
                p.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
            }
        }
        else
        {
            Reload();
        }
    }

    public void Reload()
    {
        //Trigger Reload Animation & Stop Firing
    }

    public void ReloadFunc()
    {
        //Second relod function called upon reaching animation trigger
    }

    public void SetAiming(bool _IsAiming)
    {
        Vector3 _TargetPos;

        if (_IsAiming)
            _TargetPos = aimInTransform.position + (transform.position - sightTransform.position) + (aimInTransform.forward * sightOffset);
        else
            _TargetPos = weaponReturnTransform.position;

        weaponAimInPos = weaponHolderTransform.position;
        weaponAimInPos = Vector3.SmoothDamp(weaponAimInPos, _TargetPos, ref weaponAimInPosVelocity, aimingInTime);
        weaponHolderTransform.position = weaponAimInPos;
    }
}
