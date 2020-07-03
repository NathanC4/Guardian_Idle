using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory2 : MonoBehaviour
{
    public static Inventory2 instance;

    //public delegate void OnItemChanged();
    //public OnItemChanged onItemChangedCallback;

    public List<Item> items = new List<Item>();

    public List<InventorySlot> slots;
    public event Action<ItemSlot> OnBeginDragEvent;
    public event Action<ItemSlot> OnDragEvent;
    public event Action<ItemSlot> OnEndDragEvent;
    public event Action<ItemSlot> OnDropEvent;

    public int maxSize = 20;

    void OnValidate()
    {

        GetComponentsInChildren(includeInactive: true, result: slots);
        Debug.Log("Inventory2.OnValidate(): " + slots);
    }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory!");
        }
        instance = this;

        //GetComponentsInChildren(includeInactive: true, result: slots);

        foreach (InventorySlot slot in slots)
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

        // if (onItemChangedCallback != null)
        //     onItemChangedCallback.Invoke();
    }

    public void Remove(Item item)
    {
        Debug.Log("removing: " + item.name);

        items.Remove(item);

        // if (onItemChangedCallback != null)
        //     onItemChangedCallback.Invoke();
    }
}
