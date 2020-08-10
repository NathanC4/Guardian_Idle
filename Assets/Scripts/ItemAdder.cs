using System;
using System.Collections.Generic;
using UnityEngine;
using CI.QuickSave;

public class ItemAdder : MonoBehaviour
{
    public static ItemAdder instance;

    public Item item;
    int idCounter;
    string icon;
    WearSlot ws;
    List<StatModifier> mods;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of ItemAdder!");
        }
        instance = this;
    }

    public void AddItem()
    {
        idCounter++;

        int itemtype = UnityEngine.Random.Range(0, Enum.GetValues(typeof(WearSlot)).Length + 1);
        mods = new List<StatModifier>();

        switch (itemtype) 
        {
            case 0: // Body
                ws = WearSlot.Body;
                icon = "armor_14";
                break;

            case 1: // Boots
                ws = WearSlot.Boots;
                icon = "boots_7";
                break;

            case 2: // Gloves
                ws = WearSlot.Gloves;
                icon = "gloves_18";
                break;

            case 3: // Head
                ws = WearSlot.Head;
                icon = "helmets_19";
                break;

            case 4: // Neck
                ws = WearSlot.Neck;
                icon = "necklace_2";
                break;

            case 5: // Ring
                ws = WearSlot.Ring;
                icon = "rings_6";
                break;

            case 6: // Mainhand
                ws = WearSlot.Mainhand;
                icon = "swords_10_b";
                break;

            case 7: // Offhand
                ws = WearSlot.Offhand;
                icon = "dagger_13_b";
                break;

            case 8: // Shield
                ws = WearSlot.Offhand;
                icon = "sh_b_01";
                break;
        }
        for (int i = 0; i < 3; i++)
        {
            mods.Add(RandMod());
        }
        Inventory.instance.Add(new Equipment(idCounter, "test Item", icon, ws, mods));
    }

    public StatModifier RandMod()
    {
        // ModifierType mt = (ModifierType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(ModifierType)).Length);

        ModifierType mt = ModifierType.Add;

        //Stat st = (Stat)UnityEngine.Random.Range(0, Enum.GetValues(typeof(Stat)).Length);
        Stat st;
        int s = UnityEngine.Random.Range(0, 3);

        if (s == 0)
        {
            st = Stat.Attack;
        } else if (s == 1) { st = Stat.Evasion; }
        else { st = Stat.MaxHealth; }

        double val = UnityEngine.Random.Range(1, 11);

        return new StatModifier(mt, st, val);
    }

    public void Save()
    {
        QuickSaveWriter writer = QuickSaveWriter.Create("GuardianIdleSave");
        writer.Write("itemIdCounter", idCounter);
        writer.Commit();
    }

    public void Load()
    {
        QuickSaveReader reader = QuickSaveReader.Create("GuardianIdleSave");

        if (reader.Exists("itemIdCounter"))
            idCounter = reader.Read<int>("itemIdCounter");
        else
            idCounter = 0;       
    }
}
