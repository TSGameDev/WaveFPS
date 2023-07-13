using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour, IInteractable
{
    [SerializeField] private Weapon weaponToPickup;
    [SerializeField] private bool isPrimaryWeapon;

    public void Interact(Inventory _PlayerInvetory)
    {
        if(isPrimaryWeapon)
            _PlayerInvetory.SetPrimaryWeapon(weaponToPickup);
        else
            _PlayerInvetory.SetSecondaryWeapon(weaponToPickup);
    }
}
