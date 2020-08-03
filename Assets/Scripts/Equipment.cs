﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WearSlot { Head, Neck, Body, Boots, Gloves, Ring, Mainhand, Offhand }

public class Equipment : Item
{
    public WearSlot wearSlot;
    List<StatModifier> mods;


    public Equipment(int id, string name, string imagePath, WearSlot wearSlot, List<StatModifier> mods) : base(id, name, imagePath)
    {
        icon = Resources.Load<Sprite>(imagePath);
        this.wearSlot = wearSlot;
        this.mods = mods;
    }

    public void Equip()
    {
        foreach (StatModifier sm in mods)
        {
            sm.Add();
        }
    }

    public WearSlot GetWearSlot()
    {
        return wearSlot;
    }

    public override void ShowTooltip()
    {
        string tooltip = "ID: " + id +
                        "\nName: " + name +
                        "\nWear slot: " + wearSlot;

        foreach (StatModifier mod in mods)
        {
            tooltip += "\n" + mod;
        }
        
        Tooltip.instance.Show(tooltip);

    }
}
