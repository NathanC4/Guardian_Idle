using System;
using System.Collections.Generic;
using UnityEngine;

public class EquipHandler : MonoBehaviour
{
    public static EquipHandler instance;

    public List<Equipment> items = new List<Equipment>();

    public List<ItemSlot> slots;
    public event Action<ItemSlot> OnBeginDragEvent;
    public event Action<ItemSlot> OnDragEvent;
    public event Action<ItemSlot> OnEndDragEvent;
    public event Action<ItemSlot> OnDropEvent;

    void OnValidate()
    {
        GetComponentsInChildren(includeInactive: true, result: slots);
    }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of EquipHandler!");
        }
        instance = this;

        //GetComponentsInChildren(includeInactive: true, result: slots);

        foreach (ItemSlot slot in slots)
        {
            slot.OnBeginDragEvent += OnBeginDragEvent;
            slot.OnDragEvent += OnDragEvent;
            slot.OnEndDragEvent += OnEndDragEvent;
            slot.OnDropEvent += OnDropEvent;
        }
    }

    public void Add(Equipment item)
    {
        Debug.Log("adding eq: " + item.name);

        items.Add(item);
        item.Equip();
    }

    public void Remove(Equipment item)
    {
        Debug.Log("removing eq: " + item.name);
        items.Remove(item);

        // Recalculate equipment stats
        Player.instance.ResetStats();
        
        foreach(Equipment e in items)
        {
            e.AddStats();
        }

        Player.instance.UpdateStats();
    }
}
