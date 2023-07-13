using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Currency
{
    public int bossCoins;
    public int coins;

    public Currency(int _BossCoins = 0, int _Coins = 0)
    {
        bossCoins = _BossCoins;
        coins = _Coins;
    }
}

public class Inventory : MonoBehaviour
{
    //Remove this and Start when weapon pick up is implimented
    [SerializeField] private Weapon directSetWeaponDebug;

    [SerializeField] private Transform weaponParent;
    [SerializeField] private Transform weaponAimInTransform;
    [SerializeField] private Transform weaponAimOutTransform;

    private void Start()
    {
        primaryWeapon = directSetWeaponDebug;
    }

    private Currency playerCurrency;
    private IWeapon primaryWeapon;
    private IWeapon secondaryWeapon;
    private IWeapon currentWeapon;

    public IWeapon GetPrimaryWeapon() => primaryWeapon;
    public IWeapon GetSecondaryWeapon() => secondaryWeapon;
    public IWeapon GetCurrentWeapon() => currentWeapon;

    public void SetPrimaryWeapon(IWeapon _NewWeapon)
    {
        primaryWeapon?.DestroyWeaponModel();
        primaryWeapon = _NewWeapon;
        primaryWeapon?.SpawnWeaponModel(weaponParent, weaponAimInTransform, weaponAimOutTransform);
    }

    public void SetSecondaryWeapon(IWeapon _NewWeapon)
    {
        secondaryWeapon?.DestroyWeaponModel();
        secondaryWeapon = _NewWeapon;
        secondaryWeapon?.SpawnWeaponModel(weaponParent, weaponAimInTransform, weaponAimOutTransform);
    }

    public void SetCurrentWeapon(IWeapon _NewWeapon) => currentWeapon = _NewWeapon;

    public Currency GetPlayerCurrency() => playerCurrency;
    public void AddCoins(int _AmountToAdd) => playerCurrency.coins += _AmountToAdd;
    public void SubtractCoins(int _AmountToSubtract) => playerCurrency.coins += _AmountToSubtract;
    public void AddBossCoins(int _AmountToAdd) => playerCurrency.bossCoins += _AmountToAdd;
    public void SubtractBossCoins(int _AmountToSubtract) => playerCurrency.bossCoins += _AmountToSubtract;
}
