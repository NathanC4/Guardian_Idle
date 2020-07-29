using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemAdder : MonoBehaviour
{
    public Item item;
    int idCounter = 0;
    WearSlot ws;

    public void AddItem()
    {
        idCounter++;

        int itemtype = UnityEngine.Random.Range(0, Enum.GetValues(typeof(WearSlot)).Length + 1);
        
        switch (itemtype) 
        {
            case 0: // Body
                ws = WearSlot.Body;
                Inventory.instance.Add(new Equipment(idCounter, "test Item", "armor_14", ws, new List<StatModifier>() ) );
                break;

            case 1: // Boots
                ws = WearSlot.Boots;
                Inventory.instance.Add(new Equipment(idCounter, "test Item", "boots_7", ws, new List<StatModifier>()));
                break;

            case 2: // Gloves
                ws = WearSlot.Gloves;
                Inventory.instance.Add(new Equipment(idCounter, "test Item", "gloves_18", ws, new List<StatModifier>()));
                break;

            case 3: // Head
                ws = WearSlot.Head;
                Inventory.instance.Add(new Equipment(idCounter, "test Item", "helmets_19", ws, new List<StatModifier>()));
                break;

            case 4: // Neck
                ws = WearSlot.Neck;
                Inventory.instance.Add(new Equipment(idCounter, "test Item", "necklace_2", ws, new List<StatModifier>()));
                break;

            case 5: // Ring
                ws = WearSlot.Ring;
                Inventory.instance.Add(new Equipment(idCounter, "test Item", "rings_6", ws, new List<StatModifier>()));
                break;

            case 6: // Mainhand
                ws = WearSlot.Mainhand;
                Inventory.instance.Add(new Equipment(idCounter, "test Item", "swords_10_b", ws, new List<StatModifier>()));
                break;

            case 7: // Offhand
                ws = WearSlot.Offhand;
                Inventory.instance.Add(new Equipment(idCounter, "test Item", "dagger_13_b", ws, new List<StatModifier>()));
                break;

            case 8: // Shield
                ws = WearSlot.Offhand;
                Inventory.instance.Add(new Equipment(idCounter, "test Item", "sh_b_01", ws, new List<StatModifier>()));
                break;
        }
    }

    public StatModifier RandMod()
    {
        ModifierType mt = (ModifierType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(ModifierType)).Length);
        Stat st = (Stat)UnityEngine.Random.Range(0, Enum.GetValues(typeof(Stat)).Length);
        double val = UnityEngine.Random.Range(0f, 10f);

        return new StatModifier(mt, st, val);
    }
}
