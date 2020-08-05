using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CombatHandler ch;
    public HealthBar healthBar;

    public static Player instance;

    public double health;
    

    public double[] stats;
    public double[,] statMods;


    public double Attack { get => stats[(int)Stat.Attack]; }
    public double BaseAttackDelay { get; set; }
    public double AttackDelay { get; set; }
    public double AttackSpeed { get => stats[(int)Stat.AttackSpeed]; }
    public double Armor { get => stats[(int)Stat.Armor]; }
    public double Evasion { get => stats[(int)Stat.Evasion]; }
    public double Accuracy { get => stats[(int)Stat.Accuracy]; }
    public double CritChance { get; set; }
    public double CritMulti { get; set; }
    public double MaxHealth { get => stats[(int)Stat.MaxHealth]; }




    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Player!");
        }
        instance = this;

        stats = new double[Enum.GetNames(typeof(Stat)).Length];
        statMods = new double[Enum.GetNames(typeof(Stat)).Length, Enum.GetNames(typeof(ModifierType)).Length];

        ResetStats();

        health = MaxHealth;
        UpdateHealthBar();
    }

    public void ResetStats()
    {
        // Set multipliers to 1
        for (int i = 0; i < statMods.GetLength(0); i++)
        {
            statMods[i, (int) ModifierType.Percent] = 1;
            statMods[i, (int) ModifierType.Multiply] = 1;
        }

        // Set base values
        BaseAttackDelay = 1.0;

        statMods[(int)Stat.Accuracy, (int)ModifierType.Add] = 0;
        statMods[(int)Stat.Attack, (int)ModifierType.Add] = 10;
        statMods[(int)Stat.AttackSpeed, (int)ModifierType.Add] = 1;
        statMods[(int)Stat.Armor, (int)ModifierType.Add] = 50;
        statMods[(int)Stat.Evasion, (int)ModifierType.Add] = 50;
        statMods[(int)Stat.CritChance, (int)ModifierType.Add] = 0.05;
        statMods[(int)Stat.CritMulti, (int)ModifierType.Add] = 1.5;
        statMods[(int)Stat.MaxHealth, (int)ModifierType.Add] = 100;

        UpdateStats();
    }

    public void UpdateStats()
    {
        for (int i = 0; i < stats.Length; i++)
        {
            stats[i] = statMods[i, (int)ModifierType.Add] * statMods[i, (int)ModifierType.Percent] * statMods[i, (int)ModifierType.Multiply];
            //Debug.Log("stats " + i + ": " + stats[i] + " = " + statMods[i, (int)ModifierType.Add] + " * " + statMods[i, (int)ModifierType.Percent] + " * " + statMods[i, (int)ModifierType.Multiply]);
        }

        AttackDelay = BaseAttackDelay / stats[(int)Stat.AttackSpeed];
        Debug.Log("delay:" + AttackDelay + " = " + BaseAttackDelay + "/" + AttackSpeed);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
            health = MaxHealth;

        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        healthBar.SetValue((float) (health / MaxHealth));
    }

    // increase AS by .05
    public void IncreaseAS()
    {
        //AttackSpeed += 0.05;
        ch.UpdatePlayer();
    }
}
