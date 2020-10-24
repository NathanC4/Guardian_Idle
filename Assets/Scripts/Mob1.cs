using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob1 : Enemy
{
    public Mob1 (CombatHandler ch, HealthBar healthBar) : base (ch, healthBar)
    {

    }

    public void Spawn()
    {
        Attack = 10;
        BaseAttackDelay = 1.0;
        AttackSpeed = 1.0;
        Armor = 10.0;
        Evasion = 10.0;
        Accuracy = 10.0;
        CritChance = 0.05;
        CritMulti = 1.5;

        MaxHealth = 100;
        Health = MaxHealth;
        UpdateHealthBar();
    }
}

