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

public class Inventory : ScriptableObject
{
    public Currency playerCurrency;

    public IWeapon primaryWeapon;
    public IWeapon secondaryWeapon;
}
