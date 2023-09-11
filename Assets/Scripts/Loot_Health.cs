using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot_Health : Loot
{
    [SerializeField] private int healValue;
    protected override void Trigger()
    {
        player.Heal(healValue);
        Destroy(gameObject);
    }
}
