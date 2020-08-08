using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WearSlot { Head, Neck, Body, Boots, Gloves, Ring, Mainhand, Offhand }

public class Equipment : Item
{
    public WearSlot wearSlot;
    //[SerializeField]
    public List<StatModifier> mods;


    public Equipment(int id, string name, string imagePath, WearSlot wearSlot, List<StatModifier> mods) : base(id, name, imagePath)
    {
        icon = Resources.Load<Sprite>(imagePath);
        this.wearSlot = wearSlot;
        this.mods = mods;
    }

    public void Equip()
    {
        AddStats();
        Player.instance.UpdateStats();
    }

    // Used when we don't want to update stats after every equip (ususally when recalculating stats after remove equipment)
    public void AddStats()
    {
        foreach (StatModifier sm in mods)
        {
            Player.instance.statMods[(int)sm.stat, (int)sm.type] += sm.value;
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
