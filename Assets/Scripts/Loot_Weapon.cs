using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot_Weapon : Loot
{
    [SerializeField] private Weapon weapon;
    protected override void Trigger()
    {
        weapon.ActivateItem();
        Destroy(gameObject);
    }
}
