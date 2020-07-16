using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemAdder : MonoBehaviour
{
    public Item item;
    int idCounter = 0;

    public void AddItem()
    {
        idCounter++;
        WearSlot ws = (WearSlot)UnityEngine.Random.Range(0, Enum.GetValues(typeof(WearSlot)).Length);

        Inventory.instance.Add(new Equipment(idCounter, "test Item", "Pickaxe", ws, new List<StatModifier>() ) );
    }
}
