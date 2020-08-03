using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CombatHandler ch;
    public HealthBar healthBar;

    public static Player instance;

    public int health;
    public int maxHealth = 100;

    public double[] stats = new double[Enum.GetNames(typeof(Stat)).Length];
    public double[,] statMods = new double[Enum.GetNames(typeof(Stat)).Length, Enum.GetNames(typeof(ModifierType)).Length];
    public double Attack { get; set; }
    public double BaseAttackDelay { get; set; }
    public double AttackDelay { get; set; }
    public double AttackSpeed { get; set; }
    public double Armor { get; set; }
    public double Evasion { get; set; }
    public double Accuracy { get; set; }
    public double CritChance { get; set; }
    public double CritMulti { get; set; }




    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Player!");
        }
        instance = this;

        
        BaseAttackDelay = 0.5;
        

        health = maxHealth;
        UpdateHealthBar();
    }

    public void ResetStats()
    {
        // Set multipliers to 0
        for (int i = 0; i < statMods.GetLength(0); i++)
        {
            statMods[i, (int) ModifierType.Percent] = 0;
            statMods[i, (int) ModifierType.Multiply] = 1;
        }

        // Set base values
        statMods[(int)Stat.Accuracy, (int)ModifierType.Add] = 0;
        statMods[(int)Stat.Attack, (int)ModifierType.Add] = 10;
        statMods[(int)Stat.AttackSpeed, (int)ModifierType.Add] = 1;
        statMods[(int)Stat.Armor, (int)ModifierType.Add] = 50;
        statMods[(int)Stat.Evasion, (int)ModifierType.Add] = 50;
        statMods[(int)Stat.CritChance, (int)ModifierType.Add] = 0.05;
        statMods[(int)Stat.CritMulti, (int)ModifierType.Add] = 1.5;
        statMods[(int)Stat.MaxHealth, (int)ModifierType.Add] = 100;
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
        ch.UpdatePlayer();
    }
}
