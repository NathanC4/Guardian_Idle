using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public CombatHandler ch;
    public HealthBar healthBar;

    public double Attack { get; set; }
    public double BaseAttackDelay { get; set; }
    public double AttackSpeed { get; set; }
    public double Armor { get; set; }
    public double Evasion { get; set; }
    public double Accuracy { get; set; }
    public double CritChance { get; set; }
    public double CritMulti { get; set; }
    public int Health { get; set; }
    public int MaxHealth { get; set; }

    public Enemy (CombatHandler ch, HealthBar healthBar)
    {
        this.ch = ch;
        this.healthBar = healthBar;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;

        if (Health <= 0)
            Health = MaxHealth;

        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        healthBar.SetValue((float)Health / MaxHealth);
    }

    // increase AS by .05
    public void IncreaseAS()
    {
        AttackSpeed += 0.05;
        ch.UpdateEnemy();
    }
}
