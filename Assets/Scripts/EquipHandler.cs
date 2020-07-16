using System;
using System.Collections.Generic;
using UnityEngine;

public class EquipHandler : MonoBehaviour
{
    public static EquipHandler instance;

    public List<Item> items = new List<Item>();

    public List<ItemSlot> slots;
    public event Action<ItemSlot> OnBeginDragEvent;
    public event Action<ItemSlot> OnDragEvent;
    public event Action<ItemSlot> OnEndDragEvent;
    public event Action<ItemSlot> OnDropEvent;

    public int maxSize = 20;

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

    public void Add(Item item)
    {
        Debug.Log("adding: " + item.name);

        if (items.Count >= maxSize)
            Debug.Log("Not enough room in inventory");

        items.Add(item);

        foreach (InventorySlot slot in slots)
        {
            if (slot.IsEmpty())
            {
                slot.AddItem(item);
                break;
            }
        }
    }

    public void Remove(Item item)
    {
        Debug.Log("removing: " + item.name);

        items.Remove(item);

    }
}
