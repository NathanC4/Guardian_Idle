using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public CombatHandler ch;
    public HealthBar healthBar;

    public int health;
    public int maxHealth = 100;

    public double Attack { get; set; }
    public double BaseAttackDelay { get; set; }
    public double AttackSpeed { get; set; }
    public double Armor { get; set; }
    public double Evasion { get; set; }
    public double Accuracy { get; set; }
    public double CritChance { get; set; }
    public double CritMulti { get; set; }

    void Awake()
    {
        Attack = 10;
        BaseAttackDelay = 1.0;
        AttackSpeed = 1.0;
        Armor = 10.0;
        Evasion = 10.0;
        Accuracy = 10.0;
        CritChance = 0.05;
        CritMulti = 1.5;

        health = maxHealth;
        UpdateHealthBar();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
            health = maxHealth;

        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        healthBar.SetValue((float)health / maxHealth);
    }

    // increase AS by .05
    public void IncreaseAS()
    {
        AttackSpeed += 0.05;
        ch.UpdateEnemy();
    }
}
